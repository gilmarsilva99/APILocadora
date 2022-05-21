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

        public Cliente Salvar(Cliente cliente)
        {
            Cliente clienteEncontrado = _repositorioCliente.ObterPor(cliente.Id);

            if (clienteEncontrado == null)
            {
                Cliente novoCliente = new Cliente()
                {
                    Id = 0,
                    CPF = cliente.CPF,
                    DataNascimento = cliente.DataNascimento,
                    Nome = cliente.Nome
                };

                _repositorioCliente.Salvar(novoCliente);

                return _repositorioCliente.ObterPor(novoCliente.CPF);
            }
            else
            {
                clienteEncontrado.CPF = cliente.CPF;
                clienteEncontrado.Nome = cliente.Nome;
                clienteEncontrado.DataNascimento = cliente.DataNascimento;
            }

            _repositorioCliente.Salvar(clienteEncontrado);

            return _repositorioCliente.ObterPor(clienteEncontrado.Id);
        }

        public bool Excluir(int id)
        {
            Cliente cliente = _repositorioCliente.ObterPor(id);

            if (cliente == null)
            {
                //msg
                return false;
            }

            if (cliente.Locacoes.Count >= 1)
            {
                //msg
                return false;
            }

            _repositorioCliente.Excluir(cliente);

            return true;
        }
    }
}