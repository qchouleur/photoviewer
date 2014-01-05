using PhotoViewer.Domain;
using PhotoViewer.UI.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PhotoViewer.UI
{
    public partial class PhotoEditDialog : PhotoViewerForm
    {
        public PhotoEditDialog()
        {
            InitializeComponent();

            this.Text = Resources.EditPhotoDialogFormTitle;

            this.CommentLabel.Text = Resources.Comment;
            this.RatingLabel.Text = Resources.Rating;
            this.CategoryLabel.Text = Resources.Category;
            this.DateLabel.Text = Resources.EventDate;

            this.CancelPhotoButton.Text = Resources.Cancel;
            this.SaveButton.Text = Resources.Save;
            this.CancelButton = this.CancelPhotoButton;
            this.AcceptButton = this.SaveButton;

            this.EventDateTimePicker.MinDate = new DateTime();

        }


        public PhotoEditDialog(Photo photo) : this()
        {
            this.CommentTextBox.Text = photo.Comment;
            this.CategoryTextBox.Text = photo.Category;
            this.EventDateTimePicker.Value = photo.Date;
            this.RatingTextBox.Text = photo.Rating.ToString();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(this.RatingTextBox.Text))
            {
                this.RatingTextBox.Text = 0.ToString();
            }

            int rating;
            if (!int.TryParse(this.RatingTextBox.Text, out rating))
            {
                MessageBox.Show(Resources.PleaseEnterAValidRating, Resources.InformationDialogTitle,
                    MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }


            DialogResult = DialogResult.OK;
        }

        private void CancelPhotoButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }


    }
}
