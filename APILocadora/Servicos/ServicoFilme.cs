using APILocadora.Infra.Repositorio;
using APILocadora.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APILocadora.Servicos
{
    public class ServicoFilme : IServicoFilme
    {
        private readonly IRepositorioFilme _repositorioFilme;

        public ServicoFilme(IRepositorioFilme repositorioFilme) 
        {
            _repositorioFilme = repositorioFilme; 
        }

        public Filme ObterPor(int id)
        {
            return _repositorioFilme.ObterPor(id);
        }

        public List<Filme> Listar()
        {
            return _repositorioFilme.Listar();
        }

        public Filme Salvar(Filme filme)
        {
            Filme filmeEncontrado = _repositorioFilme.ObterPor(filme.Id);

            if (filmeEncontrado == null)
            {
                Filme novoFilme = new Filme()
                {
                    Id = 0,
                    Titulo = filme.Titulo,
                    ClassificacaoIndicativa = filme.ClassificacaoIndicativa,
                    Lancamento = filme.Lancamento
                };

                _repositorioFilme.Salvar(novoFilme);

                return _repositorioFilme.ObterPor(novoFilme.Titulo, novoFilme.Lancamento);
            }
            else
            {
                filmeEncontrado.Titulo = filme.Titulo;
                filmeEncontrado.ClassificacaoIndicativa = filme.ClassificacaoIndicativa;
                filmeEncontrado.Lancamento = filme.Lancamento;
            }

            _repositorioFilme.Salvar(filmeEncontrado);

            return _repositorioFilme.ObterPor(filmeEncontrado.Id);
        }

        public bool Excluir(int id)
        {
            Filme filme = _repositorioFilme.ObterPor(id);

            if (filme == null)
            {
                //msg
                return false;
            }

            if (filme.Locacoes.Count >= 1)
            {
                //msg

                return false;
            }

            _repositorioFilme.Excluir(filme);

            return true;
        }
    }
}