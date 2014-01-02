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
    public partial class AlbumEditDialog : Form
    {
        public AlbumEditDialog()
        {
            InitializeComponent();

            this.Text = Resources.CreateAlbumDialogFormTitle;

            this.SubTitleLabel.Text = Resources.SubTitle;
            this.TitleLabel.Text = Resources.Title;
            this.DateLabel.Text = Resources.Date;

            this.SaveButton.Text = Resources.Save;
            this.CancelButton.Text = Resources.Cancel;

            this.AcceptButton = this.SaveButton;
        }

        public AlbumEditDialog(PhotoAlbum album) : this()
        {
            this.TitleTextBox.Text = album.Title;
            this.SubTitleTextBox.Text = album.SubTitle;
            this.DateTimePicker.Value = album.EventDate;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.TitleTextBox.Text))
            {
                MessageBox.Show(Resources.PleaseEnterAlbumTitle, Resources.InformationDialogTitle,
                    MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }



    }
}
