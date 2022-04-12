using ControleCinema.ConsoleApp.Compartilhado;
using System;

namespace ControleCinema.ConsoleApp.ModuloFilme
{
    public class Filme : EntidadeBase
    {

        public string Titulo { get; set; }


        public Filme(string titulo)
        {
            Titulo = titulo;
        }


    }
}

