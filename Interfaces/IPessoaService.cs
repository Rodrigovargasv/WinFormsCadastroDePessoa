
using WinFormsApp1.Entites;

namespace WinFormsApp1.Interfaces
{
    public interface IPessoaService
    {
        Task CreatePessoaAsync(Pessoa pessoa);
        Task<IEnumerable<Pessoa>> GetAllPessoasAsync();
        Task<Pessoa> GetPessoaByIdAsync(int id);
        Task UpdatePessoaAsync(Pessoa pessoa);
        Task DeletePessoaAsync(int id);

    }
}
