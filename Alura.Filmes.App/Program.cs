using Alura.Filmes.App.Dados;
using Alura.Filmes.App.Extensions;
using Alura.Filmes.App.Negocio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Alura.Filmes.App
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new AtorFilmesContexto())
            {

                context.LogSQLToConsole();

                var idioma = new Idioma { Id = 1, Nome = "English" };

                var filme = new Filme
                {
                    Titulo = "Senhor dos aneis",
                    Duracao = 189,
                    IdiomaFalado = idioma,
                    Classificacao = "Qualquer"
                };

                context.Filmes.Add(filme);
                context.SaveChanges();
                
            }
        }
    }
}