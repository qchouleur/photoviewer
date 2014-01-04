using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhotoViewer.UI
{
    public static class ImageButtonStyleExtension
    {
        public static void ToImageButton(this Button button, Image image)
        {
            button.Image = image;
            button.Size = image.Size;
            button.MinimumSize = image.Size;

            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.Text = string.Empty;

        }

    }
}
