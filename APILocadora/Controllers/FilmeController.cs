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
    public class FilmeController : ApiController
    {
        private readonly IServicoFilme _servico;

        public FilmeController(IServicoFilme servico)
        {
            _servico = servico;

        }

        public FilmeController()
        {
            _servico = new ServicoFilme(new RepositorioFilme());
        }

        [HttpGet]

        [Route("api/v1/Filme/listar")]
        public IHttpActionResult Listar()
        {
            WsResposta wsResposta = new WsResposta();

            List<Filme> lista = _servico.Listar();

            try
            {
                if (lista == null)
                {
                    wsResposta.MensagemErro = "Nenhum Filme encontrado.";
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

        [Route("api/v1/Filme/salvar")]
        public IHttpActionResult Salvar([FromBody] Filme Filme)
        {
            WsResposta wsResposta = new WsResposta();

            Filme FilmesResult = _servico.Salvar(Filme);

            try
            {
                if (FilmesResult == null)
                {
                    wsResposta.MensagemErro = "Erro ao criar Filme.";
                    wsResposta.Codigo = Constantes.EnumWsCodigo.ERRO;
                }
                else
                {
                    wsResposta.Conteudo = JsonUtils.Serializar(FilmesResult);
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

        [Route("api/v1/Filme/excluir")]
        public IHttpActionResult Excluir(int id)
        {
            WsResposta wsResposta = new WsResposta();

            bool FilmesResult = _servico.Excluir(id);

            try
            {
                if (FilmesResult == false)
                {
                    wsResposta.MensagemErro = "Erro ao excluir Filme.";
                    wsResposta.Codigo = Constantes.EnumWsCodigo.ERRO;
                }
                else
                {
                    wsResposta.Conteudo = JsonUtils.Serializar(FilmesResult);
                    wsResposta.Mensagem = "Filme excluído com sucesso.";
                }
            }
            catch (Exception ex)
            {
                wsResposta.Codigo = EnumWsCodigo.EXCECAO;
                wsResposta.Mensagem = "Erro ao excluir Filme";
                wsResposta.MensagemErro = ex.ToString();
            }
            return Ok(wsResposta);
        }

    }
}