using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInyection
{
    public class OrderManagerService : IOrderManagerService
    {
        public void Submit(Product product, string creditCardNumber, string expiryDate)
        {
            var productStockRepository = new ProductStockRepositoryService();
            if (!productStockRepository.IsInStock(product))
            {
                throw new Exception($"{product.ToString()} currently not in stock");
            }

            var paymentProcessor = new PaymentProcessorService();
            paymentProcessor.ChargeCreditCard(creditCardNumber, expiryDate);

            var shippingPorcessor = new ShippingPorcessorService();
            shippingPorcessor.MailProduct(product);
        }
    }
}
