namespace Palacio_el_restaurante.src.Conection
{
    public class Product
    {
        public int Clurp { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }

        public string Type { get; set; }


        public bool UpdateName { get; set; } = false;
        public bool UpdateDescription { get; set; } = false;
        public bool UpdatePrice { get; set; } = false;
        public bool UpdateType { get; set; } = false;

        public Product()
        {

        }
        public Product(int clurp, bool updateName = false, bool updateDescription = false, bool updatePrice = false, bool updateType = false)
        {
            Clurp = clurp;
            UpdateName = updateName;
            UpdateDescription = updateDescription;
            UpdatePrice = updatePrice;
            UpdateType = updateType;
        }
    }
}
