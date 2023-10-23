
using WinForm.Desktop.Respository.Interfaces;
using WinForm.Desktop.Services.Interfaces;
using WinFormsApp1.Entites;

namespace WinForm.Desktop.Services
{
    public class PessoaService : IPessoaService
    {

        private readonly IPessoaRepository _pessoaRepository;

        public PessoaService(IPessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }

        public Task CreatePessoaAsync(Pessoa pessoa)
        {
             return  _pessoaRepository.CreatePessoaAsync(pessoa);
        }

        public Task DeletePessoaAsync(int id)
        {
            return _pessoaRepository.DeletePessoaAsync(id);
        }

        public Task<IEnumerable<Pessoa>> GetAllPessoasAsync()
        {
            return _pessoaRepository.GetAllPessoasAsync();
        }

        public Task<Pessoa> GetPessoaByIdAsync(int id)
        {
            return _pessoaRepository.GetPessoaByIdAsync(id);
        }

        public Task UpdatePessoaAsync(Pessoa pessoa)
        {
            return _pessoaRepository.UpdatePessoaAsync(pessoa);
        }
    }
}
