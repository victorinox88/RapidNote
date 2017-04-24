﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RapidNote.Clases
{
    public class Libreta : Entidad
    {
        private int idlibreta;
        private string nombreLibreta;
        private List<Nota> listaNota;
        private Usuario usuario;

        public int Idlibreta
        {
            get { return idlibreta; }
            set { idlibreta = value; }
        }


        public string NombreLibreta
        {
            get { return nombreLibreta; }
            set { nombreLibreta = value; }
        }


        public List<Nota> ListaNota
        {
            get { return listaNota; }
            set { listaNota = value; }
        }


        public Usuario Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }
    }
}