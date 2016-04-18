using System.Drawing;
using System.IO;

namespace MVCMultiLayer.Business.Extensions
{
    public static class ImageExtensions
    {
        public static Stream ToStream(this Image image)
        {
            var stream = new System.IO.MemoryStream();
            ((System.Drawing.Bitmap)image).Save(stream, System.Drawing.Imaging.ImageFormat.Bmp);
            stream.Position = 0;

            return stream;
        }
    }
}
