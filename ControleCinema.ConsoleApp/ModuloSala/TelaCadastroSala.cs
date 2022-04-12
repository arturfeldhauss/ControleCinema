using ControleCinema.ConsoleApp.Compartilhado;
using System;
using System.Collections.Generic;




    public class TelaCadastroSala : TelaBase, ITelaCadastravel
{
    private readonly IRepositorio<Sala> _repositorioSala;
    private readonly Notificador _notificador;

    public TelaCadastroSala(IRepositorio<Sala> repositorioSala, Notificador notificador)
        : base("Cadastro de salas")
    {
        _repositorioSala = repositorioSala;
        _notificador = notificador;
    }

    

    public void Inserir()
    {
        MostrarSessao("Cadastro de Sala");

        Sala novaSala = ObterSala();

        _repositorioSala.Inserir(novaSala);

        _notificador.ApresentarMensagem("Sala cadastrado com sucesso!", TipoMensagem.Sucesso);
    }

    public void EditarSala()
    {
        MostrarSessao("Editando Sala");

        bool temSalaCadastradas = VisualizarRegistros("Pesquisando");

        if (temSalaCadastradas == false)
        {
            _notificador.ApresentarMensagem("Nenhuma sala cadastrada para editar.", TipoMensagem.Atencao);
            return;
        }

        int numeroSala = ObterNumeroRegistro();

        Sala salaAtualizada = ObterSala();

        bool conseguiuEditar = _repositorioSala.Editar(numeroSala, salaAtualizada);

        if (!conseguiuEditar)
            _notificador.ApresentarMensagem("Não foi possível editar.", TipoMensagem.Erro);
        else
            _notificador.ApresentarMensagem("Sala editado com sucesso!", TipoMensagem.Sucesso);
    }

    public void ExcluirSala()
    {
        MostrarSessao("Excluindo Sala");

        bool temSalaRegistrada = VisualizarRegistros("Pesquisando");

        if (temSalaRegistrada == false)
        {
            _notificador.ApresentarMensagem("Nenhuma sala cadastrado para excluir.", TipoMensagem.Atencao);
            return;
        }

        int numeroSala = ObterNumeroRegistro();

        bool conseguiuExcluir = _repositorioSala.Excluir(numeroSala);

        if (!conseguiuExcluir)
            _notificador.ApresentarMensagem("Não foi possível excluir.", TipoMensagem.Erro);
        else
            _notificador.ApresentarMensagem("Sala excluída com sucesso1", TipoMensagem.Sucesso);
    }

    public bool VisualizarRegistros(string tipoVisualizacao)
    {
        if (tipoVisualizacao == "Tela")
            MostrarSessao("Visualização de Salas");

        List<Sala> salas = _repositorioSala.SelecionarTodos();

        if (salas.Count == 0)
        {
            _notificador.ApresentarMensagem("Nenhuma sala disponível.", TipoMensagem.Atencao);
            return false;
        }

        foreach (Sala sala in salas)
            Console.WriteLine(sala.ToString());

        Console.ReadLine();

        return true;
    }

    private Sala ObterSala()
    {
        Console.Write("Digite o numero da sala: ");
        string numero = Console.ReadLine();

        Console.Write("Digite a capacidade da sala: ");
        string capacidade = Console.ReadLine();

        Console.Write("Digite o filme que ira passar: ");
        string filme = Console.ReadLine();

        return new Sala(numero, capacidade, filme);
    }

    public int ObterNumeroRegistro()
    {
        int numeroRegistro;
        bool numeroRegistroEncontrado;

        do
        {
            Console.Write("Digite o numero da sala que deseja editar: ");
            numeroRegistro = Convert.ToInt32(Console.ReadLine());

            numeroRegistroEncontrado = _repositorioSala.ExisteRegistro(numeroRegistro);

            if (numeroRegistroEncontrado == false)
                _notificador.ApresentarMensagem("O numero da sala não foi encontrado, digite novamente", TipoMensagem.Atencao);

        } while (numeroRegistroEncontrado == false);

        return numeroRegistro;
    }

    public void Editar()
    {
        throw new NotImplementedException();
    }

    public void Excluir()
    {
        throw new NotImplementedException();
    }
}

