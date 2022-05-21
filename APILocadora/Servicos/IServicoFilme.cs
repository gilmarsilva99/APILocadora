using APILocadora.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APILocadora.Servicos
{
    public interface IServicoFilme
    {
        Filme ObterPor(int id);
        List<Filme> Listar();
        Filme Salvar(Filme filme);
        bool Excluir(int id);
    }
}