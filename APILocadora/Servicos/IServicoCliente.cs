using APILocadora.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APILocadora.Servicos
{
    public interface IServicoCliente
    {
        Cliente ObterPor(int id);
        List<Cliente> Listar();
    }
}