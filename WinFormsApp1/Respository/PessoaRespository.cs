using Npgsql;
using Dapper;
using WinFormsApp1.Context;
using WinFormsApp1.Entites;
using WinForm.Desktop.Respository.Interfaces;


namespace WinForm.Desktop.Respository
{
    public class PessoaRespository : IPessoaRepository
    {
        private readonly WfDbcontext dbcontext;

        public PessoaRespository(WfDbcontext dbcontext)
        {
            this.dbcontext = dbcontext;
        }


        public async Task CreatePessoaAsync(Pessoa pessoa)
        {
            try
            {
                await using (var connection = new NpgsqlConnection(dbcontext.ConnectString))
                {

                    var query = @"INSERT INTO pessoa (nome, Sobrenome, Data_Nascimento , sexo) VALUES (@nome, @sobrenome, @data_nascimento, @sexo)";

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

            IEnumerable<Pessoa> pessoas;

            await using (var connection = new NpgsqlConnection(dbcontext.ConnectString))
            {
                pessoas = await connection.QueryAsync<Pessoa>("SELECT * FROM pessoa ORDER BY Id");
            }

            return pessoas;
        }


        public async Task<Pessoa> GetPessoaByIdAsync(int id)
        {
       
            await using (var connection = new NpgsqlConnection(dbcontext.ConnectString))
            {
                var query = @"SELECT * FROM pessoa WHERE Id = @Id";

                var pessoa = await connection.QueryFirstOrDefaultAsync<Pessoa>(query, new
                {
                    Id = id
                });

                return pessoa;
            }

        }

        public async Task UpdatePessoaAsync(Pessoa pessoa)
        {
            try
            {
                await using (var connection = new NpgsqlConnection(dbcontext.ConnectString))
                {
                    var query = @"UPDATE pessoa S
                            SET Nome = @Nome, Sobrenome= @Sobrenome, Data_Nascimento = @Data_Nascimento, Sexo = @Sexo 
                            WHERE Id = @Id";

                    await connection.QueryAsync(query, new
                    {
                        Id = pessoa.Id,
                        Nome = pessoa.Nome,
                        Sobrenome = pessoa.Sobrenome,
                        Data_Nascimento = pessoa.Data_Nascimento,
                        Sexo = pessoa.Sexo


                    });


                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public async Task DeletePessoaAsync(int id)
        {
            try
            {
                await using (var connection = new NpgsqlConnection(dbcontext.ConnectString))
                {
                    var deletePessoa = @"DELETE FROM pessoa WHERE Id = @Id";

                    await connection.ExecuteAsync(deletePessoa, new
                    {
                        Id = id
                    });
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Valor invalido;");
            }
        }

    }
}
