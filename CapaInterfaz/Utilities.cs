using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaInterfaz
{
    class Utilities
    {
        public static byte[] convertPicBoxImageToByte(System.Windows.Forms.PictureBox pbImage)
        {
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            pbImage.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }

        public static Image convertByteToImage(byte[] b) 
        {
            try
            {
                byte[] imageData = b.ToArray();
                Image newImage;
                using (MemoryStream ms = new MemoryStream(imageData, 0, imageData.Length))
                {
                    ms.Write(imageData, 0, imageData.Length);
                    return newImage = Image.FromStream(ms, true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.TargetSite + "\n" + ex.ToString());
                return null;
            }
        }

    }
}
