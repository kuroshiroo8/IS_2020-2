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
    public class N_Etapas
    {
        D_SQL_Datos NE = new D_SQL_Datos();

        // Acciones de Insertar, Borrar y Modificar los datos de la clase Etapas.
        public string InsertaEtapas(E_Etapas pEntidad)
        {
            pEntidad.Accion = "INSERTAR";

            string R = NE.IBM_Entidad<E_Etapas>("IBM_Etapas", pEntidad);

            if (R.Contains("Exito"))
                return "Exito: Los datos fueron insertados correctamente.";
            else
                if (R.Contains("Error"))
                return "Error: Los datos no se insertaron en el sistema.";
            else
                return R;
        }

        public string BorraEtapas(int pIdEtapas)
        {
            E_Etapas Entidad = new E_Etapas
            {
                Accion = "BORRAR",
                IdEtapa = pIdEtapas
            };

            string R = NE.IBM_Entidad<E_Etapas>("IBM_Etapas", Entidad);

            if (R.Contains("Exito"))
                return "Exito: Los datos de fueron borrados correctamente.";
            else
                if (R.Contains("Error"))
                return "Error: Los datos no se borraron del sistema.";
            else
                return R;
        }

        public string ModificaEtapas(E_Etapas pEntidad)
        {
            pEntidad.Accion = "MODIFICAR";

            string R = NE.IBM_Entidad<E_Etapas>("IBM_Etapas", pEntidad);

            if (R.Contains("Exito"))
                return "Exito: Los datos fueron modificado correctamente.";
            else
                if (R.Contains("Error"))
                return "Error: Los datos no se modificaron en el sistema.";
            else
                return R;
        }

        // Listado generales de la clase Etapas en formato DataTable y List<E_Etapas>.
        public DataTable DT_LstEtapas()
        {
            return NE.DT_ListadoGeneral("Etapas", "[PonerCampoDeOrdenacion]");
        }

        public List<E_Etapas> LstEtapas()
        {
            return D_ConvierteDatos.ConvertirDTALista<E_Etapas>(DT_LstEtapas());
        }

        // Busquedas de la claseEtapas por diferente Criterios
        public E_Etapas BuscaEtapasPorId(int pIdEtapa)
        {
            return (from Etapas in LstEtapas() where Etapas.IdEtapa == pIdEtapa select Etapas).FirstOrDefault();
        }

    }
}
