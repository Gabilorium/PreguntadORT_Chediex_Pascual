using System;
using System.Collections.Generic;
using System.Dynamic;
using Microsoft.VisualBasic.CompilerServices;
using System.Diagnostics;
using System.Timers;

namespace PreguntadORT_Chediex_Pascual.Models{

    public class Dificultades

    {
        private int _idDificultad;
        private string _nombre;

        public Dificultades(string nombre)
        {
            _nombre = nombre;
        }

        public Dificultades()
        {
            _idDificultad = 0;
            _nombre = "";
        }

        public int IdDificultad
        {
            get{ return _idDificultad;}
            set{_idDificultad = value;}
        }
        public string Nombre
        {
            get{ return _nombre;}
            set{_nombre = value;}
        }
    }
}