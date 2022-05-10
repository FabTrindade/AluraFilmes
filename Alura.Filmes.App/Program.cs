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

                var idioma = context.Idiomas
                    .Include(f => f.FilmesFalados);

                foreach (var i in idioma)
                {
                    Console.WriteLine(i);
                    foreach (var filme in i.FilmesFalados)
                    {
                        Console.WriteLine("\t"+filme.Titulo);
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}