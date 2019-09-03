using System;
using CA_Petshop.Core.ApplicationServices;
using CA_Petshop.Core.ApplicationServices.Services;
using CA_Petshop.Core.DomainServices;
using CA_Petshop.Infrastructure.Data;
using CA_Petshop.Infrastructure.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CA_Petshop.ConsoleMenu
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped<IPetRepository, PetRepository>();
            serviceCollection.AddScoped<IPetService, PetService>();
            serviceCollection.AddScoped<IConsoleMenu, ConsoleMenu>();

            var serviceProvider = serviceCollection.BuildServiceProvider();
            var menu = serviceProvider.GetRequiredService<IConsoleMenu>();
            FakeDataBase.InitData();
            //menu.Run();
        }
    }
}
