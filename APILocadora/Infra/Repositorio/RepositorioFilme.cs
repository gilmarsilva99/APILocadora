using APILocadora.Infra.Data;
using APILocadora.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using APILocadora.Models.Enum;

namespace APILocadora.Infra.Repositorio
{
    public class RepositorioFilme : IRepositorioFilme
    {
        private DataAccess _contexto;

        public RepositorioFilme()
        {
            _contexto = new DataAccess();
        }

        public Filme ObterPor(int id)
        {
            return _contexto.FilmeMaps.Find(id);
        }

        public Filme ObterPor(string titulo, TipoFilme tipo)
        {
            return _contexto.FilmeMaps.Where(a=>a.Titulo == titulo && a.Lancamento == tipo).FirstOrDefault();
        }

        public List<Filme> Listar()
        {
            return _contexto.FilmeMaps.OrderBy(a=>a.Titulo).ToList();
        }

        public void Salvar(Filme filme)
        {
            if (filme.Id == 0)
            {
                _contexto.FilmeMaps.Add(filme);
            }
            else
            {
                _contexto.Entry(filme).State = EntityState.Modified;
            }

            _contexto.SaveChanges();
        }

        public void Excluir(Filme filme)
        {
            _contexto.Entry(filme).State = EntityState.Deleted;

            _contexto.SaveChanges();
        }
    }
}