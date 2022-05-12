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
                Console.WriteLine(ClassificacaoIndicativa.CLivre.ParaString() +  " = " + "G".ParaValor());
                Console.WriteLine();                                                 
                Console.WriteLine(ClassificacaoIndicativa.C10Anos.ParaString() + " = " + "PG".ParaValor());
                Console.WriteLine();                                                 
                Console.WriteLine(ClassificacaoIndicativa.C13Anos.ParaString() + " = " + "PG-13".ParaValor());
                Console.WriteLine();                                                 
                Console.WriteLine(ClassificacaoIndicativa.C14Anos.ParaString() + " = " + "R".ParaValor());
                Console.WriteLine();                                                 
                Console.WriteLine(ClassificacaoIndicativa.C18Anos.ParaString() + " = " + "NC-17".ParaValor());
                Console.WriteLine();
            }
        }
    }
}