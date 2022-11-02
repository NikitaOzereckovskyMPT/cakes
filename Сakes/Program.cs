using System;
using System.IO;

namespace Сakes
{

    class Program
    {
        static Cake cur_cake = new Cake();
        static int main_id = 0;
        static int sub_id = -1;
        static int MAX = 0;

        static void Main(string[] args)
        {
            MAX = Data.get_lenght(5) - 1;   
            main_menu(0);
            bool is_run = true;
            while (is_run)
            {
                while (get_key());
                is_run = check_continue();
            }
        }
        
        static bool check_continue()
        {
            Console.WriteLine("Ввести следующий заказ? 1 - да, 0 - выход");
            return Console.ReadLine() == "1";
        }
        static bool get_key()
        {
            ConsoleKeyInfo key = Console.ReadKey();
            if (key.Key == ConsoleKey.Enter)  click_enter();
            if (key.Key == ConsoleKey.Escape) click_esc();
            if (key.Key == ConsoleKey.UpArrow) click_up();
            if (key.Key == ConsoleKey.DownArrow) click_down();
            return true;
        }
        static public void click_enter()
        {
            Console.Clear();
            if (sub_id >= 0)
            {
                cur_cake.set_field(main_id, sub_id);
                sub_id = -1;
                main_id = 0;
                main_menu();
                return;
            }

            if (sub_id == -1)
            {
                if (main_id == MAX - 1)
                {
                    input_count();
                    Console.Clear();
                    main_menu();
                    return;
                }
                if (main_id == MAX)
                {
                    print();
                    save();
                    return;
                }
                sub_id = 0;
                sub_menu();
            }
        }
        static public void click_esc()
        {
            Console.Clear();
            if (sub_id >= 0)
                sub_id = -1;
            main_id = 0;
            main_menu();
        }
        static public void click_up()
        {
            Console.Clear();
            if (sub_id == -1)
            {
                main_id -= 1;
                if (main_id == -1)
                    main_id = MAX;
                main_menu();
                return;
            }
            if (sub_id >= 0)
            {
                sub_id -= 1;
                if (sub_id == -1)
                    sub_id = Data.get_lenght(main_id) - 1;
                sub_menu();
                return;
            }
        }
        static public void click_down()
        {
            Console.Clear();
            if (sub_id == -1)
            {
                main_id += 1;
                if (main_id > MAX)
                    main_id = 0;
                main_menu();
                return;
            }
            if (sub_id >= 0)
            {
                sub_id += 1;
                if (sub_id == Data.get_lenght(main_id))
                    sub_id = 0;
                sub_menu();
                return;
            }
        }
        static public void input_count()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Введите число тортов. Для выхода введите 0");
                    string data = Console.ReadLine();
                    if (data == "0")
                    {
                        click_esc();
                        return;
                    }
                    cur_cake.set_count(Convert.ToInt32(data));
                    return;
                }
                catch
                {
                    Console.WriteLine("Повторите ввод");

                }
            }
        }
        
        static void main_menu(int start = 0,  int end = 6)
        {
            string[] menu = Data.menu;
            for (int i = start; i <= end; i++)
            {
                if (i != main_id) Console.WriteLine($"    {menu[i]}");
                if (i == main_id) Console.WriteLine($" -->{menu[i]}");
            }
            if (end == 6)
            {
                Console.WriteLine($"\nЦена: {cur_cake.get_price()}");
                Console.WriteLine(cur_cake.get_shot_str());
            }
        }
        static void sub_menu()
        {
            main_menu(0, main_id);
            Item[] data = Data.types_forms;
            switch(main_id)
            {
                case 0: data = Data.types_forms;   break;
                case 1: data = Data.types_sizes;   break;
                case 2: data = Data.types_tastes;  break;
                case 3: data = Data.types_glasurs; break;
                case 4: data = Data.types_decors;  break;
            }
            for(int i = 0; i < data.Length; i++)
            {
                if (i != sub_id) Console.WriteLine($"        {data[i]}");
                if (i == sub_id) Console.WriteLine($"     -->{data[i]}");
            }
            main_menu(main_id + 1, MAX);
        }

        static void save()
        {
            using (StreamWriter wr = new StreamWriter("C:\\Users\\nikti\\OneDrive\\Рабочий стол\\Chek.txt"))
            {
                wr.WriteLine($"{DateTime.Now.ToString("dd.MM.yyyy - HH:mm:ss")}");
                wr.WriteLine(cur_cake);
            }
        }
        static void print()
        {
            Console.WriteLine($"Заказ от {DateTime.Now.ToString("dd.MM.yyyy - HH:mm:ss")}");
            cur_cake.to_str();
        }
    }
}