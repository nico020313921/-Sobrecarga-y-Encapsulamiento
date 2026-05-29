using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMULADOR_BATERIA
{
    internal class Bateria
    {
        // ATRIBUTOS PRIVADOS
        private int _porcentajeCarga;
        private int _saludBateria;
        private bool _conectadoCargador;
        private bool _modoAhorroEnergia;
        private int _cargaAcumulada;

        public Bateria()
        {
            _porcentajeCarga = 100;
            _saludBateria = 100;
            _conectadoCargador = false;
            _modoAhorroEnergia = false;
            _cargaAcumulada = 0;
        }

        // PROPIEDADES
        public int PorcentajeCarga
        {
            get { return _porcentajeCarga; }
        }

        public int SaludBateria
        {
            get { return _saludBateria; }
        }

        public bool ConectadoCargador
        {
            get { return _conectadoCargador; }
        }

        public bool ModoAhorroEnergia
        {
            get { return _modoAhorroEnergia; }
        }
        public string EstadoTexto
        {
            get
            {
                string texto =
                    "BATERIA: " + _porcentajeCarga + "%";

                if (_conectadoCargador)
                {
                    texto = "CARGANDO - " + texto;
                }

                return texto;
            }
        }

        // CONECTAR / DESCONECTAR CARGADOR
        public void AlternarCargador()
        {
            _conectadoCargador = !_conectadoCargador;
        }

        // CONSUMIR ENERGÍA
        public void ConsumirEnergia()
        {
            ConsumirEnergia(1);
        }

        // CONSUMIR ENERGÍA 
        public void ConsumirEnergia(int consumo)
        {
            if (_modoAhorroEnergia)
            {
                consumo = consumo / 2;

                if (consumo == 0)
                {
                    consumo = 1;
                }
            }

            _porcentajeCarga -= consumo;

            if (_porcentajeCarga < 0)
            {
                _porcentajeCarga = 0;
            }

            // ACTIVAR MODO AHORRO
            if (_porcentajeCarga < 20)
            {
                _modoAhorroEnergia = true;
            }

            // DESACTIVAR MODO AHORRO
            if (_porcentajeCarga > 50)
            {
                _modoAhorroEnergia = false;
            }
        }

        // CICLO DE CARGA
        public void CicloDeCarga()
        {
            if (_conectadoCargador == false)
            {
                Console.WriteLine("El cargador no está conectado.");
                return;
            }

            // LÍMITE SEGÚN SALUD
            if (_porcentajeCarga < _saludBateria)
            {
                _porcentajeCarga++;

                _cargaAcumulada++;

                // DESACTIVAR MODO AHORRO
                if (_porcentajeCarga > 50)
                {
                    _modoAhorroEnergia = false;
                }
            }

            // DESGASTE DE HARDWARE
            if (_cargaAcumulada >= 100)
            {
                _saludBateria--;

                if (_saludBateria < 0)
                {
                    _saludBateria = 0;
                }

                _cargaAcumulada = 0;
            }
        }

    }
}
