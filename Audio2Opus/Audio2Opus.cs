using System.Diagnostics;
using System.Windows.Forms;
using FFMpegCore;

namespace Audio2Opus
{
    public partial class Audio2Opus : Form
    {
        readonly Action<double>? progressHandler = null!;

        public static void SetProgressBarValue(ProgressBar pb, int val)
        {
            if (pb.Value < val)
            {
                //値を増やす時
                if (val < pb.Maximum)
                {
                    //目的の値より一つ大きくしてから、目的の値にする
                    pb.Value = val + 1;
                    pb.Value = val;
                }
                else
                {
                    //最大値にする時
                    //最大値を1つ増やしてから、元に戻す
                    pb.Maximum++;
                    pb.Value = val + 1;
                    pb.Value = val;
                    pb.Maximum--;
                }
            }
            else
            {
                //値を減らす時は、そのまま
                pb.Value = val;
            }
        }

        public Audio2Opus()
        {
            InitializeComponent();

            progressHandler = new Action<double>(p =>
            {
                Invoke(() =>
                {
                    SetProgressBarValue(StatusProgressBar, (int)p);
                });
            });
        }

        private void ClearListButton_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to clear the list?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                FileListView.Items.Clear();

                ClearListButton.Enabled = false;
            }
        }

        private void FileListView_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data == null) return;

            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;

        }

        private void FileListView_DragDrop(object sender, DragEventArgs e)
        {
            if (ClearListButton.Enabled == false) ClearListButton.Enabled = true;

            if (e.Data == null) return;

            if (e.Data.GetData(DataFormats.FileDrop, false) is string[] fileNames)
            {
                foreach (var file in fileNames)
                {
                    if (File.Exists(file))
                    {
                        if (!FileListView.Items.Cast<ListViewItem>().Any(item => item.Text.Equals(file, StringComparison.OrdinalIgnoreCase)))
                        {
                            FileListView.Items.Add(new ListViewItem(file));
                        }
                    }
                }
            }
        }

        private async void ConvertButton_Click(object sender, EventArgs e)
        {
            ClearListButton.Enabled = false;
            FileListView.Enabled = false;
            BitrateNumericUpDown.Enabled = false;
            ConvertButton.Enabled = false;
            FFMpegLogTextBox.Clear();
            StatusProgressBar.Value = 0;
            OverallStatusProgressBar.Value = 0;

            List<string> filesToConvert = FileListView.Items
                .Cast<ListViewItem>()
                .Select(item => item.Text)
                .ToList();

            AudioBatchConverter converter = new(
                log => Invoke(() => FFMpegLogTextBox.AppendText(log + Environment.NewLine)),
                progress => Invoke(() => SetProgressBarValue(StatusProgressBar, (int)progress)),
                progressOverall => Invoke(() => SetProgressBarValue(OverallStatusProgressBar, (int)progressOverall))
            );

            await converter.ConvertFilesAsync(filesToConvert, "output", (int)BitrateNumericUpDown.Value);

            ConvertButton.Enabled = true;
            BitrateNumericUpDown.Enabled = true;
            FileListView.Enabled = true;
            ClearListButton.Enabled = true;
        }
    }
}
