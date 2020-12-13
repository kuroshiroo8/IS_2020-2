/*************************************************************************************
* Autor: PCSIS (Archivo generado automáticamente con GeneradorDeCodigo Ver.1.0.0)
* Proyecto: [Poner_Nombre_Del_Proyecto]
* Archivo: E_PlanEstudioMateria.cs
* Fecha de creación: 11/17/2020
* Propósito: [Poner_La_Una_Descripción_Del_Proposito_Principal_Del_Archivo]
* D.R. PCSIS (Proyectos Computacionales y Servicios de Ingeniería de Software
****************************************************************************************/

using System;

namespace Entidades
{
    public class E_PlanEstudioMateria
    {
        #region Atributos
        private string _Accion;
        private int _IdPlanEstudioMateria;
        private int _IdPlanEstudio;
        private int _IdMateria;
        private int _IdTipoMateria;
        private int _IdEtapa;
        private int _IdAreaConocimiento;
        private int _Semestre;
        private string _NombrePlanEstudio;
        private string _NombreMateria;
        private string _NombreTipoMateria;
        private string _NombreEtapa;
        private string _NombreArea;
        #endregion

        #region Constructor
        public E_PlanEstudioMateria()
        {
            _Accion = string.Empty;
            _IdPlanEstudioMateria = 0;
            _IdPlanEstudio = 0;
            _IdMateria = 0;
            _IdTipoMateria = 0;
            _IdEtapa = 0;
            _IdAreaConocimiento = 0;
            _Semestre = 0;
            _NombrePlanEstudio = string.Empty;
            _NombreMateria = string.Empty;
            _NombreTipoMateria = string.Empty;
            _NombreEtapa = string.Empty;
            _NombreArea = string.Empty;
        }
        #endregion

        #region Encapsulamiento
        public string Accion { get => _Accion; set => _Accion = value; }
        public int IdPlanEstudioMateria { get => _IdPlanEstudioMateria; set => _IdPlanEstudioMateria = value; }
        public int IdPlanEstudio { get => _IdPlanEstudio; set => _IdPlanEstudio = value; }
        public int IdMateria { get => _IdMateria; set => _IdMateria = value; }
        public int IdTipoMateria { get => _IdTipoMateria; set => _IdTipoMateria = value; }
        public int IdEtapa { get => _IdEtapa; set => _IdEtapa = value; }
        public int IdAreaConocimiento { get => _IdAreaConocimiento; set => _IdAreaConocimiento = value; }
        public int Semestre { get => _Semestre; set => _Semestre = value; }
        public string NombrePlanEstudio { get => _NombrePlanEstudio; set => _NombrePlanEstudio = value; }
        public string NombreMateria { get => _NombreMateria; set => _NombreMateria = value; }
        public string NombreTipoMateria { get => _NombreTipoMateria; set => _NombreTipoMateria = value; }
        public string NombreEtapa { get => _NombreEtapa; set => _NombreEtapa = value; }
        public string NombreArea { get => _NombreArea; set => _NombreArea = value; }
        #endregion
    }
}

