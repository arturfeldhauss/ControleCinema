using System;



using ControleCinema.ConsoleApp.Compartilhado;


public class Sessao : EntidadeBase
{


    private readonly string _filme;
    private readonly string _ingresso;
    

    public string numero { get => _ingresso; }

    public Sessao(string numero, string ingresso, string filme)
    {
        _ingresso = ingresso;
        _filme = filme;
    }



}
