﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RapidNote.Clases;
using RapidNote.DAO.IDAOS;
using RapidNote.DAO.DAOFactory;

namespace RapidNote.Logica.Comandos.Nota
{
    public class ComandoMostrarNota : Comando<Entidad>
    {
        private Entidad nota;
        
        public ComandoMostrarNota(Entidad _nota)
        {
            nota = _nota;
        }
        
        public override Entidad Ejecutar()
        {
            IDAONota accion = FabricaDAO.CrearFabricaDeDAO(1).CrearDAONota();

            nota = accion.MostrarNota(nota);

            return nota;
            
        }

        
    }
}