
using Autofac;

using WinForm.Desktop.Respository;
using WinForm.Desktop.Respository.Interfaces;
using WinForm.Desktop.Services;
using WinForm.Desktop.Services.Interfaces;
using WinFormsApp1.Context;
using WinFormsApp1.Entites;
using WinFormsApp1.Services;

namespace WinFormsApp1.IoC
{
    public class DependencyInjectionConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<WfDbcontext>();

            builder.RegisterType<PessoaRespository>().As<IPessoaRepository>();

            builder.RegisterType<ErroProviderService>().As<IErroProvider>();
            builder.RegisterType<PessoaService>().As<IPessoaService>();

            builder.RegisterType<CreateDatabaseRespository>().As<ICreateDabaseRepository>();
            builder.RegisterType<CreateDatabaseService>().As<ICreateDabaseService>();

            builder.RegisterType<CreateDatabaseService>();

          
           

            builder.RegisterType<GridPessoa>().AsSelf();

            

            return builder.Build(); 
        }

    }
}
