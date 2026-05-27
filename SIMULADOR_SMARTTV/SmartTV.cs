using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMULADOR_SMARTTV
{
    internal class SmartTV
    {
        // ATRIBUTOS PRIVADOS
        private string _marca;
        private int _pulgadas;
        private bool _encendido;
        private int _canalActual;
        private int _volumen;
        private bool _esPremium;

        // CONSTRUCTOR
        public SmartTV(string marca, int pulgadas, bool esPremium)
        {
            _marca = marca;
            _pulgadas = pulgadas;
            _esPremium = esPremium;

            _encendido = false;
            _canalActual = 1;
            _volumen = 20;
        }

        // PROPIEDADES
        public string Marca
        {
            get { return _marca; }
            set { _marca = value; }
        }

        public int Pulgadas
        {
            get { return _pulgadas; }
            set { _pulgadas = value; }
        }

        public bool Encendido
        {
            get { return _encendido; }
        }

        public int CanalActual
        {
            get { return _canalActual; }
        }

        public int Volumen
        {
            get { return _volumen; }
        }

        public bool EsPremium
        {
            get { return _esPremium; }
        }

        // PROPIEDAD SOLO LECTURA
        public string CodigoConfig
        {
            get
            {
                string plan;

                if (_esPremium)
                {
                    plan = "PREM";
                }
                else
                {
                    plan = "STD";
                }

                return _marca.ToUpper() + "-" + _pulgadas + "-" + plan;
            }
        }

        // POWER
        public void Power()
        {
            _encendido = !_encendido;
        }

        // CAMBIAR CANAL 
        public void CambiarCanal()
        {
            if (_encendido == false)
            {
                Console.WriteLine("La TV está apagada.");
                return;
            }

            _canalActual++;

            int maximoCanal;

            if (_esPremium)
            {
                maximoCanal = 500;
            }
            else
            {
                maximoCanal = 100;
            }

            if (_canalActual > maximoCanal)
            {
                _canalActual = 1;
            }
        }

        // CAMBIAR CANAL
        public void CambiarCanal(int canal)
        {
            if (_encendido == false)
            {
                Console.WriteLine("La TV está apagada.");
                return;
            }

            int maximoCanal;

            if (_esPremium)
            {
                maximoCanal = 500;
            }
            else
            {
                maximoCanal = 100;
            }

            if (canal >= 1 && canal <= maximoCanal)
            {
                _canalActual = canal;
            }
            else
            {
                Console.WriteLine("Canal fuera de rango.");
            }
        }

        // REGULAR VOLUMEN
        public void RegularVolumen(bool subir)
        {
            if (_encendido == false)
            {
                Console.WriteLine("La TV está apagada.");
                return;
            }

            if (subir)
            {
                _volumen += 2;

                if (_volumen > 100)
                {
                    _volumen = 100;
                }
            }
            else
            {
                _volumen -= 2;

                if (_volumen < 0)
                {
                    _volumen = 0;
                }
            }
        }
    }
}

