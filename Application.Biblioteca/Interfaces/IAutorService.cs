using Domain.Biblioteca.Autor.dtoAutor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Application.Biblioteca.Interfaces
{
    public interface IAutorService
    {
        HttpResponseMessage Post(object autor);
        HttpResponseMessage Get(int? idAutor = null); 
        HttpResponseMessage Delete(int? idAutor = null);
        //HttpResponseMessage Put(int idAutor, object autor);
    }

}
