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
        private int _puntaje;
        private DateTime _dia;

        public ScoreBoard(string username, int puntaje, DateTime dia)
        {
            _username = username;
            _puntaje = puntaje;
            _dia = dia;
        }

        public ScoreBoard()
        {
            _username = "";
            _puntaje = 0;
            _dia = new DateTime();
           
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

        public int Puntaje
        {
            get{ return _puntaje;}
            set{_puntaje = value;}
        }
        public DateTime Dia
        {
            get{ return _dia;}
            set{_dia = value;}
        }
    }
}