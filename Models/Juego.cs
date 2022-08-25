using System;
using System.Collections.Generic;
using System.Dynamic;
using Microsoft.VisualBasic.CompilerServices;
using System.Diagnostics;
using System.Timers;
using System.Data.SqlClient;
using Dapper;

namespace PreguntadORT_Chediex_Pascual.Models{

    public class Juego

    {
        static private string _username;
        static private int _puntajeActual;
        static private int _cantidadPreguntasCorrectas;
        private static List<Preguntas> _preguntas = new List<Preguntas>();
        private static List<Respuestas> _respuestas = new List<Respuestas>();
        public Juego(string username, int puntajeActual, int cantidadPreguntasCorrectas, List<Preguntas> preguntas, List<Respuestas> respuestas)
        {
            _username = username;
            _puntajeActual = puntajeActual;
            _cantidadPreguntasCorrectas = cantidadPreguntasCorrectas;
            _preguntas = preguntas;
            _respuestas = respuestas;
        }

        public Juego()
        {
            _username = "";
            _puntajeActual = 0;
            _cantidadPreguntasCorrectas = 0;
        }

        public string Username
        {
            get{ return _username;}
            set{_username = value;}
        }

        public int PuntajeActual
        {
            get{ return _puntajeActual;}
            set{_puntajeActual = value;}
        }
        
        public int CantidadPreguntasCorrectas
        {
            get{ return _cantidadPreguntasCorrectas;}
            set{_cantidadPreguntasCorrectas = value;}
        }

        public List<Preguntas> ListaPreguntas
        {
            get{ return _preguntas;}
            set{_preguntas = value;}
        }

        public List<Respuestas> ListaRespuestas
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
            _preguntas = BD.ObtenerPreguntas(IdDificultad, IdCategoria);
            _respuestas = BD.ObtenerRespuestas(_preguntas);
        }
        public static void ObtenerCategorias()
        {
            BD.ObtenerCategorias();
        }
        public static void ObtenerDificultades()
        {
            BD.ObtenerDificultades();
        }
        public static void ObtenerProximaPregunta()
        {
            BD.ProximaPregunta();
        }
        public static void ObtenerProximasRespuestas(int IdPregunta)
        {
            BD.ObtenerProximasRespuestas(IdPregunta);
        }
        public static bool VerificarRespuestas(int IdPregunta, int IdRespuesta)
        {
            bool correcta = false;

            
            using(SqlConnection db = new SqlConnection(_conectionString))
            {
                string SQL = "SELECT Correcta FROM Preguntas WHERE IdRespuesta = @pIdRespuesta";
                correcta = db.Execute(SQL, new{pIdRespuesta = IdRespuesta});
                if(correcta == true)
                {
                    _cantidadPreguntasCorrectas= _cantidadPreguntasCorrectas + 1;
                    _puntajeActual = _puntajeActual + 1;
                    /*--------HACER SWITCH DIFICULTAD------*/
                    string SQL2 = "DELETE FROM Preguntas WHERE IdPregunta = @pIdPregunta";
                    using(SqlConnection db = new SqlConnection(_conectionString))
                    {
                        db.Execute(SQL2, new{pIdPregunta = IdPregunta});
                    }
                }
            }
            return correcta;

        }

    }
}