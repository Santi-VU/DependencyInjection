using DependencyInyection;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInjection.Containers
{
    class Container
    {
        private ServiceCollection serviceCollection;
        public ServiceProvider serviceProvider { get; protected set; }

        public Container()
        {
            serviceCollection = new ServiceCollection();

            serviceCollection.AddSingleton<IOrderManagerService, OrderManagerService>();
            serviceCollection.AddSingleton<IPaymentProcessorService, PaymentProcessorService>();
            serviceCollection.AddSingleton<IProductStockRepositoryService, ProductStockRepositoryService>();
            serviceCollection.AddSingleton<IShippingPorcessorService, ShippingPorcessorService>();
            serviceProvider = serviceCollection.BuildServiceProvider();
        }
    }
}
