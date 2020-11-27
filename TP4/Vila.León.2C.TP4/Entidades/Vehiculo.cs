using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public enum ETamanio { Pequeño = 60,Mediano = 120, Grande = 240}
    public enum EPago { Telepase, Manual}
    public class Vehiculo
    {
        private ETamanio tamanio;
        private EPago metodoDePago;

        public Vehiculo(ETamanio tamanio, EPago metodoDePago)
        {
            this.metodoDePago = metodoDePago;
            this.tamanio = tamanio;
        }

        public ETamanio Tamanio
        {
            get { return tamanio; }
        }
        public EPago MetodoDePago
        {
            get { return metodoDePago; }
        }

        public override string ToString()
        {
            return $"Vehiculo: {this.Tamanio}\nPago {this.MetodoDePago}";
        }

    }
}
