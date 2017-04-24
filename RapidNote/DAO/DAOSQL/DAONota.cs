﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RapidNote.DAO.IDAOS;
using System.Data.SqlClient;
using System.Data;
using RapidNote.Clases;
using RapidNote.Clases.Fabrica;

namespace RapidNote.DAO.DAOSQL
{
    public class DAONota : IDAONota
    {
        public List<Entidad> ListarNotas(Entidad usuario)
        {
            SqlCommand sqlcmd = new SqlCommand();
            Conexion connexion = new Conexion();
            List<Entidad> listaNotas = new List<Entidad>();
            Entidad nota = null;

            try
            {
                connexion.AbrirConexionBd();
                sqlcmd.Connection = connexion.ObjetoConexion();
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = "ListarNotas";
                sqlcmd.CommandTimeout = 2;

                SqlParameter parametroCorreo = new SqlParameter("@correoUsuario", (usuario as Usuario).Correo);
                sqlcmd.Parameters.Add(parametroCorreo);
                sqlcmd.ExecuteNonQuery();
                SqlDataReader sqlrd;
                sqlrd = sqlcmd.ExecuteReader();
                while (sqlrd.Read())
                {
                    nota = FabricaEntidad.CrearNota();
                    (nota as Nota).Idnota = int.Parse(sqlrd["idNota"].ToString());
                    (nota as Nota).Titulo = sqlrd["TITULO"].ToString();
                    (nota as Nota).Fechacreacion = DateTime.Parse(sqlrd["fechaCreacion"].ToString());
                    listaNotas.Add(nota);
                }
                return listaNotas;
            }
            catch (Exception E)
            {
                Console.WriteLine(E.Message);
                return listaNotas;
            }

            finally
            {
                connexion.CerrarConexionBd();
            }
        }


        public Entidad MostrarNota(Entidad nota)
        {
            SqlCommand sqlcmd = new SqlCommand();
            Conexion connexion = new Conexion();

            try
            {
                connexion.AbrirConexionBd();
                sqlcmd.Connection = connexion.ObjetoConexion();
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = "MostrarNota";
                sqlcmd.CommandTimeout = 2;

                SqlParameter parametroCorreo = new SqlParameter("@tituloNota", (nota as Nota).Titulo);
                sqlcmd.Parameters.Add(parametroCorreo);
                sqlcmd.ExecuteNonQuery();
                SqlDataReader sqlrd;
                sqlrd = sqlcmd.ExecuteReader();
                while (sqlrd.Read())
                {
                    (nota as Nota).Contenido = sqlrd["CONTENIDO"].ToString();
                    (nota as Nota).Fechacreacion = DateTime.Parse(sqlrd["fechaCreacion"].ToString());
                    (nota as Nota).Libreta.NombreLibreta = sqlrd["nombreLibreta"].ToString();
                    if (sqlrd["fechaModificacion"].ToString() != null)
                    {
                        (nota as Nota).Fechamodificacion = DateTime.Parse(sqlrd["fechaModificacion"].ToString());
                    }
                    //(nota as Nota).Libreta.NombreLibreta = sqlrd["nombreLibreta"].ToString();                    
                }
                return nota;
            }
            catch (Exception E)
            {
                Console.WriteLine(E.Message);
                return nota;
            }

            finally
            {
                connexion.CerrarConexionBd();
            }
        }


        public List<Entidad> ListarAjuntos(Entidad nota)
        {
            SqlCommand sqlcmd = new SqlCommand();
            Conexion connexion = new Conexion();
            List<Entidad> listaAdjuntos = new List<Entidad>();
            Entidad adjunto = null;

            try
            {
                connexion.AbrirConexionBd();
                sqlcmd.Connection = connexion.ObjetoConexion();
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = "listarAdjuntosPorNota";
                sqlcmd.CommandTimeout = 2;

                SqlParameter parametroCorreo = new SqlParameter("@tituloNota", (nota as Nota).Titulo);
                sqlcmd.Parameters.Add(parametroCorreo);
                sqlcmd.ExecuteNonQuery();
                SqlDataReader sqlrd;
                sqlrd = sqlcmd.ExecuteReader();
                while (sqlrd.Read())
                {
                    adjunto = FabricaEntidad.CrearAdjunto();
                    (adjunto as Adjunto).Titulo = sqlrd["TITULO"].ToString();
                    listaAdjuntos.Add(adjunto);
                }
                return listaAdjuntos;
            }
            catch (Exception E)
            {
                Console.WriteLine(E.Message);
                return listaAdjuntos;
            }

            finally
            {
                connexion.CerrarConexionBd();
            }
        }


