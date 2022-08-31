using System;
using System.Collections.Generic;
using System.Dynamic;
using Microsoft.VisualBasic.CompilerServices;
using System.Diagnostics;
using System.Timers;
using System.Data.SqlClient;
using Dapper;

namespace PreguntadORT_Chediex_Pascual.Models{

    public static class Juego

    {
        static private string _username;
        static private int _puntajeActual;
        static private int _cantidadPreguntasCorrectas;
        private static List<Preguntas> _preguntas = new List<Preguntas>();
        private static List<Categorias> _categorias = new List<Categorias>();
        private static List<Dificultades> _dificultades = new List<Dificultades>();
        private static List<Respuestas> _respuestas = new List<Respuestas>();

        private static string _conectionString = 
        @"Server=A-PHZ2-AMI-014; DataBase=Qatar2022;Trusted_Connection=True;";

        public static string Username
        {
            get{ return _username;}
            set{_username = value;}
        }

        public static int PuntajeActual
        {
            get{ return _puntajeActual;}
            set{_puntajeActual = value;}
        }
        
        public static int CantidadPreguntasCorrectas
        {
            get{ return _cantidadPreguntasCorrectas;}
            set{_cantidadPreguntasCorrectas = value;}
        }

        public static List<Preguntas> ListaPreguntas
        {
            get{ return _preguntas;}
            set{_preguntas = value;}
        }

        public static List<Respuestas> ListaRespuestas
        {
            get{ return _respuestas;}
            set{_respuestas = value;}
        }
        public static void InicializarJuego()
        {
            _username = "";
            _puntajeActual = 0;
            _cantidadPreguntasCorrectas = 0;
        }
        public static void CargarPartida(string Username, int IdDificultad, int IdCategoria)
        {
            _username = Username;
            _preguntas = BD.ObtenerPreguntas(IdDificultad, IdCategoria);
            _respuestas = BD.ObtenerRespuestas(_preguntas);
        }
        public static List<Categorias> ObtenerCategorias()
        {
            _categorias = BD.ObtenerCategorias();
            return _categorias;
        }
        public static List<Dificultades> ObtenerDificultades()
        {
            _dificultades = BD.ObtenerDificultades();
            return _dificultades;
        }
        public static Preguntas ObtenerProximaPregunta()
        {
            int proxpreg = -1;
            
            if(proxpreg < _preguntas.Count())
            {
                proxpreg = proxpreg +1;
            }
            return BD.ObtenerPregunta(proxpreg);       
            
        }
        public static List<Respuestas> ObtenerProximasRespuestas(int IdPregunta)
        {
            return BD.ObtenerProximasRespuestas(IdPregunta);
        }
        public static int VerificarRespuestas(int IdPregunta, int IdRespuesta)
        {
            int correcta = 0;

            
            using(SqlConnection db = new SqlConnection(_conectionString))
            {
                string SQL = "SELECT Correcta FROM Preguntas WHERE IdRespuesta = @pIdRespuesta";
                correcta = db.Execute(SQL, new{pIdRespuesta = IdRespuesta});
                if(correcta == 1)
                {
                    _cantidadPreguntasCorrectas= _cantidadPreguntasCorrectas + 1;
                    _puntajeActual = _puntajeActual + 1;
                    /*--------HACER SWITCH DIFICULTAD------*/
                    string SQL2 = "DELETE FROM Preguntas WHERE IdPregunta = @pIdPregunta";
                    db.Execute(SQL2, new{pIdPregunta = IdPregunta});
                }
            }
            return correcta;

        }

    }
}