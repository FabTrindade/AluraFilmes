namespace Alura.Filmes.App.Negocio
{
    public class FilmeCategoria
    {
        public Filme Filme { get; set; }            //navigation property
        public Categoria Categoria { get; set; }    //navigation property
    }
}   