/*************************************************************************************
* Autor: PCSIS (Archivo generado automáticamente con GeneradorDeCodigo Ver.1.0.0)
* Proyecto: [Poner_Nombre_Del_Proyecto]
* Archivo: E_Etapas.cs
* Fecha de creación: 11/17/2020
* Propósito: [Poner_La_Una_Descripción_Del_Proposito_Principal_Del_Archivo]
* D.R. PCSIS (Proyectos Computacionales y Servicios de Ingeniería de Software
****************************************************************************************/

using System;

namespace Entidades
{
    public class E_Etapas
    {
        #region Atributos
        private string _Accion;
        private int _IdEtapa;
        private string _ClaveEtapa;
        private string _NombreEtapa;
        #endregion

        #region Constructor
        public E_Etapas()
        {
            _Accion = string.Empty;
            _IdEtapa = 0;
            _ClaveEtapa = string.Empty;
            _NombreEtapa = string.Empty;
        }
        #endregion

        #region Encapsulamiento
        public string Accion { get => _Accion; set => _Accion = value; }
        public int IdEtapa { get => _IdEtapa; set => _IdEtapa = value; }
        public string ClaveEtapa { get => _ClaveEtapa; set => _ClaveEtapa = value; }
        public string NombreEtapa { get => _NombreEtapa; set => _NombreEtapa = value; }
        #endregion
    }
}

