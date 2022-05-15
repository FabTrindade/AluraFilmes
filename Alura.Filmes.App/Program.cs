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

                Console.WriteLine("Clientes:");
                foreach (var cliente in context.Clientes)
                {
                    Console.WriteLine(cliente);
                }

                Console.WriteLine("Funcionários:");
                foreach (var func in context.Funcionarios)
                {
                    Console.WriteLine(func);
                }
            }
        }
    }
}