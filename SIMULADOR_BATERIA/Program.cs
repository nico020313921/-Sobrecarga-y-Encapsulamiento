using System;

namespace SIMULADOR_BATERIA
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Bateria bateria = new Bateria();

            int opcion;

            do
            {
                Console.Clear();

                Console.WriteLine("===== SMARTPHONE =====");

                Console.WriteLine(bateria.EstadoTexto);

                Console.WriteLine("Salud de batería: " +
                    bateria.SaludBateria + "%");

                Console.WriteLine("Modo ahorro: " +
                    (bateria.ModoAhorroEnergia ?
                    "ACTIVADO" : "DESACTIVADO"));

                Console.WriteLine();

                Console.WriteLine("1 - Conectar/Desconectar cargador");
                Console.WriteLine("2 - Consumir energía en reposo");
                Console.WriteLine("3 - Abrir aplicación pesada");
                Console.WriteLine("4 - Simular carga");
                Console.WriteLine("0 - Salir");

                Console.Write("Opción: ");
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:

                        bateria.AlternarCargador();
                        break;

                    case 2:

                        bateria.ConsumirEnergia();
                        break;

                    case 3:

                        Console.Write(
                            "Ingrese consumo de batería: ");

                        int consumo =
                            int.Parse(Console.ReadLine());

                        bateria.ConsumirEnergia(consumo);
                        break;

                    case 4:

                        bateria.CicloDeCarga();
                        break;
                }

                Console.WriteLine();
                Console.WriteLine(
                    "Presione una tecla para continuar...");

                Console.ReadKey();

            } while (opcion != 0);
        }
    }
}
