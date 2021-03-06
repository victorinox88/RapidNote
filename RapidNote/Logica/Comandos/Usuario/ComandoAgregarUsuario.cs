﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RapidNote.Clases;
using RapidNote.DAO.DAOFactory;
using RapidNote.DAO.IDAOS;

namespace RapidNote.Logica.Comandos.usuario
{
    public class ComandoAgregarUsuario : Comando<Entidad>
    {
        private Entidad usuario;
        

        public ComandoAgregarUsuario(Entidad _usuario)
        {
            usuario = _usuario;
        }

        public override Entidad Ejecutar()
        {
            IDAOUsuario accion = FabricaDAO.CrearFabricaDeDAO(1).CrearDAOUsuario();

            accion.AgregarUsuario(usuario);

            return entidad;
        }
    }
}