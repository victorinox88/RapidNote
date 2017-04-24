﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RapidNote.Clases;
using RapidNote.Presentacion.Contrato.Libreta;
using RapidNote.Presentacion.Presentador.Libreta;

namespace RapidNote.Presentacion.Vista
{
    public partial class AccesarLibreta : System.Web.UI.Page, IContratoAccesarLibreta
    {
        private PresentadorAccesarLibreta presentador;

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            presentador = new PresentadorAccesarLibreta(this);

        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            presentador = new PresentadorAccesarLibreta(this);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Sesion["usuario"] == null)
                Response.Redirect("login.aspx");
            else
            {
                if (!IsPostBack)
                {
                    presentador.IniciarVista();
                }
            }
        }

        public List<Entidad> gridviewlibreta
        {
            set {
                GridViewLibreta.DataSource = value;
                GridViewLibreta.DataBind();
            }
        }

        public string contenidoBusqueda
        {
            get { return "%" + TextBoxBuscadorSiteM.Text + "%"; }
        }

        public System.Web.SessionState.HttpSessionState Sesion
        {
            get { return Session; }
        }

        protected void ClickBuscarNota(object sender, EventArgs e)
        {
            (Sesion["usuario"] as Usuario).Estado = TextBoxBuscadorSiteM.Text;
            Response.Redirect("BuscarNota.aspx");
            //presentador.IniciarVista();
        }

        protected void GridViewRowEventHandler(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#ceedfc'");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=''");
                e.Row.Attributes.Add("style", "cursor:pointer;");
                e.Row.Attributes.Add("onclick", "location='EditarNota.aspx?id=" + e.Row.Cells[0].Text + "'");
            }
        }

        protected void Details_Click(object sender, EventArgs e)
        {
            Button Button1 = (Button)sender;
            GridViewRow grdRow = (GridViewRow)Button1.Parent.Parent;
            string strField1 = grdRow.Cells[0].Text;
            string strField2 = grdRow.Cells[1].Text;
            Response.Redirect("../Vista/index.aspx?id="+strField1);
        }
    }
}