using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Entidades
{
    public class Cabina : IComparable
    {
        private double recaudacion;
        private Queue<Vehiculo> colaDeVehiculos;

        public Cabina()
        {
            colaDeVehiculos = new Queue<Vehiculo>();
        }

        public double Recaudacion
        {
            get { return recaudacion; }
        }

        public Queue<Vehiculo> ColaDeVehiculos
        {
            get { return colaDeVehiculos; }
            set { colaDeVehiculos = value; }
        }

        public void CobrarVehiculos()
        {
            
            foreach (Vehiculo v in colaDeVehiculos)
            {
                Console.WriteLine($"Cobrando {v}");
                recaudacion += this.Precio(v);
                colaDeVehiculos.Dequeue();
                Thread.Sleep(2000);
            }
        }

        public int CompareTo(object obj)
        {
            Cabina cabina = (Cabina)obj;

            if (this.colaDeVehiculos.Count > cabina.colaDeVehiculos.Count)
                return 1;
            if (this.colaDeVehiculos.Count < cabina.colaDeVehiculos.Count)
                return -1;

            return 0;
        }

        private double Precio(Vehiculo v)
        {
            if (v.MetodoDePago == EPago.Telepase)
                return (double)v.Tamanio / 2;
            else
                return (double)v.Tamanio;
        }
    }
}
