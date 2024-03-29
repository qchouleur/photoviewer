﻿namespace PhotoViewer.UI
{
    partial class AlbumEditDialog
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
            this.TitleLabel = new System.Windows.Forms.Label();
            this.SubTitleLabel = new System.Windows.Forms.Label();
            this.DateLabel = new System.Windows.Forms.Label();
            this.TitleTextBox = new System.Windows.Forms.TextBox();
            this.SubTitleTextBox = new System.Windows.Forms.TextBox();
            this.DateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.SaveAlbumButton = new System.Windows.Forms.Button();
            this.CancelAlbumButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Location = new System.Drawing.Point(9, 9);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(53, 13);
            this.TitleLabel.TabIndex = 0;
            this.TitleLabel.Text = "TitleLabel";
            // 
            // SubTitleLabel
            // 
            this.SubTitleLabel.AutoSize = true;
            this.SubTitleLabel.Location = new System.Drawing.Point(9, 62);
            this.SubTitleLabel.Name = "SubTitleLabel";
            this.SubTitleLabel.Size = new System.Drawing.Size(72, 13);
            this.SubTitleLabel.TabIndex = 1;
            this.SubTitleLabel.Text = "SubTitleLabel";
            // 
            // DateLabel
            // 
            this.DateLabel.AutoSize = true;
            this.DateLabel.Location = new System.Drawing.Point(9, 116);
            this.DateLabel.Name = "DateLabel";
            this.DateLabel.Size = new System.Drawing.Size(56, 13);
            this.DateLabel.TabIndex = 2;
            this.DateLabel.Text = "DateLabel";
            // 
            // TitleTextBox
            // 
            this.TitleTextBox.Location = new System.Drawing.Point(12, 25);
            this.TitleTextBox.Name = "TitleTextBox";
            this.TitleTextBox.Size = new System.Drawing.Size(310, 20);
            this.TitleTextBox.TabIndex = 3;
            // 
            // SubTitleTextBox
            // 
            this.SubTitleTextBox.Location = new System.Drawing.Point(12, 78);
            this.SubTitleTextBox.Name = "SubTitleTextBox";
            this.SubTitleTextBox.Size = new System.Drawing.Size(310, 20);
            this.SubTitleTextBox.TabIndex = 4;
            // 
            // DateTimePicker
            // 
            this.DateTimePicker.Location = new System.Drawing.Point(12, 132);
            this.DateTimePicker.Name = "DateTimePicker";
            this.DateTimePicker.Size = new System.Drawing.Size(310, 20);
            this.DateTimePicker.TabIndex = 5;
            // 
            // SaveAlbumButton
            // 
            this.SaveAlbumButton.Location = new System.Drawing.Point(12, 168);
            this.SaveAlbumButton.Name = "SaveAlbumButton";
            this.SaveAlbumButton.Size = new System.Drawing.Size(83, 23);
            this.SaveAlbumButton.TabIndex = 6;
            this.SaveAlbumButton.Text = "SaveButton";
            this.SaveAlbumButton.UseVisualStyleBackColor = true;
            this.SaveAlbumButton.Click += new System.EventHandler(this.onSaveClick);
            // 
            // CancelAlbumButton
            // 
            this.CancelAlbumButton.Location = new System.Drawing.Point(101, 168);
            this.CancelAlbumButton.Name = "CancelAlbumButton";
            this.CancelAlbumButton.Size = new System.Drawing.Size(83, 23);
            this.CancelAlbumButton.TabIndex = 7;
            this.CancelAlbumButton.Text = "CancelButton";
            this.CancelAlbumButton.UseVisualStyleBackColor = true;
            this.CancelAlbumButton.Click += new System.EventHandler(this.onCancelClick);
            // 
            // AlbumEditDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 202);
            this.Controls.Add(this.CancelAlbumButton);
            this.Controls.Add(this.SaveAlbumButton);
            this.Controls.Add(this.DateTimePicker);
            this.Controls.Add(this.SubTitleTextBox);
            this.Controls.Add(this.TitleTextBox);
            this.Controls.Add(this.DateLabel);
            this.Controls.Add(this.SubTitleLabel);
            this.Controls.Add(this.TitleLabel);
            this.Name = "AlbumEditDialog";
            this.Text = "CreateAlbumDialogForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.Label SubTitleLabel;
        private System.Windows.Forms.Label DateLabel;
        private System.Windows.Forms.Button SaveAlbumButton;
        private System.Windows.Forms.Button CancelAlbumButton;
        public System.Windows.Forms.TextBox TitleTextBox;
        public System.Windows.Forms.TextBox SubTitleTextBox;
        public System.Windows.Forms.DateTimePicker DateTimePicker;
    }
}