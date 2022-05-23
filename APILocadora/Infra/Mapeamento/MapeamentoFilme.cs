using APILocadora.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace APILocadora.Infra.Mapeamento
{
    public class MapeamentoFilme : EntityTypeConfiguration<Filme>
    {
        public MapeamentoFilme()
        {
            HasKey(p => p.Id);
            ToTable("Filme");
            Property(p => p.Id)
               .IsRequired()
               .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
               .HasColumnType("int");
            Property(p => p.Titulo)
               .IsRequired()
               .HasColumnType("varchar");
            Property(p => p.ClassificacaoIndicativa)
               .IsRequired()
               .HasColumnType("int");
            Property(p => p.Lancamento)
               .IsRequired();
               


            HasMany(p => p.Locacoes)
               .WithRequired(c => c.Filme)
               .HasForeignKey(p => p.Id_Filme);
        }

    }
}