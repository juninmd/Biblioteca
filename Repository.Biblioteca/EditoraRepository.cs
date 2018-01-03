using Domain.Biblioteca.Editora;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Biblioteca.Autor.dtoAutor;

namespace Repository.Biblioteca
{
    public class EditoraRepository : IEditoraRepository
    {

        private readonly DataBaseConnect _conexao;

        public EditoraRepository()
        {
            _conexao = new DataBaseConnect();
        }

        public IEnumerable<EditoraDto> Get()
        {

            _conexao.ExecutarProcedure("BLTC_SelectEditora");

            var editoras = new List<EditoraDto>();

            using (var reader = _conexao.ExecuteReader())

                while (reader.Read())
                    editoras.Add(new EditoraDto
                    {
                       idEditora = reader.GetInt16(reader.GetOrdinal("ID_Editora")),
                       nomeEditora = reader.GetString(reader.GetOrdinal("Nome_Editora")),                   
                    });
                return editoras;
        }


        public IEnumerable<EditoraDto> GetById(int idEditora)
        {
            _conexao.ExecutarProcedure("BLTC_BuscaPorIdEditora");
            _conexao.AddParametro("@ID", idEditora);

            var editoras = new List<EditoraDto>();
            using (var reader = _conexao.ExecuteReader())
                while (reader.Read())
                    editoras.Add(new EditoraDto
                    {
                        idEditora = reader.GetInt16(reader.GetOrdinal("ID_Editora")),
                        nomeEditora = reader.GetString(reader.GetOrdinal("Nome_Editora")),
                    });
            return editoras;
        }

        public void Delete(int idEditora)
        {
            _conexao.ExecutarProcedure("BLTC_DeletaEditora");
            _conexao.AddParametro("@ID", idEditora);
            _conexao.ExecutarSemRetorno();
        }

        public void Post(EditoraDto editora)
        {
            _conexao.ExecutarProcedure("BLTC_InsereEditora");
            _conexao.AddParametro("@nome", editora.nomeEditora);
            _conexao.ExecutarSemRetorno();
        }

        public void Put(EditoraDto editora)
        {
            _conexao.ExecutarProcedure("BLTC_AlteraEditora");
            _conexao.AddParametro("@ID", editora.idEditora);
            _conexao.AddParametro("@NovoNome", editora.nomeEditora);
            _conexao.ExecutarSemRetorno();
        }


    }
}
