using Alura.Filmes.App.Negocio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Filmes.App.Dados
{
    public class PessoaConfiguration<T> : IEntityTypeConfiguration<T>  where T: Pessoa
    {   
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            
            builder
                .Property(a => a.PrimeiroNome)
                .HasColumnName("first_name")
                .HasColumnType("varchar(45)")
                .IsRequired();
            builder
                .Property(a => a.UltimoNome)
                .HasColumnName("last_name")
                .HasColumnType("varchar(45)")
                .IsRequired();
            builder
                .Property(a => a.Email)
                .HasColumnName("email")
                .HasColumnType("varchar(50)");
            builder
                .Property(a => a.Ativo)
                .HasColumnName("active")
                .IsRequired();
            builder
                .Property<DateTime>("last_update")
                .HasColumnType("datetime")
                .HasDefaultValueSql("getdate()")
                .IsRequired();
        }
    }
}
