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
    public class N_AreaConocimiento
    {
        D_SQL_Datos DAC = new D_SQL_Datos();

        // Acciones de Insertar, Borrar y Modificar los datos de la clase AreaConocimiento.
        public string InsertaAreaConocimiento(E_AreaConocimiento pEntidad)
        {
            pEntidad.Accion = "INSERTAR";

            string R = DAC.IBM_Entidad<E_AreaConocimiento>("IBM_AreaConocimiento", pEntidad);

            if (R.Contains("Exito"))
                return "Exito: Los datos fueron insertados correctamente.";
            else
                if (R.Contains("Error"))
                return "Error: Los datos no se insertaron en el sistema.";
            else
                return R;
        }

        public string BorraAreaConocimiento(int pIdAreaConocimiento)
        {
            E_AreaConocimiento Entidad = new E_AreaConocimiento
            {
                Accion = "BORRAR",
                IdAreaConocimiento = pIdAreaConocimiento
            };

            string R = DAC.IBM_Entidad<E_AreaConocimiento>("IBM_AreaConocimiento", Entidad);

            if (R.Contains("Exito"))
                return "Exito: Los datos fueron borrados correctamente.";
            else
                if (R.Contains("Error"))
                return "Error: Los datos no se borraron del sistema.";
            else
                return R;
        }

        public string ModificaAreaConocimiento(E_AreaConocimiento pEntidad)
        {
            pEntidad.Accion = "MODIFICAR";

            string R = DAC.IBM_Entidad<E_AreaConocimiento>("IBM_AreaConocimiento", pEntidad);

            if (R.Contains("Exito"))
                return "Exito: Los datos fueron modificados correctamente.";
            else
                if (R.Contains("Error"))
                return "Error: Los datos no se modificaron en el sistema.";
            else
                return R;
        }

        // Listado generales de la clase AreaConocimiento en formato DataTable y List<E_AreaConocimiento>.
        public DataTable DT_LstAreaConocimiento()
        {
            return DAC.DT_ListadoGeneral("AreaConocimiento", "[PonerCampoDeOrdenacion]");
        }

        public List<E_AreaConocimiento> LstAreaConocimiento()
        {
            return D_ConvierteDatos.ConvertirDTALista<E_AreaConocimiento>(DT_LstAreaConocimiento());
        }

        // Busquedas de la claseAreaConocimiento por diferente Criterios
        public E_AreaConocimiento BuscaAreaConocimientoPorId(int pIdAreaConocimiento)
        {
            return (from AreaConocimiento in LstAreaConocimiento() where AreaConocimiento.IdAreaConocimiento == pIdAreaConocimiento select AreaConocimiento).FirstOrDefault();
        }

    }
}