        public List<Entidad> ListarEtiquetas(Entidad nota)
        {
            SqlCommand sqlcmd = new SqlCommand();
            Conexion connexion = new Conexion();
            List<Entidad> listaEtiquetas = new List<Entidad>();
            Entidad etiqueta = null;

            try
            {
                connexion.AbrirConexionBd();
                sqlcmd.Connection = connexion.ObjetoConexion();
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = "listarEtiquetasPorNota";
                sqlcmd.CommandTimeout = 2;

                SqlParameter parametroCorreo = new SqlParameter("@tituloNota", (nota as Nota).Titulo);
                sqlcmd.Parameters.Add(parametroCorreo);
                sqlcmd.ExecuteNonQuery();
                SqlDataReader sqlrd;
                sqlrd = sqlcmd.ExecuteReader();
                while (sqlrd.Read())
                {
                    etiqueta = FabricaEntidad.CrearEtiqueta();
                    (etiqueta as Etiqueta).Nombre = sqlrd["nombre"].ToString();
                    listaEtiquetas.Add(etiqueta);
                }
                return listaEtiquetas;
            }
            catch (Exception E)
            {
                Console.WriteLine(E.Message);
                return listaEtiquetas;
            }

            finally
            {
                connexion.CerrarConexionBd();
            }
        }


        public Entidad NuevaNota(Entidad nota)
        {
            SqlCommand sqlcmd = new SqlCommand();
            Conexion connexion = new Conexion();

            try
            {
                connexion.AbrirConexionBd();
                sqlcmd.Connection = connexion.ObjetoConexion();
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = "CrearNota";
                sqlcmd.CommandTimeout = 2;

                SqlParameter parametroTitulo = new SqlParameter("@tituloNota", (nota as Nota).Titulo);
                sqlcmd.Parameters.Add(parametroTitulo);
                SqlParameter parametroContenido = new SqlParameter("@contenidoNota", (nota as Nota).Contenido);
                sqlcmd.Parameters.Add(parametroContenido);
                SqlParameter parametroNombreL = new SqlParameter("@nombreLibreta", (nota as Nota).Libreta.NombreLibreta);
                sqlcmd.Parameters.Add(parametroNombreL);

                sqlcmd.ExecuteNonQuery();
                
                return nota;
            }
            catch (Exception E)
            {
                Console.WriteLine(E.Message);
                return nota;
            }

            finally
            {
                connexion.CerrarConexionBd();
            }
        }


        public List<Entidad> ListarLibretas(Entidad usuario)
        {
            SqlCommand sqlcmd = new SqlCommand();
            Conexion connexion = new Conexion();
            List<Entidad> listaLibretas = new List<Entidad>();
            Entidad libreta = null;

            try
            {
                connexion.AbrirConexionBd();
                sqlcmd.Connection = connexion.ObjetoConexion();
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = "ConsultarLibretas";
                sqlcmd.CommandTimeout = 2;

                SqlParameter parametroCorreo = new SqlParameter("@correoUsuario", (usuario as Usuario).Correo);
                sqlcmd.Parameters.Add(parametroCorreo);
                sqlcmd.ExecuteNonQuery();
                SqlDataReader sqlrd;
                sqlrd = sqlcmd.ExecuteReader();
                while (sqlrd.Read())
                {
                    libreta = FabricaEntidad.CrearLibreta();
                    (libreta as Libreta).Idlibreta = int.Parse(sqlrd["idLibreta"].ToString());
                    (libreta as Libreta).NombreLibreta = sqlrd["nombreLibreta"].ToString();
                    listaLibretas.Add(libreta);
                }
                return listaLibretas;
            }
            catch (Exception E)
            {
                Console.WriteLine(E.Message);
                return listaLibretas;
            }

            finally
            {
                connexion.CerrarConexionBd();
            }
        }


