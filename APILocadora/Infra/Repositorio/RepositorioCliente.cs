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

        public Cliente ObterPor(string cpf)
        {
            Cliente cliente = _contexto.ClienteMaps.Where(a=>a.CPF == cpf).FirstOrDefault();

            return cliente;
        }

        public List<Cliente> Listar()
        {
            return _contexto.ClienteMaps.Include(o => o.Locacoes).OrderBy(a => a.Nome).ToList();
        }

        public void Salvar(Cliente cliente) 
        {
            if (cliente.Id == 0)
            {
                _contexto.ClienteMaps.Add(cliente);
            }
            else
            {
                _contexto.Entry(cliente).State = EntityState.Modified;
            }

            _contexto.SaveChanges();
        }

        public void Excluir(Cliente cliente)
        {
            _contexto.Entry(cliente).State = EntityState.Deleted;

            _contexto.SaveChanges();
        }
    }
}