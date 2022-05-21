using APILocadora.Infra.Data;
using APILocadora.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace APILocadora.Infra.Repositorio
{
    public class RepositorioLocacao : IRepositorioLocacao
    {
        private DataAccess _contexto;

        public RepositorioLocacao()
        {
            _contexto = new DataAccess();
        }

        public Locacao ObterPor(int id)
        {
            return _contexto.LocacaoMaps.Find(id);
        }

        public List<Locacao> Listar()
        {
            return _contexto.LocacaoMaps.OrderBy(a => a.DataLocacao).ToList();
        }

        public void Salvar(Locacao locacao)
        {
            if (locacao.Id == 0)
            {
                _contexto.LocacaoMaps.Add(locacao);
            }
            else
            {
                _contexto.Entry(locacao).State = EntityState.Modified;
            }

            _contexto.SaveChanges();
        }

        public void Excluir(Locacao locacao)
        {
            _contexto.Entry(locacao).State = EntityState.Deleted;

            _contexto.SaveChanges();
        }
    }
}