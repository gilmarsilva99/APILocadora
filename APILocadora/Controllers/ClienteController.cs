using APILocadora.Infra.Repositorio;
using APILocadora.Models;
using APILocadora.Servicos;
using APILocadora.Utilitarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using static APILocadora.Utilitarios.Constantes;

namespace APILocadora.Controllers
{
    public class ClienteController : ApiController
    {
        private readonly IServicoCliente _servico;

        public ClienteController(IServicoCliente servico)
        {
            _servico = servico;
            
        }

        public ClienteController()
        {
            _servico = new ServicoCliente(new RepositorioCliente());
        }

        [HttpGet]

        [Route("api/v1/cliente/listar")]
        public IHttpActionResult Listar()
        {
            WsResposta wsResposta = new WsResposta();

            List<Cliente> lista = _servico.Listar();

            try
            {
                if (lista == null)
                {
                    wsResposta.MensagemErro = "Nenhum cliente encontrado.";
                    wsResposta.Codigo = Constantes.EnumWsCodigo.ERRO;
                }
                else
                {
                    wsResposta.Conteudo = JsonUtils.Serializar(lista);
                }
            }
            catch (Exception ex)
            {
                wsResposta.Codigo = EnumWsCodigo.EXCECAO;
                wsResposta.Mensagem = "Erro ao carregar dados";
                wsResposta.MensagemErro = ex.ToString();
            }
            return Ok(wsResposta);
        }
    }
}