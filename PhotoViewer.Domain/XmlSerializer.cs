using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace PhotoViewer.Domain
{
    public class XmlSerializer
    {

        private IPhotoSource photoSource;
        
        public XmlSerializer(IPhotoSource photoSource)
        {
            this.photoSource = photoSource;
        }

        public void Serialize(IEnumerable<Photo> photos, string fileName)
        {
            XDocument document = new XDocument(new XDeclaration("1.0", "utf-8", "yes"),
                new XElement("Photos", 
                    photos.Select(photo => new XElement("Photo", 
                        new XAttribute("category", photo.Category ?? string.Empty ),
                        new XAttribute("comment", photo.Comment ?? string.Empty),
                        new XAttribute("rating", photo.Rating),
                        new XAttribute("date", photo.Date),
                        new XAttribute("path", photo.Path)))));

            document.Save(fileName);
        }


        public void Serialize(IEnumerable<PhotoAlbum> albums, string fileName)
        {
            XDocument document = new XDocument(new XDeclaration("1.0", "utf-8", "yes"),
                new XElement("Albums",
                    albums.Select(album => new XElement("Album",
                        new XAttribute("title", album.Title),
                        new XAttribute("subtitle", album.SubTitle ?? string.Empty),
                        new XAttribute("date", album.EventDate),
                        album.Photos.Select(photo => 
                            new XElement("Photo", 
                                new XAttribute("path", photo.Path)))))));

            document.Save(fileName);
        }


        public IEnumerable<Photo> DeserializePhotos(string fileName)
        {
            XDocument document = XDocument.Load(fileName);

            return from photo in document.Descendants("Photo")
                   select new Photo(photo.Attribute("path").Value,
                                    photo.Attribute("comment").Value,
                                    photo.Attribute("category").Value,
                                    int.Parse(photo.Attribute("rating").Value),
                                    DateTime.Parse(photo.Attribute("date").Value));
                   
        }

        public IEnumerable<PhotoAlbum> DeserializeAlbums(string fileName)
        {
            XDocument document = XDocument.Load(fileName);

            foreach (var albumElement in document.Descendants("Album"))
            {
                PhotoAlbum album = new PhotoAlbum(albumElement.Attribute("title").Value,
                                         albumElement.Attribute("subtitle").Value,
                                         DateTime.Parse(albumElement.Attribute("date").Value));

                IEnumerable<Photo> photos = albumElement.Descendants("Photo")
                    .Select(p => photoSource.GetPhoto(p.Attribute("path").Value))
                    .Where(p => p != null);

                album.Add(photos);

                yield return album;
            }

            
                   
        }
    }
}
