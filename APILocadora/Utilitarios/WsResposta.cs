using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static APILocadora.Utilitarios.Constantes;

namespace APILocadora.Utilitarios
{
    public class WsResposta
    {
        public EnumWsCodigo Codigo { get; set; }
        public string Mensagem { get; set; }
        public string MensagemErro { get; set; }
        public string Conteudo { get; set; }
        public WsResposta()
        {
            Codigo = EnumWsCodigo.OK;
            Mensagem = string.Empty;
            MensagemErro = string.Empty;
            Conteudo = string.Empty;
        }
    }
}