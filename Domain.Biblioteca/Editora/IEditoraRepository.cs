using Domain.Biblioteca.Autor.dtoAutor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Biblioteca.Editora
{
    public interface IEditoraRepository
    {
        IEnumerable<EditoraDto> Get();
        IEnumerable<EditoraDto> GetById(int idEditora);
        void Post(EditoraDto editora);
        void Delete(int idEditora);
        void Put(EditoraDto editora);
    }
}
