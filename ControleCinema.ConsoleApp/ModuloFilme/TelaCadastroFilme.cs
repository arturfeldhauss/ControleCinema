using ControleCinema.ConsoleApp.Compartilhado;
using ControleCinema.ConsoleApp.ModuloGenero;
using System;
using System.Collections.Generic;

namespace ControleCinema.ConsoleApp.ModuloFilme
{
    public class TelaCadastroFilme : TelaBase, ITelaCadastravel
    {
        private readonly IRepositorio<Filme> _repositorioTitulo;
        private readonly Notificador _notificador;

        public TelaCadastroFilme(IRepositorio<Filme> repositorioTitulo, Notificador notificador)
            : base("Cadastro de Titulo de Filme")
        {
            _repositorioTitulo = repositorioTitulo;
            _notificador = notificador;
        }

        public void Inserir()
        {
            MostrarSessao("Cadastro de Titulo de Filme");

            Filme novoFilme = ObterFilme();

            
            

            _notificador.ApresentarMensagem("Titulo de Filme cadastrado com sucesso!", TipoMensagem.Sucesso);
        }

        public void Editar()
        {
            MostrarSessao("Editando Titulo de Filme");

            bool temFilmesCadastrados = VisualizarRegistros("Pesquisando");

            if (temFilmesCadastrados == false)
            {
                _notificador.ApresentarMensagem("Nenhum Titulo de filme cadastrado para editar.", TipoMensagem.Atencao);
                return;
            }

            int numeroTitulo = ObterNumeroTitulo();

            Filme tituloAtualizado = ObterFilme();

            bool conseguiuEditar = _repositorioTitulo.Editar(numeroTitulo, tituloAtualizado);

            if (!conseguiuEditar)
                _notificador.ApresentarMensagem("Não foi possível editar.", TipoMensagem.Erro);
            else
                _notificador.ApresentarMensagem("Titulo de Filme editado com sucesso!", TipoMensagem.Sucesso);
        }

        public void Excluir()
        {
            MostrarSessao("Excluindo Titulo de Filme");

            bool temFuncionariosRegistrados = VisualizarRegistros("Pesquisando");

            if (temFuncionariosRegistrados == false)
            {
                _notificador.ApresentarMensagem("Nenhum titulo de filme cadastrado para excluir.", TipoMensagem.Atencao);
                return;
            }

            int numeroTitulo = ObterNumeroTitulo();

            bool conseguiuExcluir = _repositorioTitulo.Excluir(numeroTitulo);

            if (!conseguiuExcluir)
                _notificador.ApresentarMensagem("Não foi possível excluir.", TipoMensagem.Erro);
            else
                _notificador.ApresentarMensagem("Gênero de Filme excluído com sucesso1", TipoMensagem.Sucesso);
        }

        public bool VisualizarRegistros(string tipoVisualizacao)
        {
            if (tipoVisualizacao == "Tela")
                MostrarSessao("Visualização de Titulo de Filme");

            List<Filme> filmes = _repositorioTitulo.SelecionarTodos();
 
            if (filmes.Count == 0)
            {
                _notificador.ApresentarMensagem("Nenhum Titulo de filme disponível.", TipoMensagem.Atencao);
                return false;
            }

            foreach (Filme f in filmes)
                Console.WriteLine(f.ToString());

            Console.ReadLine();

            return true;
        }

        private Filme ObterFilme()
        {
            Console.Write("Digite a descrição do titulo: ");
            string descricaoTitulo = Console.ReadLine();

            return new Filme(descricaoTitulo);
        }

        public int ObterNumeroTitulo()
        {
            int numeroRegistro;
            bool numeroRegistroEncontrado;

            do
            {
                Console.Write("Digite o ID do titulo de filme que deseja editar: ");
                numeroRegistro = Convert.ToInt32(Console.ReadLine());

                numeroRegistroEncontrado = _repositorioTitulo.ExisteRegistro(numeroRegistro);

                if (numeroRegistroEncontrado == false)
                    _notificador.ApresentarMensagem("ID do Titulo de filme não foi encontrado, digite novamente", TipoMensagem.Atencao);

            } while (numeroRegistroEncontrado == false);

            return numeroRegistro;
        }
    }
}
