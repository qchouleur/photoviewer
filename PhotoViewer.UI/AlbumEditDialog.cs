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
    public partial class AlbumEditDialog : PhotoViewerForm
    {
        public AlbumEditDialog()
        {
            InitializeComponent();

            this.Text = Resources.CreateAlbumDialogFormTitle;

            this.SubTitleLabel.Text = Resources.SubTitle;
            this.TitleLabel.Text = Resources.Title;
            this.DateLabel.Text = Resources.Date;

            this.SaveAlbumButton.Text = Resources.Save;
            this.CancelAlbumButton.Text = Resources.Cancel;

            this.AcceptButton = this.SaveAlbumButton;
        }

        public AlbumEditDialog(PhotoAlbum album) : this()
        {
            this.TitleTextBox.Text = album.Title;
            this.SubTitleTextBox.Text = album.SubTitle;
            this.DateTimePicker.Value = album.EventDate;
        }

        private void onSaveClick(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.TitleTextBox.Text))
            {
                MessageBox.Show(Resources.PleaseEnterAlbumTitle, Resources.InformationDialogTitle,
                    MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void onCancelClick(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

    }
}
