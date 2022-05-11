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

                var ator1 = new Ator { PrimeiroNome = "James", UltimoNome = "Watson" };
                var ator2 = new Ator { PrimeiroNome = "James", UltimoNome = "Watson" };

                context.Atores.AddRange(ator1, ator2);
                context.SaveChanges();


                var query = context.Atores
                    .Where(a => a.PrimeiroNome == "James" && a.UltimoNome == "Watson");

                Console.WriteLine("Encontrados:" + query.Count());
                
            }
        }
    }
}