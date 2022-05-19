using APILocadora.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace APILocadora.Infra.Mapeamento
{
    public class MapeamentoCliente : EntityTypeConfiguration<Cliente>
    {
        public MapeamentoCliente()
        {
            HasKey(p => p.Id);
            ToTable("Cliente");
            Property(p => p.Id)
               .IsRequired()
               .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
               .HasColumnType("int");
            Property(p => p.Nome)
               .IsRequired()
               .HasColumnType("varchar");
            Property(p => p.CPF)
               .IsRequired()
               .HasColumnType("varchar");
            Property(p => p.DataNascimento)
               .IsRequired()
               .HasColumnType("datetime");

            HasMany(p => p.Locacoes)
               .WithRequired(c => c.Cliente)
               .HasForeignKey(p => p.Id_Cliente);

        }
    }
}