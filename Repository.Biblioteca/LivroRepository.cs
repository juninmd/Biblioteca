using Domain.Biblioteca.Livro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Biblioteca.Autor.dtoAutor;

namespace Repository.Biblioteca
{
    public class LivroRepository : ILivroRepository
    {

        private readonly DataBaseConnect _conexao;

        public LivroRepository()
        {
            _conexao = new DataBaseConnect();
        }

        public IEnumerable<LivroDto> Get()
        {

            _conexao.ExecutarProcedure("BLTC_SelectLivros");

            var livros = new List<LivroDto>();

            using (var reader = _conexao.ExecuteReader())

                while (reader.Read())
                    livros.Add(new LivroDto
                    {
                        idLivro = reader.GetInt16(reader.GetOrdinal("ID_Livro")),
                        nomeLivro = reader.GetString(reader.GetOrdinal("Nome_Livro")),
                        ISBN = reader.GetString(reader.GetOrdinal("ISBN")),
                        dataPubLivro = reader.GetDateTime(reader.GetOrdinal("Data_Pub")),
                        precoLivro = reader.GetDecimal (reader.GetOrdinal("Preco_Livro")),
                        idAutor = reader.GetInt16(reader.GetOrdinal("ID_Autor")),
                        idEditora = reader.GetInt16(reader.GetOrdinal("ID_Editora"))
                    });

                return livros;
        }

        public IEnumerable<LivroDto> GetById(int idLivro)
        {
            _conexao.ExecutarProcedure("BLTC_BuscaPorIdLivro");
            _conexao.AddParametro("@ID", idLivro);

            var livros = new List<LivroDto>();
            using (var reader = _conexao.ExecuteReader())
                while (reader.Read())
                    livros.Add(new LivroDto
                    {
                        idLivro = reader.GetInt16(reader.GetOrdinal("ID_Livro")),
                        nomeLivro = reader.GetString(reader.GetOrdinal("Nome_Livro")),
                        ISBN = reader.GetString(reader.GetOrdinal("ISBN")),
                        dataPubLivro = reader.GetDateTime(reader.GetOrdinal("Data_Pub")),
                        precoLivro = reader.GetDecimal(reader.GetOrdinal("Preco_Livro")),
                        idAutor = reader.GetInt16(reader.GetOrdinal("ID_Autor")),
                        idEditora = reader.GetInt16(reader.GetOrdinal("ID_Editora"))
                    });
            return livros;
        }



        public void Delete(int idLivro)
        {
            _conexao.ExecutarProcedure("BLTC_DeletarLivro");
            _conexao.AddParametro("@ID", idLivro);
            _conexao.ExecutarSemRetorno();
        }

        public void Post(LivroDto livro)
        {
            _conexao.ExecutarProcedure("BLTC_InsertLivros");
            _conexao.AddParametro("@NomeLivro", livro.nomeLivro);
            _conexao.AddParametro("@ISBN", livro.ISBN);
            _conexao.AddParametro("@IDAutor", livro.idAutor);
            _conexao.AddParametro("@DataPub", livro.dataPubLivro);
            _conexao.AddParametro("@PrecoLivro", livro.precoLivro);
            _conexao.AddParametro("@IDEditora", livro.idEditora);
            _conexao.ExecutarSemRetorno();
        }

        public void Put(LivroDto livro)
        {
            _conexao.ExecutarProcedure("BLTC_AlteraLivro");
            _conexao.AddParametro("@ID", livro.idLivro);
            _conexao.AddParametro("@NovoNome", livro.nomeLivro);
            _conexao.AddParametro("@NovoISBN", livro.ISBN);
            _conexao.AddParametro("@NovoIdAutor", livro.idAutor);
            _conexao.AddParametro("@NovaData", livro.dataPubLivro);
            _conexao.AddParametro("@NovoPreco", livro.precoLivro);
            _conexao.AddParametro("@NovoIdEditora", livro.idEditora);
            _conexao.ExecutarSemRetorno();
        }
    }
}
