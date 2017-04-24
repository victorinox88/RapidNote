﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RapidNote.Presentacion.Contrato.Libreta;
using RapidNote.Presentacion.Presentador.Libreta;



namespace RapidNote.Presentacion.Vista
{
    public partial class CrearLibreta : System.Web.UI.Page, IContratoAgregarLibreta
    {
        private PresentadorAgregarLibreta presentador;
        protected void Page_Load(object sender, EventArgs e)
        {
            presentador = new PresentadorAgregarLibreta(this);
        }

        public string getNombre()
        {
            return nombre.Text;
        }

        public Label MensajeError
        {
            get { return mensajeError; }
            set { mensajeError = value; }
        }

        public System.Web.SessionState.HttpSessionState Sesion
        {
            get { return Session; }
        }

        public void Redireccionar(string _ruta)
        {
            Response.Redirect(_ruta);
        }   

        protected void registrar_Click(object sender, EventArgs e)
        {
             presentador.Ejecutar();
        }

        protected void Cancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Vista/index.aspx");
        }
    }
}