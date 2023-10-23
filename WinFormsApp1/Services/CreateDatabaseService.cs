
using WinForm.Desktop.Respository.Interfaces;
using WinForm.Desktop.Services.Interfaces;

namespace WinForm.Desktop.Services
{
    public class CreateDatabaseService : ICreateDabaseService
    {

        private readonly ICreateDabaseRepository _createDabase;

        public CreateDatabaseService(ICreateDabaseRepository createDabase)
        {
            _createDabase = createDabase;
        }

        public  void CreateDabase()
        {
            try
            {
                _createDabase.CreateDabase();
            }
            catch 
            {
                MessageBox.Show("Já existe um banco de dados com estes dados.");
            }
        }
    }
}
