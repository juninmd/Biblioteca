using Domain.Biblioteca.Autor.dtoAutor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Biblioteca
{
    public class AutorRepository : IAutorRepository
    {

        private readonly DataBaseConnect _conexao;

        public AutorRepository()
        {
            _conexao = new DataBaseConnect();
        }

        public IEnumerable<AutorDto> Get()
        {
            _conexao.ExecutarProcedure("BLTC_SelectAutor");

            var autores = new List<AutorDto>();

            using (var reader = _conexao.ExecuteReader())

                while (reader.Read())
                    autores.Add(new AutorDto
                    {
                        idAutor = reader.GetInt16(reader.GetOrdinal("ID_Autor")),
                        nomeAutor = reader.GetString(reader.GetOrdinal("Nome_Autor")),
                        sobrenomeAutor = reader.GetString(reader.GetOrdinal("Sobrenome_Autor"))
                    });

                return autores;
        }

        public IEnumerable<AutorDto> GetById(int idAutor)
        {
            _conexao.ExecutarProcedure("BLTC_BuscaPorIdAutor");
            _conexao.AddParametro("@ID", idAutor);

            var autores = new List<AutorDto>();
            using (var reader = _conexao.ExecuteReader())
                while (reader.Read())
                    autores.Add(new AutorDto
                    {
                        idAutor = reader.GetInt16(reader.GetOrdinal("ID_Autor")),
                        nomeAutor = reader.GetString(reader.GetOrdinal("Nome_Autor")),
                        sobrenomeAutor = reader.GetString(reader.GetOrdinal("Sobrenome_Autor"))
                    });
                return autores;  
        }

        public void Delete(int idAutor)
        {
            _conexao.ExecutarProcedure("BLTC_DeletaAutor");
            _conexao.AddParametro("@ID", idAutor);
            _conexao.ExecutarSemRetorno();
        }

        public void Post(AutorDto autor)
        {
            _conexao.ExecutarProcedure("BLTC_InsertAutor");
            _conexao.AddParametro("@NomeAutor", autor.nomeAutor);
            _conexao.AddParametro("@SobrenomeAutor", autor.sobrenomeAutor);
            _conexao.ExecutarSemRetorno();
        }

        public void Put(AutorDto autor)
        {
            _conexao.ExecutarProcedure("BLTC_AlteraAutor");
            _conexao.AddParametro("@ID", autor.idAutor);
            _conexao.AddParametro("@NovoNome", autor.nomeAutor);
            _conexao.AddParametro("@NovoSobrenome", autor.sobrenomeAutor);

            _conexao.ExecutarSemRetorno();    
        }


    }
}

