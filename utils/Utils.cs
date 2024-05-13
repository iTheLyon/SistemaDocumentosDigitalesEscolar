using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SDD2.utils
{
    public static class Utils
    {
        public static void SaveFileToFolder(string filePath, string folderName)
        {
            try
            {
                // Ruta de la carpeta donde se guardará el archivo
                string folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, folderName);

                // Si la carpeta no existe, la creamos
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                // Obtenemos el nombre del archivo de la ruta
                string fileName = Path.GetFileName(filePath);

                // Ruta completa de destino
                string destinationFilePath = Path.Combine(folderPath, fileName);

                // Copiamos el archivo a la carpeta de destino
                File.Copy(filePath, destinationFilePath, true);

                Console.WriteLine("Archivo guardado exitosamente en: " + destinationFilePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al guardar el archivo: " + ex.Message);
            }
        }

        public static string getPath(String foldername, String filename)
        {
            string r = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, foldername,filename);
            return r;
        }

    }
}
