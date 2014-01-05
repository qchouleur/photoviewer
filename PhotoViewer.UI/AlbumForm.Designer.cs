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
            this.components = new System.ComponentModel.Container();
            this.AlbumTreeView = new System.Windows.Forms.TreeView();
            this.PhotoListView = new System.Windows.Forms.ListView();
            this.AddPhotoButton = new System.Windows.Forms.Button();
            this.RemovePhotoButton = new System.Windows.Forms.Button();
            this.ImportExternalPhotoButton = new System.Windows.Forms.Button();
            this.DeletePhotoButton = new System.Windows.Forms.Button();
            this.ZoomOutButton = new System.Windows.Forms.Button();
            this.ZoomInButton = new System.Windows.Forms.Button();
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.RemoveAlbumButton = new System.Windows.Forms.Button();
            this.AddAlbumButton = new System.Windows.Forms.Button();
            this.EditPhotoButton = new System.Windows.Forms.Button();
            this.EditAlbumButton = new System.Windows.Forms.Button();
            this.DetailPhotoButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // AlbumTreeView
            // 
            this.AlbumTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.AlbumTreeView.Location = new System.Drawing.Point(50, 12);
            this.AlbumTreeView.Name = "AlbumTreeView";
            this.AlbumTreeView.Size = new System.Drawing.Size(146, 507);
            this.AlbumTreeView.TabIndex = 0;
            this.AlbumTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.onAlbumSelection);
            this.AlbumTreeView.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.onAlbumDoubleClick);
            // 
            // PhotoListView
            // 
            this.PhotoListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PhotoListView.Location = new System.Drawing.Point(202, 12);
            this.PhotoListView.Name = "PhotoListView";
            this.PhotoListView.Size = new System.Drawing.Size(689, 507);
            this.PhotoListView.TabIndex = 1;
            this.PhotoListView.UseCompatibleStateImageBehavior = false;
            this.PhotoListView.DragDrop += new System.Windows.Forms.DragEventHandler(this.onPhotoDragDrop);
            this.PhotoListView.DragEnter += new System.Windows.Forms.DragEventHandler(this.onPhotoDragEnter);
            this.PhotoListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.onThumbnailDoubleClick);
            this.PhotoListView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.onPhotoMouseDown);
            this.PhotoListView.MouseMove += new System.Windows.Forms.MouseEventHandler(this.onPhotoMouseMove);
            this.PhotoListView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.onPhotoMouseUp);
            // 
            // AddPhotoButton
            // 
            this.AddPhotoButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AddPhotoButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.AddPhotoButton.Location = new System.Drawing.Point(897, 12);
            this.AddPhotoButton.Name = "AddPhotoButton";
            this.AddPhotoButton.Size = new System.Drawing.Size(32, 32);
            this.AddPhotoButton.TabIndex = 2;
            this.AddPhotoButton.UseVisualStyleBackColor = true;
            this.AddPhotoButton.Click += new System.EventHandler(this.onAddPhoto);
            // 
            // RemovePhotoButton
            // 
            this.RemovePhotoButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RemovePhotoButton.Location = new System.Drawing.Point(897, 50);
            this.RemovePhotoButton.Name = "RemovePhotoButton";
            this.RemovePhotoButton.Size = new System.Drawing.Size(32, 32);
            this.RemovePhotoButton.TabIndex = 3;
            this.RemovePhotoButton.UseVisualStyleBackColor = true;
            this.RemovePhotoButton.Click += new System.EventHandler(this.onRemovePhoto);
            // 
            // ImportExternalPhotoButton
            // 
            this.ImportExternalPhotoButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ImportExternalPhotoButton.Location = new System.Drawing.Point(897, 88);
            this.ImportExternalPhotoButton.Name = "ImportExternalPhotoButton";
            this.ImportExternalPhotoButton.Size = new System.Drawing.Size(32, 32);
            this.ImportExternalPhotoButton.TabIndex = 4;
            this.ImportExternalPhotoButton.UseVisualStyleBackColor = true;
            this.ImportExternalPhotoButton.Click += new System.EventHandler(this.onImportPhoto);
            // 
            // DeletePhotoButton
            // 
            this.DeletePhotoButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DeletePhotoButton.Location = new System.Drawing.Point(897, 202);
            this.DeletePhotoButton.Name = "DeletePhotoButton";
            this.DeletePhotoButton.Size = new System.Drawing.Size(32, 32);
            this.DeletePhotoButton.TabIndex = 5;
            this.DeletePhotoButton.UseVisualStyleBackColor = true;
            this.DeletePhotoButton.Click += new System.EventHandler(this.onDeletePhoto);
            // 
            // ZoomOutButton
            // 
            this.ZoomOutButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ZoomOutButton.Location = new System.Drawing.Point(897, 487);
            this.ZoomOutButton.Name = "ZoomOutButton";
            this.ZoomOutButton.Size = new System.Drawing.Size(32, 32);
            this.ZoomOutButton.TabIndex = 6;
            this.ZoomOutButton.UseVisualStyleBackColor = true;
            this.ZoomOutButton.Click += new System.EventHandler(this.onZoomOutClick);
            // 
            // ZoomInButton
            // 
            this.ZoomInButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ZoomInButton.Location = new System.Drawing.Point(897, 449);
            this.ZoomInButton.Name = "ZoomInButton";
            this.ZoomInButton.Size = new System.Drawing.Size(32, 32);
            this.ZoomInButton.TabIndex = 7;
            this.ZoomInButton.UseVisualStyleBackColor = true;
            this.ZoomInButton.Click += new System.EventHandler(this.onZoomInClick);
            // 
            // RemoveAlbumButton
            // 
            this.RemoveAlbumButton.Location = new System.Drawing.Point(12, 50);
            this.RemoveAlbumButton.Name = "RemoveAlbumButton";
            this.RemoveAlbumButton.Size = new System.Drawing.Size(32, 32);
            this.RemoveAlbumButton.TabIndex = 9;
            this.RemoveAlbumButton.UseVisualStyleBackColor = true;
            this.RemoveAlbumButton.Click += new System.EventHandler(this.onDeleteAlbum);
            // 
            // AddAlbumButton
            // 
            this.AddAlbumButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.AddAlbumButton.Location = new System.Drawing.Point(12, 12);
            this.AddAlbumButton.Name = "AddAlbumButton";
            this.AddAlbumButton.Size = new System.Drawing.Size(32, 32);
            this.AddAlbumButton.TabIndex = 8;
            this.AddAlbumButton.UseVisualStyleBackColor = true;
            this.AddAlbumButton.Click += new System.EventHandler(this.onCreateAlbum);
            // 
            // EditPhotoButton
            // 
            this.EditPhotoButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.EditPhotoButton.Location = new System.Drawing.Point(897, 126);
            this.EditPhotoButton.Name = "EditPhotoButton";
            this.EditPhotoButton.Size = new System.Drawing.Size(32, 32);
            this.EditPhotoButton.TabIndex = 10;
            this.EditPhotoButton.UseVisualStyleBackColor = true;
            this.EditPhotoButton.Click += new System.EventHandler(this.onPhotoEdit);
            // 
            // EditAlbumButton
            // 
            this.EditAlbumButton.Location = new System.Drawing.Point(12, 88);
            this.EditAlbumButton.Name = "EditAlbumButton";
            this.EditAlbumButton.Size = new System.Drawing.Size(32, 32);
            this.EditAlbumButton.TabIndex = 11;
            this.EditAlbumButton.UseVisualStyleBackColor = true;
            this.EditAlbumButton.Click += new System.EventHandler(this.onEditAlbum);
            // 
            // DetailPhotoButton
            // 
            this.DetailPhotoButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DetailPhotoButton.Location = new System.Drawing.Point(897, 164);
            this.DetailPhotoButton.Name = "DetailPhotoButton";
            this.DetailPhotoButton.Size = new System.Drawing.Size(32, 32);
            this.DetailPhotoButton.TabIndex = 12;
            this.DetailPhotoButton.UseVisualStyleBackColor = true;
            this.DetailPhotoButton.Click += new System.EventHandler(this.onPhotoDetail);
            // 
            // AlbumForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 531);
            this.Controls.Add(this.DetailPhotoButton);
            this.Controls.Add(this.EditAlbumButton);
            this.Controls.Add(this.EditPhotoButton);
            this.Controls.Add(this.RemoveAlbumButton);
            this.Controls.Add(this.AddAlbumButton);
            this.Controls.Add(this.ZoomInButton);
            this.Controls.Add(this.ZoomOutButton);
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
        private System.Windows.Forms.Button ZoomOutButton;
        private System.Windows.Forms.Button ZoomInButton;
        private System.Windows.Forms.ToolTip ToolTip;
        private System.Windows.Forms.Button RemoveAlbumButton;
        private System.Windows.Forms.Button AddAlbumButton;
        private System.Windows.Forms.Button EditPhotoButton;
        private System.Windows.Forms.Button EditAlbumButton;
        private System.Windows.Forms.Button DetailPhotoButton;

    }
}