using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInyection
{
    public class ShippingPorcessorService : IShippingPorcessorService
    {
        public void MailProduct(Product product)
        {
            var productStockRepository = new ProductStockRepositoryService();
            productStockRepository.ReduceStock(product);

            Console.WriteLine("Call to shipping api");
        }
    }
}