        public List<Entidad> BuscarNotasEtiqueta(Entidad usuario)
        {
            SqlCommand sqlcmd = new SqlCommand();
            Conexion connexion = new Conexion();
            List<Entidad> listaNotas = new List<Entidad>();
            Entidad nota = null;

            try
            {
                connexion.AbrirConexionBd();
                sqlcmd.Connection = connexion.ObjetoConexion();
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = "BuscarNotaEtiqueta";
                sqlcmd.CommandTimeout = 2;

                SqlParameter parametroFraseBusqueda = new SqlParameter("@contenidoBusqueda", usuario.Estado);
                sqlcmd.Parameters.Add(parametroFraseBusqueda);
                SqlParameter parametroCorreo = new SqlParameter("@correoUsuario", (usuario as Usuario).Correo);
                sqlcmd.Parameters.Add(parametroCorreo);
                
                sqlcmd.ExecuteNonQuery();
                SqlDataReader sqlrd;
                sqlrd = sqlcmd.ExecuteReader();
                while (sqlrd.Read())
                {
                    nota = FabricaEntidad.CrearNota();
                    (nota as Nota).Idnota = Convert.ToInt32(sqlrd["idNota"]);
                    (nota as Nota).Titulo = sqlrd["titulo"].ToString();
                    (nota as Nota).Fechacreacion = DateTime.Parse(sqlrd["fechaCreacion"].ToString());
                    listaNotas.Add(nota);
                }
                return listaNotas;
            }
            catch (Exception E)
            {
                Console.WriteLine(E.Message);
                return listaNotas;
            }

            finally
            {
                connexion.CerrarConexionBd();
            }
        }


        public List<Entidad> BuscarNotas(Entidad usuario)
        {
            SqlCommand sqlcmd = new SqlCommand();
            Conexion connexion = new Conexion();
            List<Entidad> listaNotas = new List<Entidad>();
            Entidad nota = null;

            try
            {
                connexion.AbrirConexionBd();
                sqlcmd.Connection = connexion.ObjetoConexion();
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = "BuscarNotaContenido";
                sqlcmd.CommandTimeout = 2;

                SqlParameter parametroFraseBusqueda = new SqlParameter("@contenidoBusqueda", usuario.Estado);
                sqlcmd.Parameters.Add(parametroFraseBusqueda);
                SqlParameter parametroCorreo = new SqlParameter("@correoUsuario", (usuario as Usuario).Correo);
                sqlcmd.Parameters.Add(parametroCorreo);

                sqlcmd.ExecuteNonQuery();
                SqlDataReader sqlrd;
                sqlrd = sqlcmd.ExecuteReader();
                while (sqlrd.Read())
                {
                    nota = FabricaEntidad.CrearNota();
                    (nota as Nota).Idnota = Convert.ToInt32(sqlrd["idNota"]);
                    (nota as Nota).Titulo = sqlrd["titulo"].ToString();
                    (nota as Nota).Fechacreacion = DateTime.Parse(sqlrd["fechaCreacion"].ToString());
                    listaNotas.Add(nota);
                }
                return listaNotas;
            }
            catch (Exception E)
            {
                Console.WriteLine(E.Message);
                return listaNotas;
            }

            finally
            {
                connexion.CerrarConexionBd();
            }
        }

