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
		private int _HC;
		private int _HL;
		private int _HT;
		private int _HE;
		private int _HPP;
		private int _CR;
		private string _PropositoGeneral;
		private string _Competencia;
		private string _Evidencia;
		private string _Metodologia;
		private string _Criterios;
		private string _BibliografiaBasica;
		private string _BibliografiaComplementaria;
		private string _PerfilDocente;
		private Boolean _EstadoMateria;
		private string _PathPUA;
		#endregion

		#region Constructor
		public E_Materias()
		{
			_Accion = string.Empty;
			_IdMateria = 0;
			_ClaveMateria = string.Empty;
			_NombreMateria = string.Empty;
			_HC = 0;
			_HL = 0;
			_HT = 0;
			_HE = 0;
			_HPP = 0;
			_CR = 0;
			_PropositoGeneral = string.Empty;
			_Competencia = string.Empty;
			_Evidencia = string.Empty;
			_Metodologia = string.Empty;
			_Criterios = string.Empty;
			_BibliografiaBasica = string.Empty;
			_BibliografiaComplementaria = string.Empty;
			_PerfilDocente = string.Empty;
			_EstadoMateria = false;
			_PathPUA = string.Empty;
		}
		#endregion

		#region Encapsulamiento
		public string Accion { get => _Accion; set => _Accion = value; }
		public int IdMateria { get => _IdMateria; set => _IdMateria = value; }
		public string ClaveMateria { get => _ClaveMateria; set => _ClaveMateria = value; }
		public string NombreMateria { get => _NombreMateria; set => _NombreMateria = value; }
		public int HC { get => _HC; set => _HC = value; }
		public int HL { get => _HL; set => _HL = value; }
		public int HT { get => _HT; set => _HT = value; }
		public int HE { get => _HE; set => _HE = value; }
		public int HPP { get => _HPP; set => _HPP = value; }
		public int CR { get => _CR; set => _CR = value; }
		public string PropositoGeneral { get => _PropositoGeneral; set => _PropositoGeneral = value; }
		public string Competencia { get => _Competencia; set => _Competencia = value; }
		public string Evidencia { get => _Evidencia; set => _Evidencia = value; }
		public string Metodologia { get => _Metodologia; set => _Metodologia = value; }
		public string Criterios { get => _Criterios; set => _Criterios = value; }
		public string BibliografiaBasica { get => _BibliografiaBasica; set => _BibliografiaBasica = value; }
		public string BibliografiaComplementaria { get => _BibliografiaComplementaria; set => _BibliografiaComplementaria = value; }
		public string PerfilDocente { get => _PerfilDocente; set => _PerfilDocente = value; }
		public Boolean EstadoMateria { get => _EstadoMateria; set => _EstadoMateria = value; }
		public string PathPUA { get => _PathPUA; set => _PathPUA = value; }
		#endregion
	}
}

