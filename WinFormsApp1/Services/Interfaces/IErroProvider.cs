namespace WinForm.Desktop.Services.Interfaces
{
    public interface IErroProvider
    {
        void ErroProvider(Control control, string mensagem);

        public void ClearError(Control control);
    }
}
