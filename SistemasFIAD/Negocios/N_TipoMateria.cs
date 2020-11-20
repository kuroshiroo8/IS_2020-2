/*************************************************************************************
* Autor: PCSIS (Archivo generado automáticamente con GeneradorDeCodigo Ver.1.0.0)
* Proyecto: [Poner_Nombre_Del_Proyecto]
* Archivo: .cs
* Fecha de creación: 11/17/2020
* Propósito: [Poner_La_Una_Descripción_Del_Proposito_Principal_Del_Archivo]
* D.R. PCSIS (Proyectos Computacionales y Servicios de Ingeniería de Software
****************************************************************************************/

#region Using
using System.Data;
using System. Linq;
using System.Collections.Generic;

using DatosSQL;
using Entidades;
#endregion

namespace Negocios
{
	public class N_TipoMateria
	{
		D_SQL_Datos NTM = new D_SQL_Datos();
		
		// Acciones de Insertar, Borrar y Modificar los datos de la clase TipoMateria.
		public string InsertaTipoMateria(E_TipoMateria pEntidad)
		{
			pEntidad.Accion = "INSERTAR";

			string R = NTM.IBM_Entidad<E_TipoMateria>("IBM_TipoMateria", pEntidad);

			if (R.Contains("Exito"))
				return "Exito: Los datos fueron insertados correctamente.";
			else
				if (R.Contains("Error"))
					 return "Error: Los datos no se insertaron en el sistema.";
				else
					return R;
		}

		public string BorraTipoMateria(int pIdTipoMateria)
		{
			E_TipoMateria Entidad = new E_TipoMateria
			{
				Accion = "BORRAR",
				IdTipoMateria = pIdTipoMateria
			};

			string R = NTM.IBM_Entidad<E_TipoMateria>("IBM_TipoMateria", Entidad);

			if (R.Contains("Exito"))
				return "Exito: Los datos de fueron borrados correctamente.";
			else
				if (R.Contains("Error"))
					 return "Error: Los datos no se borraron del sistema.";
				else
					return R;
		}

		public string ModificaTipoMateria(E_TipoMateria pEntidad)
		{
			pEntidad.Accion = "MODIFICAR";

			string R = NTM.IBM_Entidad<E_TipoMateria>("IBM_TipoMateria", pEntidad);

			if (R.Contains("Exito"))
				return "Exito: Los datos fueron modificado correctamente.";
			else
				if (R.Contains("Error"))
					 return "Error: Los datos no se modificaron en el sistema.";
				else
					return R;
		}

		// Listado generales de la clase TipoMateria en formato DataTable y List<E_TipoMateria>.
		public DataTable DT_LstTipoMateria()
		{
			return NTM.DT_ListadoGeneral("TipoMateria", "[PonerCampoDeOrdenacion]");
		}

		public List<E_TipoMateria> LstTipoMateria()
		{
			return D_ConvierteDatos.ConvertirDTALista<E_TipoMateria>(DT_LstTipoMateria());
		}

		// Busquedas de la claseTipoMateria por diferente Criterios
		public E_TipoMateria BuscaTipoMateriaPorId(int pIdTipoMateria)
		{
			return (from TipoMateria in LstTipoMateria() where TipoMateria.IdTipoMateria == pIdTipoMateria select TipoMateria).FirstOrDefault();
		}

	}}
