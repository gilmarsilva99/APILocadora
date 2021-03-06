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

        [HttpPost]

        [Route("api/v1/cliente/salvar")]
        public IHttpActionResult Salvar([FromBody] Cliente cliente)
        {
            WsResposta wsResposta = new WsResposta();           

            Cliente clientesResult = _servico.Salvar(cliente);

            try
            {
                if (clientesResult == null)
                {
                    wsResposta.MensagemErro = "Erro ao criar cliente.";
                    wsResposta.Codigo = Constantes.EnumWsCodigo.ERRO;
                }
                else
                {
                    wsResposta.Conteudo = JsonUtils.Serializar(clientesResult);
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

        [Route("api/v1/cliente/excluir")]
        public IHttpActionResult Excluir(int id)
        {
            WsResposta wsResposta = new WsResposta();

            bool clientesResult = _servico.Excluir(id);

            try
            {
                if (clientesResult == false)
                {
                    wsResposta.MensagemErro = "Erro ao excluir cliente.";
                    wsResposta.Codigo = Constantes.EnumWsCodigo.ERRO;
                }
                else
                {
                    wsResposta.Conteudo = JsonUtils.Serializar(clientesResult);
                    wsResposta.Mensagem = "Cliente excluído com sucesso.";
                }
            }
            catch (Exception ex)
            {
                wsResposta.Codigo = EnumWsCodigo.EXCECAO;
                wsResposta.Mensagem = "Erro ao excluir cliente";
                wsResposta.MensagemErro = ex.ToString();
            }
            return Ok(wsResposta);
        }


    }
}