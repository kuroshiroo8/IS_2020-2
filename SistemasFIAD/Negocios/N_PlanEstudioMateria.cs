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
	public class N_PlanEstudioMateria
	{
		D_SQL_Datos NPEM = new D_SQL_Datos();
		
		// Acciones de Insertar, Borrar y Modificar los datos de la clase PlanEstudioMateria.
		public string InsertaPlanEstudioMateria(E_PlanEstudioMateria pEntidad)
		{
			pEntidad.Accion = "INSERTAR";

			string R = NPEM.IBM_Entidad<E_PlanEstudioMateria>("IBM_PlanEstudioMateria", pEntidad);

			if (R.Contains("Exito"))
				return "Exito: Los datos fueron insertados correctamente.";
			else
				if (R.Contains("Error"))
					 return "Error: Los datos no se insertaron en el sistema.";
				else
					return R;
		}

		public string BorraPlanEstudioMateria(int pIdPlanEstudioMateria)
		{
			E_PlanEstudioMateria Entidad = new E_PlanEstudioMateria
			{
				Accion = "BORRAR",
				IdPlanEstudioMateria = pIdPlanEstudioMateria
			};

			string R = NPEM.IBM_Entidad<E_PlanEstudioMateria>("IBM_PlanEstudioMateria", Entidad);

			if (R.Contains("Exito"))
				return "Exito: Los datos de fueron borrados correctamente.";
			else
				if (R.Contains("Error"))
					 return "Error: Los datos no se borraron del sistema.";
				else
					return R;
		}

		public string ModificaPlanEstudioMateria(E_PlanEstudioMateria pEntidad)
		{
			pEntidad.Accion = "MODIFICAR";

			string R = NPEM.IBM_Entidad<E_PlanEstudioMateria>("IBM_PlanEstudioMateria", pEntidad);

			if (R.Contains("Exito"))
				return "Exito: Los datos fueron modificado correctamente.";
			else
				if (R.Contains("Error"))
					 return "Error: Los datos no se modificaron en el sistema.";
				else
					return R;
		}

		// Listado generales de la clase PlanEstudioMateria en formato DataTable y List<E_PlanEstudioMateria>.
		public DataTable DT_LstPlanEstudioMateria()
		{
			return NPEM.DT_ListadoGeneral("PlanEstudioMateria", "[PonerCampoDeOrdenacion]");
		}

		public List<E_PlanEstudioMateria> LstPlanEstudioMateria()
		{
			return D_ConvierteDatos.ConvertirDTALista<E_PlanEstudioMateria>(DT_LstPlanEstudioMateria());
		}

		// Busquedas de la clasePlanEstudioMateria por diferente Criterios
		public E_PlanEstudioMateria BuscaPlanEstudioMateriaPorId(int pIdPlanEstudioMateria)
		{
			return (from PlanEstudioMateria in LstPlanEstudioMateria() where PlanEstudioMateria.IdPlanEstudioMateria == pIdPlanEstudioMateria select PlanEstudioMateria).FirstOrDefault();
		}

	}}
