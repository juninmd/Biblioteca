using Domain.Biblioteca.Autor.dtoAutor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Biblioteca.Livro
{
    public interface ILivroRepository
    {
        IEnumerable<LivroDto> GetById(int idLivro);
        IEnumerable<LivroDto> Get();
        void Post(LivroDto livro);
        void Delete(int idLivro);
        void Put(LivroDto livro);
    }
}
