using System;
namespace Сakes
{
    public class Cake
    {
        Item forma = new Item();
        Item size = new Item();
        Item taste = new Item();
        Item glasur = new Item();
        Item decor = new Item();
        int count;

        public double get_price()
        {
            double sum = 100;
            sum += forma.price;
            sum += size.price;
            sum += taste.price;
            sum += glasur.price;
            sum += decor.price;
            return sum;
        }
        public void to_str()
        {
            Console.WriteLine($"Форма: {forma}");
            Console.WriteLine($"Размер: {size}");
            Console.WriteLine($"Вкус: {taste}");
            Console.WriteLine($"Глазурь: {glasur}");
            Console.WriteLine($"Декор: {decor}");
            Console.WriteLine($"Число: {count}");
            Console.WriteLine(string.Format("Цена: {0:f2}", get_price()));
        }
        public override string ToString()
        {
            string res = "";
            res += $"Форма - {forma}\n";
            res += $"Размер - {size}\n";
            res += $"Вкус - {taste}\n";
            res += $"Глазурь - {glasur}\n";
            res += $"Декор - {decor}\n";
            res += $"Число - {count}\n";
            res += string.Format("Цена - {0:f2}", get_price());
            return res;
        }
        public void set_field(int field_id, int data_id)
        {
            switch (field_id)
            {
                case 0: forma = Data.types_forms[data_id]; break;
                case 1: size = Data.types_sizes[data_id]; break;
                case 2: taste = Data.types_tastes[data_id]; break;
                case 3: glasur = Data.types_glasurs[data_id]; break;
                case 4: decor = Data.types_decors[data_id]; break;
            }
        }
        public void set_count(int count)
        {
            this.count = count;
        }
        public string get_shot_str()
        {
            string res = "";
            if (forma.name != "") res += $"| Форма - {forma} ";
            if (size.name != "") res += $"| Размер - {size}";
            if (taste.name != "") res += $"| Вкус - {taste}";
            if (glasur.name != "") res += $"| Глазурь - {glasur}";
            if (decor.name != "") res += $"| Декор - {decor}";
            if (count != 0) res += $"| Кол-во - {count}";
            return res;
        }
    }
}
