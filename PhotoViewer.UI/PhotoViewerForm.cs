using PhotoViewer.UI.Properties;
using System.Drawing;
using System.Windows.Forms;

namespace PhotoViewer.UI
{
    public class PhotoViewerForm : Form
    {
        public static readonly Size PhotoThumbnailSize = new Size(75, 75);


        public PhotoViewerForm()
        {
            this.Icon = Resources.Icon;
        }
    }
}
