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
    class FilmeCategoriaConfiguration : IEntityTypeConfiguration<FilmeCategoria>
    {
        public void Configure(EntityTypeBuilder<FilmeCategoria> builder)
        {
            builder.ToTable("film_category");
            builder.Property<int>("film_id").IsRequired();
            builder.Property<byte>("category_id").IsRequired();


            builder.Property<DateTime>("last_update")
                .HasColumnType("datetime")
                .HasDefaultValueSql("getdate()")
                .IsRequired();

            builder.HasKey("film_id", "category_id");

            builder
                .HasOne(fc => fc.Filme)
                .WithMany(c => c.Categorias)
                .HasForeignKey("film_id");

            builder
                .HasOne(fc => fc.Categoria)
                .WithMany(f => f.Filmes)
                .HasForeignKey("category_id");
        }
    }
}
