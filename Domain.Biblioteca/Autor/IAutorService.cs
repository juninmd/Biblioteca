using Domain.Biblioteca.Autor.dtoAutor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Biblioteca.Autor
{
    public interface IAutorService
    {
        void Post(AutorDto autor);
    }
}
