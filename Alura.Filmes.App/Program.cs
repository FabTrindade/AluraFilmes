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
                var filmes = context.Filmes
                    .Where(a => a.Duracao > 180);
                    
                foreach(var filme in filmes)
                {
                    Console.WriteLine(filme);
                    Console.WriteLine("Última atualização: " + context.Entry(filme).Property("last_update").CurrentValue);
                    Console.WriteLine();
                }
                Console.WriteLine("Total de filmes encontrados: " + filmes.Count());
            }
        }
    }
}