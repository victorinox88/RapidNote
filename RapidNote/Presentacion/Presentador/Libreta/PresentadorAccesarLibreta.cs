using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RapidNote.Presentacion.Contrato.Libreta;
using RapidNote.Clases;
using RapidNote.Logica.Comandos;
using RapidNote.Logica.Fabrica;
using RapidNote.Clases.Fabrica;


namespace RapidNote.Presentacion.Presentador.Libreta
{
    public class PresentadorAccesarLibreta
    {
        private IContratoAccesarLibreta _vista;

        private Comando<List<Entidad>> comando;

        private List<Entidad> lista;

        public PresentadorAccesarLibreta(IContratoAccesarLibreta vista)
        {
            this._vista = vista;
        }

        public void IniciarVista()
        {
            Entidad usuario = _vista.Sesion["usuario"] as Clases.Usuario;
            comando = FabricaComando.CrearComandoListarLibretas(usuario);
            lista = comando.Ejecutar();
            _vista.gridviewlibreta = lista;
        }
    }
}