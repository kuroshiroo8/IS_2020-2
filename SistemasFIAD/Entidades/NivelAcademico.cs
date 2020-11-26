/*************************************************************************************
* Autor: PCSIS (Archivo generado automáticamente con GeneradorDeCodigo Ver.1.0.0)
* Proyecto: [Poner_Nombre_Del_Proyecto]
* Archivo: E_NivelAcademico.cs
* Fecha de creación: 11/17/2020
* Propósito: [Poner_La_Una_Descripción_Del_Proposito_Principal_Del_Archivo]
* D.R. PCSIS (Proyectos Computacionales y Servicios de Ingeniería de Software
****************************************************************************************/

using System;

namespace Entidades
{
    public class E_NivelAcademico
    {
        #region Atributos
        private string _Accion;
        private int _IdNivelAcademico;
        private string _ClaveNivelAcademico;
        private string _NombreNivelAcademico;
        #endregion

        #region Constructor
        public E_NivelAcademico()
        {
            _Accion = string.Empty;
            _IdNivelAcademico = 0;
            _ClaveNivelAcademico = string.Empty;
            _NombreNivelAcademico = string.Empty;
        }
        #endregion

        #region Encapsulamiento
        public string Accion { get => _Accion; set => _Accion = value; }
        public int IdNivelAcademico { get => _IdNivelAcademico; set => _IdNivelAcademico = value; }
        public string ClaveNivelAcademico { get => _ClaveNivelAcademico; set => _ClaveNivelAcademico = value; }
        public string NombreNivelAcademico { get => _NombreNivelAcademico; set => _NombreNivelAcademico = value; }
        #endregion
    }
}

