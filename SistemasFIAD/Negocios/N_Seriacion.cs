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
	public class N_Seriacion
	{
		D_SQL_Datos NS = new D_SQL_Datos();
		
		// Acciones de Insertar, Borrar y Modificar los datos de la clase Seriacion.
		public string InsertaSeriacion(E_Seriacion pEntidad)
		{
			pEntidad.Accion = "INSERTAR";

			string R = NS.IBM_Entidad<E_Seriacion>("IBM_Seriacion", pEntidad);

			if (R.Contains("Exito"))
				return "Exito: Los datos fueron insertados correctamente.";
			else
				if (R.Contains("Error"))
					 return "Error: Los datos no se insertaron en el sistema.";
				else
					return R;
		}

		public string BorraSeriacion(int pIdSeriacion)
		{
			E_Seriacion Entidad = new E_Seriacion
			{
				Accion = "BORRAR",
				IdSeriacion = pIdSeriacion
			};

			string R = NS.IBM_Entidad<E_Seriacion>("IBM_Seriacion", Entidad);

			if (R.Contains("Exito"))
				return "Exito: Los datos de fueron borrados correctamente.";
			else
				if (R.Contains("Error"))
					 return "Error: Los datos no se borraron del sistema.";
				else
					return R;
		}

		public string ModificaSeriacion(E_Seriacion pEntidad)
		{
			pEntidad.Accion = "MODIFICAR";

			string R = NS.IBM_Entidad<E_Seriacion>("IBM_Seriacion", pEntidad);

			if (R.Contains("Exito"))
				return "Exito: Los datos fueron modificado correctamente.";
			else
				if (R.Contains("Error"))
					 return "Error: Los datos no se modificaron en el sistema.";
				else
					return R;
		}

		// Listado generales de la clase Seriacion en formato DataTable y List<E_Seriacion>.
		public DataTable DT_LstSeriacion()
		{
			return NS.DT_ListadoGeneral("Seriacion", "[PonerCampoDeOrdenacion]");
		}

		public List<E_Seriacion> LstSeriacion()
		{
			return D_ConvierteDatos.ConvertirDTALista<E_Seriacion>(DT_LstSeriacion());
		}

		// Busquedas de la claseSeriacion por diferente Criterios
		public E_Seriacion BuscaSeriacionPorId(int pIdSeriacion)
		{
			return (from Seriacion in LstSeriacion() where Seriacion.IdSeriacion == pIdSeriacion select Seriacion).FirstOrDefault();
		}

	}}
