﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;

using Entidades;
using Negocios;

namespace GePE.Login
{
    public partial class Login : System.Web.UI.Page
    {
        N_Usuarios NU = new N_Usuarios();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                InicializaControles();
        }

        #region Métodos generales
        protected void InicializaControles()
        {
            ControlesOFF();
            ControlesClear();
            ControlesOnOFF(true);
            CargarDatosListasPlanEstudio();
            VisibleOnOFF(true);
        }
        protected void ControlesOFF()
        {
            lblNombreAccion.Visible = false;

            lbEmail.Visible = false;
            lbLogin.Visible = false;
            lbPass.Visible = false;

            TbEmail.Visible = false;
            TbPass.Visible = false;

            ddlLogin.Visible = false;
        }
        protected void ControlesClear()
        {
            lblNombreAccion.Text = string.Empty;

            TbEmail.Text = string.Empty;
            TbPass.Text = string.Empty;

            ddlLogin.Items.Clear();
        }
        protected void ControlesOnOFF(bool TrueOrFalse)
        {
            lbEmail.Enabled = TrueOrFalse;
            lbLogin.Enabled = TrueOrFalse;
            lbPass.Enabled = TrueOrFalse;

            TbEmail.Enabled = TrueOrFalse;
            TbPass.Enabled = TrueOrFalse;

            ddlLogin.Enabled = TrueOrFalse;
        }
        protected void VisibleOnOFF(bool TrueOrFalse)
        {
            lbEmail.Visible = TrueOrFalse;
            lbLogin.Visible = TrueOrFalse;
            lbPass.Visible = TrueOrFalse;

            TbEmail.Visible = TrueOrFalse;
            TbPass.Visible = TrueOrFalse;

            ddlLogin.Visible = TrueOrFalse;
        }
        private void CargarDatosListasPlanEstudio()
        {
            ddlLogin.Items.Clear();
            DroplistLogin();
        }
        #endregion

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            lblNombreAccion.Text = "";
            lblNombreAccion.Visible = false;

            if (TbEmail.Text.Trim() != string.Empty)
            {
                string str = Convert.ToString(TbEmail.Text.Trim());
                List<E_Usuarios> LstUsuario = NU.BuscaUsuario(str);
                if (LstUsuario.Count.Equals(1))
                {
                    foreach (var item in LstUsuario)
                    {
                        if (item != null)
                        {
                            if (TbPass.Text.Trim() != string.Empty)
                            {
                                if ((TbPass.Text.Trim() == item.PassUsuario) && (ddlLogin.SelectedItem.Text == item.TipoUsuario))
                                {
                                    Session["IdUsuario"] = item.IdUsuario;
                                    Session["NombreUsuario"] = item.NombreUsuario;
                                    Session["CorreoUsuario"] = item.CorreoUsuario;
                                    Session["PassUsuario"] = item.PassUsuario;
                                    Session["TipoUsuario"] = item.TipoUsuario;
                                    Session["ClaveUsuario"] = item.ClaveUsuario;
                                    Session["ApellidoPaterno"] = item.ApellidoPaterno;
                                    Session["ApellidoMaterno"] = item.ApellidoMaterno;

                                    Response.Redirect("../Carreras/GestionCarreras.aspx");

                                }
                                else
                                {
                                    lblNombreAccion.Text = "*Contraseña o tipo de usuario incorrecto";
                                    lblNombreAccion.Visible = true;
                                }
                            }
                        }

                    }
                }
                else
                {
                    lblNombreAccion.Text = "*Correo mal escrito o no existente";
                    lblNombreAccion.Visible = true;
                }
            }
        }

        protected void BtnSinLogin_Click(object sender, EventArgs e)
        {
            Session["IdUsuario"] = "";
            Session["NombreUsuario"] = "";
            Session["CorreoUsuario"] = "";
            Session["PassUsuario"] = "";
            Session["TipoUsuario"] = "";
            Session["ClaveUsuario"] = "";
            Session["ApellidoPaterno"] = "";
            Session["ApellidoMaterno"] = "";

            Response.Redirect("../Carreras/GestionCarreras.aspx");
        }

        #region Cargar DropDownList
        private void DroplistLogin()
        {
            ListItem i;
            i = new ListItem("<Seleccione>", "");
            ddlLogin.Items.Add(i);
            i = new ListItem("ADMINISTRADOR", "1");
            ddlLogin.Items.Add(i);
            i = new ListItem("CAPTURISTA", "2");
            ddlLogin.Items.Add(i);
            i = new ListItem("INTERNO", "3");
            ddlLogin.Items.Add(i);
        }
        #endregion
    }
}