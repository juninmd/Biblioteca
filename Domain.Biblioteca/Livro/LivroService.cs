using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Biblioteca.Livro
{
    public class LivroService : ILivroService
    {
        private readonly ILivroRepository _livroRepository;

        public LivroService(ILivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }

        public void Post(LivroDto livro)
        {
            if (!livro.idLivro.HasValue)
                _livroRepository.Post(livro);
            else
                _livroRepository.Put(livro);
        }
    }
}
