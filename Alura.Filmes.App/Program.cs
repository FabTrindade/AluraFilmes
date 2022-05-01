using Alura.Filmes.App.Dados;
using System;

namespace Alura.Filmes.App
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new AtorFilmesContexto())
            {                
                foreach(var ator in context.Atores)
                {
                    Console.WriteLine(ator);
                }
            }
        }
    }
}