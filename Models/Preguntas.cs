using System;
using System.Collections.Generic;
using System.Dynamic;
using Microsoft.VisualBasic.CompilerServices;
using System.Diagnostics;
using System.Timers;

namespace PreguntadORT_Chediex_Pascual.Models{

    public class Preguntas

    {
        private int _idPregunta;
        private int _idCategoria;
        private int _idDificultad;
        private string _enunciado;
        private string _foto;

        public Preguntas(int idCategoria int idDificultad, string enunciado, string foto)
        {
            _idCategoria=idCategoria;
            _idDificultad=idDificultad;
            _enunciado = enunciado;
            _foto=foto;
        }

        public Preguntas()
        {
            _idDificultad = 0;
            _nombre = "";
            _foto="";
        }

        public int IdPregunta
        {
            get{ return _idPregunta;}
            set{_idPregunta = value;}
        }
        
        public int IdCategoria
        {
            get{ return _idCategoria;}
            set{_idCategoria = value;}
        }

        public int IdDificultad
        {
            get{ return _idDificultad;}
            set{_idDificultad = value;}
        }

        public string Enunciado
        {
            get{ return _enunciado;}
            set{_enunciado = value;}
        }

        public string Foto
        {
            get{ return _foto;}
            set{_foto = value;}
        }
    }
}