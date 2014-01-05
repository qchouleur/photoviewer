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

        public int Count { get { return photos.Count; } }
        public IEnumerable<Photo> Photos { get { return photos.AsReadOnly(); } }

        private List<Photo> photos = new List<Photo>();

        public PhotoAlbum() {  }

        public PhotoAlbum(string title, string subtitle, DateTime date)
        {
            this.Title = title;
            this.SubTitle = subtitle;
            this.EventDate = date;
        }

        public Photo this[int index]
        {
            get { return photos[index]; }
            set { photos[index] = value; }
        }

        public bool Contains(Photo photo)
        {
            return photos.Contains(photo);
        }

        public void Remove(Photo photo)
        {
            photos.Remove(photo);
        }
    
        public void Add(Photo photo)
        {
            if(!this.photos.Any(p => p.Path == photo.Path))
                this.photos.Add(photo);
        }

        public void Add(IEnumerable<Photo> photos)
        {
            foreach (var photo in photos)
            {
                this.Add(photo);
            }
        }

        public bool IsEmpty
        {
            get
            {
                return !photos.Any();
            }
        }


        public void MovePhoto(int index, Photo photo)
        {
            photos.Remove(photo);
            photos.Insert(index, photo);
        }
    }
}
