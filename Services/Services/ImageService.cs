using System.Buffers.Text;
using System.Drawing.Imaging;
using System.Drawing;

namespace DeepLome.Services.Services
{
    public static class ImageService
    {
        private static string _filePath = @"D:\Programmin\C#\DeepLome.NET6\TempDeepLomeBackendRepo\Services\UserImages";

        public static void SaveImage(string photoString) 
        {
#warning Сделать тут так, чтобы не было проблем с линуксом.
            var photoInByteArray = FromBase64StringToBytes(photoString);
            using (Image image = Image.FromStream(new MemoryStream(photoInByteArray)))
            {
                image.Save("output.jpg", ImageFormat.Jpeg);  // Or Png
            }
        }

        public static byte[] FromBase64StringToBytes(string photoString)
        {
            return Convert.FromBase64String(photoString);
        }

    }
}
