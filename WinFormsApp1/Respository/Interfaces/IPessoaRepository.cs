
using WinFormsApp1.Entites;

namespace WinForm.Desktop.Respository.Interfaces
{
    public interface IPessoaRepository
    {
        Task CreatePessoaAsync(Pessoa pessoa);
        Task<IEnumerable<Pessoa>> GetAllPessoasAsync();
        Task<Pessoa> GetPessoaByIdAsync(int id);
        Task UpdatePessoaAsync(Pessoa pessoa);
        Task DeletePessoaAsync(int id);

    }
}
