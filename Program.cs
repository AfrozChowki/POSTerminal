using System;
using POSTerminal.Services;

namespace POSTerminal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PointOfSaleTerminal terminal = new PointOfSaleTerminal();
            terminal.SetPricing();
            String products = Console.ReadLine();

            try
            {
                foreach (char productCode in products)
                {
                    terminal.Scan(productCode.ToString());
                }

                decimal result = terminal.CalculateTotal();
                Console.WriteLine("Total Price : {0}", result.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }
    }
}
