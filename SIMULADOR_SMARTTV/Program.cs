using System;

namespace SIMULADOR_SMARTTV
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Ingrese la marca: ");
            string marca = Console.ReadLine();

            Console.Write("Ingrese las pulgadas: ");
            int pulgadas = int.Parse(Console.ReadLine());

            Console.Write("¿Tiene plan Premium? (S/N): ");
            string respuesta = Console.ReadLine().ToUpper();

            bool esPremium = respuesta == "S";

            SmartTV tv = new SmartTV(marca, pulgadas, esPremium);

            int opcion;

            do
            {
                Console.Clear();

                Console.WriteLine("===== SMART TV =====");
                Console.WriteLine("CODIGO: " + tv.CodigoConfig);
                Console.WriteLine("Estado: " + (tv.Encendido ? "ENCENDIDA" : "APAGADA"));
                Console.WriteLine("Canal Actual: " + tv.CanalActual);

                if (tv.Volumen == 0)
                {
                    Console.WriteLine("Volumen: MUTE");
                }
                else
                {
                    Console.WriteLine("Volumen: " + tv.Volumen);
                }

                Console.WriteLine();
                Console.WriteLine("1 - Power");
                Console.WriteLine("2 - Canal +1");
                Console.WriteLine("3 - Cambiar canal");
                Console.WriteLine("4 - Volumen +");
                Console.WriteLine("5 - Volumen -");
                Console.WriteLine("0 - Salir");

                Console.Write("Opción: ");
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        tv.Power();
                        break;

                    case 2:
                        tv.CambiarCanal();
                        break;

                    case 3:
                        Console.Write("Ingrese canal: ");
                        int canal = int.Parse(Console.ReadLine());

                        tv.CambiarCanal(canal);
                        break;

                    case 4:
                        tv.RegularVolumen(true);
                        break;

                    case 5:
                        tv.RegularVolumen(false);
                        break;
                }

                Console.WriteLine();
                Console.WriteLine("Presione una tecla para continuar...");
                Console.ReadKey();

            } while (opcion != 0);
        }
    }
}
