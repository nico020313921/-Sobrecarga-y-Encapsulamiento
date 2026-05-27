using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMULADOR_MICROONDAS
{
    internal class Microondas
    {
        // ATRIBUTOS PRIVADOS
        private int _potencia;
        private int _tiempoSegundos;
        private bool _puertaAbierta;
        private bool _enFuncionamiento;

        // CONSTRUCTOR
        public Microondas(int potencia)
        {
            _potencia = potencia;
            _tiempoSegundos = 0;
            _puertaAbierta = false;
            _enFuncionamiento = false;
        }

        // PROPIEDADES
        public int Potencia
        {
            get { return _potencia; }
            set
            {
                if (value >= 1 && value <= 10)
                {
                    _potencia = value;
                }
            }
        }

        public int TiempoSegundos
        {
            get { return _tiempoSegundos; }
        }

        public bool PuertaAbierta
        {
            get { return _puertaAbierta; }
        }

        public bool EnFuncionamiento
        {
            get { return _enFuncionamiento; }
        }

        // PROPIEDAD SOLO LECTURA
        public string PantallaTiempo
        {
            get
            {
                int minutos = _tiempoSegundos / 60;
                int segundos = _tiempoSegundos % 60;

                return minutos.ToString("00") + ":" + segundos.ToString("00");
            }
        }

        // AGREGAR TIEMPO 
        public void AgregarTiempo()
        {
            AgregarTiempo(30);
        }

        // AGREGAR TIEMPO 
        public void AgregarTiempo(int segundos)
        {
            _tiempoSegundos += segundos;

            if (_tiempoSegundos > 3600)
            {
                _tiempoSegundos = 3600;
            }
        }

        // INICIAR
        public void Iniciar()
        {
            if (_puertaAbierta)
            {
                Console.WriteLine("No se puede iniciar con la puerta abierta.");
                return;
            }

            if (_tiempoSegundos == 0)
            {
                Console.WriteLine("Debe agregar tiempo.");
                return;
            }

            _enFuncionamiento = true;
        }

        // DETENER
        public void Detener()
        {
            if (_enFuncionamiento)
            {
                _enFuncionamiento = false;
            }
            else
            {
                _tiempoSegundos = 0;
            }
        }

        // ABRIR / CERRAR PUERTA
        public void AbrirCerrarPuerta()
        {
            _puertaAbierta = !_puertaAbierta;

            // SEGURIDAD
            if (_puertaAbierta && _enFuncionamiento)
            {
                _enFuncionamiento = false;
            }
        }
    }
}


