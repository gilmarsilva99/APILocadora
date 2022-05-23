using APILocadora.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APILocadora.Servicos
{
    public interface IServicoLocacao
    {
        Locacao ObterPor(int id);
        bool Excluir(int id);
        List<Locacao> Listar();
        Locacao Salvar(Locacao locacao);
    }
}