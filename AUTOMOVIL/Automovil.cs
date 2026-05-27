using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUTOMOVIL
{
    internal class Automovil
    {
        private string _marca;
        private bool _motorEncendido;
        private int _velocidadActual;
        private bool _cajaAutomatica;
        private bool _modoCrucero;
        public Automovil(string marca, bool cajaAutomatica)
        {
            _marca = marca;
            _cajaAutomatica = cajaAutomatica;
            _motorEncendido = false;
            _velocidadActual = 0;
            _modoCrucero = false;
        }

        public string Marca
        {
            get { return _marca; }
            set { _marca = value; }
        }

        public bool MotorEncendido
        {
            get { return _motorEncendido; }
            set { _motorEncendido = value; }
        }

        public int VelocidadActual
        {
            get { return _velocidadActual; }
            set { _velocidadActual = value; }
        }

        public bool CajaAutomatica
        {
            get { return _cajaAutomatica; }
            set { _cajaAutomatica = value; }
        }

        public bool ModoCrucero
        {
            get { return _modoCrucero; }
            set { _modoCrucero = value; }
        }
        // PROPIEDAD SOLO LECTURA
        public string Identificador
        {
            get
            {
                string tipoCaja;

                if (_cajaAutomatica)
                {
                    tipoCaja = "AUTO";
                }
                else
                {
                    tipoCaja = "MAN";
                }

                return _marca.Substring(0, 3).ToUpper() + "-" + tipoCaja + "-2026";
            }
        }

        // MÉTODO ENCENDER/APAGAR
        public void EncenderApagar()
        {
            _motorEncendido = !_motorEncendido;

            if (_motorEncendido == false)
            {
                _velocidadActual = 0;
                _modoCrucero = false;
            }
        }

        // ACELERAR 
        public void Acelerar()
        {
            Acelerar(10);
        }

        // ACELERAR
        public void Acelerar(int aumento)
        {
            if (_motorEncendido == false)
            {
                Console.WriteLine("El motor está apagado.");
                return;
            }

            _velocidadActual += aumento;

            if (_cajaAutomatica)
            {
                if (_velocidadActual > 220)
                {
                    _velocidadActual = 220;
                }
            }
            else
            {
                if (_velocidadActual > 180)
                {
                    _velocidadActual = 180;
                }
            }
        }

        // FRENAR 
        public void Frenar()
        {
            if (_motorEncendido == false)
            {
                Console.WriteLine("El motor está apagado.");
                return;
            }

            _velocidadActual = 0;
            _modoCrucero = false;
        }

        // FRENAR 
        public void Frenar(int disminucion)
        {
            if (_motorEncendido == false)
            {
                Console.WriteLine("El motor está apagado.");
                return;
            }

            _velocidadActual -= disminucion;

            if (_velocidadActual < 0)
            {
                _velocidadActual = 0;
            }

            _modoCrucero = false;
        }

        // ACTIVAR/DESACTIVAR MODO CRUCERO
        public void ActivarModoCrucero()
        {
            if (_velocidadActual > 60)
            {
                _modoCrucero = true;
            }
            else
            {
                Console.WriteLine("Debe superar los 60 km/h.");
            }
        }
    }
}

    