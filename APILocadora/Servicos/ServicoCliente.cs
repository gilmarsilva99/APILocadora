using APILocadora.Infra.Repositorio;
using APILocadora.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APILocadora.Servicos
{
    public class ServicoCliente : IServicoCliente
    {
        private readonly IRepositorioCliente _repositorioCliente;

        public ServicoCliente(IRepositorioCliente repositorioCliente)
        {
            _repositorioCliente = repositorioCliente;
        }

        public Cliente ObterPor(int id)
        {
            return _repositorioCliente.ObterPor(id);
        }

        public List<Cliente> Listar()
        {
            return _repositorioCliente.Listar();
        }
    }
}