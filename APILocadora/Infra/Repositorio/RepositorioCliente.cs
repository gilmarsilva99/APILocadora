using APILocadora.Infra.Data;
using APILocadora.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace APILocadora.Infra.Repositorio
{
    public class RepositorioCliente : IRepositorioCliente
    {
        private DataAccess _contexto;

        public RepositorioCliente()
        {
            _contexto = new DataAccess();
        }

        public Cliente ObterPor(int id)
        {
            Cliente cliente = _contexto.ClienteMaps.Find(id);

            return cliente;
        }

        public List<Cliente> Listar()
        {
            return _contexto.ClienteMaps.Include(o => o.Locacoes).OrderBy(a => a.Nome).ToList();
        }
    }
}