        public int BuscarIdNota(Entidad nota)
        {
            SqlCommand sqlcmd = new SqlCommand();
            Conexion connexion = new Conexion();
            int aux = 0;

            try
            {
                connexion.AbrirConexionBd();
                sqlcmd.Connection = connexion.ObjetoConexion();
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = "BuscarIdNota";
                sqlcmd.CommandTimeout = 2;

                SqlParameter parametroTitulo = new SqlParameter("@tituloNota", (nota as Nota).Titulo);
                sqlcmd.Parameters.Add(parametroTitulo);

                sqlcmd.ExecuteNonQuery();
                SqlDataReader sqlrd;
                sqlrd = sqlcmd.ExecuteReader();
                while (sqlrd.Read())
                {

                    aux = int.Parse(sqlrd["IDNOTA"].ToString());

                }

                return aux;
            }
            catch (Exception E)
            {
                Console.WriteLine(E.Message);
                return aux;
            }

            finally
            {
                connexion.CerrarConexionBd();
            }
        }

        public Entidad BuscarNota(Entidad nota)
        {
            SqlCommand sqlcmd = new SqlCommand();
            Conexion connexion = new Conexion();
            //int aux = 0;

            try
            {
                connexion.AbrirConexionBd();
                sqlcmd.Connection = connexion.ObjetoConexion();
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = "BuscarNota";
                sqlcmd.CommandTimeout = 2;

                SqlParameter parametroTitulo = new SqlParameter("@idNota", (nota as Nota).Idnota);
                sqlcmd.Parameters.Add(parametroTitulo);

                sqlcmd.ExecuteNonQuery();
                SqlDataReader sqlrd;
                sqlrd = sqlcmd.ExecuteReader();
                while (sqlrd.Read())
                {

                    (nota as Nota).Contenido = sqlrd["CONTENIDO"].ToString();
                    (nota as Nota).Fechacreacion = DateTime.Parse(sqlrd["fechaCreacion"].ToString());
                    (nota as Nota).Libreta.NombreLibreta = sqlrd["nombreLibreta"].ToString();
                    (nota as Nota).Titulo = sqlrd["titulo"].ToString();
                    if (sqlrd["fechaModificacion"].ToString() != null)
                    {
                        (nota as Nota).Fechamodificacion = DateTime.Parse(sqlrd["fechaModificacion"].ToString());
                    }

                }

                return nota;
            }
            catch (Exception E)
            {
                Console.WriteLine(E.Message);
                return nota;
            }

            finally
            {
                connexion.CerrarConexionBd();
            }
        }


        public Entidad EditarNota(Entidad nota)
        {
            SqlCommand sqlcmd = new SqlCommand();
            Conexion connexion = new Conexion();

            try
            {
                connexion.AbrirConexionBd();
                sqlcmd.Connection = connexion.ObjetoConexion();
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = "EditarNota";
                sqlcmd.CommandTimeout = 2;

                SqlParameter parametroTitulo = new SqlParameter("@tituloNota", (nota as Nota).Titulo);
                sqlcmd.Parameters.Add(parametroTitulo);
                SqlParameter parametroContenido = new SqlParameter("@contenidoNota", (nota as Nota).Contenido);
                sqlcmd.Parameters.Add(parametroContenido);
                SqlParameter parametroIdNota = new SqlParameter("@idNota", (nota as Nota).Idnota);
                sqlcmd.Parameters.Add(parametroIdNota);

                sqlcmd.ExecuteNonQuery();

                return nota;
            }
            catch (Exception E)
            {
                Console.WriteLine(E.Message);
                return nota;
            }

            finally
            {
                connexion.CerrarConexionBd();
            }
        }


        public Entidad BorrarNota(Entidad nota)
        {
            SqlCommand sqlcmd = new SqlCommand();
            Conexion connexion = new Conexion();

            try
            {
                connexion.AbrirConexionBd();
                sqlcmd.Connection = connexion.ObjetoConexion();
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = "BorrarNota";
                sqlcmd.CommandTimeout = 2;

                SqlParameter parametroIdNota = new SqlParameter("@idNota", (nota as Nota).Idnota);
                sqlcmd.Parameters.Add(parametroIdNota);

                sqlcmd.ExecuteNonQuery();

                return nota;
            }
            catch (Exception E)
            {
                Console.WriteLine(E.Message);
                return nota;
            }

            finally
            {
                connexion.CerrarConexionBd();
            }
        }

    }
}