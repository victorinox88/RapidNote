﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RapidNote.Clases;

namespace RapidNote.DAO.IDAOS
{
    public interface IDAOUsuario : IDAO
    {
        Entidad ConsultarLogin(Entidad usuario);
        void AgregarUsuario(Entidad usuario);
        Entidad ListarUsuario(Entidad usuario);
        Boolean InsertarToken(String correo, Entidad usuario);
    }
}
