using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Entidades;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Vehiculo v1 = new Vehiculo(ETamanio.Grande,EPago.Manual);
            Vehiculo v2 = new Vehiculo(ETamanio.Mediano,EPago.Telepase);
            Vehiculo v3 = new Vehiculo(ETamanio.Grande, EPago.Manual);
            Vehiculo v4 = new Vehiculo(ETamanio.Pequeño,EPago.Telepase);
            Vehiculo v5 = new Vehiculo(ETamanio.Mediano, EPago.Manual);
            Cabina cabina1 = new Cabina();
            Cabina cabina2 = new Cabina();
            Cabina cabina3 = new Cabina();
            Peaje peaje = new Peaje();
            peaje += cabina1;
            peaje += cabina2;
            peaje += cabina3;
            peaje += v1;
            peaje += v2;
            peaje += v3;
            peaje += v4;
            peaje += v5;

            while(true)
            {
                if( peaje.Vehiculos.Count != 0)
                {
                    Thread threadPeaje = new Thread(peaje.RepartirVehiculos);
                    Thread threadCabina1 = new Thread(cabina1.CobrarVehiculos);
                    Thread threadCabina2 = new Thread(cabina1.CobrarVehiculos);
                    Thread threadCabina3 = new Thread(cabina1.CobrarVehiculos);

                    threadPeaje.Start();

                    threadCabina1.Start();

                    threadCabina2.Start();

                    threadCabina3.Start();


                }
            }
        }
    }
}
