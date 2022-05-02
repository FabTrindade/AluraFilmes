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

                foreach (var item in context.Elenco)
                {
                    var entidade = context.Entry(item);
                    var filmId = entidade.Property("film_id").CurrentValue;
                    var atorId = entidade.Property("actor_id").CurrentValue;
                    var lastUpd = entidade.Property("last_update").CurrentValue;

                    Console.WriteLine($"Filme {filmId}, Ator {atorId}, LastUpdadte {lastUpd}");

                }
            }
        }
    }
}