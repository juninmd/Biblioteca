using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Biblioteca.Editora
{
    public interface IEditoraService
    {
        void Post(EditoraDto editora);
    }
}
