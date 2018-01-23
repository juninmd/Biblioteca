using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Biblioteca.Livro
{
    public class LivroDto
    {
        public int? idLivro { get; set; }
        public string nomeLivro { get; set; }
        public string ISBN { get; set; }
        public int idAutor { get; set; }
        public DateTime dataPubLivro { get; set; }
        public decimal precoLivro { get; set; }
        public int idEditora { get; set; }
    }
}
