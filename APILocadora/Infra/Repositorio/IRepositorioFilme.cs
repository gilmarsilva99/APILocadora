using APILocadora.Models;
using APILocadora.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APILocadora.Infra.Repositorio
{
    public interface IRepositorioFilme
    {
        Filme ObterPor(int id);
        List<Filme> Listar();
        void Salvar(Filme filme);
        void Excluir(Filme filme);
        bool JaExiste(string titulo, int classificacaoIndicativa);
        List<Filme> FilmesNuncaAlugados();
        List<Filme> CincoFilmesMaisAlugadosNoAno();
        List<Filme> TresMenosAlugadosUltimaSemana();
    }
}