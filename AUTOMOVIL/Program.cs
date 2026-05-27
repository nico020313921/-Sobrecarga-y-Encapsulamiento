using AUTOMOVIL;
using System;

namespace AUTOMÓVIL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Ingrese la marca: ");
            string marca = Console.ReadLine();

            Console.Write("¿Caja automática? (S/N): ");
            string respuesta = Console.ReadLine().ToUpper();

            bool cajaAutomatica = respuesta == "S";

            Automovil auto = new Automovil(marca, cajaAutomatica);

            int opcion;

            do
            {
                Console.Clear();

                Console.WriteLine("===== TABLERO =====");
                Console.WriteLine("IDENTIFICADOR: " + auto.Identificador);
                Console.WriteLine("Motor: " + (auto.MotorEncendido ? "ON" : "OFF"));
                Console.WriteLine("Velocidad: " + auto.VelocidadActual + " km/h");
                Console.WriteLine("Modo Crucero: " + (auto.ModoCrucero ? "ACTIVO" : "INACTIVO"));

                Console.WriteLine();
                Console.WriteLine("1 - Encender/Apagar");
                Console.WriteLine("2 - Acelerar +10");
                Console.WriteLine("3 - Acelerar con valor");
                Console.WriteLine("4 - Frenar de emergencia");
                Console.WriteLine("5 - Frenar con valor");
                Console.WriteLine("6 - Activar modo crucero");
                Console.WriteLine("0 - Salir");

                Console.Write("Opción: ");
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        auto.EncenderApagar();
                        break;

                    case 2:
                        auto.Acelerar();
                        break;

                    case 3:
                        Console.Write("Ingrese velocidad a aumentar: ");
                        int aumento = int.Parse(Console.ReadLine());

                        auto.Acelerar(aumento);
                        break;

                    case 4:
                        auto.Frenar();
                        break;

                    case 5:
                        Console.Write("Ingrese velocidad a disminuir: ");
                        int disminucion = int.Parse(Console.ReadLine());

                        auto.Frenar(disminucion);
                        break;

                    case 6:
                        auto.ActivarModoCrucero();
                        break;
                }

                Console.WriteLine();
                Console.WriteLine("Presione una tecla para continuar...");
                Console.ReadKey();

            } while (opcion != 0);
        }
    }
}
