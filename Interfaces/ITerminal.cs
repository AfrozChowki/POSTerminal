using System;

namespace POSTerminal.Interfaces
{
    public interface ITerminal
    {
        void SetPricing();
        void Scan(String product);
        decimal CalculateTotal();
    }
}
