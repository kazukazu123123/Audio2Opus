namespace Audio2Opus
{
    partial class Audio2Opus
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            FileListView = new ListView();
            ConvertButton = new Button();
            StatusProgressBar = new ProgressBar();
            OverallStatusProgressBar = new ProgressBar();
            BitrateNumericUpDown = new NumericUpDown();
            BitrateLabel = new Label();
            ClearListButton = new Button();
            FFMpegLogTextBox = new TextBox();
            SplitContainer = new SplitContainer();
            ((System.ComponentModel.ISupportInitialize)BitrateNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)SplitContainer).BeginInit();
            SplitContainer.Panel1.SuspendLayout();
            SplitContainer.Panel2.SuspendLayout();
            SplitContainer.SuspendLayout();
            SuspendLayout();
            // 
            // FileListView
            // 
            FileListView.AllowDrop = true;
            FileListView.Dock = DockStyle.Fill;
            FileListView.Location = new Point(0, 0);
            FileListView.Name = "FileListView";
            FileListView.Size = new Size(400, 197);
            FileListView.TabIndex = 1;
            FileListView.UseCompatibleStateImageBehavior = false;
            FileListView.View = View.List;
            FileListView.DragDrop += FileListView_DragDrop;
            FileListView.DragEnter += FileListView_DragEnter;
            // 
            // ConvertButton
            // 
            ConvertButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ConvertButton.Location = new Point(12, 273);
            ConvertButton.Name = "ConvertButton";
            ConvertButton.Size = new Size(554, 51);
            ConvertButton.TabIndex = 2;
            ConvertButton.Text = "Convert";
            ConvertButton.UseVisualStyleBackColor = true;
            ConvertButton.Click += ConvertButton_Click;
            // 
            // StatusProgressBar
            // 
            StatusProgressBar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            StatusProgressBar.Location = new Point(12, 215);
            StatusProgressBar.Name = "StatusProgressBar";
            StatusProgressBar.Size = new Size(360, 23);
            StatusProgressBar.TabIndex = 4;
            // 
            // OverallStatusProgressBar
            // 
            OverallStatusProgressBar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            OverallStatusProgressBar.Location = new Point(12, 244);
            OverallStatusProgressBar.Name = "OverallStatusProgressBar";
            OverallStatusProgressBar.Size = new Size(360, 23);
            OverallStatusProgressBar.TabIndex = 5;
            // 
            // BitrateNumericUpDown
            // 
            BitrateNumericUpDown.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            BitrateNumericUpDown.Location = new Point(461, 244);
            BitrateNumericUpDown.Maximum = new decimal(new int[] { 510, 0, 0, 0 });
            BitrateNumericUpDown.Minimum = new decimal(new int[] { 8, 0, 0, 0 });
            BitrateNumericUpDown.Name = "BitrateNumericUpDown";
            BitrateNumericUpDown.Size = new Size(105, 23);
            BitrateNumericUpDown.TabIndex = 0;
            BitrateNumericUpDown.Value = new decimal(new int[] { 8, 0, 0, 0 });
            // 
            // BitrateLabel
            // 
            BitrateLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            BitrateLabel.AutoSize = true;
            BitrateLabel.Location = new Point(378, 246);
            BitrateLabel.Name = "BitrateLabel";
            BitrateLabel.Size = new Size(77, 15);
            BitrateLabel.TabIndex = 6;
            BitrateLabel.Text = "Bitrate (kbps)";
            // 
            // ClearListButton
            // 
            ClearListButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            ClearListButton.Enabled = false;
            ClearListButton.Location = new Point(461, 215);
            ClearListButton.Name = "ClearListButton";
            ClearListButton.Size = new Size(105, 23);
            ClearListButton.TabIndex = 7;
            ClearListButton.Text = "Clear List";
            ClearListButton.UseVisualStyleBackColor = true;
            ClearListButton.Click += ClearListButton_Click;
            // 
            // FFMpegLogTextBox
            // 
            FFMpegLogTextBox.Dock = DockStyle.Fill;
            FFMpegLogTextBox.Location = new Point(0, 0);
            FFMpegLogTextBox.Multiline = true;
            FFMpegLogTextBox.Name = "FFMpegLogTextBox";
            FFMpegLogTextBox.ReadOnly = true;
            FFMpegLogTextBox.ScrollBars = ScrollBars.Vertical;
            FFMpegLogTextBox.Size = new Size(150, 197);
            FFMpegLogTextBox.TabIndex = 8;
            // 
            // SplitContainer
            // 
            SplitContainer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            SplitContainer.Location = new Point(12, 12);
            SplitContainer.Name = "SplitContainer";
            // 
            // SplitContainer.Panel1
            // 
            SplitContainer.Panel1.Controls.Add(FileListView);
            // 
            // SplitContainer.Panel2
            // 
            SplitContainer.Panel2.Controls.Add(FFMpegLogTextBox);
            SplitContainer.Size = new Size(554, 197);
            SplitContainer.SplitterDistance = 400;
            SplitContainer.TabIndex = 9;
            // 
            // Audio2Opus
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(578, 336);
            Controls.Add(SplitContainer);
            Controls.Add(ClearListButton);
            Controls.Add(BitrateLabel);
            Controls.Add(BitrateNumericUpDown);
            Controls.Add(OverallStatusProgressBar);
            Controls.Add(StatusProgressBar);
            Controls.Add(ConvertButton);
            Name = "Audio2Opus";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Audio2Opus";
            ((System.ComponentModel.ISupportInitialize)BitrateNumericUpDown).EndInit();
            SplitContainer.Panel1.ResumeLayout(false);
            SplitContainer.Panel2.ResumeLayout(false);
            SplitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)SplitContainer).EndInit();
            SplitContainer.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView FileListView;
        private Button ConvertButton;
        private ProgressBar StatusProgressBar;
        private ProgressBar OverallStatusProgressBar;
        private NumericUpDown BitrateNumericUpDown;
        private Label BitrateLabel;
        private Button ClearListButton;
        private TextBox FFMpegLogTextBox;
        private SplitContainer SplitContainer;
    }
}
