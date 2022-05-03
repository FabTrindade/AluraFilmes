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

                var filme = context.Filmes
                    .Include(f => f.Atores)
                    .ThenInclude(fa => fa.Ator)
                    .First();

                Console.WriteLine(filme);
                Console.WriteLine("Elenco:");

                foreach (var actor in filme.Atores)
                {
                    Console.WriteLine(actor.Ator);
                }


                var ator = context.Atores
                    .Include(f => f.Filmes)
                    .ThenInclude(fa => fa.Filme)
                    .First();

                Console.WriteLine(ator);
                Console.WriteLine("Filmes:");

                foreach (var film in ator.Filmes)
                {
                    Console.WriteLine(film.Filme);
                }

                Console.WriteLine("Quantidade de filmes encontrados:" + ator.Filmes.Count);

            }
        }
    }
}