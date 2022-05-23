using APILocadora.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APILocadora.Servicos
{
    public interface IServicoRelatorio
    {
        List<Cliente> ClientesEmAtrasoDevolucao();
        List<Filme> FilmesNuncaAlugados();
        List<Filme> CincoFilmesMaisAlugadosNoAno();
        List<Filme> TresMenosAlugadosUltimaSemana();
        List<Cliente> SegundoClienteMaisALugou();

    }
}