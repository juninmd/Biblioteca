using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Biblioteca.Livro
{
    public interface ILivroService
    {
        void Post(LivroDto livro);
    }
}
