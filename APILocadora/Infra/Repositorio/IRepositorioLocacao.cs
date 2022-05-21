using APILocadora.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APILocadora.Infra.Repositorio
{
    public interface IRepositorioLocacao
    {
        Locacao ObterPor(int id);
        List<Locacao> Listar();
        void Excluir(Locacao locacao);
        void Salvar(Locacao locacao);
    }
}