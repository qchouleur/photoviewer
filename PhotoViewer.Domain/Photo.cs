using System;
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

        public string Category { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }
        public DateTime DateTaken { get; set ;}

        public string Path { get; set; }

        private readonly Image content;

        #region EXIF

        private static readonly int ExifTitleId = 0x0320;
        private static readonly int ExifManufacturerId = 0x010F;
        private static readonly int ExifEquipmentId = 0x0110;

        public string Title { get; private set; }
        public string EquipmentManufacturer { get; private set; }
        public string EquipmentModel { get; private set; }

        #endregion

        public Photo() { } 
        public Photo(string path)
        {
            this.Path = path;
            this.content = Image.FromFile(path);

            this.Title = retrieveExifDataById(ExifTitleId);
            this.EquipmentManufacturer = retrieveExifDataById(ExifManufacturerId);
            this.EquipmentModel = retrieveExifDataById(ExifEquipmentId);
            
        }

        private string retrieveExifDataById(int propertyId)
        {
            if (!content.PropertyIdList.Contains(propertyId))
            {
                return string.Empty;
            }

            return Encoding.ASCII.GetString(
                content.GetPropertyItem(propertyId).Value);
        }
    }
}
