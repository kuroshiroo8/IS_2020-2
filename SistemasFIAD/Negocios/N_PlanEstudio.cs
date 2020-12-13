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
using System.Linq;
using System.Collections.Generic;

using DatosSQL;
using Entidades;
#endregion

namespace Negocios
{
    public class N_PlanEstudio
    {
        D_SQL_Datos NPE = new D_SQL_Datos();

        // Acciones de Insertar, Borrar y Modificar los datos de la clase PlanEstudio.
        public string InsertaPlanEstudio(E_PlanEstudio pEntidad)
        {
            pEntidad.Accion = "INSERTAR";

            string R = NPE.IBM_Entidad<E_PlanEstudio>("IBM_PlanEstudio", pEntidad);

            if (R.Contains("Exito"))
                return "Exito: Los datos fueron insertados correctamente.";
            else
                if (R.Contains("Error"))
                return "Error: Los datos no se insertaron en el sistema.";
            else
                return R;
        }

        public string BorraPlanEstudio(int pIdPlanEstudio)
        {
            E_PlanEstudio Entidad = new E_PlanEstudio
            {
                Accion = "BORRAR",
                IdPlanEstudio = pIdPlanEstudio
            };

            string R = NPE.IBM_Entidad<E_PlanEstudio>("IBM_PlanEstudio", Entidad);

            if (R.Contains("Exito"))
                return "Exito: Los datos fueron borrados correctamente.";
            else
                if (R.Contains("Error"))
                return "Error: Los datos no se borraron del sistema.";
            else
                return R;
        }

        public string ModificaPlanEstudio(E_PlanEstudio pEntidad)
        {
            pEntidad.Accion = "MODIFICAR";

            string R = NPE.IBM_Entidad<E_PlanEstudio>("IBM_PlanEstudio", pEntidad);

            if (R.Contains("Exito"))
                return "Exito: Los datos fueron modificado correctamente.";
            else
                if (R.Contains("Error"))
                return "Error: Los datos no se modificaron en el sistema.";
            else
                return R;
        }

        // Listado generales de la clase PlanEstudio en formato DataTable y List<E_PlanEstudio>.
        public DataTable DT_LstPlanEstudio()
        {
            return NPE.DT_ListadoGeneral("PlanEstudio", "ClavePlanEstudio");
        }

        public List<E_PlanEstudio> LstPlanEstudio()
        {
            return D_ConvierteDatos.ConvertirDTALista<E_PlanEstudio>(DT_LstPlanEstudio());
        }

        // Busquedas de la clasePlanEstudio por diferente Criterios
        public E_PlanEstudio BuscaPlanEstudioPorId(int pIdPlanEstudio)
        {
            return (from PlanEstudio in LstPlanEstudio() where PlanEstudio.IdPlanEstudio == pIdPlanEstudio select PlanEstudio).FirstOrDefault();
        }

        public List<E_PlanEstudio> BuscaPlanEstudio(string CriterioBusqueda)
        {
            return (from PlanEstudio in LstPlanEstudio()
                    where
                    PlanEstudio.PlanEstudio.ToUpper().Contains(CriterioBusqueda.ToUpper())
                    select PlanEstudio).ToList();
        }
    }
}
