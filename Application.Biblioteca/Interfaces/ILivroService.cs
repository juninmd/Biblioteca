using Domain.Biblioteca.Livro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Application.Biblioteca.Interfaces
{
    public interface ILivroService
    {
        HttpResponseMessage Post(object livro);
        HttpResponseMessage Get(int? idLivro = null);
        HttpResponseMessage Delete(int? idLivro = null);
        HttpResponseMessage Put(LivroDto livro);
    }
}
