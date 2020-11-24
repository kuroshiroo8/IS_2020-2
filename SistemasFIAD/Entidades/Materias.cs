/*************************************************************************************
* Autor: PCSIS (Archivo generado automáticamente con GeneradorDeCodigo Ver.1.0.0)
* Proyecto: [Poner_Nombre_Del_Proyecto]
* Archivo: E_Materias.cs
* Fecha de creación: 11/17/2020
* Propósito: [Poner_La_Una_Descripción_Del_Proposito_Principal_Del_Archivo]
* D.R. PCSIS (Proyectos Computacionales y Servicios de Ingeniería de Software
****************************************************************************************/

using System;

namespace Entidades
{
    public class E_Materias
    {
        #region Atributos
        private string _Accion;
        private int _IdMateria;
        private string _ClaveMateria;
        private string _NombreMateria;
        private int _HoraClaseMateria;
        private int _HoraTallerMateria;
        private int _HoraLaboratorioMateria;
        private int _HoraExtraClaseMateria;
        private int _CreditosMateria;
        private Boolean _EstadoMateria;
        private string _EtapaFormacionMateria;
        private string _CaracteristicasFormacionMateria;
        private int _SemestreMateria;
        private string _AreaConocimientoMateria;
        private string _PathPUAnoOficialMateria;
        private string _PathPUAOficialMateria;
        private string _IdPlanEstudio;
        private string _StatusMateria;
        private string _PropositoGeneral;
        private string _Competencia;
        private string _Evidencia;
        private string _Metodologia;
        private string _Criterios;
        private string _BibliografiaBasica;
        private string _BibliografiaComplementaria;
        private string _PerfilDocente;
        private int _HPP;
        #endregion

        #region Constructor
        public E_Materias()
        {
            _Accion = string.Empty;
            _IdMateria = 0;
            _ClaveMateria = string.Empty;
            _NombreMateria = string.Empty;
            _HoraClaseMateria = 0;
            _HoraTallerMateria = 0;
            _HoraLaboratorioMateria = 0;
            _HoraExtraClaseMateria = 0;
            _CreditosMateria = 0;
            _HPP = 0;
            _PropositoGeneral = string.Empty;
            _Competencia = string.Empty;
            _Evidencia = string.Empty;
            _Metodologia = string.Empty;
            _Criterios = string.Empty;
            _BibliografiaBasica = string.Empty;
            _BibliografiaComplementaria = string.Empty;
            _PerfilDocente = string.Empty;
            _EstadoMateria = false;
            _EtapaFormacionMateria = string.Empty;
            _CaracteristicasFormacionMateria = string.Empty;
            _SemestreMateria = 0;
            _AreaConocimientoMateria = string.Empty;
            _PathPUAnoOficialMateria = string.Empty;
            _PathPUAOficialMateria = string.Empty;
            _IdPlanEstudio = string.Empty;
            _StatusMateria = string.Empty;
        }
        #endregion

        #region Encapsulamiento
        public string Accion { get => _Accion; set => _Accion = value; }
        public int IdMateria { get => _IdMateria; set => _IdMateria = value; }
        public string ClaveMateria { get => _ClaveMateria; set => _ClaveMateria = value; }
        public string NombreMateria { get => _NombreMateria; set => _NombreMateria = value; }
        public int HoraClaseMateria { get => _HoraClaseMateria; set => _HoraClaseMateria = value; }
        public int HoraTallerMateria { get => _HoraTallerMateria; set => _HoraTallerMateria = value; }
        public int HoraLaboratorioMateria { get => _HoraLaboratorioMateria; set => _HoraLaboratorioMateria = value; }
        public int HoraExtraClaseMateria { get => _HoraExtraClaseMateria; set => _HoraExtraClaseMateria = value; }
        public int HPP { get => _HPP; set => _HPP = value; }
        public int CreditosMateria { get => _CreditosMateria; set => _CreditosMateria = value; }
        public string PropositoGeneral { get => _PropositoGeneral; set => _PropositoGeneral = value; }
        public string Competencia { get => _Competencia; set => _Competencia = value; }
        public string Evidencia { get => _Evidencia; set => _Evidencia = value; }
        public string Metodologia { get => _Metodologia; set => _Metodologia = value; }
        public string Criterios { get => _Criterios; set => _Criterios = value; }
        public string BibliografiaBasica { get => _BibliografiaBasica; set => _BibliografiaBasica = value; }
        public string BibliografiaComplementaria { get => _BibliografiaComplementaria; set => _BibliografiaComplementaria = value; }
        public string PerfilDocente { get => _PerfilDocente; set => _PerfilDocente = value; }
        public Boolean EstadoMateria { get => _EstadoMateria; set => _EstadoMateria = value; }
        public string EtapaFormacionMateria { get => _EtapaFormacionMateria; set => _EtapaFormacionMateria = value; }
        public string CaracteristicasFormacionMateria { get => _CaracteristicasFormacionMateria; set => _CaracteristicasFormacionMateria = value; }
        public int SemestreMateria { get => _SemestreMateria; set => _SemestreMateria = value; }
        public string AreaConocimientoMateria { get => _AreaConocimientoMateria; set => _AreaConocimientoMateria = value; }
        public string PathPUAnoOficialMateria { get => _PathPUAnoOficialMateria; set => _PathPUAnoOficialMateria = value; }
        public string PathPUAOficialMateria { get => _PathPUAOficialMateria; set => _PathPUAOficialMateria = value; }
        public string IdPlanEstudio { get => _IdPlanEstudio; set => _IdPlanEstudio = value; }
        public string StatusMateria { get => _StatusMateria; set => _StatusMateria = value; }
        #endregion
    }
}

