namespace Сakes
{
    public class Item
    {
        public string name = "";
        public int price = 0;
        public Item(string name, int price)
        {
            this.name = name;
            this.price = price;
        }
        public Item() { }
        public override string ToString()
        {
            return $"{name}: {price}";
        }
    }
}
