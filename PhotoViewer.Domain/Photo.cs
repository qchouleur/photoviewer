﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoViewer.Domain
{
    public class Photo
    {
        
        public static readonly Photo EmptyPhoto = new Photo();

        public string Name { get { return System.IO.Path.GetFileNameWithoutExtension(Path); } }
        public long Size { get { return new FileInfo(Path).Length; } }
        public string Extension { get { return System.IO.Path.GetExtension(Path); } }

        public string Category { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }
        public DateTime Date { get; set ;}
        

        public string Path { get; set; }

        public Image Image { get; private set; }

        #region EXIF

        private static readonly int ExifTitleId = 0x0320;
        private static readonly int ExifManufacturerId = 0x010F;
        private static readonly int ExifEquipmentId = 0x0110;
        private static readonly int ExifArtistId = 0x013B;
        private static readonly int ExifLensManufacturerId = 0xa433;
        private static readonly int ExifLensModel = 0xa434;

        public string Title { get; private set; }
        public string EquipmentManufacturer { get; private set; }
        public string EquipmentModel { get; private set; }
        public string Artist { get; private set; }
        public string LensManufacturer { get; private set; }
        public string LensModel { get; private set; }

        #endregion

        public Photo() { } 
        public Photo(string path)
        {
            this.Date = DateTime.Now;
            this.Path = path;
            this.Image = Image.FromFile(path);


            this.Title = retrieveExifDataById(ExifTitleId);
            this.EquipmentManufacturer = retrieveExifDataById(ExifManufacturerId);
            this.EquipmentModel = retrieveExifDataById(ExifEquipmentId);
            this.Artist = retrieveExifDataById(ExifArtistId);
            this.LensManufacturer = retrieveExifDataById(ExifLensManufacturerId);
            this.LensModel = retrieveExifDataById(ExifLensModel);
            
        }
        public Photo(string path, string comment, string category, int rating, DateTime date) : this(path)
        {
            this.Comment = comment;
            this.Rating = rating;
            this.Category = category;
            this.Date = date;
        }

        private string retrieveExifDataById(int propertyId)
        {
            if (!Image.PropertyIdList.Contains(propertyId))
            {
                return string.Empty;
            }

            return Encoding.ASCII.GetString(
                Image.GetPropertyItem(propertyId).Value);
        }
    }
}
