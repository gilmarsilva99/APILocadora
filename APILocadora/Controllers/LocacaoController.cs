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
    public class LocacaoController : ApiController
    {
        private readonly IServicoLocacao _servico;

        public LocacaoController(IServicoLocacao servico)
        {
            _servico = servico;
            
        }

        public LocacaoController()
        {
            _servico = new ServicoLocacao(new RepositorioLocacao(), new RepositorioCliente(), new RepositorioFilme());
        }

        [HttpGet]

        [Route("api/v1/locacao/listar")]
        public IHttpActionResult Listar()
        {
            WsResposta wsResposta = new WsResposta();

            List<Locacao> lista = _servico.Listar();

            try
            {
                if (lista == null)
                {
                    wsResposta.MensagemErro = "Nenhum locacao encontrado.";
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

        [HttpPost]

        [Route("api/v1/locacao/salvar")]
        public IHttpActionResult Salvar([FromBody] Locacao locacao)
        {
            WsResposta wsResposta = new WsResposta();

            Locacao locacaosResult = _servico.Salvar(locacao);

            try
            {
                if (locacaosResult == null)
                {
                    wsResposta.MensagemErro = "Erro ao criar locacao.";
                    wsResposta.Codigo = Constantes.EnumWsCodigo.ERRO;
                }
                else
                {
                    wsResposta.Conteudo = JsonUtils.Serializar(locacaosResult);
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


        [HttpPost]

        [Route("api/v1/locacao/excluir")]
        public IHttpActionResult Excluir(int id)
        {
            WsResposta wsResposta = new WsResposta();

            bool locacaosResult = _servico.Excluir(id);

            try
            {
                if (locacaosResult == false)
                {
                    wsResposta.MensagemErro = "Erro ao excluir locacao.";
                    wsResposta.Codigo = Constantes.EnumWsCodigo.ERRO;
                }
                else
                {
                    wsResposta.Conteudo = JsonUtils.Serializar(locacaosResult);
                    wsResposta.Mensagem = "locacao excluído com sucesso.";
                }
            }
            catch (Exception ex)
            {
                wsResposta.Codigo = EnumWsCodigo.EXCECAO;
                wsResposta.Mensagem = "Erro ao excluir locacao";
                wsResposta.MensagemErro = ex.ToString();
            }
            return Ok(wsResposta);
        }
    }
}