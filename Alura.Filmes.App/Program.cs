using Alura.Filmes.App.Dados;
using Alura.Filmes.App.Extensions;
using Alura.Filmes.App.Negocio;
using System;

namespace Alura.Filmes.App
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new AtorFilmesContexto())
            {
                Ator ator = new Ator()
                {
                    PrimeiroNome = "Leonardo",
                    UltimoNome = "Di Caprio"
                };
                //context.Entry(ator).Property("last_update").CurrentValue = DateTime.Now;

                context.LogSQLToConsole();

                context.Atores.Add(ator);
                context.SaveChanges();
            }
        }
    }
}