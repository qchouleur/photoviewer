using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhotoViewer.Domain
{
    public interface IPhotoSource
    {
        Photo GetPhoto(string path);
    }
}
