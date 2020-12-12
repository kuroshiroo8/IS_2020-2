/*************************************************************************************
* Autor: PCSIS (Archivo generado automáticamente con GeneradorDeCodigo Ver.1.0.0)
* Proyecto: [Poner_Nombre_Del_Proyecto]
* Archivo: .cs
* Fecha de creación: 11/12/2020
* Propósito: [Poner_La_Una_Descripción_Del_Proposito_Principal_Del_Archivo]
* D.R. PCSIS (Proyectos Computacionales y Servicios de Ingeniería de Software
****************************************************************************************/

#region Using
using System.Data;
using System.Linq;
using System.Collections.Generic;
using System.Configuration;

using DatosSQL;
using Entidades;
#endregion

namespace Negocios
{
    public class N_Carreras
    {
        DatosSQL.D_SQL_Datos DC = new DatosSQL.D_SQL_Datos();

        // Acciones de Insertar, Borrar y Modificar los datos de la clase Carreras.
        public string InsertaCarreras(E_Carreras pEntidad)
        {
            pEntidad.Accion = "INSERTAR";

            string R = DC.IBM_Entidad<E_Carreras>("IBM_Carreras", pEntidad);

            if (R.Contains("Exito"))
                return "Exito: Los datos fueron insertados correctamente.";
            else if (R.Contains("Violation"))
                return "Error: El campo clave de la carrera ya existe.";
            else if (R.Contains("Error"))
                return "Error: Los datos no se insertaron en el sistema.";

            return R;
        }

        public string BorraCarreras(int pIdCarreras)
        {
            E_Carreras Entidad = new E_Carreras
            {
                Accion = "BORRAR",
                IdCarrera = pIdCarreras
            };

            string R = DC.IBM_Entidad<E_Carreras>("IBM_Carreras", Entidad);

            if (R.Contains("Exito"))
                return "Exito: Los datos fueron borrados correctamente.";
            else if (R.Contains("Error"))
                return "Error: Los datos no se borraron del sistema.";

            return R;
        }

        public string ModificaCarreras(E_Carreras pEntidad)
        {
            pEntidad.Accion = "MODIFICAR";

            string R = DC.IBM_Entidad<E_Carreras>("IBM_Carreras", pEntidad);

            if (R.Contains("Exito"))
                return "Exito: Los datos fueron modificados correctamente.";
            else if (R.Contains("Violation"))
                return "Error: El campo clave de la carrera ya existe.";
            else if (R.Contains("Error"))
                return "Error: Los datos no se modificaron en el sistema.";

            return R;
        }

        // Listado generales de la clase Carreras en formato DataTable y List<E_Carreras>.
        public DataTable GetDT_LstCarreras()
        {
            return DC.DT_ListadoGeneral("Carreras", "ClaveCarrera");
        }

        public List<E_Carreras> LstCarreras()
        {
            return D_ConvierteDatos.ConvertirDTALista<E_Carreras>(GetDT_LstCarreras());
        }

        // Busquedas de la claseCarreras por diferente Criterios
        public E_Carreras BuscaCarrerasPorId(int pIdCarrera)
        {
            return (from Carreras in LstCarreras() where Carreras.IdCarrera == pIdCarrera select Carreras).FirstOrDefault();
        }

        public List<E_Carreras> BuscaCarrera(string CriterioBusqueda)
        {
            return (from Carreras in LstCarreras()
                    where
                        Carreras.NombreCarrera.ToUpper().Contains(CriterioBusqueda.ToUpper()) ||
                        Carreras.AliasCarrera.Contains(CriterioBusqueda)
                    select Carreras).ToList();
        }
    }
}
