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

                //Lista os filmes e categorias de um ator.
                var ator = context.Atores
                  .Include(a => a.Filmes)
                  .ThenInclude(fa => fa.Filme)
                  .ThenInclude(f => f.Categorias)
                  .ThenInclude(fc => fc.Categoria)
                  .ToList();

                foreach (var act in ator)
                {
                    Console.WriteLine($"Filme(s) do ator(a) {act.PrimeiroNome} {act.UltimoNome}");
                    foreach (var film in act.Filmes)
                    {
                        Console.Write($"\t{film.Filme.Titulo} ({film.Filme.Id})");
                        foreach (var cat in film.Filme.Categorias)
                        {
                            Console.Write(", " + cat.Categoria.Nome);
                            Console.WriteLine();
                        }
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}