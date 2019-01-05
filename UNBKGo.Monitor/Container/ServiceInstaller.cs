using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using UNBKGo.Service.Application;

namespace UNBKGo.Monitor.Container
{
    class ServiceInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<Dispatcher>()
                    .UsingFactoryMethod(() => Dispatcher.CurrentDispatcher)
                    .LifestylePerThread(),
                Component.For<NotifyPropertChangedInterceptor>()
                    .LifestyleTransient(),

                Classes.FromThisAssembly()
                    .InNamespace("UNBKGo.Monitor.ViewModels")
                    .WithServiceSelf()
                    .Configure(x => x.Interceptors<NotifyPropertChangedInterceptor>())
                    .LifestyleSingleton(),
                Classes.FromThisAssembly()
                    .InNamespace("UNBKGo.Monitor.Views")
                    .WithServiceSelf()
                    .LifestyleSingleton(),

                Classes.FromAssemblyInThisApplication()
                    .InNamespace("UNBKGo.Service.Diagnostics")
                    .WithServiceDefaultInterfaces()
                    .LifestyleTransient(),
                Classes.FromAssemblyInThisApplication()
                    .InNamespace("UNBKGo.Service.IO")
                    .WithServiceDefaultInterfaces()
                    .LifestyleTransient(),
                Classes.FromAssemblyInThisApplication()
                    .InNamespace("UNBKGo.Service.Net")
                    .WithServiceDefaultInterfaces()
                    .LifestyleTransient()
            );
        }
    }
}
