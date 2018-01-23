using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Biblioteca.Editora
{
    public class EditoraService : IEditoraService
    {
        private readonly IEditoraRepository _editoraRepository;

        public EditoraService(IEditoraRepository editoraRepository)
        {
            _editoraRepository = editoraRepository;
        }

        public void Post(EditoraDto editora)
        {
            if (!editora.idEditora.HasValue)
                _editoraRepository.Post(editora);
            else
                _editoraRepository.Put(editora);     
        }

    }
}
