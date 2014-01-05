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
    public partial class PhotoDetailForm : PhotoViewerForm
    {
        private readonly Photo photo;

        public PhotoDetailForm(Photo photo)
        {
            InitializeComponent();

            this.photo = photo;
            this.Text = Resources.PhotoDetailFormTitle;
        }

        private void onLoad(object sender, EventArgs e)
        {
            this.PictureBox.Image = photo.Image;

            this.PhotoPropertyGrid.SelectedObject = new PhotoInfo(photo);            
        }

        private class PhotoInfo
        {
            
            [ReadOnly(true)]
            [Category("Information")]
            [DisplayName("Nom")]
            public string Name { get; set; }

            [ReadOnly(true)]
            [Category("Information")]
            [DisplayName("Commentaire")]
            public string Comment { get; set; }

            [ReadOnly(true)]
            [Category("Information")]
            [DisplayName("Note")]
            public int Rating { get; set; }

            [ReadOnly(true)]
            [Category("Information")]
            [DisplayName("Catégorie")]
            public string Category { get; set; }

            #region EXIF

            [ReadOnly(true)]
            [Category("Information EXIF")]
            [DisplayName("Fabricant")]
            public string ManufacturerName { get; set; }
            
            [ReadOnly(true)]
            [Category("Information EXIF")]
            [DisplayName("Modéle")]
            public string ManufacturerProductName { get; set; }
            
            [ReadOnly(true)]
            [Category("Information EXIF")]
            [DisplayName("Titre")]
            public string Title { get; set; }

            [ReadOnly(true)]
            [Category("Information EXIF")]
            [DisplayName("Fabricant de l'objectif")]
            public string LensManufacturerName { get; set; }

            [ReadOnly(true)]
            [Category("Information EXIF")]
            [DisplayName("Modéle de l'objectif")]
            public string LensModelName { get; set; }

            [ReadOnly(true)]
            [Category("Information EXIF")]
            [DisplayName("Nom de l'artiste")]
            public string ArtistName { get; set; }


            #endregion


            public PhotoInfo(Photo photo)
            {
                this.Name = photo.Name;
                this.Rating = photo.Rating;
                this.Comment = photo.Comment;
                this.Category = photo.Category;


                this.LensManufacturerName = photo.LensManufacturer;
                this.LensModelName = photo.LensModel;
                this.ArtistName = photo.Artist;
                this.ManufacturerName = photo.EquipmentManufacturer;
                this.ManufacturerProductName = photo.EquipmentModel;
                this.Title = photo.Title;
            }
        }
    }
}
