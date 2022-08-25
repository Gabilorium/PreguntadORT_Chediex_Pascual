using System;
using System.Collections.Generic;
using System.Dynamic;
using Microsoft.VisualBasic.CompilerServices;
using System.Diagnostics;
using System.Timers;

namespace PreguntadORT_Chediex_Pascual.Models{

    public class Categorias

    {
        private int _idCategoria;
        private string _nombre;
        private string _foto;

        public Categorias(string nombre, string foto)
        {
            _nombre = nombre;
            _foto=foto;
        }

        public Categorias()
        {
            _idCategoria = 0;
            _nombre = "";
            _foto="";
        }

        public int IdCategoria
        {
            get{ return _idCategoria;}
            set{_idCategoria = value;}
        }
        public string Nombre
        {
            get{ return _nombre;}
            set{_nombre = value;}
        }
        public string Foto
        {
            get{ return _foto;}
            set{_foto = value;}
        }
    }
}