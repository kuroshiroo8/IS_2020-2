/*************************************************************************************
* Autor: PCSIS (Archivo generado automáticamente con GeneradorDeCodigo Ver.1.0.0)
* Proyecto: [Poner_Nombre_Del_Proyecto]
* Archivo: E_AreaConocimiento.cs
* Fecha de creación: 11/17/2020
* Propósito: [Poner_La_Una_Descripción_Del_Proposito_Principal_Del_Archivo]
* D.R. PCSIS (Proyectos Computacionales y Servicios de Ingeniería de Software
****************************************************************************************/

using System;

namespace Entidades
{
    public class E_AreaConocimiento
    {
        #region Atributos
        private string _Accion;
        private int _IdAreaConocimiento;
        private string _ClaveAreaConocimiento;
        private string _DescripcionAreaConocimiento;
        #endregion

        #region Constructor
        public E_AreaConocimiento()
        {
            _Accion = string.Empty;
            _IdAreaConocimiento = 0;
            _ClaveAreaConocimiento = string.Empty;
            _DescripcionAreaConocimiento = string.Empty;
        }
        #endregion

        #region Encapsulamiento
        public string Accion { get => _Accion; set => _Accion = value; }
        public int IdAreaConocimiento { get => _IdAreaConocimiento; set => _IdAreaConocimiento = value; }
        public string ClaveAreaConocimiento { get => _ClaveAreaConocimiento; set => _ClaveAreaConocimiento = value; }
        public string DescripcionAreaConocimiento { get => _DescripcionAreaConocimiento; set => _DescripcionAreaConocimiento = value; }
        #endregion
    }
}

