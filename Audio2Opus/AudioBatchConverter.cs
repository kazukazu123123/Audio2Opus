using FFMpegCore;

namespace Audio2Opus
{
    public class AudioBatchConverter(
        Action<string> logHandler,
        Action<double> progressHandler,
        Action<double> progressOverallHandler)
    {
        private readonly Action<string> _logHandler = logHandler ?? throw new ArgumentNullException(nameof(logHandler));
        private readonly Action<double> _progressHandler = progressHandler ?? throw new ArgumentNullException(nameof(progressHandler));
        private readonly Action<double> _progressOverallHandler = progressOverallHandler ?? throw new ArgumentNullException(nameof(progressOverallHandler));

        public async Task ConvertFilesAsync(List<string> inputFiles, string outputDirectory, int bitrateKbps)
        {
            var fileAnalyses = new List<(string Path, TimeSpan Duration)>();

            foreach (var file in inputFiles)
            {
                try
                {
                    var analysis = FFProbe.Analyse(file);
                    if (analysis != null && analysis.Duration.TotalSeconds > 0)
                    {
                        fileAnalyses.Add((file, analysis.Duration));
                    }
                    else
                    {
                        _logHandler($"Skipped (unreadable or zero-length): {file}");
                    }
                }
                catch (Exception ex)
                {
                    _logHandler($"Skipped (FFProbe error): {file} - {ex.Message}");
                }
            }

            if (fileAnalyses.Count == 0)
            {
                _logHandler("No valid input files found.");
                _progressOverallHandler(0);
                return;
            }

            int totalFiles = fileAnalyses.Count;
            int completedFiles = 0;

            foreach (var (inputPath, duration) in fileAnalyses)
            {
                try
                {
                    string fileName = Path.GetFileNameWithoutExtension(inputPath);
                    string outputPath = Path.Combine(outputDirectory, $"{fileName}.ogg");

                    _logHandler.Invoke($"Conversion Started: {inputPath}");

                    await FFMpegArguments
                        .FromFileInput(inputPath)
                        .OutputToFile(outputPath, true, options => options
                            .WithCustomArgument("-vn")
                            .WithCustomArgument("-c:a libopus")
                            .WithCustomArgument("-f ogg")
                            .WithCustomArgument($"-b:a {bitrateKbps}k"))
                        .NotifyOnProgress(_progressHandler, duration)
                        //.NotifyOnError(_logHandler.Invoke)
                        .ProcessAsynchronously();

                    _logHandler.Invoke($"Conversion Complete: {outputPath}");

                    completedFiles++;
                    _progressOverallHandler((double)completedFiles / totalFiles * 100.0);
                }
                catch (Exception ex)
                {
                    _logHandler.Invoke($"Error: {ex.Message}");
                }
            }

            _progressOverallHandler(100);
        }
    }
}
