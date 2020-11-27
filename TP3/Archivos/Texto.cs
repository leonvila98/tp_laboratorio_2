using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        /// <summary>
        /// Guarda en un archivo de texto especificado un string
        /// </summary>
        /// <param name="archivo">Ruta donde se guardara el string</param>
        /// <param name="datos">string a guardar</param>
        /// <returns>true - Si guardo el string false - Si no guardo el string</returns>
        public bool Guardar(string archivo, string datos)
        {
            StreamWriter streamWriter = null;
            if (!string.IsNullOrEmpty(archivo))
            {
                try
                {
                    streamWriter = new StreamWriter(archivo, true);
                    streamWriter.WriteLine(datos);
                }
                finally
                {
                    if (streamWriter != null)
                        streamWriter.Close();
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// Lee un archivo de texto y lo convierte a string
        /// </summary>
        /// <param name="archivo">Ruta del archivo a leer</param>
        /// <param name="datos">string del archivo ya convertido</param>
        /// <returns>true si lo leyo-true si no lo pudo leer</returns>
        public bool Leer(string archivo, out string datos)
        {
            StreamReader streamReader = null;
            if (File.Exists(archivo))
            {
                try
                {
                    streamReader = new StreamReader(archivo);

                    string text = string.Empty;
                    string newLine = streamReader.ReadLine();

                    while (newLine != null)
                    {
                        text += newLine + "\n";
                        newLine = streamReader.ReadLine();
                    }
                    datos = text;
                }
                finally
                {
                    if (streamReader != null)
                        streamReader.Close();
                }
                return true;
            }
            else
                datos = "";
            return false;        
        }
        
    }
}
