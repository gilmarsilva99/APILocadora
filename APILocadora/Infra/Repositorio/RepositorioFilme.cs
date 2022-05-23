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

        public bool JaExiste(string titulo, int classificacaoIndicativa)
        {
            Filme filmeEncontrado = _contexto.FilmeMaps.Where(a => a.Titulo == titulo && a.ClassificacaoIndicativa == classificacaoIndicativa).FirstOrDefault();

            if (filmeEncontrado != null)
            {
                return true;
            }

            return false;
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

        public List<Filme> FilmesNuncaAlugados()
        {
            return _contexto.FilmeMaps.Include(a => a.Locacoes).Where(a => a.Locacoes.Count() == 0).ToList();
        }

        public List<Filme> CincoFilmesMaisAlugadosNoAno() 
        {
            string query = @"Select top(5) f.Id, F.Titulo, F.Lancamento, F.ClassificacaoIndicativa, COUNT(L.Id_Filme) QtdLocacoes
                                from Filme F
	                                left join Locacao L ON F.Id = L.Id_Filme
                                where YEAR(L.DataLocacao) = YEAR(GETDATE())
                                GROUP BY 
                                f.Id, F.Titulo, F.Lancamento, F.ClassificacaoIndicativa
                                order by QtdLocacoes

                                    ";
            return _contexto.Database.SqlQuery<Filme>(query).ToList();       
        }

        public List<Filme> TresMenosAlugadosUltimaSemana()
        {
            string query = @"Select top(3) f.Id, F.Titulo, F.Lancamento, F.ClassificacaoIndicativa, COUNT(L.Id_Filme) QtdLocacoes
                                from Filme F
	                                left join Locacao L ON F.Id = L.Id_Filme
                                where DATEDIFF(DAY, L.DataLocacao, GETDATE()) <= 7
                                GROUP BY 
                                f.Id, F.Titulo, F.Lancamento, F.ClassificacaoIndicativa
                                order by QtdLocacoes";           

            return _contexto.Database.SqlQuery<Filme>(query).ToList();
        }
    }
}