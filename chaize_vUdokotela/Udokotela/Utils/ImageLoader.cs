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
        public static string SearchImageWithExplorer()
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.DefaultExt = ".png";
            dlg.Filter = "Image Files (*.jpeg;*.png;*.jpg;*.gif)|*.jpeg;*.png;*.jpg;*.gif";
            bool? result = dlg.ShowDialog();
            if (result.HasValue && result.Value)
            {
                return dlg.FileName;
            }
            else
            {
                return null;
            }
        }

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
