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
    public class E_TipoMateria
    {
        #region Atributos
        private string _Accion;
        private int _IdTipoMateria;
        private string _NombreTipoMateria;
        private string _Etapa;
        private int _Semestre;
        #endregion

        #region Constructor
        public E_TipoMateria()
        {
            _Accion = string.Empty;
            _IdTipoMateria = 0;
            _NombreTipoMateria = string.Empty;
            _Etapa = string.Empty;
            _Semestre = 0;
        }
        #endregion

        #region Encapsulamiento
        public string Accion { get => _Accion; set => _Accion = value; }
        public int IdTipoMateria { get => _IdTipoMateria; set => _IdTipoMateria = value; }
        public string NombreTipoMateria { get => _NombreTipoMateria; set => _NombreTipoMateria = value; }
        public string Etapa { get => _Etapa; set => _Etapa = value; }
        public int Semestre { get => _Semestre; set => _Semestre = value; }
        #endregion
    }
}

