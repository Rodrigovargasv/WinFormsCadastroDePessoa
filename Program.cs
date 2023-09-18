using Autofac;
using System.ComponentModel;
using WinFormsApp1.IoC;

namespace WinFormsApp1
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            //Application.Run(new Form1());


            // configuração de injeção de dependencia

            var container = DependencyInjectionConfig.Configure();

            using (var scope = container.BeginLifetimeScope())
            {
                var mainForm = scope.Resolve<FrmCadastroPessoa>();
                Application.Run(mainForm);
            }


            
        }
    }
}