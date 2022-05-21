using APILocadora.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APILocadora.Models
{
    public class Filme
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public int ClassificacaoIndicativa { get; set; }
        public TipoFilme Lancamento { get; set; }
        public List<Locacao> Locacoes { get; set; }
    }
}