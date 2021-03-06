using APILocadora.Models.Enum;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APILocadora.Models
{
    public class Locacao
    {
        public int Id { get; set; }
        public int Id_Cliente { get; set; }
        public int Id_Filme { get; set; }
        public DateTime DataLocacao { get; set; }
        public DateTime DataDevolucao { get; set; }

        [JsonIgnore]
        public Cliente Cliente { get; set; }

        [JsonIgnore]
        public Filme Filme { get; set; }       

        
        public void DefinirDevolução(TipoFilme tipo)
        {
            if (tipo == TipoFilme.Lancamento)
            {
                DataDevolucao = DataLocacao.AddDays(2);
            }
            else
            {
                DataDevolucao = DataLocacao.AddDays(3);
            }
        }

    }
}