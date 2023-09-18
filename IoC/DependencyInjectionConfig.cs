
using Autofac;
using WinFormsApp1.Context;
using WinFormsApp1.Interfaces;
using WinFormsApp1.Services;

namespace WinFormsApp1.IoC
{
    public class DependencyInjectionConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<WfDbcontext>();

            builder.RegisterType<PessoaService>().As<IPessoaService>();

            builder.RegisterType<ErroProviderService>().As<IErroProvider>();

            builder.RegisterType<FrmCadastroPessoa>().AsSelf();

            return builder.Build(); 
        }

    }
}
