using Alura.Filmes.App.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Alura.Filmes.App.Extensions
{
    public static class ClassificacaoIndicativaExtensions
    {
        private static Dictionary<string, ClassificacaoIndicativa> mapa = 
        new Dictionary<string, ClassificacaoIndicativa>
        {
            {"G", ClassificacaoIndicativa.CLivre},
            {"PG", ClassificacaoIndicativa.C10Anos},
            {"PG-13", ClassificacaoIndicativa.C13Anos},
            {"R", ClassificacaoIndicativa.C14Anos},
            {"NC-17", ClassificacaoIndicativa.C18Anos}
        };

        public static string ParaString(this ClassificacaoIndicativa valor)
        {
            return mapa.First(c => c.Value == valor).Key;
        }

        public static ClassificacaoIndicativa ParaValor (this string key)
        {
            return mapa.First(s => s.Key == key).Value;
        }
    }
}
