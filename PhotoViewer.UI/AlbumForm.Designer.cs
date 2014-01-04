namespace PhotoViewer.UI
{
    partial class AlbumForm
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
            this.AlbumTreeView = new System.Windows.Forms.TreeView();
            this.PhotoListView = new System.Windows.Forms.ListView();
            this.AddPhotoButton = new System.Windows.Forms.Button();
            this.RemovePhotoButton = new System.Windows.Forms.Button();
            this.ImportExternalPhotoButton = new System.Windows.Forms.Button();
            this.DeletePhotoButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // AlbumTreeView
            // 
            this.AlbumTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.AlbumTreeView.Location = new System.Drawing.Point(12, 12);
            this.AlbumTreeView.Name = "AlbumTreeView";
            this.AlbumTreeView.Size = new System.Drawing.Size(132, 507);
            this.AlbumTreeView.TabIndex = 0;
            this.AlbumTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.onAlbumSelection);
            // 
            // PhotoListView
            // 
            this.PhotoListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PhotoListView.Location = new System.Drawing.Point(150, 12);
            this.PhotoListView.Name = "PhotoListView";
            this.PhotoListView.Size = new System.Drawing.Size(597, 507);
            this.PhotoListView.TabIndex = 1;
            this.PhotoListView.UseCompatibleStateImageBehavior = false;
            // 
            // AddPhotoButton
            // 
            this.AddPhotoButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AddPhotoButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.AddPhotoButton.Location = new System.Drawing.Point(753, 12);
            this.AddPhotoButton.Name = "AddPhotoButton";
            this.AddPhotoButton.Size = new System.Drawing.Size(32, 32);
            this.AddPhotoButton.TabIndex = 2;
            this.AddPhotoButton.UseVisualStyleBackColor = true;
            this.AddPhotoButton.Click += new System.EventHandler(this.onAddPhotoClick);
            // 
            // RemovePhotoButton
            // 
            this.RemovePhotoButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RemovePhotoButton.Location = new System.Drawing.Point(753, 50);
            this.RemovePhotoButton.Name = "RemovePhotoButton";
            this.RemovePhotoButton.Size = new System.Drawing.Size(32, 32);
            this.RemovePhotoButton.TabIndex = 3;
            this.RemovePhotoButton.UseVisualStyleBackColor = true;
            this.RemovePhotoButton.Click += new System.EventHandler(this.onRemovePhotoClick);
            // 
            // ImportExternalPhotoButton
            // 
            this.ImportExternalPhotoButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ImportExternalPhotoButton.Location = new System.Drawing.Point(753, 88);
            this.ImportExternalPhotoButton.Name = "ImportExternalPhotoButton";
            this.ImportExternalPhotoButton.Size = new System.Drawing.Size(32, 32);
            this.ImportExternalPhotoButton.TabIndex = 4;
            this.ImportExternalPhotoButton.UseVisualStyleBackColor = true;
            this.ImportExternalPhotoButton.Click += new System.EventHandler(this.onImportPhotoClick);
            // 
            // DeletePhotoButton
            // 
            this.DeletePhotoButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DeletePhotoButton.Location = new System.Drawing.Point(753, 126);
            this.DeletePhotoButton.Name = "DeletePhotoButton";
            this.DeletePhotoButton.Size = new System.Drawing.Size(32, 32);
            this.DeletePhotoButton.TabIndex = 5;
            this.DeletePhotoButton.UseVisualStyleBackColor = true;
            this.DeletePhotoButton.Click += new System.EventHandler(this.onDeletePhotoClick);
            // 
            // AlbumForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 531);
            this.Controls.Add(this.DeletePhotoButton);
            this.Controls.Add(this.ImportExternalPhotoButton);
            this.Controls.Add(this.RemovePhotoButton);
            this.Controls.Add(this.AddPhotoButton);
            this.Controls.Add(this.PhotoListView);
            this.Controls.Add(this.AlbumTreeView);
            this.Name = "AlbumForm";
            this.Text = "AlbumForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView AlbumTreeView;
        private System.Windows.Forms.ListView PhotoListView;
        private System.Windows.Forms.Button AddPhotoButton;
        private System.Windows.Forms.Button RemovePhotoButton;
        private System.Windows.Forms.Button ImportExternalPhotoButton;
        private System.Windows.Forms.Button DeletePhotoButton;

    }
}