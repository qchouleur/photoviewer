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
    public partial class OpenPhotoFromStorageDialog : PhotoViewerForm
    {
        private ImageList imageList = new ImageList();

        public IEnumerable<Photo> SelectedPhotos 
        { 
            get 
            {
                foreach (ListViewItem selectedItem in PhotoListView.SelectedItems)
                {
                    yield return selectedItem.Tag as Photo;
                }

            }
        }

        public OpenPhotoFromStorageDialog()
        {
            InitializeComponent();

            this.imageList.ImageSize = PhotoThumbnailSize;
            this.PhotoListView.View = View.LargeIcon;
            this.PhotoListView.LargeImageList = imageList;

            this.Text = Resources.OpenDialogTitle;

            this.AcceptButton = this.OkButton;
            this.CancelButton = this.Cancel;

            this.OkButton.Text = Resources.Open;
            this.Cancel.Text = Resources.Cancel;

            populatePhotoList();

        }

        private void populatePhotoList()
        {
            foreach (Photo photo in InternalPhotoBase.Instance.GetPhotos())
            {
                imageList.Images.Add(photo.Name, photo.Image);
                ListViewItem photoItem = new ListViewItem(photo.Name) { Tag = photo, ImageKey = photo.Name};
                PhotoListView.Items.Add(photoItem);
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void Ok_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

    }
}
