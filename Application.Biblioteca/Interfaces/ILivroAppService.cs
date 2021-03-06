﻿using Domain.Biblioteca.Livro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Application.Biblioteca.Interfaces
{
    public interface ILivroAppService
    {
        HttpResponseMessage Post(LivroDto livro);
        HttpResponseMessage Get(int? idLivro = null);
        HttpResponseMessage GetById(int? idLivro = null);
        HttpResponseMessage Delete(int idLivro);
        HttpResponseMessage Put(LivroDto livro);
    }
}
