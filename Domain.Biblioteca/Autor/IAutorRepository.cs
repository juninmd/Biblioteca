using Domain.Biblioteca.Autor.dtoAutor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Biblioteca.Autor.dtoAutor
{
    public interface IAutorRepository
    {
        IEnumerable<AutorDto> Get();
        IEnumerable<AutorDto> GetById(int idAutor);
        void Post(AutorDto autor);
        void Delete(int idAutor);
        void Put(AutorDto autor);
    }
}
