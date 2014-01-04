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
    public partial class AlbumSlideshowForm : PhotoViewerForm
    {
        private readonly AlbumSlideshow slideshow;
        private Rectangle formBoundsBeforeFullScreen { get; set; }
        private Rectangle pictureBoxBoundsBeforeFullScreen { get; set; }
        private bool isFullScreen { get; set; }

        public AlbumSlideshowForm(PhotoAlbum album)
        {

            this.slideshow = new AlbumSlideshow(album, () => { this.onSlide(); });

            InitializeComponent();

            this.pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            this.MinimumSize = this.Size;
            this.Text = Resources.SlideshowFormTitle;

            PlayPauseButton.ToImageButton(Resources.play);
            NextButton.ToImageButton(Resources.next);
            PreviousButton.ToImageButton(Resources.previous);
            SlideAccelerateButton.ToImageButton(Resources.add);
            SlideDecelerateButton.ToImageButton(Resources.minus);

            HideSpeedControlButtons();

            onSlide();

            // Permet de récupérer l'évenement OnKeyPress
            this.KeyPreview = true;
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

                case Keys.Space:
                    PlayPauseButton_Click(this, null);
                    return true;
                case Keys.Right:
                    slideshow.NextPhoto();
                    return true;
                case Keys.Left :
                    slideshow.PreviousPhoto();
                    return true;
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

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case '+' :
                    slideshow.IncreaseSlideSpeed();
                    break;
                case '-' :
                    slideshow.DecreaseSlideSpeed();
                    break;
                default :
                    base.OnKeyPress(e);
                    break;
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
