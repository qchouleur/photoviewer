using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoViewer.Domain
{
    public class PhotoAlbum
    {
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public DateTime EventDate { get; set; }

        private List<Photo> photos = new List<Photo>();

        public PhotoAlbum() {  }

        public PhotoAlbum(string title, string subtitle, DateTime date)
        {
            this.Title = title;
            this.SubTitle = subtitle;
            this.EventDate = date;
        }

        public bool Contains(Photo photo)
        {
            return photos.Contains(photo);
        }

        public void Remove(Photo photo)
        {
            photos.Remove(photo);
        }
    }
}
