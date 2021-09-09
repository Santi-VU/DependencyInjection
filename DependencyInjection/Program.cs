using DependencyInjection.Containers;
using DependencyInyection;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DependencyInjection
{
    class Program
    {
        static void Main(string[] args)
        {
            Container container = new Container();

            var product = string.Empty;
            var orderManager = container.serviceProvider.GetService<IOrderManagerService>();

            while (product != "exit")
            {
                Console.WriteLine(@"Enter your product
    Keyboard = 0,
    Mouse = 1,
    Mic = 2,
    Speaker = 3
                    ");
                product = Console.ReadLine();
                try
                {
                    if (Enum.TryParse(product, out Product productEnum))
                    {
                        Console.WriteLine("Please enter a valid payment method: XXXXXXXXXXXXXXXX;MMYY");
                        var paymentMethod = Console.ReadLine();
                        if (string.IsNullOrEmpty(paymentMethod) || paymentMethod.Split(";").Length != 2)
                            throw new Exception("Invalid payment method");
                        orderManager.Submit(productEnum, paymentMethod.Split(";")[0], paymentMethod.Split(";")[1]);
                        Console.WriteLine($"{productEnum.ToString()} has been shipped");
                    }
                    else
                    {
                        Console.WriteLine("Invalid product");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.WriteLine(Environment.NewLine);
            }
        }
    }
}
