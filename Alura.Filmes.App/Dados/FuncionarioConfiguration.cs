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
    class FuncionarioConfiguration : PessoaConfiguration<Funcionario>
    {
        public override void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            base.Configure(builder);

            builder
                .ToTable("staff");
            builder
                .Property(a => a.Id)
                .HasColumnName("staff_id");
           builder
                .Property(a => a.NomeUsuario)
                .HasColumnName("username")
                .HasColumnType("varchar(16)")
                .IsRequired();
            builder
                .Property(a => a.Senha)
                .HasColumnName("password")
                .HasColumnType("varchar(40)")
                .IsRequired();
        }
    }
}
