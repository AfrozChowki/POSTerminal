using System.Collections.Generic;
using POSTerminal.Interfaces;
using POSTerminal.Models;

namespace POSTerminal.Services
{
    /// <summary>
    /// POSTerminal Class to handle POS operations
    /// </summary>
    public class PointOfSaleTerminal : ITerminal
    {
        private Dictionary<string, ProductPricing> _productPricings;
        private Dictionary<string, int> _scannedProducts = new Dictionary<string, int>();

        /// <summary>
        /// CalculateTotal will calculate total as per pricings set
        /// </summary>
        /// <returns>decimal</returns>
        public decimal CalculateTotal()
        {
            if(_productPricings == null)
            {
                return 0;
            }

            decimal total = 0;
            foreach(var scannedProduct in _scannedProducts)
            {
                ProductPricing pricing = _productPricings[scannedProduct.Key];
                if (pricing.HasVolumePrice && scannedProduct.Value >= pricing.Volume)
                {
                    int remainder = scannedProduct.Value % pricing.Volume;
                    int quotient = scannedProduct.Value / pricing.Volume;

                    total += (quotient * pricing.VolumePrice) + (remainder * pricing.UnitPrice);
                }
                else
                {
                    total += scannedProduct.Value * pricing.UnitPrice;
                }
            }

            return total;
        }

        /// <summary>
        /// This method will scan the product code and update the dictionary
        /// </summary>
        /// <param name="productCode"></param>
        public void Scan(string productCode)
        {
            if(!_productPricings.ContainsKey(productCode))
            {
                throw new System.Exception("Invalid product code!");
            }

            if (_scannedProducts.ContainsKey(productCode))
            {
                _scannedProducts[productCode] += 1;
            }
            else
            {
                _scannedProducts.Add(productCode, 1);
            }
        }

        /// <summary>
        /// This Method will set the Products Pricings in a Dictionary
        /// </summary>
        public void SetPricing()
        {
            _productPricings = new Dictionary<string, ProductPricing>()
            {
                {"A", new ProductPricing()
                    {
                    ProductCode = "A",
                    UnitPrice = 1.25M,
                    HasVolumePrice = true,
                    VolumePrice = 3,
                    Volume = 3
                    } 
                },
                {"B", new ProductPricing()
                    {
                    ProductCode = "B",
                    UnitPrice = 4.25M,
                    HasVolumePrice = false,
                    }
                },
                {
                    "C", new ProductPricing()
                    {
                        ProductCode = "C",
                        UnitPrice = 1,
                        HasVolumePrice = true,
                        VolumePrice = 5,
                        Volume = 6
                    }
                },
                {
                    "D", new ProductPricing()
                    {
                    ProductCode = "D",
                    UnitPrice = 0.75M,
                    HasVolumePrice = false,
                    }
                }
            };
        }
    }
}
