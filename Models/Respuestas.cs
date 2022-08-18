using System;
using System.Collections.Generic;
using System.Dynamic;
using Microsoft.VisualBasic.CompilerServices;
using System.Diagnostics;
using System.Timers;

namespace PreguntadORT_Chediex_Pascual.Models{

    public class Respuestas

    {
        private int _idRespuesta;
        private int _idPregunta;
        private int _opcion;
        private string _contenido;
        private bool _correcta;
        private string _foto;

        public Respuestas(int idPregunta, int opcion, string contenido, bool correcta, string foto)
        {
            _idCategoria = idPregunta;
            _opcion = opcion;
            _contenido = contenido;
            _correcta = correcta;
            _foto = foto;
        }

        public Respuestas()
        {
            _idDificultad = 0;
            _nombre = "";
            _foto="";
        }

        public int IdPregunta
        {
            get{ return _idRespuesta;}
            set{_idRespuesta = value;}
        }

        public int Opcion
        {
            get{ return _opcion;}
            set{_opcion = value;}
        }
        
        public string Contenido
        {
            get{ return _contenido;}
            set{_contenido = value;}
        }

        public bool Correcta
        {
            get{ return _correcta;}
            set{_correcta = value;}
        }

        public string Foto
        {
            get{ return _foto;}
            set{_foto = value;}
        }
    }
}