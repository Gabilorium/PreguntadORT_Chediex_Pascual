using System;
using System.Collections.Generic;
using System.Dynamic;
using Microsoft.VisualBasic.CompilerServices;
using System.Diagnostics;
using System.Data.SqlClient;
using Dapper;

namespace PreguntadORT_Chediex_Pascual.Models{

    public class BD
    {
        private static List<Preguntas> _ListaPreguntas = new List<Preguntas>();
        private static List<Respuestas> _ListaRespuestas = new List<Respuestas>();
        private static List<Categorias> _ListaCategorias = new List<Categorias>();
        private static List<Dificultades> _ListaDificultades = new List<Dificultades>();
        private static string _conectionString = 
        @"Server=A-PHZ2-AMI-014; DataBase=Qatar2022;Trusted_Connection=True;";
        public static List<Categorias>  ObtenerCategorias()
        {
            using(SqlConnection db = new SqlConnection(_conectionString))
            {
                string SQL = "SELECT * FROM Categorias";
                _ListaCategorias = db.Query<Categorias>(SQL).ToList();
            }
            return _ListaCategorias;
        }
        public static List<Dificultades>  ObtenerDificultades()
        {
            using(SqlConnection db = new SqlConnection(_conectionString))
            {
                string SQL = "SELECT * FROM Dificultades";
                _ListaDificultades = db.Query<Dificultades>(SQL).ToList();
            }
            return _ListaDificultades;
        }
        public static List<Preguntas> ObtenerPreguntas(int IdDificultad, int IdCategoria)
        {
            /*if(IdDificultad != -1 && IdCategoria != -1)
            {
                using(SqlConnection db = new SqlConnection(_conectionString))
                {
                    string SQL = "SELECT * FROM Preguntas WHERE IdCategoria = @pIdCategoria AND IdDificultad = @pIdDificultad";
                    _ListaPreguntas = db.Query<Preguntas>(SQL, new{pIdCategoria = IdCategoria, pIdDificultad = IdDificultad}).ToList();
                }
            }
            else if(IdDificultad != -1 && IdCategoria == -1)
            {
                using(SqlConnection db = new SqlConnection(_conectionString))
                {
                    string SQL = "SELECT * FROM Preguntas WHERE IdCategoria = @pIdCategoria";
                    _ListaPreguntas = db.Query<Preguntas>(SQL, new{pIdCategoria = IdCategoria}).ToList();
                }
            }
            else if(IdDificultad == -1 && IdCategoria != -1)
            {
                using(SqlConnection db = new SqlConnection(_conectionString))
                {
                    string SQL = "SELECT * FROM Preguntas WHERE IdDificultad = @pIdDificultad";
                    _ListaPreguntas = db.Query<Preguntas>(SQL, new{pIdDificultad = IdDificultad}).ToList();
                }
            }
            else if(IdDificultad == -1 && IdCategoria == -1)
            {
                using(SqlConnection db = new SqlConnection(_conectionString))
                {
                    string SQL = "SELECT * FROM Preguntas";
                    _ListaPreguntas = db.Query<Preguntas>(SQL).ToList();
                }
            }*/
             using(SqlConnection db = new SqlConnection(_conectionString))
                {
                    string SQL = "SELECT * FROM Preguntas";
                    string connector = " WHERE ";
                    if(IdCategoria != -1)
                    {
                        SQL = SQL + connector + "IdCategoria = @pIdCategoria";
                        connector = " AND ";
                    }
                    if(IdDificultad != -1)
                    {
                        SQL = SQL + connector + "IdDificultad = @pIdDificultad";
                    }
                    SQL = SQL + " order by NEWID()";
                    _ListaPreguntas = db.Query<Preguntas>(SQL, new{pIdCategoria = IdCategoria, pIdDificultad = IdDificultad}).ToList();
                }
            return _ListaPreguntas;
        }
        public static Preguntas ObtenerPregunta(int IdPregunta)
        {
            Preguntas pregunta;  
            using(SqlConnection db = new SqlConnection(_conectionString))
            {
                string SQL = "SELECT * FROM Preguntas WHERE IdPregunta = @pIdPregunta";
                pregunta= db.QueryFirstOrDefault<Preguntas>(SQL, new{pIdPregunta = IdPregunta});
            }
            return pregunta;
        }
        public static List<Respuestas> ObtenerRespuestas(List<Preguntas> IdPregunta)
        {
            
            using(SqlConnection db = new SqlConnection(_conectionString))
            {
                string SQL = "SELECT * FROM Respuestas WHERE IdPregunta = @pIdPregunta";
                _ListaRespuestas = db.Query<Respuestas>(SQL, new{pIdPregunta = IdPregunta}).ToList();
            }
            return _ListaRespuestas;
        }
        public static List<Respuestas> ObtenerProximasRespuestas(int IdPregunta)
        {
            using(SqlConnection db = new SqlConnection(_conectionString))
            {
                string SQL = "SELECT * FROM Respuestas WHERE IdPregunta = @pIdPregunta";
                _ListaRespuestas = db.Query<Respuestas>(SQL, new{pIdPregunta = IdPregunta}).ToList();
            }
            return _ListaRespuestas;
        }
    }
}