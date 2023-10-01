using System;

namespace Palacio_el_restaurante.src.Conection
{
    public class Sale
    {
        private int idSale, amount;
        private String idDish, idEmploy;
        private float price;
        private DateTime date;

        public int IdSale { get => idSale; set => idSale = value; }
        public int Amount { get => amount; set => amount = value; }
        public string IdDish { get => idDish; set => idDish = value; }
        public string IdEmploy { get => idEmploy; set => idEmploy = value; }
        public float Price { get => price; set => price = value; }
        public DateTime Date { get => date; set => date = value; }
    }
}
