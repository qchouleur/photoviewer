using PhotoViewer.Domain;
using PhotoViewer.UI.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhotoViewer.UI
{
    public partial class AlbumForm : PhotoViewerForm
    {
        private ImageList photoThumbnails = new ImageList() { ImageSize = PhotoThumbnailSize };

        private bool IsAlbumSelected()
        {
            return this.AlbumTreeView.SelectedNode != null
                   && this.AlbumTreeView.SelectedNode.Tag as PhotoAlbum != null;
        }

        private PhotoAlbum selectedAlbum
        {
            get
            {
                if (AlbumTreeView.SelectedNode == null)
                {
                    return null;
                }
                return this.AlbumTreeView.SelectedNode.Tag as PhotoAlbum;
            }
        }

        private IEnumerable<Photo> selectedPhotos
        {
            get
            {
                foreach (ListViewItem selectedPhotos in PhotoListView.SelectedItems)
                {
                    Photo photo = selectedPhotos.Tag as Photo;
                    if (photo == null) continue;
                    yield return photo;
                }
            }
        }

        public AlbumForm()
        {            
            InitializeComponent();


            this.Text = Resources.AlbumFormTitle;
            this.Menu = CreateMenu();

            #region AlbumInit
            
            this.AddAlbumButton.ToImageButton(Resources.addPhoto);
            this.RemoveAlbumButton.ToImageButton(Resources.removePhoto);
            this.EditAlbumButton.ToImageButton(Resources.editIcon);

            ToolTip.SetToolTip(this.AddAlbumButton, Resources.CreateAlbum);
            ToolTip.SetToolTip(this.RemoveAlbumButton, Resources.DeleteAlbum);
            ToolTip.SetToolTip(this.EditAlbumButton, Resources.EditAlbumInformation);

            #endregion

            #region PhotoInit
            
            this.PhotoListView.View = View.LargeIcon;
            this.PhotoListView.LargeImageList = photoThumbnails;

            // Autorise le drag and drop de fichier depuis l'éxterieur
            this.PhotoListView.AllowDrop = true;

            this.AddPhotoButton.ToImageButton(Resources.addPhoto);
            this.RemovePhotoButton.ToImageButton(Resources.removePhoto);
            this.ImportExternalPhotoButton.ToImageButton(Resources.importPhoto);
            this.EditPhotoButton.ToImageButton(Resources.editIcon);
            this.DeletePhotoButton.ToImageButton(Resources.deletePhoto);
            this.ZoomInButton.ToImageButton(Resources.zoomin);
            this.ZoomOutButton.ToImageButton(Resources.zoomout);

            ToolTip.SetToolTip(this.AddPhotoButton, Resources.AddPhotoFromStorage);
            ToolTip.SetToolTip(this.RemovePhotoButton, Resources.RemovePhotoFromAlbum);
            ToolTip.SetToolTip(this.ImportExternalPhotoButton, Resources.Import);
            ToolTip.SetToolTip(this.DeletePhotoButton, Resources.DeletePhotoFromStorage);
            ToolTip.SetToolTip(this.EditPhotoButton, Resources.EditPhotoInformation);

            #endregion
        }

        private MainMenu CreateMenu()
        {
            MainMenu menu = new MainMenu();

            MenuItem albumMenuItem = new MenuItem("&" + Resources.Album);
            MenuItem createAlbumMenuItem = new MenuItem("&" + Resources.Create, new EventHandler(onCreateAlbum));
            MenuItem removeAlbumMenuItem = new MenuItem("&" + Resources.Delete, new EventHandler(onDeleteAlbum));
            MenuItem editAlbumMenuItem = new MenuItem("&" + Resources.Edit, new EventHandler(onEditAlbum));
            MenuItem slideshowAlbumMenuItem = new MenuItem("&" + Resources.Slideshow, new EventHandler(onSlideShow));

            albumMenuItem.MenuItems.Add(createAlbumMenuItem);
            albumMenuItem.MenuItems.Add(removeAlbumMenuItem);
            albumMenuItem.MenuItems.Add(editAlbumMenuItem);
            albumMenuItem.MenuItems.Add(slideshowAlbumMenuItem);

            menu.MenuItems.Add(albumMenuItem);


            MenuItem photoMenuItem = new MenuItem("&" + Resources.Photo);
            MenuItem addPhotoMenuItem = new MenuItem("&" + Resources.AddElement, new EventHandler(onAddPhoto));
            MenuItem editPhotoMenuItem = new MenuItem("&" + Resources.Edit, new EventHandler(onPhotoEdit));
            MenuItem removePhotoMenuItem = new MenuItem("&" + Resources.Withdraw, new EventHandler(onRemovePhoto));
            MenuItem importPhotoMenuItem = new MenuItem("&" + Resources.Edit, new EventHandler(onImportPhoto));
            MenuItem deletePhotoMenuItem = new MenuItem("&" + Resources.Delete, new EventHandler(onDeletePhoto));

            photoMenuItem.MenuItems.Add(addPhotoMenuItem);
            photoMenuItem.MenuItems.Add(editPhotoMenuItem);
            photoMenuItem.MenuItems.Add(removePhotoMenuItem);
            photoMenuItem.MenuItems.Add(importPhotoMenuItem);
            photoMenuItem.MenuItems.Add(deletePhotoMenuItem);

            menu.MenuItems.Add(photoMenuItem);


            return menu;
        }

        private void updateAlbumList()
        {
            this.AlbumTreeView.Nodes.Clear();

            foreach (PhotoAlbum album in InternalPhotoBase.Instance.GetAlbums())
            {
                this.AlbumTreeView.Nodes.Add(new TreeNode(album.Title) { Tag = album });
            }
        }

        private void updateAlbumPhotosList()
        {
            this.PhotoListView.Items.Clear();
            this.photoThumbnails.Images.Clear();

            if (!IsAlbumSelected())
            {
                return;
            }

            foreach (Photo photo in selectedAlbum.Photos)
            {
                photoThumbnails.Images.Add(photo.Name, photo.Image);
                ListViewItem photoItem = new ListViewItem(photo.Name) { Tag = photo, ImageKey = photo.Name };
                PhotoListView.Items.Add(photoItem);
            }
        }


        #region AlbumEventHandlers
        
        private void onSlideShow(object sender, EventArgs e)
        {
            if (!IsAlbumSelected())
            {
                MessageBox.Show(Resources.PleaseSelectAlbum, Resources.InformationDialogTitle,
                    MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }

            new AlbumSlideshowForm(selectedAlbum).Show();
        }

        private void onAlbumDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            onSlideShow(sender, e);
        }

        private void onEditAlbum(object sender, EventArgs e)
        {

            if (!IsAlbumSelected())
            {
                MessageBox.Show(Resources.PleaseSelectAlbum, Resources.InformationDialogTitle,
                    MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }

            AlbumEditDialog albumEditionDialog = new AlbumEditDialog(selectedAlbum);
            DialogResult dialogResult = albumEditionDialog.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                selectedAlbum.EventDate = albumEditionDialog.DateTimePicker.Value;
                selectedAlbum.Title = albumEditionDialog.TitleTextBox.Text;
                selectedAlbum.SubTitle = albumEditionDialog.SubTitleTextBox.Text;
            }

            this.updateAlbumList();
        }

        private void onDeleteAlbum(object sender, EventArgs e)
        {
            if (!IsAlbumSelected())
            {
                MessageBox.Show(Resources.PleaseSelectAlbum, Resources.InformationDialogTitle,
                    MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }

            InternalPhotoBase.Instance.Remove(selectedAlbum);
            this.updateAlbumList();
            this.updateAlbumPhotosList();
        }

        private void onCreateAlbum(object sender, EventArgs e)
        {
            AlbumEditDialog albumCreationDialog = new AlbumEditDialog();
            DialogResult dialogResult = albumCreationDialog.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {

                DateTime date = albumCreationDialog.DateTimePicker.Value;
                string title = albumCreationDialog.TitleTextBox.Text;
                string subtitle = albumCreationDialog.SubTitleTextBox.Text;

                InternalPhotoBase.Instance.Add(new PhotoAlbum(title, subtitle, date));
                this.updateAlbumList();
            }

        }
        
        private void onAlbumSelection(object sender, TreeViewEventArgs e)
        {
            updateAlbumPhotosList();
        }

        #endregion

        #region PhotoEventHandlers
        
        private void onAddPhoto(object sender, EventArgs e)
        {
            if (!IsAlbumSelected())
            {
                MessageBox.Show(Resources.PleaseSelectAlbum, Resources.InformationDialogTitle,
                    MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }

            OpenPhotoFromStorageDialog openFromStorageDialog =
                new OpenPhotoFromStorageDialog();

            if (openFromStorageDialog.ShowDialog() == DialogResult.OK
                && openFromStorageDialog.SelectedPhotos.Any())
            {
                selectedAlbum.Add(openFromStorageDialog.SelectedPhotos);
                updateAlbumPhotosList();
            }

        }

        private void onRemovePhoto(object sender, EventArgs e)
        {

            if (!IsAlbumSelected())
            {
                MessageBox.Show(Resources.PleaseSelectAlbum, Resources.InformationDialogTitle,
                    MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }


            if (!selectedPhotos.Any())
            {
                MessageBox.Show(Resources.PleaseSelectOneOrMorePhotos, Resources.InformationDialogTitle,
                    MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }

            foreach(Photo photo in selectedPhotos)
            {
                selectedAlbum.Remove(photo);
            }

            updateAlbumPhotosList();
        }

        private void onImportPhoto(object sender, EventArgs e)
        {
            if (!IsAlbumSelected())
            {
                MessageBox.Show(Resources.PleaseSelectAlbum, Resources.InformationDialogTitle,
                    MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }

            OpenFileDialog importPhotoDialog = new OpenFileDialog();
            importPhotoDialog.InitialDirectory =  Environment.GetFolderPath(Environment.SpecialFolder.CommonPictures);
            importPhotoDialog.Filter = "Photos|*.png;*.jpeg;*.jpg";
            importPhotoDialog.Multiselect = true;

            if (importPhotoDialog.ShowDialog() == DialogResult.OK 
                && importPhotoDialog.FileNames.Any())
            {
                var selectedPhotos = importPhotoDialog.FileNames.Select(fileName => new Photo(fileName));
                var importedPhotos = InternalPhotoBase.Instance.Import(selectedPhotos);
                selectedAlbum.Add(importedPhotos);
                updateAlbumPhotosList();
            }
        }

        private void onDeletePhoto(object sender, EventArgs e)
        {
            if (!IsAlbumSelected())
            {
                MessageBox.Show(Resources.PleaseSelectAlbum, Resources.InformationDialogTitle,
                    MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }

            if (!selectedPhotos.Any())
            {
                MessageBox.Show(Resources.PleaseSelectOneOrMorePhotos, Resources.InformationDialogTitle,
                    MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }

            var validationResult = MessageBox.Show(Resources.PhotoDeleteValidationMessage, 
                Resources.InformationDialogTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);

            if (validationResult == DialogResult.OK)
            {
                InternalPhotoBase.Instance.Delete(selectedPhotos);
                updateAlbumPhotosList();
            }
        }

        private void onThumbnailDoubleClick(object sender, MouseEventArgs e)
        {
            onPhotoEdit(sender, e);
        }

        private void onPhotoEdit(object sender, EventArgs e)
        {
            if (!selectedPhotos.Any())
            {
                MessageBox.Show(Resources.PleaseSelectOnePhoto, Resources.InformationDialogTitle,
                    MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }

            Photo photo = selectedPhotos.First();
            PhotoEditDialog photoEditDialog = new PhotoEditDialog(photo);
            if (photoEditDialog.ShowDialog() == DialogResult.OK)
            {
                photo.Rating = int.Parse(photoEditDialog.RatingTextBox.Text);
                photo.Comment = photoEditDialog.CommentTextBox.Text;
                photo.Category = photoEditDialog.CategoryTextBox.Text;
                photo.DateTaken = photoEditDialog.EventDateTimePicker.Value;
            }
        }

        private void onZoomInClick(object sender, EventArgs e)
        {
            int newWidth = photoThumbnails.ImageSize.Width + 30;
            int newHeight = photoThumbnails.ImageSize.Height + 30;

            if (newWidth < 256 || newHeight < 256)
            {
                photoThumbnails.ImageSize =  new Size(newWidth, newHeight);
                updateAlbumPhotosList();
            }
        }

        private void onZoomOutClick(object sender, EventArgs e)
        {
            int newWidth = photoThumbnails.ImageSize.Width - 30;
            int newHeight = photoThumbnails.ImageSize.Height - 30;


            if (newWidth >= 1 || newHeight >= 1)
            {
                photoThumbnails.ImageSize = new Size(newWidth, newHeight);
                updateAlbumPhotosList();
            }
        }

        private void onPhotoDragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void onPhotoDragDrop(object sender, DragEventArgs e)
        {

            if (!IsAlbumSelected())
            {
                MessageBox.Show(Resources.PleaseSelectAlbum, Resources.InformationDialogTitle,
                    MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }

            string[] dropedFilesPath = e.Data.GetData(DataFormats.FileDrop) as string[];
            if (dropedFilesPath == null)
            {
                return;
            }

            List<Photo> photos = new List<Photo>();
            foreach (string dropedFilePath in dropedFilesPath)
            {
                if (InternalPhotoBase.AcceptPhotoOfExtension(Path.GetExtension(dropedFilePath)))
                {
                    photos.Add(new Photo(dropedFilePath));
                }
            }

            var importedPhotos = InternalPhotoBase.Instance.Import(photos);
            selectedAlbum.Add(importedPhotos);
            updateAlbumPhotosList();
        }

        #endregion

        

    }
}
