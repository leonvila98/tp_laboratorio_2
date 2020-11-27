using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Peaje
    {
        //private Cabina cabina1;
        //private Cabina cabina2;
        //private Cabina cabina3;
        //private Cabina cabina4;
        private Queue<Vehiculo> vehiculos;
        private List<Cabina> cabinas;

        public Peaje()
        {
            vehiculos = new Queue<Vehiculo>();
            cabinas = new List<Cabina>();
            //cabina1 = new Cabina();
            //cabina2 = new Cabina();
            //cabina3 = new Cabina();
            //cabina4 = new Cabina();
        }
        public Peaje(Queue<Vehiculo> vehiculos):this()
        {
            Vehiculos = vehiculos;
        }

        public double RecaudacionTotal
        {
            get 
            { 
                return CalcularRecaudacion(); 
            }
        }


        public Queue<Vehiculo> Vehiculos
        {
            get { return vehiculos; }
            set 
            { 
                if(value != null)
                    vehiculos = value; 
            }
        }

        public void RepartirVehiculos()
        {           
            foreach (Vehiculo v in Vehiculos)
            {
                cabinas.Sort();
                cabinas[0].ColaDeVehiculos.Enqueue(v);
            }
        }
        private double CalcularRecaudacion()
        {
            double acumulador = 0;
            foreach(Cabina c in cabinas)
            {
                acumulador += c.Recaudacion;
            }
            return acumulador;
        }

        public static Peaje operator +(Peaje p ,Cabina c)
        {
            if(c!=null && !p.cabinas.Contains(c))
            {
                p.cabinas.Add(c);
            }
            return p;
        }
        public static Peaje operator +(Peaje p, Vehiculo v)
        {
            if (v!=null && !p.Vehiculos.Contains(v))
            {
                p.Vehiculos.Enqueue(v);
            }
            return p;
        }
        public static Peaje operator -(Peaje p ,Vehiculo v)
        {
            if (v != null && p.Vehiculos.Contains(v))
            {
                p.Vehiculos.Dequeue();
            }
            return p;
        }
    }
}
