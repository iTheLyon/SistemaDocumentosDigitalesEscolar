
using SDD2.models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SDD2
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);

            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            // Configurar el directorio de datos
            AppDomain.CurrentDomain.SetData("DataDirectory", baseDirectory);
            var context = new DataBase();
            bool isCreated = context.Database.CreateIfNotExists();
            if (isCreated) context.initializeModel();
            context.Dispose();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmLogin());
        }


        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            LogError(e.ExceptionObject as Exception);
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            LogError(e.Exception);
        }

        static void LogError(Exception ex)
        {
            if (ex != null)
            {
                // Loguear el error en un archivo de texto
                string logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "error.log");
                File.AppendAllText(logFilePath, $"{DateTime.Now}: {ex.ToString()}{Environment.NewLine}");
                MessageBox.Show($"Ocurrió un error: {ex.Message}. Consulte el archivo error.log para más detalles.");
            }
        }
    }
}
