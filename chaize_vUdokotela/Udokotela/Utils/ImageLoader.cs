using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Udokotela.Utils
{
    public class ImageLoader
    {
        public static byte[] Load(string filename)
        {
            if (!File.Exists(filename))
            {
                return null;
            }
            return LoadFileData(filename);
        }

        private static byte[] LoadFileData(string filename)
        {
            try
            {
                return File.ReadAllBytes(filename);
            }
            catch (Exception)
            {
                Console.WriteLine($"Error reading all bytes from {filename}");
                return null;
            }
        }
    }
}
