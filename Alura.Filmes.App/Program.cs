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
                
                var filme = context.Filmes
                     .Include(c => c.Categorias)
                     .ThenInclude(fc => fc.Categoria)
                     .ToList();

                var ator = context.Atores
                   .Include(a => a.Filmes)
                   .ThenInclude(fc => fc.Filme);

                
                foreach (var act in ator)
                {
                    
                    Console.WriteLine($"Filmes do ator {act.PrimeiroNome} {act.UltimoNome}:");
                    foreach (var film in act.Filmes)
                    {
                        var q_cat = filme.Where(c => c.Id == film.Filme.Id).FirstOrDefault();
                                                
                        Console.Write($"\t{film.Filme.Titulo} ({film.Filme.Id})");
                        if (q_cat != null)
                        {
                            foreach (var cat in q_cat.Categorias)
                            {
                                Console.Write(", " + cat.Categoria.Nome);
                            }
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine($", sem categoria registrada");
                        }
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}