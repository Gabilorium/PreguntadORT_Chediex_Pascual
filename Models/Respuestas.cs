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

        public Respuestas(int idPregunta, int opcion, string contenido, bool correcta)
        {
            _idPregunta = idPregunta;
            _opcion = opcion;
            _contenido = contenido;
            _correcta = correcta;
        }

        public Respuestas()
        {
            _idPregunta = 0;
            _opcion = 0;
            _contenido = "";
            _correcta = false;
            _foto = "";
        }
        public int IdRespuesta
        {
            get{ return _idRespuesta;}
            set{_idRespuesta = value;}
        }
        public int IdPregunta
        {
            get{ return _idPregunta;}
            set{_idPregunta = value;}
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