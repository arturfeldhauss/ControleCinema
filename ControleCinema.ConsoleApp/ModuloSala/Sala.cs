using System;

/// <summary>
/// Summary description for Class1
/// </summary>
using ControleCinema.ConsoleApp.Compartilhado;


public class Sala : EntidadeBase
{


    private readonly string _numero;
    private readonly string _capacidade;
    private readonly string _filme;

    public string numero { get => _numero; }

    public Sala(string numero, string capacidade, string filme)
    {
        _numero = numero;
        _capacidade = capacidade;
        _filme = filme;
    }



}


