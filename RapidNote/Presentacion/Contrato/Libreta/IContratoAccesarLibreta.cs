using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.SessionState;
using RapidNote.Clases;

namespace RapidNote.Presentacion.Contrato.Libreta
{
    public interface IContratoAccesarLibreta
    {
        List<Entidad> gridviewlibreta { set; }

        String contenidoBusqueda { get; }

        HttpSessionState Sesion { get; }
    }
}
