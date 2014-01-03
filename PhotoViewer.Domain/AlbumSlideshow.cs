using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace PhotoViewer.Domain
{
    public class AlbumSlideshow
    {
        private static readonly double DefaultSlideIntervalInMilliseconds = 1000;
        private static readonly double IntervalIncrementInMilliseconds = 200;

        private int _photoIndex;
        private int photoIndex
        {
            get { return _photoIndex; }
            set 
            { 
                _photoIndex = value;
                onSlideAction.Invoke();
            }
        }
        
        private readonly Timer slideTimer;
        private readonly Action onSlideAction;
        private readonly PhotoAlbum album;

        public Photo CurrentPhoto {
            get
            {
                if (album.IsEmpty)
                {
                    return Photo.EmptyPhoto;
                }

                return album[photoIndex];
            } 
        }
        public bool Started { get; private set; }

        public AlbumSlideshow(PhotoAlbum album, Action onSlideAction)
        {
            this.onSlideAction = onSlideAction;
            this.album = album;

            slideTimer = new Timer(DefaultSlideIntervalInMilliseconds);
            slideTimer.Elapsed += onSlideIntervalElapsed;
        }

        private void onSlideIntervalElapsed(object sender, ElapsedEventArgs e)
        {
            NextPhoto();
        }

        public void IncreaseSlideSpeed()
        {
            if (slideTimer.Interval - IntervalIncrementInMilliseconds > 0)
            {
                slideTimer.Stop();
                slideTimer.Interval -= IntervalIncrementInMilliseconds;
                slideTimer.Start();
            }
        }

        public void DecreaseSlideSpeed()
        {
            slideTimer.Stop();
            slideTimer.Interval += IntervalIncrementInMilliseconds;
            slideTimer.Start();
        }

        public void Start()
        {
            slideTimer.Start();
            Started = true;
        }

        public void Pause()
        {
            slideTimer.Stop();
            Started = false;
        }

        public void NextPhoto()
        {
            photoIndex = (photoIndex + 1 == album.Count) ? 
                0 : photoIndex + 1;
        }

        public void PreviousPhoto()
        {
            photoIndex = (photoIndex > 0) ?
                photoIndex - 1 : album.Count - 1;
        }
    }
}
