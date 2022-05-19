using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace APILocadora.Infra.Data
{
    public interface IDbConn
    {
        SqlConnection Connection { get; }
        string server_dbname { get; set; }
        string server_name { get; set; }
        string server_pass { get; set; }
        string server_user { get; set; }
    }
}