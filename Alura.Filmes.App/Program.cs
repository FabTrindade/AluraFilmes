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
                 
                //Selecione primeiro filme o mostra sua categoria
                var filme = context.Filmes
                     .Include(c => c.Categorias)
                     .ThenInclude(fc => fc.Categoria)
                     .First();

                 Console.WriteLine(filme);
                 Console.WriteLine("Categorias:");

                 foreach (var cat in filme.Categorias)
                 {
                     Console.WriteLine(cat.Categoria);
                 }



                //Seleciona uma categoria e mostra seus filmes
                var categoria = context.Categorias
                   .Include(c => c.Filmes)
                   .ThenInclude(fc => fc.Filme)
                   .First();

                
                Console.WriteLine();
                Console.WriteLine(categoria);
                Console.WriteLine("Filmes:");

                foreach (var film in categoria.Filmes)
                {
                    Console.WriteLine($"{film.Filme.Titulo} ({film.Filme.Id}) : {film.Categoria.Nome}");
                }


                Console.WriteLine();
                Console.WriteLine("Quantidade encontrada:" + categoria.Filmes.Count);

            }
        }
    }
}