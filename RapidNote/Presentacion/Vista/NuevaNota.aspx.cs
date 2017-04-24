﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using RapidNote.Presentacion.Contrato.Nota;
using RapidNote.Clases;
using RapidNote.Presentacion.Presentador.Nota;

namespace RapidNote.Presentacion.Vista
{
    public partial class NuevaNota : System.Web.UI.Page, IContratoNuevaNota
    {
        PresentadorNuevaNota presentador;
        string rutaArchivo="";
        string nombreArchivo = "";
        HttpFileCollection hffc;

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            presentador = new PresentadorNuevaNota(this);

        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            presentador = new PresentadorNuevaNota(this);
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
     
            ScriptManager scripManager = ScriptManager.GetCurrent(this.Page);
            scripManager.RegisterPostBackControl(Button1);
        }

        protected void ClickBuscarNota(object sender, EventArgs e)
        {
            (Sesion["usuario"] as Usuario).Estado = TextBoxBuscadorSiteM.Text;
            Response.Redirect("BuscarNota.aspx");
            //presentador.IniciarVista();
        }

        public System.Web.SessionState.HttpSessionState Sesion
        {
            get { return Session; }
        }


        public string getContenido()
        {
            return TextBoxContenido.Text;
        }

        public string archivo() 
        {
            return FileUploadArchivo.FileName;
        }

        public string getTitulo()
        {
            return TextBoxTitulo.Text;
        }                

        public string getNombreLibreta()
        {
            return DropDownListLibretas.SelectedValue;
        }

        public string[] getRutas()
        {
            return rutaArchivo.Split(';');
        }

        public string[] getNombrearchivo()
        {
            return nombreArchivo.Split(';');
        }

        public HttpFileCollection getHfc()
        {
            return hffc;
        }

        public void setListaLibretas(List<Entidad> listaLibretas)
        {
            DropDownListLibretas.Items.Clear();
            for (int i = 0; i < listaLibretas.Count; i++) 
            {
                DropDownListLibretas.Items.Add((listaLibretas[i] as Libreta).NombreLibreta);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            presentador.Ejecutar();
            string directorio = @"C:\Users\victor\Documents\GitHub\DesarrolloBMW\RapidNote\RapidNote\Archivo\";
            hffc = Request.Files;
            for (int i = 0; i < hffc.Count; i++)
            {
                HttpPostedFile hpf = hffc[i];
                if (hpf.ContentLength > 0)
                {
                    nombreArchivo += hpf.FileName + ";";
                    rutaArchivo += directorio + hpf.FileName + ";";
                }

            }
            if (rutaArchivo != "")
            {
                presentador.Adjuntar();
            }
            
            LabelResultado.Text="Almacenado";
            Response.Redirect("../Vista/index.aspx");
        }

    }
}