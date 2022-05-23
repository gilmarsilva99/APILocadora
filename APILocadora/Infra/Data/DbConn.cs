using MySqlConnector;
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

        //public SqlConnection Connection
        //{
        //    get { return new SqlConnection(GetConnection()); }

        //}
        public MySqlConnection Connection
        {
            get { return new MySqlConnection(cs); }

        }
        public DbConn()
        {
            Connection.Open();
        }

        string cs = @"server=localhost;userid=root;password=123456;database=locadora";        

        private string GetConnection()
        {
            foreach (ConnectionStringSettings conn in ConfigurationManager.ConnectionStrings)
            {
                if (conn.Name == "locadora")
                    return conn.ConnectionString;
            }
            return "";
        }

    }
}