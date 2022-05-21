using APILocadora.Infra.Repositorio;
using APILocadora.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APILocadora.Servicos
{
    public class ServicoLocacao : IServicoLocacao
    {
        private readonly IRepositorioLocacao _repositorioLocacao;
        private readonly IRepositorioCliente _repositorioCliente;
        private readonly IRepositorioFilme _repositorioFilme;

        public ServicoLocacao(IRepositorioLocacao repositorioLocacao, IRepositorioCliente repositorioCliente, IRepositorioFilme repositorioFilme)
        {
            _repositorioLocacao = repositorioLocacao;
            _repositorioCliente = repositorioCliente;
            _repositorioFilme = repositorioFilme;
        }

        public Locacao ObterPor(int id)
        {
            return _repositorioLocacao.ObterPor(id);
        }

        public List<Locacao> Listar()
        {
            return _repositorioLocacao.Listar();
        }

        public bool Excluir(int id)
        {
            Locacao locacao = _repositorioLocacao.ObterPor(id);

            if (locacao == null)
            {
                //msg

                return false;
            }

            _repositorioLocacao.Excluir(locacao);

            return true;
        }

        public Locacao Salvar(Locacao locacao)
        {
            Locacao locacaoEncontrada = _repositorioLocacao.ObterPor(locacao.Id);

            Cliente cliente = _repositorioCliente.ObterPor(locacao.Id_Cliente);

            if (cliente == null)
            {
                //msg
                return null;
            }

            Filme filme = _repositorioFilme.ObterPor(locacao.Id_Filme);

            if (filme == null)
            {
                //msg
                return null;
            }

            if (locacaoEncontrada == null)
            {               

                Locacao novaLocacao = new Locacao() 
                {
                    Id = 0,
                    DataLocacao = locacao.DataLocacao,
                    Id_Cliente = cliente.Id,
                    Id_Filme = filme.Id,                   
                    
                };

                novaLocacao.DefinirDevolução(filme.Lancamento);

                _repositorioLocacao.Salvar(novaLocacao);

                return _repositorioLocacao.ObterPor(novaLocacao.Id);
            }
            else
            {
                locacaoEncontrada.DataLocacao = locacao.DataLocacao;
                locacaoEncontrada.Id_Cliente = locacao.Id_Cliente;
                locacaoEncontrada.Id_Filme = locacao.Id_Filme;

                locacaoEncontrada.DefinirDevolução(filme.Lancamento);
            }

            _repositorioLocacao.Salvar(locacaoEncontrada);

            return _repositorioLocacao.ObterPor(locacaoEncontrada.Id);

        }
    }
}