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
        private static List<ScoreBoard> _ListaScoreBoard = new List<ScoreBoard>();
        private static string _conectionString = 
        @"Server=A-PHZ2-CIDI-026; DataBase=PreguntadOrt;Trusted_Connection=True;";
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
            using(SqlConnection db = new SqlConnection(_conectionString))
            {
                string SQL = "SELECT * FROM Preguntas";
                string connector = " WHERE ";
                if(IdDificultad != -1)
                {
                    SQL = SQL + connector + "IdDificultad = @pIdDificultad";
                    connector = " AND ";
                }
                if(IdCategoria != -1)
                {
                    SQL = SQL + connector + "IdCategoria = @pIdCategoria";
                    
                }
                SQL = SQL + " order by NEWID()";
                _ListaPreguntas = db.Query<Preguntas>(SQL, new{pIdDificultad = IdDificultad, pIdCategoria = IdCategoria}).ToList();
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
        public static List<Respuestas> ObtenerRespuestas(List<Preguntas> preguntas)
        {
            List<Respuestas> listarespuestas = new List<Respuestas>();
            foreach (Preguntas preg in preguntas)
            {
                string SQL = "SELECT * FROM Respuestas WHERE IdPregunta = @pIdPregunta";
                using(SqlConnection db = new SqlConnection(_conectionString))
                {

                    listarespuestas.AddRange(db.Query<Respuestas>(SQL, new{pIdPregunta = preg.IdPregunta}));
                }
            }
            return listarespuestas;
            
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
        public static void IsertarScoreboard(ScoreBoard score)
        {
            string SQL = "INSERT INTO ScoreBoard(Username,Puntaje,Dia) VALUES (@pUsername, @pPuntaje, @pDia)";
            using(SqlConnection db = new SqlConnection(_conectionString))
            {
                db.Execute(SQL, new{pUsername = score.Username, pPuntaje = score.Puntaje, pDia = score.Dia});
            }
        }
        public static List<ScoreBoard> ObtenerScoreBoard()
        {
            using(SqlConnection db = new SqlConnection(_conectionString))
            {
                string SQL = "SELECT * FROM ScoreBoard ORDER BY Puntaje desc";
                _ListaScoreBoard = db.Query<ScoreBoard>(SQL).ToList();
            }
            return _ListaScoreBoard;
        }
        public static void AgregarPregunta(Preguntas preg)
        {
            string SQL = "INSERT INTO Preguntas(IdCategoria, IdDificultad, Enunciado, Foto) VALUES (@pCategoria, @pDificultad, @pEnunciado, @pfoto); ";
            using(SqlConnection db = new SqlConnection(_conectionString))
            {
                db.Execute(SQL, new{pCategoria = preg.IdCategoria, pDificultad = preg.IdDificultad, pEnunciado = preg.Enunciado, pfoto = preg.Foto});
            }
            //select del maximo id (cambiar  SELECT SCOPE_IDENTITY())
        }
        public static int GetIdPregunta(Preguntas preg)
        {
            string SQL = "SELECT MAX(IdPRegunta) FROM Preguntas; ";
            using(SqlConnection db = new SqlConnection(_conectionString))
            {
                return db.Execute(SQL);
            }
            //select del maximo id (cambiar  SELECT SCOPE_IDENTITY())
        }
        public static void AgregarRespuesta(Respuestas resp)
        {
            string SQL = "INSERT INTO Respuestas(IdPregunta, Opcion, Contenido, Correcta) VALUES (@pIdPregunta, @pOpcion, @pContenido, @pCorrecta)";
            using(SqlConnection db = new SqlConnection(_conectionString))
            {
                db.Execute(SQL, new{pIdPregunta = resp.IdPregunta, pOpcion = resp.Opcion, pContenido = resp.Contenido, pCorrecta = resp.Correcta});
            }
        }
        public static void EliminarPregunta(int IdPregunta)
        {
            string SQL = "DELETE FROM Preguntas WHERE IdPregunta = @pIdPregunta;";
            using(SqlConnection db = new SqlConnection(_conectionString))
            {
                db.Execute(SQL, new{pIdPregunta = IdPregunta});
            }
        }
    }
}