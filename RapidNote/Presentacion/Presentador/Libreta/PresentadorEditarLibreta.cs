using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RapidNote.Presentacion.Contrato.Libreta;
using RapidNote.Clases;
using RapidNote.Logica.Comandos;
using RapidNote.Logica.Comandos.Libreta;
using RapidNote.Logica.Fabrica;

namespace RapidNote.Presentacion.Presentador.Libreta
{
    public class PresentadorEditarLibreta
    {
        private IContratoEditarLibreta _vista;
        private Comando<Entidad> comando;
        private Entidad libreta;

        public PresentadorEditarLibreta(IContratoEditarLibreta vista)
        {
            this._vista = vista;
        }

        public void IniciarVista() 
        {
            
        }
    }
}