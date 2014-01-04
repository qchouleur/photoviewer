namespace PhotoViewer.UI
{
    partial class OpenPhotoFromStorageDialog
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
            this.PhotoListView = new System.Windows.Forms.ListView();
            this.OkButton = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PhotoListView
            // 
            this.PhotoListView.Location = new System.Drawing.Point(12, 12);
            this.PhotoListView.Name = "PhotoListView";
            this.PhotoListView.Size = new System.Drawing.Size(710, 390);
            this.PhotoListView.TabIndex = 0;
            this.PhotoListView.UseCompatibleStateImageBehavior = false;
            // 
            // Ok
            // 
            this.OkButton.Location = new System.Drawing.Point(263, 409);
            this.OkButton.Name = "Ok";
            this.OkButton.Size = new System.Drawing.Size(75, 23);
            this.OkButton.TabIndex = 1;
            this.OkButton.Text = "OpenPhotoButton";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.Ok_Click);
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(344, 409);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(75, 23);
            this.Cancel.TabIndex = 2;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // OpenPhotoFromStorageDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 442);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.PhotoListView);
            this.Name = "OpenPhotoFromStorageDialog";
            this.Text = "InternalPhotoListForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView PhotoListView;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Button Cancel;
    }
}