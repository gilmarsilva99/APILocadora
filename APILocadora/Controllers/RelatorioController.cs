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
    public class RelatorioController : ApiController
    {
        private readonly IServicoRelatorio _servico;

        public RelatorioController(IServicoRelatorio servico)
        {
            _servico = servico;            
        }

        public RelatorioController()
        {
            _servico = new ServicoRelatorio(new RepositorioLocacao(), new RepositorioCliente(), new RepositorioFilme());
        }

        [HttpGet]

        [Route("api/v1/relatorio/ClientesEmAtrasoDevolucao")]
        public IHttpActionResult ClientesEmAtrasoDevolucao()
        {
            WsResposta wsResposta = new WsResposta();

            List<Cliente> lista = _servico.ClientesEmAtrasoDevolucao();

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


        [HttpGet]

        [Route("api/v1/relatorio/FilmesNuncaAlugados")]
        public IHttpActionResult FilmesNuncaAlugados()
        {
            WsResposta wsResposta = new WsResposta();

            List<Filme> lista = _servico.FilmesNuncaAlugados();

            try
            {
                if (lista == null)
                {
                    wsResposta.MensagemErro = "Nenhum filme encontrado.";
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

        [HttpGet]

        [Route("api/v1/relatorio/CincoFilmesMaisAlugadosNoAno")]
        public IHttpActionResult CincoFilmesMaisAlugadosNoAno()
        {
            WsResposta wsResposta = new WsResposta();

            List<Filme> lista = _servico.CincoFilmesMaisAlugadosNoAno();

            try
            {
                if (lista == null)
                {
                    wsResposta.MensagemErro = "Nenhum filme encontrado.";
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

        [HttpGet]

        [Route("api/v1/relatorio/TresMenosAlugadosUltimaSemana")]
        public IHttpActionResult TresMenosLugadosUltimaSemana()
        {
            WsResposta wsResposta = new WsResposta();

            List<Filme> lista = _servico.TresMenosAlugadosUltimaSemana();

            try
            {
                if (lista == null)
                {
                    wsResposta.MensagemErro = "Nenhum filme encontrado.";
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

        [HttpGet]

        [Route("api/v1/relatorio/SegundoClienteMaisALugou")]
        public IHttpActionResult SegundoClienteMaisALugou()
        {
            WsResposta wsResposta = new WsResposta();

            List<Cliente> lista = _servico.SegundoClienteMaisALugou();

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