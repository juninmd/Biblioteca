using Domain.Biblioteca.Autor.dtoAutor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Biblioteca.Autor
{
    public class AutorService : IAutorService
    {
        private readonly IAutorRepository _autorRepository;

        public AutorService(IAutorRepository autorRepository)
        {
            _autorRepository = autorRepository;
        }

        public void Post(AutorDto autor)
        {
            if (!autor.idAutor.HasValue)
                _autorRepository.Post(autor);
            else
                _autorRepository.Put(autor);            
        }
    }
}
