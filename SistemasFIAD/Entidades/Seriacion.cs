/*************************************************************************************
* Autor: PCSIS (Archivo generado automáticamente con GeneradorDeCodigo Ver.1.0.0)
* Proyecto: [Poner_Nombre_Del_Proyecto]
* Archivo: E_Seriacion.cs
* Fecha de creación: 11/17/2020
* Propósito: [Poner_La_Una_Descripción_Del_Proposito_Principal_Del_Archivo]
* D.R. PCSIS (Proyectos Computacionales y Servicios de Ingeniería de Software
****************************************************************************************/

using System;

namespace Entidades
{
    public class E_Seriacion
    {
        #region Atributos
        private string _Accion;
        private int _IdSeriacion;
        private int _IdMateria;
        private int _IdMateriaSeriada;
        #endregion

        #region Constructor
        public E_Seriacion()
        {
            _Accion = string.Empty;
            _IdSeriacion = 0;
            _IdMateria = 0;
            _IdMateriaSeriada = 0;
        }
        #endregion

        #region Encapsulamiento
        public string Accion { get => _Accion; set => _Accion = value; }
        public int IdSeriacion { get => _IdSeriacion; set => _IdSeriacion = value; }
        public int IdMateria { get => _IdMateria; set => _IdMateria = value; }
        public int IdMateriaSeriada { get => _IdMateriaSeriada; set => _IdMateriaSeriada = value; }
        #endregion
    }
}

