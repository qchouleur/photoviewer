using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoViewer.Domain
{
    public class InternalPhotoBase : IPhotoSource
    {
        public static readonly string ApplicationFolderPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "PhotoViewer");
        private static readonly string AlbumFilePath = 
            Path.Combine(ApplicationFolderPath, "albums.xml");
        private static readonly string PhotoFilePath =
            Path.Combine(ApplicationFolderPath, "photos.xml");

        private static string[] ValidImageExtension = 
            new string[] { ".png", ".jpg", ".jpeg" };

        private static InternalPhotoBase instance;

        private List<Photo> photos = new List<Photo>();
        private List<PhotoAlbum> albums = new List<PhotoAlbum>();
        private XmlSerializer serializer;


        private InternalPhotoBase() { }

        public void Load()
        {
            serializer = new XmlSerializer(this);

            if (!Directory.Exists(ApplicationFolderPath))
            {
                Directory.CreateDirectory(ApplicationFolderPath);
            }


            if (File.Exists(PhotoFilePath))
            {
                this.photos = serializer.DeserializePhotos(PhotoFilePath).ToList();
            }


            if (File.Exists(AlbumFilePath))
            {
                this.albums = serializer.DeserializeAlbums(AlbumFilePath).ToList();
            }
        }

        public void Save()
        {
            if (photos.Any())
            {
                serializer.Serialize(photos, PhotoFilePath);
            }

            if (albums.Any())
            {
                serializer.Serialize(albums, AlbumFilePath);
            }
        }

        public static InternalPhotoBase Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new InternalPhotoBase();
                }
                return instance;
            }
        }

        public void Add(PhotoAlbum album)
        {
            this.albums.Add(album);
        }

        public void Remove(PhotoAlbum album)
        {
            this.albums.Remove(album);
        }

        public void Add(Photo photo)
        {
            // Empéche de rajouter plusieurs fois la même image
            if (!photos.Any(p => p.Path == photo.Path))
            {
                this.photos.Add(photo);
            }
        }

        public IEnumerable<Photo> Import(IEnumerable<Photo> photos) 
        {

            List<Photo> importedPhotos = new List<Photo>();

            foreach (Photo photo in photos)
            {

                string photoName = Path.GetFileName(photo.Path);
                string destination = Path.Combine(ApplicationFolderPath, photoName);

                // N'importe que les photos non présentes 
                // Remplace la photo dupliquée par celle déjà présente
                if(this.photos.Any(p => p.Path == destination))
                {
                    importedPhotos.Add(this.photos.First(p => p.Path == destination));
                    continue;
                }

                File.Copy(photo.Path, destination, true);
                photo.Path = destination;
                this.Add(photo);
                importedPhotos.Add(photo);
            }

            return importedPhotos;
        }

        public void Remove(Photo photo)
        {
            this.photos.Remove(photo);

            foreach (var album in this.albums)
            {
                if (album.Contains(photo))
                {
                    album.Remove(photo);
                }
            }
        }

        public void Remove(IEnumerable<Photo> photos)
        {
            foreach (var photo in photos)
            {
                Remove(photo);
            }
        }

        public void Delete(Photo photo)
        {
            Remove(photo);
            photo.Image.Dispose();
            File.Delete(photo.Path);
        }

        public void Delete(IEnumerable<Photo> photos)
        {
            foreach (Photo photo in photos)
            {
                Delete(photo);
            }
        }

        public IEnumerable<PhotoAlbum> GetAlbums()
        {
            return this.albums.AsReadOnly();
        }
    
        public IEnumerable<Photo> GetPhotos()
        {
            return photos.AsReadOnly();
        }

        public static bool AcceptPhotoOfExtension(string extension)
        {
            return ValidImageExtension.Contains(extension);
        }

        public Photo GetPhoto(string path)
        {
            return photos.FirstOrDefault(p => p.Path == path);
        }
    }
}
