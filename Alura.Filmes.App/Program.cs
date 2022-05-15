using Alura.Filmes.App.Dados;
using Alura.Filmes.App.Extensions;
using Alura.Filmes.App.Negocio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data.SqlClient;
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

                var categ = "Action";

                var paramCateg = new SqlParameter("category_name", categ);

                var paramTotal = new SqlParameter
                {
                    ParameterName = "@total_actors",
                    Size = 4,
                    Direction = System.Data.ParameterDirection.Output
                };

                context.Database.ExecuteSqlCommand(
                    "total_actors_from_given_category @category_name, @total_actors OUT",
                    paramCateg,
                    paramTotal);
                Console.WriteLine($"Total de atures na categoria {categ}: {paramTotal.Value}");
            }
        }
    }
}