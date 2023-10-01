using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palacio_el_restaurante.src.Conection
{
    public class SaleHistory
    {
        private List<Sale> salesList;

        public SaleHistory()
        {
            salesList = new List<Sale>();
        }
        public void AddSale(Sale sale)
        {
            salesList.Add(sale);
        }

        public List<Sale> GetAllSales()
        {
            return salesList;
        }

        public List<Sale> GetSalesByDate(DateTime startDate, DateTime endDate)
        {
            List<Sale> filteredSales = new List<Sale>();

            foreach (Sale sale in salesList)
            {
                if (sale.Date >= startDate && sale.Date <= endDate)
                {
                    filteredSales.Add(sale);
                }
            }

            return filteredSales;
        }

        public List<Sale> GetSalesByEmployee(string employeeId)
        {
            List<Sale> salesByEmployee = new List<Sale>();

            foreach (Sale sale in salesList)
            {
                if (sale.IdEmploy.Equals(employeeId, StringComparison.OrdinalIgnoreCase))
                {
                    salesByEmployee.Add(sale);
                }
            }

            return salesByEmployee;
        }

        public List<Sale> GetSalesByDish(string dishId)
        {
            List<Sale> salesByDish = new List<Sale>();

            foreach (Sale sale in salesList)
            {
                if (sale.IdDish.Equals(dishId, StringComparison.OrdinalIgnoreCase))
                {
                    salesByDish.Add(sale);
                }
            }

            return salesByDish;
        }
    }
}
