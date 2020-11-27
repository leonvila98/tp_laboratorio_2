using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Excepciones;

namespace Archivos
{
    public class Xml<T> : IArchivo<T> 
    {
        /// <summary>
        /// Serializa y guarda en formato XML un objeto
        /// </summary>
        /// <param name="archivo">Nombre del archivo que se guardara</param>
        /// <param name="datos">Objeto a guardar</param>
        /// <returns>true si guardo-false si no guardo</returns>
        public bool Guardar(string archivo, T datos)
        {
            if(datos != null)
            {
                using (XmlTextWriter writer = new XmlTextWriter($"{this.GetDirectoryPath}{archivo}", Encoding.UTF8))
                {
                    writer.Formatting = Formatting.Indented;
                    XmlSerializer serializer = new XmlSerializer(typeof(T));
                    serializer.Serialize(writer, datos);
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Deserializa y convierte en objeto un aarchivo XML
        /// </summary>
        /// <param name="archivo">Nombre del archivo a leer</param>
        /// <param name="datos">Objeto deserializado</param>
        /// <returns></returns>
        public bool Leer(string archivo,out T datos)
        {
            datos = default(T);
            if (File.Exists(archivo))
            {
                using (XmlTextReader reader = new XmlTextReader(archivo))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(T));
                    datos = (T)serializer.Deserialize(reader);
                    return true;
                }
            }
            return false;
        }
        
        /// <summary>
        /// Ruta del escritorio del pc
        /// </summary>
        public string GetDirectoryPath
        {
            get
            {
                return Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\";
            }
        }
    }
}
