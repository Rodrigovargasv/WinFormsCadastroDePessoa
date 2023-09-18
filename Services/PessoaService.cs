using Npgsql;
using Dapper;
using WinFormsApp1.Context;
using WinFormsApp1.Entites;
using WinFormsApp1.Interfaces;

namespace WinFormsApp1.Services
{
    public class PessoaService : IPessoaService
    {
        private readonly WfDbcontext dbcontext;

        public PessoaService(WfDbcontext dbcontext)
        {
            this.dbcontext = dbcontext;
        }


        public async Task CreatePessoaAsync(Pessoa pessoa)
        {
            try
            {
                await using (var connection = new NpgsqlConnection(dbcontext.ConnectString))
                {

                    var query = "INSERT INTO pessoa (nome, Sobrenome, Data_Nascimento , sexo) VALUES (@nome, @sobrenome, @data_nascimento, @sexo)";

                    await connection.ExecuteAsync(query, new
                    {
                        nome = pessoa.Nome,
                        sobrenome = pessoa.Sobrenome,
                        data_nascimento = pessoa.Data_Nascimento,
                        sexo = pessoa.Sexo,
                    });

                }
            }
            catch
            {
                MessageBox.Show("Valores invalidos");
            }
        }

        public async Task<IEnumerable<Pessoa>> GetAllPessoasAsync()
        {
            var connection = new NpgsqlConnection(dbcontext.ConnectString);
            await connection.OpenAsync(); // Open the database connection

           
            var pessoas = await connection.QueryAsync<Pessoa>("SELECT * FROM pessoa");



            return pessoas;
        }


        public Task<Pessoa> GetPessoaByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdatePessoaAsync(Pessoa pessoa)
        {
            throw new NotImplementedException();
        }


        public Task DeletePessoaAsync(int id)
        {
            throw new NotImplementedException();
        }

    }
}
