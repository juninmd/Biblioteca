using System;
using System.Data;
using System.Data.SqlClient;

namespace Repository.Biblioteca
{
    class DataBaseConnect : IDisposable
    {
        private readonly SqlConnection minhaConexao;
        private readonly string ConnectionString = @"data source=.\SQLEXPRESS; Integrated Security=SSPI; Initial Catalog =db_Biblioteca";
        public SqlCommand Command { get; set; }

        public DataBaseConnect()
        {
            minhaConexao = Connect();
        }

        private SqlConnection Connect()
        {
            var connection = new SqlConnection(ConnectionString);
            if (connection.State == ConnectionState.Broken)
            {
                connection.Close();
                connection.Open();
            }
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }

            return connection;
        }


        public void Dispose()
        {
            if(minhaConexao.State == ConnectionState.Open)
            {
                minhaConexao.Close();
            }
        }

        //Daqui pra baixo é para o uso de procedures
        public void ExecutarProcedure(string nomeProcedure)
        {
            Command = new SqlCommand(nomeProcedure, Connect())
            {
                CommandType = CommandType.StoredProcedure
            };
        }

        public void AddParametro(string nomeParametro, object valor)
        {
            Command.Parameters.Add(new SqlParameter(nomeParametro, valor ?? DBNull.Value));
        }

        public void ExecutarSemRetorno()
        {
            Command.ExecuteNonQuery();
        }

        public SqlDataReader ExecuteReader()
        {
            return Command.ExecuteReader();
        }



    }
}
