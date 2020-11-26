/*************************************************************************************
* Autor: PCSIS (Archivo generado automáticamente con GeneradorDeCodigo Ver.1.0.0)
* Proyecto: [Poner_Nombre_Del_Proyecto]
* Archivo: E_Carreras.cs
* Fecha de creación: 11/12/2020
* Propósito: [Poner_La_Una_Descripción_Del_Proposito_Principal_Del_Archivo]
* D.R. PCSIS (Proyectos Computacionales y Servicios de Ingeniería de Software
****************************************************************************************/

using System;

namespace Entidades
{
    public class E_Carreras
    {
        #region Atributos
        private string _Accion;
        private int _IdCarrera;
        //private int _IdCoordinador;
        private string _ClaveCarrera;
        private string _NombreCarrera;
        private string _AliasCarrera;
        private Boolean _EstadoCarrera;
        //private string _StatusCarrera;
        #endregion

        #region Constructor
        public E_Carreras()
        {
            _Accion = string.Empty;
            _IdCarrera = 0;
            //_IdCoordinador = 0;
            _ClaveCarrera = string.Empty;
            _NombreCarrera = string.Empty;
            _AliasCarrera = string.Empty;
            _EstadoCarrera = false;
            //_StatusCarrera = string.Empty;
        }
        #endregion

        #region Encapsulamiento
        public string Accion { get => _Accion; set => _Accion = value; }
        public int IdCarrera { get => _IdCarrera; set => _IdCarrera = value; }
        //public int IdCoordinador { get => _IdCoordinador; set => _IdCoordinador = value; }
        public string ClaveCarrera { get => _ClaveCarrera; set => _ClaveCarrera = value; }
        public string NombreCarrera { get => _NombreCarrera; set => _NombreCarrera = value; }
        public string AliasCarrera { get => _AliasCarrera; set => _AliasCarrera = value; }
        public Boolean EstadoCarrera { get => _EstadoCarrera; set => _EstadoCarrera = value; }
        //public string StatusCarrera { get => _StatusCarrera; set => _StatusCarrera = value; }
        #endregion
    }
}

