
using Dapper;
using Npgsql;
using System.Data.SqlClient;
using WinForm.Desktop.Respository.Interfaces;
using WinFormsApp1.Context;
using WinFormsApp1.Entites;

namespace WinForm.Desktop.Respository
{
    public class CreateDatabaseRespository : ICreateDabaseRepository
    {


        private readonly WfDbcontext dbcontext;

        public CreateDatabaseRespository(WfDbcontext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        public async void CreateDabase()
        {

            try
            {

                var database = "wf_database";
                int count;

                await using (var connection = new NpgsqlConnection(dbcontext.ConnectString))
                {
                    connection.Open();

                    // Consulta SQL para verificar a existência do banco de dados
                    string sql = "SELECT 1 FROM pg_database WHERE datname = 'wf_database'";

                    // Executa a consulta usando Dapper
                    count = connection.QueryFirstOrDefault<int>(sql, new { database });


                }

                if (count == 0)
                {
                    await using (var connection = new NpgsqlConnection(dbcontext.ConnectString))
                    {
                        var queryDatabase = @"CREATE DATABASE wf_database";
                        var queryTable = "CREATE TABLE pessoa (Id SERIAL PRIMARY KEY," +
                            "Nome VARCHAR(80) NOT NULL," +
                            "Sobrenome VARCHAR(80) NOT NULL,Data_Nascimento DATE NOT NULL," +
                            "Sexo VARCHAR(1) NOT NULL)";


                        await connection.ExecuteAsync(queryDatabase);
                        await connection.ExecuteAsync(queryTable);

                    }
                    
                }
                else
                    return;
                


                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Este banco de dados já foi criado.");
            }


        }
    }
}
