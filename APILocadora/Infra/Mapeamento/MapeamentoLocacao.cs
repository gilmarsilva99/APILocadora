using APILocadora.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace APILocadora.Infra.Mapeamento
{
    public class MapeamentoLocacao : EntityTypeConfiguration<Locacao>
    {
        public MapeamentoLocacao()
        {

            HasKey(p => p.Id);
            ToTable("Locacao");
            Property(p => p.Id)
               .IsRequired()
               .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
               .HasColumnType("int");
            Property(p => p.Id_Cliente)
               .IsRequired()
               .HasColumnType("int");
            Property(p => p.Id_Filme)
               .IsRequired()
               .HasColumnType("int");
            Property(p => p.DataLocacao)
               .IsRequired()
               .HasColumnType("datetime");
            Property(p => p.DataLocacao)
               .HasColumnType("datetime");
        }

    }
}