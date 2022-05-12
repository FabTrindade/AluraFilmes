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

                var filme = new Filme
                {
                    Titulo = "Jumanji",
                    Duracao = 189,
                    AnoLancamento = "1995",
                    IdiomaFalado = context.Idiomas.First(),
                    Classificacao = ClassificacaoIndicativa.C14Anos
                };

                context.Filmes.Add(filme);
                context.SaveChanges();

                var query = context.Filmes
                    .FirstOrDefault(a => a.Titulo == "Jumanji");

                Console.WriteLine(query.Classificacao);
            }
        }
    }
}