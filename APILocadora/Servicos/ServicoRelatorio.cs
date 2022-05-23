using APILocadora.Infra.Repositorio;
using APILocadora.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APILocadora.Servicos
{
    public class ServicoRelatorio : IServicoRelatorio
    {
        private readonly IRepositorioLocacao _repositorioLocacao;
        private readonly IRepositorioCliente _repositorioCliente;
        private readonly IRepositorioFilme _repositorioFilme;

        public ServicoRelatorio(IRepositorioLocacao repositorioLocacao, IRepositorioCliente repositorioCliente, IRepositorioFilme repositorioFilme)
        {
            _repositorioLocacao = repositorioLocacao;
            _repositorioCliente = repositorioCliente;
            _repositorioFilme = repositorioFilme;
        }

        public List<Cliente> ClientesEmAtrasoDevolucao()
        {
            return _repositorioCliente.ClientesEmAtrasoDevolucao();
        }

        public List<Filme> FilmesNuncaAlugados()
        {
            return _repositorioFilme.FilmesNuncaAlugados();
        }

        public List<Filme> CincoFilmesMaisAlugadosNoAno()
        {
            return _repositorioFilme.CincoFilmesMaisAlugadosNoAno();
        }
        public List<Filme> TresMenosAlugadosUltimaSemana()
        {
            return _repositorioFilme.TresMenosAlugadosUltimaSemana();
        }

        public List<Cliente> SegundoClienteMaisALugou()
        {
            return _repositorioCliente.SegundoClienteMaisALugou();
        }
    }
}