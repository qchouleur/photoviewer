namespace PhotoViewer.UI
{
    partial class PhotoDetailForm
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
            this.PictureBox = new System.Windows.Forms.PictureBox();
            this.FirstSeparatorLine = new System.Windows.Forms.Label();
            this.PhotoPropertyGrid = new System.Windows.Forms.PropertyGrid();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // PictureBox
            // 
            this.PictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PictureBox.Location = new System.Drawing.Point(12, 12);
            this.PictureBox.Name = "PictureBox";
            this.PictureBox.Size = new System.Drawing.Size(420, 209);
            this.PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureBox.TabIndex = 0;
            this.PictureBox.TabStop = false;
            // 
            // FirstSeparatorLine
            // 
            this.FirstSeparatorLine.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FirstSeparatorLine.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.FirstSeparatorLine.Location = new System.Drawing.Point(-1, 235);
            this.FirstSeparatorLine.Name = "FirstSeparatorLine";
            this.FirstSeparatorLine.Size = new System.Drawing.Size(451, 2);
            this.FirstSeparatorLine.TabIndex = 1;
            // 
            // PhotoPropertyGrid
            // 
            this.PhotoPropertyGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PhotoPropertyGrid.Location = new System.Drawing.Point(12, 240);
            this.PhotoPropertyGrid.Name = "PhotoPropertyGrid";
            this.PhotoPropertyGrid.Size = new System.Drawing.Size(420, 326);
            this.PhotoPropertyGrid.TabIndex = 3;
            // 
            // PhotoDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 578);
            this.Controls.Add(this.PhotoPropertyGrid);
            this.Controls.Add(this.FirstSeparatorLine);
            this.Controls.Add(this.PictureBox);
            this.Name = "PhotoDetailForm";
            this.Text = "PhotoDetailForm";
            this.Load += new System.EventHandler(this.onLoad);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox PictureBox;
        private System.Windows.Forms.Label FirstSeparatorLine;
        private System.Windows.Forms.PropertyGrid PhotoPropertyGrid;
    }
}