using System;

namespace Presentation.Biblioteca.ViewModels
{
    public class LivroViewModel
    {
        public int? idLivro { get; set; }
        public string nomeLivro { get; set; }
        public string ISBN { get; set; }
        public int idAutor { get; set; }
        public DateTime dataPubLivro { get; set; }
        public decimal precoLivro { get; set; }
        public int idEditora { get; set; }

        public string DataFormatada => dataPubLivro.ToShortDateString();

    }
}