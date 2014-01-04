namespace PhotoViewer.UI
{
    partial class AlbumSlideshowForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.PlayPauseButton = new System.Windows.Forms.Button();
            this.NextButton = new System.Windows.Forms.Button();
            this.PreviousButton = new System.Windows.Forms.Button();
            this.SlideAccelerateButton = new System.Windows.Forms.Button();
            this.SlideDecelerateButton = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // PlayPauseButton
            // 
            this.PlayPauseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.PlayPauseButton.Location = new System.Drawing.Point(275, 343);
            this.PlayPauseButton.Name = "PlayPauseButton";
            this.PlayPauseButton.Size = new System.Drawing.Size(68, 68);
            this.PlayPauseButton.TabIndex = 0;
            this.PlayPauseButton.Text = "PlayPause";
            this.PlayPauseButton.UseVisualStyleBackColor = true;
            this.PlayPauseButton.Click += new System.EventHandler(this.PlayPauseButton_Click);
            // 
            // NextButton
            // 
            this.NextButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.NextButton.Location = new System.Drawing.Point(349, 343);
            this.NextButton.Name = "NextButton";
            this.NextButton.Size = new System.Drawing.Size(68, 68);
            this.NextButton.TabIndex = 1;
            this.NextButton.Text = "Next";
            this.NextButton.UseVisualStyleBackColor = true;
            this.NextButton.Click += new System.EventHandler(this.NextButton_Click);
            // 
            // PreviousButton
            // 
            this.PreviousButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.PreviousButton.Location = new System.Drawing.Point(201, 343);
            this.PreviousButton.Name = "PreviousButton";
            this.PreviousButton.Size = new System.Drawing.Size(68, 68);
            this.PreviousButton.TabIndex = 2;
            this.PreviousButton.Text = "Previous";
            this.PreviousButton.UseVisualStyleBackColor = true;
            this.PreviousButton.Click += new System.EventHandler(this.PreviousButton_Click);
            // 
            // SlideAccelerateButton
            // 
            this.SlideAccelerateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SlideAccelerateButton.Location = new System.Drawing.Point(551, 343);
            this.SlideAccelerateButton.Name = "SlideAccelerateButton";
            this.SlideAccelerateButton.Size = new System.Drawing.Size(68, 68);
            this.SlideAccelerateButton.TabIndex = 3;
            this.SlideAccelerateButton.Text = "SpeedUp";
            this.SlideAccelerateButton.UseVisualStyleBackColor = true;
            this.SlideAccelerateButton.Click += new System.EventHandler(this.SlideAccelerateButton_Click);
            // 
            // SlideDecelerateButton
            // 
            this.SlideDecelerateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SlideDecelerateButton.Location = new System.Drawing.Point(477, 343);
            this.SlideDecelerateButton.Name = "SlideDecelerateButton";
            this.SlideDecelerateButton.Size = new System.Drawing.Size(68, 68);
            this.SlideDecelerateButton.TabIndex = 4;
            this.SlideDecelerateButton.Text = "SpeedDown";
            this.SlideDecelerateButton.UseVisualStyleBackColor = true;
            this.SlideDecelerateButton.Click += new System.EventHandler(this.SlideDecelerateButton_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox.Location = new System.Drawing.Point(0, 0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(632, 337);
            this.pictureBox.TabIndex = 5;
            this.pictureBox.TabStop = false;
            // 
            // AlbumSlideshowForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 423);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.SlideDecelerateButton);
            this.Controls.Add(this.SlideAccelerateButton);
            this.Controls.Add(this.PreviousButton);
            this.Controls.Add(this.NextButton);
            this.Controls.Add(this.PlayPauseButton);
            this.Name = "AlbumSlideshowForm";
            this.Text = "AlbumSlideshowForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button PlayPauseButton;
        private System.Windows.Forms.Button NextButton;
        private System.Windows.Forms.Button PreviousButton;
        private System.Windows.Forms.Button SlideAccelerateButton;
        private System.Windows.Forms.Button SlideDecelerateButton;
        private System.Windows.Forms.PictureBox pictureBox;

    }
}