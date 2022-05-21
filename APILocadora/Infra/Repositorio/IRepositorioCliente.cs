using APILocadora.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APILocadora.Infra.Repositorio
{
    public interface IRepositorioCliente
    {
        Cliente ObterPor(int id);
        List<Cliente> Listar();
        Cliente ObterPor(string cpf);
        void Salvar(Cliente cliente);
        void Excluir(Cliente cliente);
    }
}