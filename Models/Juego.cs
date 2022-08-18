using System;
using System.Collections.Generic;
using System.Dynamic;
using Microsoft.VisualBasic.CompilerServices;
using System.Diagnostics;
using System.Timers;

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

        static void InicializarJuego()
        {
            _username = "";
            _puntajeActual = 0;
            _cantidadPreguntasCorrectas = 0;
        }
        static void ObtenerCategorias()
        {
            BD.ObtenerCategorias();
        }
        static void ObtenerDificultades()
        {
            BD.ObtenerDificultades();
        }
        static void CargarPartida(string username, int dificultad, int categoria)
        {
            _preguntas = BD.ObtenerPreguntas(dificultad, categoria);
            _respuestas = BD.ObtenerRespuestas(_preguntas);
        }
        static void ProximaPregunta()
        {
            Random rand = new Random();
            int i = rand.Next();

        }
        

    }
}