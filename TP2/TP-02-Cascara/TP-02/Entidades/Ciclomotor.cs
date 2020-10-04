using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Ciclomotor : Vehiculo
    {
        public Ciclomotor(EMarca marca, string chasis, ConsoleColor color)
            :base(chasis, marca, color)
        { }

        /// <summary>
        /// Las motos son chicas
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Chico;
            }
        }

        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CICLOMOTOR");
            sb.AppendLine(this);
            sb.AppendFormat("TAMAÑO : {0}\n", this.Tamanio);
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
