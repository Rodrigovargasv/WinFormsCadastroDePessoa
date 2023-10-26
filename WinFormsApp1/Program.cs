using Autofac;
using WinForm.Desktop.Services;
using WinForm.Desktop.Services.Interfaces;
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

            
            // configuração de injeção de dependencia

            var container = DependencyInjectionConfig.Configure();


            
            using (var scope = container.BeginLifetimeScope())
            {

                var createDatabaseService = scope.Resolve<ICreateDabaseService>();

                createDatabaseService.CreateDabase();

                var mainForm = scope.Resolve<GridPessoa>(
                    new TypedParameter(typeof(ICreateDabaseService), createDatabaseService));



                Application.Run(mainForm);
            }



        }
    }
}