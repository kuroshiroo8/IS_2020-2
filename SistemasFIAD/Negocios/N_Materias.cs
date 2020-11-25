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
	public class N_Materias
	{
		D_SQL_Datos NM = new D_SQL_Datos();
		
		// Acciones de Insertar, Borrar y Modificar los datos de la clase Materias.
		public string InsertaMaterias(E_Materias pEntidad)
		{
			pEntidad.Accion = "INSERTAR";

			string R = NM.IBM_Entidad<E_Materias>("IBM_Materias", pEntidad);

			if (R.Contains("Exito"))
				return "Exito: Los datos fueron insertados correctamente.";
			else
				if (R.Contains("Error"))
					 return "Error: Los datos no se insertaron en el sistema.";
				else
					return R;
		}

		public string BorraMaterias(int pIdMaterias)
		{
			E_Materias Entidad = new E_Materias
			{
				Accion = "BORRAR",
				IdMateria = pIdMaterias
			};

			string R = NM.IBM_Entidad<E_Materias>("IBM_Materias", Entidad);

			if (R.Contains("Exito"))
				return "Exito: Los datos de fueron borrados correctamente.";
			else
				if (R.Contains("Error"))
					 return "Error: Los datos no se borraron del sistema.";
				else
					return R;
		}

		public string ModificaMaterias(E_Materias pEntidad)
		{
			pEntidad.Accion = "MODIFICAR";

			string R = NM.IBM_Entidad<E_Materias>("IBM_Materias", pEntidad);

			if (R.Contains("Exito"))
				return "Exito: Los datos fueron modificado correctamente.";
			else
				if (R.Contains("Error"))
					 return "Error: Los datos no se modificaron en el sistema.";
				else
					return R;
		}

		// Listado generales de la clase Materias en formato DataTable y List<E_Materias>.
		public DataTable DT_LstMaterias()
		{
			return NM.DT_ListadoGeneral("Materias", "ClaveMateria");
		}

		public List<E_Materias> LstMaterias()
		{
			return D_ConvierteDatos.ConvertirDTALista<E_Materias>(DT_LstMaterias());
		}

		// Busquedas de la claseMaterias por diferente Criterios
		public E_Materias BuscaMateriasPorId(int pIdMateria)
		{
			return (from Materias in LstMaterias() where Materias.IdMateria == pIdMateria select Materias).FirstOrDefault();
		}

        public List<E_Materias> BuscaMateria(string CriterioBusqueda)
        {
            return (from Materias in LstMaterias()
                    where
Materias.NombreMateria.ToUpper().Contains(CriterioBusqueda.ToUpper())
                    select Materias).ToList();
        }
    }
}
