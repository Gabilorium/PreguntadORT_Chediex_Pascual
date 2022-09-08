using System;
using System.Collections.Generic;
using System.Dynamic;
using Microsoft.VisualBasic.CompilerServices;
using System.Diagnostics;
using System.Timers;
using System.Data.SqlClient;

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
            Preguntas preg = new Preguntas();
            for (int i = 0; i < _preguntas.Count(); i++)
            {
                preg = _preguntas[i];
            }
            return preg;
        }
        public static List<Respuestas> ObtenerProximasRespuestas(int IdPregunta)
        {
            if(_preguntas.Count() > 0)
            {
                return BD.ObtenerProximasRespuestas(IdPregunta);
            }
            else
            {
                return null;
            }

        }
        public static bool VerificarRespuestas(int IdPregunta, int IdRespuesta, int IdDificultad)
        {
            for(int i = 0; i<_preguntas.Count(); i++)
            {
                if(_preguntas[i].IdPregunta == IdPregunta)
                {
                    _preguntas.RemoveAt(i);
                }
            }
            foreach (Respuestas item in _respuestas)
            {
                if(item.IdRespuesta == IdRespuesta){
                    if(item.Correcta == true){
                        switch(IdDificultad){
                            case 1:
                            _puntajeActual += 100;
                            break;
                            case 2:
                            _puntajeActual += 200;
                            break;
                            case 3:
                            _puntajeActual += 300;
                            break;
                        }
                        _cantidadPreguntasCorrectas++;
                        return true;
                    }
                }
            }
            return false;
        }

    }
}