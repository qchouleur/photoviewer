using PhotoViewer.Domain;
using PhotoViewer.UI.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhotoViewer.UI
{
    public partial class AlbumForm : PhotoViewerForm
    {
        private ImageList photoThumbnails = new ImageList() { ImageSize = PhotoThumbnailSize };

        public AlbumForm()
        {            
            InitializeComponent();


            this.Text = Resources.AlbumFormTitle;
            this.Menu = CreateMenu();

            this.PhotoListView.View = View.LargeIcon;
            this.PhotoListView.LargeImageList = photoThumbnails;

            this.AddPhotoButton.ToImageButton(Resources.addPhoto);
            this.RemovePhotoButton.ToImageButton(Resources.removePhoto);
            this.ImportExternalPhotoButton.ToImageButton(Resources.importPhoto);
            this.DeletePhotoButton.ToImageButton(Resources.deletePhoto);

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

            return menu;
        }

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

        private void onEditAlbum(object sender, EventArgs e)
        {

            if (!IsAlbumSelected())
            {
                MessageBox.Show(Resources.PleaseSelectAlbum, Resources.InformationDialogTitle,
                    MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }

            AlbumEditDialog albumCreationDialog = new AlbumEditDialog(selectedAlbum);
            DialogResult dialogResult = albumCreationDialog.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                selectedAlbum.EventDate = albumCreationDialog.DateTimePicker.Value;
                selectedAlbum.Title = albumCreationDialog.TitleTextBox.Text;
                selectedAlbum.SubTitle = albumCreationDialog.SubTitleTextBox.Text;
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
            if (selectedAlbum == null)
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

        private void AddPhotoButton_Click(object sender, EventArgs e)
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

        private void RemovePhotoButton_Click(object sender, EventArgs e)
        {
            if (!IsAlbumSelected())
            {
                MessageBox.Show(Resources.PleaseSelectAlbum, Resources.InformationDialogTitle,
                    MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }

            if (!selectedPhotos.Any())
            {
                return;
            }

            foreach(Photo photo in selectedPhotos)
            {
                selectedAlbum.Remove(photo);
            }

            updateAlbumPhotosList();
        }

        private void ImportExternalPhotoButton_Click(object sender, EventArgs e)
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

        private void DeletePhotoButton_Click(object sender, EventArgs e)
        {
            if (!selectedPhotos.Any())
            {
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

        private void AlbumTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            updateAlbumPhotosList();
        }
    
    }
}
