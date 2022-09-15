using System;
using System.Collections.Generic;
using System.Dynamic;
using Microsoft.VisualBasic.CompilerServices;
using System.Diagnostics;
using System.Timers;
using System.Data.SqlClient;

namespace PreguntadORT_Chediex_Pascual.Models
{
    public class ScoreBoard

    {
        private int _idPuntaje;
        private string _username;
        private int _puntajeActual;
        private DateTime _fecha;

        public ScoreBoard(string username, int puntajeActual, DateTime fecha)
        {
            _username = username;
            _puntajeActual = puntajeActual;
            _fecha = fecha;
        }

        public ScoreBoard()
        {
            _username = "";
            _puntajeActual = 0;
            DateTime fecha = DateTime.Today;
            _fecha = fecha;
        }
        public int IdPuntaje
        {
            get{ return _idPuntaje;}
            set{_idPuntaje = value;}
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
        public DateTime Fecha
        {
            get{ return _fecha;}
            set{_fecha = value;}
        }
    }
}