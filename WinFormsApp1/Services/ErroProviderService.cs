
using System.Windows.Forms;
using WinForm.Desktop.Services.Interfaces;

namespace WinFormsApp1.Services
{
    public class ErroProviderService : IErroProvider
    {
        private readonly ErrorProvider _errorProvider = new ErrorProvider();

        public void ClearError(Control control)
        {
            _errorProvider.SetError(control, "");
        }

        public void ErroProvider(Control control, string mensagem)
        {
        
            _errorProvider.SetError(control, mensagem);
        }

        
    }
}
