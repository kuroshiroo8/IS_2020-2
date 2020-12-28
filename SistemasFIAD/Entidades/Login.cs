/*************************************************************************************
* Autor: PCSIS (Archivo generado automáticamente con GeneradorDeCodigo Ver.1.0.0)
* Proyecto: [Poner_Nombre_Del_Proyecto]
* Archivo: E_TipoMateria.cs
* Fecha de creación: 11/17/2020
* Propósito: [Poner_La_Una_Descripción_Del_Proposito_Principal_Del_Archivo]
* D.R. PCSIS (Proyectos Computacionales y Servicios de Ingeniería de Software
****************************************************************************************/

using System;

namespace Entidades
{
    public class E_Usuarios
    {
        #region Atributos
        private string _Accion;
        private int _IdUsuario;
        private string _NombreUsuario;
        private string _CorreoUsuario;
        private string _PassUsuario;
        private string _TipoUsuario;
        #endregion

        #region Constructor
        public E_Usuarios()
        {
            _Accion = string.Empty;
            _IdUsuario = 0;
            _NombreUsuario = string.Empty;
            _CorreoUsuario = string.Empty;
            _PassUsuario = string.Empty;
            _TipoUsuario = string.Empty;
        }
        #endregion

        #region Encapsulamiento
        public string Accion { get => _Accion; set => _Accion = value; }
        public int IdUsuario { get => _IdUsuario; set => _IdUsuario = value; }
        public string NombreUsuario { get => _NombreUsuario; set => _NombreUsuario = value; }
        public string CorreoUsuario { get => _CorreoUsuario; set => _CorreoUsuario = value; }
        public string PassUsuario { get => _PassUsuario; set => _PassUsuario = value; }
        public string TipoUsuario { get => _TipoUsuario; set => _TipoUsuario = value; }
        #endregion
    }
}

