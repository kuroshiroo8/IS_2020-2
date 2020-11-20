/*************************************************************************************
* Autor: PCSIS (Archivo generado automáticamente con GeneradorDeCodigo Ver.1.0.0)
* Proyecto: [Poner_Nombre_Del_Proyecto]
* Archivo: E_PlanEstudio.cs
* Fecha de creación: 11/17/2020
* Propósito: [Poner_La_Una_Descripción_Del_Proposito_Principal_Del_Archivo]
* D.R. PCSIS (Proyectos Computacionales y Servicios de Ingeniería de Software
****************************************************************************************/

using System;

namespace Entidades
{
	public class E_PlanEstudio
	{
		#region Atributos
		private string _Accion;
		private int _IdPlanEstudio;
		private int _IdNivelAcademico;
		private int _IdCarrera;
		private string _ClavePlanEstudio;
		private string _PlanEstudio;
		private string _ProgramaEducativo;
		private string _FechaCreacion;
		private int _TotalCreditos;
		private Boolean _EstadoPlanEstudios;
		private string _Comentarios;
		private string _PerfilDeIngreso;
		private string _PerfilDeEgreso;
		private string _CampoOcupacional;
		#endregion

		#region Constructor
		public E_PlanEstudio()
		{
			_Accion = string.Empty;
			_IdPlanEstudio = 0;
			_IdNivelAcademico = 0;
			_IdCarrera = 0;
			_ClavePlanEstudio = string.Empty;
			_PlanEstudio = string.Empty;
			_ProgramaEducativo = string.Empty;
			_FechaCreacion = string.Empty;
			_TotalCreditos = 0;
			_EstadoPlanEstudios = false;
			_Comentarios = string.Empty;
			_PerfilDeIngreso = string.Empty;
			_PerfilDeEgreso = string.Empty;
			_CampoOcupacional = string.Empty;
		}
		#endregion

		#region Encapsulamiento
		public string Accion { get => _Accion; set => _Accion = value; }
		public int IdPlanEstudio { get => _IdPlanEstudio; set => _IdPlanEstudio = value; }
		public int IdNivelAcademico { get => _IdNivelAcademico; set => _IdNivelAcademico = value; }
		public int IdCarrera { get => _IdCarrera; set => _IdCarrera = value; }
		public string ClavePlanEstudio { get => _ClavePlanEstudio; set => _ClavePlanEstudio = value; }
		public string PlanEstudio { get => _PlanEstudio; set => _PlanEstudio = value; }
		public string ProgramaEducativo { get => _ProgramaEducativo; set => _ProgramaEducativo = value; }
		public string FechaCreacion { get => _FechaCreacion; set => _FechaCreacion = value; }
		public int TotalCreditos { get => _TotalCreditos; set => _TotalCreditos = value; }
		public Boolean EstadoPlanEstudios { get => _EstadoPlanEstudios; set => _EstadoPlanEstudios = value; }
		public string Comentarios { get => _Comentarios; set => _Comentarios = value; }
		public string PerfilDeIngreso { get => _PerfilDeIngreso; set => _PerfilDeIngreso = value; }
		public string PerfilDeEgreso { get => _PerfilDeEgreso; set => _PerfilDeEgreso = value; }
		public string CampoOcupacional { get => _CampoOcupacional; set => _CampoOcupacional = value; }
		#endregion
	}
}

