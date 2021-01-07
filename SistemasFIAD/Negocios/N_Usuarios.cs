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
    public class N_Usuarios
    {
        D_SQL_Datos NU = new D_SQL_Datos();

        // Acciones de Insertar, Borrar y Modificar los datos de la clase TipoMateria.
        public string InsertaUsuario(E_Usuarios pEntidad)
        {
            pEntidad.Accion = "INSERTAR";

            string R = NU.IBM_Entidad<E_Usuarios>("IBM_Usuarios", pEntidad);

            if (R.Contains("Exito"))
                return "Exito: El usuario se creo correctamente.";
            else
                if (R.Contains("Error"))
                return "Error: El usuario no se creo. (clave o correo repetidos)";
            else
                return R;
        }

        public string BorraUsuario(int pIdUsuarios)
        {
            E_Usuarios Entidad = new E_Usuarios
            {
                Accion = "BORRAR",
                IdUsuario = pIdUsuarios
            };

            string R = NU.IBM_Entidad<E_Usuarios>("IBM_Usuarios", Entidad);

            if (R.Contains("Exito"))
                return "Exito: El usuario se borro correctamente.";
            else
                if (R.Contains("Error"))
                return "Error: El usuario no se borro.";
            else
                return R;
        }

        public string ModificaUsuario(E_Usuarios pEntidad)
        {
            pEntidad.Accion = "MODIFICAR";

            string R = NU.IBM_Entidad<E_Usuarios>("IBM_Usuarios", pEntidad);

            if (R.Contains("Exito"))
                return "Exito: El usuario se modifico correctamente.";
            else
                if (R.Contains("Error"))
                return "Error: El usuario no se modifico. (clave o correo repetidos)";
            else
                return R;
        }

        // Listado generales de la clase TipoMateria en formato DataTable y List<E_TipoMateria>.
        public DataTable DT_LstUsuario()
        {
            return NU.DT_ListadoGeneral("Usuarios", "[CorreoUsuario]");
        }

        public List<E_Usuarios> LstUsuario()
        {
            return D_ConvierteDatos.ConvertirDTALista<E_Usuarios>(DT_LstUsuario());
        }

        // Busquedas de la claseTipoMateria por diferente Criterios
        public E_Usuarios BuscaUsuarioPorId(int pIdUsuarios)
        {
            return (from Usuarios in LstUsuario() where Usuarios.IdUsuario == pIdUsuarios select Usuarios).FirstOrDefault();
        }

        public List<E_Usuarios> BuscaUsuario(string CriterioBusqueda)
        {
            return (from Usuarios in LstUsuario()
                    where
                    Usuarios.CorreoUsuario.ToUpper().Contains(CriterioBusqueda.ToUpper())
                    select Usuarios).ToList();
        }
    }
}
