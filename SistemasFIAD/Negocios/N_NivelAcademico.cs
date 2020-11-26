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
    public class N_NivelAcademico
    {
        D_SQL_Datos NNA = new D_SQL_Datos();

        // Acciones de Insertar, Borrar y Modificar los datos de la clase NivelAcademico.
        public string InsertaNivelAcademico(E_NivelAcademico pEntidad)
        {
            pEntidad.Accion = "INSERTAR";

            string R = NNA.IBM_Entidad<E_NivelAcademico>("IBM_NivelAcademico", pEntidad);

            if (R.Contains("Exito"))
                return "Exito: Los datos fueron insertados correctamente.";
            else
                if (R.Contains("Error"))
                return "Error: Los datos no se insertaron en el sistema.";
            else
                return R;
        }

        public string BorraNivelAcademico(int pIdNivelAcademico)
        {
            E_NivelAcademico Entidad = new E_NivelAcademico
            {
                Accion = "BORRAR",
                IdNivelAcademico = pIdNivelAcademico
            };

            string R = NNA.IBM_Entidad<E_NivelAcademico>("IBM_NivelAcademico", Entidad);

            if (R.Contains("Exito"))
                return "Exito: Los datos de fueron borrados correctamente.";
            else
                if (R.Contains("Error"))
                return "Error: Los datos no se borraron del sistema.";
            else
                return R;
        }

        public string ModificaNivelAcademico(E_NivelAcademico pEntidad)
        {
            pEntidad.Accion = "MODIFICAR";

            string R = NNA.IBM_Entidad<E_NivelAcademico>("IBM_NivelAcademico", pEntidad);

            if (R.Contains("Exito"))
                return "Exito: Los datos fueron modificado correctamente.";
            else
                if (R.Contains("Error"))
                return "Error: Los datos no se modificaron en el sistema.";
            else
                return R;
        }

        // Listado generales de la clase NivelAcademico en formato DataTable y List<E_NivelAcademico>.
        public DataTable DT_LstNivelAcademico()
        {
            return NNA.DT_ListadoGeneral("NivelAcademico", "[PonerCampoDeOrdenacion]");
        }

        public List<E_NivelAcademico> LstNivelAcademico()
        {
            return D_ConvierteDatos.ConvertirDTALista<E_NivelAcademico>(DT_LstNivelAcademico());
        }

        // Busquedas de la claseNivelAcademico por diferente Criterios
        public E_NivelAcademico BuscaNivelAcademicoPorId(int pIdNivelAcademico)
        {
            return (from NivelAcademico in LstNivelAcademico() where NivelAcademico.IdNivelAcademico == pIdNivelAcademico select NivelAcademico).FirstOrDefault();
        }

    }
}
