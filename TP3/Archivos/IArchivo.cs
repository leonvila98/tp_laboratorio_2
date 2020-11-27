using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    public interface IArchivo <T>
    {
        bool Guardar(string archivo, T datos);
        bool Leer(string archivo, out T datos);
    }
}
