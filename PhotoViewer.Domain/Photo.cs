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

        private static readonly int ExifTitleId = 0x0320;
        private static readonly int ExifManufacturerId = 0x010F;
        private static readonly int ExifEquipmentId = 0x0110;



        public static readonly string StoragePath = @"C:\Users\QC\Projects\PhotoViewer";

        public string Category { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }
        public DateTime DateTaken { get; set ;}

        private readonly Image content;

        #region EXIF 

        public string Title { get; private set; }
        public string EquipmentManufacturer { get; private set; }
        public string EquipmentModel { get; private set; }

        #endregion

        public Photo(string name)
        {
            content = Image.FromFile(Path.Combine(StoragePath,name));

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
