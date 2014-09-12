using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text.RegularExpressions;
namespace CapaLogicaNegocio
{

   
           
     public class Validaciones
    {
        //clase  de Verification de Ingreso de valores numericos
        /**************************************************************/
        public void numerosReales(KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 58) && (e.KeyChar != 44))
                if (e.KeyChar != 13 && e.KeyChar != 8 && e.KeyChar != 46)
                {
                    e.Handled = true;
                    return;
                }

        }


        //clase  de Verification de Ingreso de valores numericos
        /**************************************************************/
        public void numeros(KeyPressEventArgs e)
        {
            if (e.KeyChar < 48 || e.KeyChar > 58)
                if (e.KeyChar != 13 && e.KeyChar != 8)
                {
                    e.Handled = true;
                    return;
                }

        }
        //clase  de Verification de Ingreso de letras
        /**************************************************************/
        public void Letras(KeyPressEventArgs e)
        {
            if (e.KeyChar < 65 || e.KeyChar > 90)
                if (e.KeyChar != 13 && e.KeyChar != 8 && e.KeyChar != 32)
                    if (!char.IsLetter(e.KeyChar))
                    {
                        e.Handled = true;
                        return;
                    }
        }


        public void Enter(KeyPressEventArgs e, Control control)
        {
            if (e.KeyChar == 13)
                control.Focus();
        }
        public bool esCedulaValida(String cedula)
        {
            bool mistmatch = false;
            for (int i = 0; i < cedula.Length; i++)
            {
                if (i > 0 && cedula[i] != cedula[i - 1])
                    mistmatch = true;
            }
            if (mistmatch == false)
                return mistmatch;

            //verifica que tenga 10 dígitos 
            if (!(cedula.Length == 10))
            {
                return false;
            }
            //verifica que los dos primeros dígitos correspondan a un valor entre 1 y NUMERO_DE_PROVINCIAS
            int prov = int.Parse(cedula.Substring(0, 2));
            if (!((prov > 0) && (prov <= 24)))
            {
                return false;
            }
            //verifica que el último dígito de la cédula sea válido
            int[] d = new int[10];
            //Asignamos el string a un array
            for (int i = 0; i < d.Length; i++)
            {
                d[i] = int.Parse(cedula.Substring(i, 1) + "");
            }
            int imp = 0;
            int par = 0;
            //sumamos los duplos de posición impar
            for (int i = 0; i < d.Length; i += 2)
            {
                d[i] = ((d[i] * 2) > 9) ? ((d[i] * 2) - 9) : (d[i] * 2);
                imp += d[i];
            }
            //sumamos los digitos de posición par
            for (int i = 1; i < (d.Length - 1); i += 2)
            {
                par += d[i];
            }
            //Sumamos los dos resultados
            int suma = imp + par;
            //Restamos de la decena superior
            int d10 = int.Parse(Convert.ToString(suma + 10).Substring(0, 1) + "0") - suma;
            //Si es diez el décimo dígito es cero        
            d10 = (d10 == 10) ? 0 : d10;
            //si el décimo dígito calculado es igual al digitado la cédula es correcta
            return d10 == d[9];
        }
        public Byte[] LeerImagen(string sPath)
        {

            Byte[] data = null;
            FileInfo fInfo = new FileInfo(sPath);
            long numBytes = fInfo.Length;
            FileStream fStream = new FileStream(sPath, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fStream);
            data = br.ReadBytes(Convert.ToInt32(numBytes));
            return data;
        }
        public  byte[] ImageToByte(Image img)
        {
            //ImageConverter converter = new ImageConverter();

            //return (byte[])converter.ConvertTo(img, typeof(byte[]));
            if (img != null)
            {
                MemoryStream ms = new MemoryStream();
                img.Save(ms, ImageFormat.Jpeg);
                return ms.ToArray();

            }
            else
            {
                return null;
            }
        }

        public bool email_bien_escrito(String email)
        {
            String expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    


    
    }


    
}

