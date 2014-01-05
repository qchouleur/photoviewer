using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhotoViewer.Domain
{
    public class AlbumHTMLPrinter
    {
        public int PhotoPerRowCount { get; set; }
        public int PhotoWidth { get; set; }
        public int PhotoHeight { get; set; }


        public AlbumHTMLPrinter(int photoPerRowCount, int photoWidth, int photoHeight)
        {
            this.PhotoHeight = photoHeight;
            this.PhotoWidth = photoWidth;
            this.PhotoPerRowCount = photoPerRowCount;
        }

        public string Print(PhotoAlbum album)
        {
            return string.Format("<html> {0} {1} </html>", printHeader(album), printBody(album));
        }

        private string printBody(PhotoAlbum album)
        {
            StringBuilder bodyBuilder = new StringBuilder();

            bodyBuilder.AppendLine("<body bgcolor=\"#333333\">");
            bodyBuilder.AppendLine("<center>");
            bodyBuilder.AppendLine("<H1 style=\"color:#FDF5E6\">" + album.Title + "</H1>");

            bodyBuilder.AppendLine("<table border=\"0\" cellpadding=\"3\" cellspacing=\"10\" width=\"" + PhotoPerRowCount * PhotoWidth + "\">");


            int currentPhotoInRowCount = 0;
            bodyBuilder.AppendLine("<tr>");
            foreach (Photo photo in album.Photos)
            {
                if (currentPhotoInRowCount == PhotoPerRowCount)
                {
                    bodyBuilder.AppendLine("</tr>");
                    bodyBuilder.AppendLine("<tr>");
                    currentPhotoInRowCount = 0;
                }

                bodyBuilder.AppendLine("<td width=\"" + PhotoWidth + "\" align=\"center\">" +
                                       "<img border=\"0\" src=\"file:\\\\" + photo.Path + "\" align=\"center\" width=\"" + PhotoWidth + "\" height=\"" + PhotoHeight + "\"/></td>");

                currentPhotoInRowCount++;
            }
            bodyBuilder.AppendLine("</tr>");
            

            bodyBuilder.AppendLine("</table>");
            bodyBuilder.AppendLine("</center>");
            bodyBuilder.AppendLine("</body>");


            return bodyBuilder.ToString();
        }

        private string printHeader(PhotoAlbum album)
        {
            return "<head><title>" + album.Title + "</title></head>";
        }

    }
}
