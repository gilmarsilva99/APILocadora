using APILocadora.Infra.Mapeamento;
using APILocadora.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace APILocadora.Infra.Data
{
    public class DataAccess : DbContext
    {
        public DataAccess() : base("locadora")
        {
            Database.SetInitializer<DataAccess>(null);
        }
        public virtual DbSet<Cliente> ClienteMaps { get; set; }
        public virtual DbSet<Filme> FilmeMaps { get; set; }
        public virtual DbSet<Locacao> LocacaoMaps { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            try
            {
                modelBuilder.Configurations.Add(new MapeamentoCliente());
                modelBuilder.Configurations.Add(new MapeamentoFilme());
                modelBuilder.Configurations.Add(new MapeamentoLocacao());
            }
            catch (Exception ex)
            {
                //Log.AddLog("SQLiteBD.OnModelCreating", ex.Message, ex.ToString());
            }
        }

    }
}