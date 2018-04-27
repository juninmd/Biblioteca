using Domain.Biblioteca.Autor.dtoAutor;

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
