namespace PhotoViewer.UI
{
    partial class PhotoEditDialog
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
            this.CancelPhotoButton = new System.Windows.Forms.Button();
            this.DateLabel = new System.Windows.Forms.Label();
            this.EventDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.SaveButton = new System.Windows.Forms.Button();
            this.CommentLabel = new System.Windows.Forms.Label();
            this.CommentTextBox = new System.Windows.Forms.RichTextBox();
            this.CategoryLabel = new System.Windows.Forms.Label();
            this.CategoryTextBox = new System.Windows.Forms.TextBox();
            this.RatingLabel = new System.Windows.Forms.Label();
            this.RatingTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // CancelPhotoButton
            // 
            this.CancelPhotoButton.Location = new System.Drawing.Point(173, 305);
            this.CancelPhotoButton.Name = "CancelPhotoButton";
            this.CancelPhotoButton.Size = new System.Drawing.Size(83, 23);
            this.CancelPhotoButton.TabIndex = 11;
            this.CancelPhotoButton.Text = "CancelButton";
            this.CancelPhotoButton.UseVisualStyleBackColor = true;
            this.CancelPhotoButton.Click += new System.EventHandler(this.CancelPhotoButton_Click);
            // 
            // DateLabel
            // 
            this.DateLabel.AutoSize = true;
            this.DateLabel.Location = new System.Drawing.Point(9, 263);
            this.DateLabel.Name = "DateLabel";
            this.DateLabel.Size = new System.Drawing.Size(56, 13);
            this.DateLabel.TabIndex = 8;
            this.DateLabel.Text = "DateLabel";
            // 
            // EventDateTimePicker
            // 
            this.EventDateTimePicker.Location = new System.Drawing.Point(12, 279);
            this.EventDateTimePicker.Name = "EventDateTimePicker";
            this.EventDateTimePicker.Size = new System.Drawing.Size(310, 20);
            this.EventDateTimePicker.TabIndex = 9;
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(84, 305);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(83, 23);
            this.SaveButton.TabIndex = 10;
            this.SaveButton.Text = "SaveButton";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // CommentLabel
            // 
            this.CommentLabel.AutoSize = true;
            this.CommentLabel.Location = new System.Drawing.Point(9, 9);
            this.CommentLabel.Name = "CommentLabel";
            this.CommentLabel.Size = new System.Drawing.Size(77, 13);
            this.CommentLabel.TabIndex = 12;
            this.CommentLabel.Text = "CommentLabel";
            // 
            // CommentTextBox
            // 
            this.CommentTextBox.Location = new System.Drawing.Point(12, 25);
            this.CommentTextBox.Name = "CommentTextBox";
            this.CommentTextBox.Size = new System.Drawing.Size(310, 96);
            this.CommentTextBox.TabIndex = 13;
            this.CommentTextBox.Text = "";
            // 
            // CategoryLabel
            // 
            this.CategoryLabel.AutoSize = true;
            this.CategoryLabel.Location = new System.Drawing.Point(9, 142);
            this.CategoryLabel.Name = "CategoryLabel";
            this.CategoryLabel.Size = new System.Drawing.Size(75, 13);
            this.CategoryLabel.TabIndex = 14;
            this.CategoryLabel.Text = "CategoryLabel";
            // 
            // CategoryTextBox
            // 
            this.CategoryTextBox.Location = new System.Drawing.Point(12, 158);
            this.CategoryTextBox.Name = "CategoryTextBox";
            this.CategoryTextBox.Size = new System.Drawing.Size(309, 20);
            this.CategoryTextBox.TabIndex = 15;
            // 
            // RatingLabel
            // 
            this.RatingLabel.AutoSize = true;
            this.RatingLabel.Location = new System.Drawing.Point(9, 201);
            this.RatingLabel.Name = "RatingLabel";
            this.RatingLabel.Size = new System.Drawing.Size(64, 13);
            this.RatingLabel.TabIndex = 17;
            this.RatingLabel.Text = "RatingLabel";
            // 
            // RatingTextBox
            // 
            this.RatingTextBox.Location = new System.Drawing.Point(12, 217);
            this.RatingTextBox.Name = "RatingTextBox";
            this.RatingTextBox.Size = new System.Drawing.Size(53, 20);
            this.RatingTextBox.TabIndex = 18;
            // 
            // PhotoEditDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 340);
            this.Controls.Add(this.RatingTextBox);
            this.Controls.Add(this.RatingLabel);
            this.Controls.Add(this.CategoryTextBox);
            this.Controls.Add(this.CategoryLabel);
            this.Controls.Add(this.CommentTextBox);
            this.Controls.Add(this.CommentLabel);
            this.Controls.Add(this.CancelPhotoButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.EventDateTimePicker);
            this.Controls.Add(this.DateLabel);
            this.Name = "PhotoEditDialog";
            this.Text = "PhotoEditDialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CancelPhotoButton;
        private System.Windows.Forms.Label DateLabel;
        public System.Windows.Forms.DateTimePicker EventDateTimePicker;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Label CommentLabel;
        private System.Windows.Forms.Label CategoryLabel;
        private System.Windows.Forms.Label RatingLabel;
        public System.Windows.Forms.RichTextBox CommentTextBox;
        public System.Windows.Forms.TextBox CategoryTextBox;
        public System.Windows.Forms.TextBox RatingTextBox;
    }
}