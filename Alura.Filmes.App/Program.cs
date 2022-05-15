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

                var sql = "INSERT INTO language (name) VALUES ('Teste 1'), ('Teste 2'), ('Teste 3')";
                var registros = context.Database.ExecuteSqlCommand(sql);
                System.Console.WriteLine($"O total de registros afetados é {registros}.");

                var deleteSql = "DELETE FROM language WHERE name LIKE 'Teste%'";
                registros = context.Database.ExecuteSqlCommand(deleteSql);
                System.Console.WriteLine($"O total de registros afetados é {registros}.");
            }
        }
    }
}