using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace APILocadora.Infra.Data
{
    public class DbConn : IDbConn
    {
        public string server_name { get; set; }
        public string server_user { get; set; }
        public string server_pass { get; set; }
        public string server_dbname { get; set; }

        //private readonly IConfiguration _configutarion;

        //public DbConn(IConfiguration configuration)
        //{
        //    _configutarion = configuration;
        //}

        public SqlConnection Connection
        {
            get { return new SqlConnection(GetConnection()); }

        }

        private string GetConnection()
        {
            //string conect = _configutarion.GetConnectionString("locadora");

            //return conect;

            foreach (ConnectionStringSettings conn in ConfigurationManager.ConnectionStrings)
            {
                if (conn.Name == "locadora")
                    return conn.ConnectionString;
            }
            return "";
        }

    }
}