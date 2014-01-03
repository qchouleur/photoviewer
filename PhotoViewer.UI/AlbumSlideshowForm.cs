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
    public partial class AlbumSlideshowForm : Form
    {
        private readonly AlbumSlideshow slideshow;
        private Rectangle formBoundsBeforeFullScreen { get; set; }
        private Rectangle pictureBoxBoundsBeforeFullScreen { get; set; }
        private bool isFullScreen { get; set; }

        public AlbumSlideshowForm(PhotoAlbum album)
        {
            album.Add(new Photo(@"C:\Users\QC\Downloads\random.jpg"));
            album.Add(new Photo(@"C:\Users\QC\Downloads\random-pics.jpg"));
            album.Add(new Photo(@"C:\Users\QC\Downloads\index.jpg"));


            this.slideshow = new AlbumSlideshow(album, () => { this.onSlide(); });

            InitializeComponent();

            this.pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;

            this.MinimumSize = this.Size;

            InitializeImageButton(PlayPauseButton, Resources.play);
            InitializeImageButton(NextButton, Resources.next);
            InitializeImageButton(PreviousButton, Resources.previous);
            InitializeImageButton(SlideAccelerateButton, Resources.add);
            InitializeImageButton(SlideDecelerateButton, Resources.minus);

            HideSpeedControlButtons();

            onSlide();
        }

        
        private static void InitializeImageButton(Button button, Image image)
        {
            button.Image = image;
            button.Size = image.Size;
            button.MinimumSize = image.Size;

            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.Text = string.Empty;
            
        }

        #region EventHandlers

        private void PlayPauseButton_Click(object sender, EventArgs e)
        {
            if (slideshow.Started)
            {
                slideshow.Pause();
                HideSpeedControlButtons();
                PlayPauseButton.Image = Resources.play;
            }
            else
            {
                slideshow.Start();
                ShowSpeedControlButtons();
                PlayPauseButton.Image = Resources.pause;
            }
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            slideshow.NextPhoto();
        }

        private void PreviousButton_Click(object sender, EventArgs e)
        {
            slideshow.PreviousPhoto();
        }

        private void SlideDecelerateButton_Click(object sender, EventArgs e)
        {
            this.slideshow.DecreaseSlideSpeed();
        }

        private void SlideAccelerateButton_Click(object sender, EventArgs e)
        {
            this.slideshow.IncreaseSlideSpeed();
        }

        private void onSlide()
        {
            pictureBox.Image = (slideshow.CurrentPhoto == Photo.EmptyPhoto) ?
                Resources.emptyAlbum : slideshow.CurrentPhoto.Image;

        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.F11:
                    if (!this.isFullScreen)
                    {
                        this.enterFullScreen();
                    }
                    return true;
                case Keys.Escape :
                    if (this.isFullScreen)
                    {
                        this.exitFullScreen();
                    }
                    return true;
                default:
                    return base.ProcessCmdKey(ref msg, keyData);
            }
        }

        #endregion
        

        private void ShowSpeedControlButtons()
        {
            SlideAccelerateButton.Show();
            SlideDecelerateButton.Show();
        }

        private void HideSpeedControlButtons()
        {
            SlideDecelerateButton.Hide();
            SlideAccelerateButton.Hide();
        }

        private void enterFullScreen()
        {
            this.isFullScreen = true;

            this.formBoundsBeforeFullScreen = this.Bounds;
            this.pictureBoxBoundsBeforeFullScreen = this.pictureBox.Bounds;

            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Bounds = Screen.PrimaryScreen.Bounds;

            this.pictureBox.BringToFront();
            this.pictureBox.Bounds = this.Bounds;
        }

        private void exitFullScreen()
        {
            this.isFullScreen = false;

            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;

            this.Bounds = this.formBoundsBeforeFullScreen;

            this.pictureBox.Bounds = this.pictureBoxBoundsBeforeFullScreen;
            this.pictureBox.SendToBack();

        }

    }
}
