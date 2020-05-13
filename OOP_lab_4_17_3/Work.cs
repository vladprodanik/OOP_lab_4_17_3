using System;
using System.IO;

namespace OOP_lab_4_17_3
{
    class Work
    {
        public static void Key()
        {
            Parse(Read(), false);

            Console.WriteLine("Додавання записiв: +");
            Console.WriteLine("Редагування записiв: E");
            Console.WriteLine("Знищення записiв: -");
            Console.WriteLine("Виведення записiв: Enter");
            Console.WriteLine("Пошук записiв: F");
            Console.WriteLine("Сортуванн записiв: S");
            Console.WriteLine("Вихiд: Esc");

            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.OemPlus:
                    Console.WriteLine();
                    Add();
                    break;

                case ConsoleKey.E:
                    Console.WriteLine();
                    Edit();
                    break;

                case ConsoleKey.OemMinus:
                    Console.WriteLine();
                    Remove();
                    break;

                case ConsoleKey.Enter:
                    Console.WriteLine();
                    Write(Program.weather);
                    Key();
                    break;

                case ConsoleKey.F:
                    Console.WriteLine();
                    Find();
                    break;

                case ConsoleKey.S:
                    Console.WriteLine();
                    Sort();
                    break;

                case ConsoleKey.Escape:
                    return;
            }
        }
        public static string[] Read()
        {
            StreamReader fromFile = new StreamReader("base.txt");

            return fromFile.ReadToEnd().Split("\r\n", StringSplitOptions.RemoveEmptyEntries);
        }

        public static void Add()
        {
            Console.WriteLine("Введiть данi");

            string str = Console.ReadLine();

            string[] elements = str.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Parse(elements, true);

            Key();
        }

        public static void Remove()
        {
            Console.Write("Мiсто: ");

            string city = Console.ReadLine();

            bool[] write = new bool[Program.weather.Length];

            for (int i = 0; i < Program.weather.Length; ++i)
            {
                if (Program.weather[i] != null)
                {
                    if (Program.weather[i].City == city)
                    {
                        Console.WriteLine("{0,-15} {1, -15} {2, -30} {3, -30} {4, -15}", Program.weather[i].Date.ToShortDateString(), Program.weather[i].City, Program.weather[i].Perssure, Program.weather[i].Temperature, Program.weather[i].WindSpeed);

                        Console.WriteLine("Видалити? (Y/N)");

                        var key = Console.ReadKey().Key;

                        if (key == ConsoleKey.Y)
                        {
                            Program.delete[i] = true;
                        }
                        else
                        {
                            Program.delete[i] = false;
                        }
                    }
                }
            }
        }

        public static void Edit()
        {
            Console.Write("Мiсто: ");

            string city = Console.ReadLine();

            bool[] write = new bool[Program.weather.Length];

            for (int i = 0; i < Program.weather.Length; ++i)
            {
                if (Program.weather[i] != null)
                {
                    if (Program.weather[i].City == city)
                    {
                        Console.WriteLine("{0,-15} {1, -15} {2, -30} {3, -30} {4, -15}", Program.weather[i].Date.ToShortDateString(), Program.weather[i].City, Program.weather[i].Perssure, Program.weather[i].Temperature, Program.weather[i].WindSpeed);

                        Console.WriteLine("Введiть нову iнформацiю");

                        string str = Console.ReadLine();

                        string[] elements = str.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                        Program.weather[i] = new Weather(DateTime.Parse(elements[i]), elements[i + 1], int.Parse(elements[+2]), int.Parse(elements[i + 3]), int.Parse(elements[i + 4]));
                    }
                }
            }
        }

        public static void Find()
        {
            Console.Write("Мiсто: ");

            string city = Console.ReadLine();

            bool[] write = new bool[Program.weather.Length];

            for (int i = 0; i < Program.weather.Length; ++i)
            {
                if (Program.weather[i] != null)
                {
                    if (Program.weather[i].City == city)
                    {
                        write[i] = true;
                    }
                    else
                    {
                        write[i] = false;
                    }
                }

            }

            Write(Program.weather, write);

            Key();
        }

        public static void Sort()
        {
            int index = 0;

            while (Program.weather[index + 1] != null)
            {
                for (int i = 0; i < Program.weather.Length - 1; ++i)
                {
                    if (Program.weather[i + 1] != null)
                    {
                        if (Program.weather[i].Date > Program.weather[i + 1].Date)
                        {
                            DateTime tempDate;
                            string tempStr;
                            int tempInt;

                            tempDate = Program.weather[i].Date;
                            Program.weather[i].Date = Program.weather[i + 1].Date;
                            Program.weather[i + 1].Date = tempDate;

                            tempStr = Program.weather[i].City;
                            Program.weather[i].City = Program.weather[i + 1].City;
                            Program.weather[i + 1].City = tempStr;

                            tempInt = Program.weather[i].Perssure;
                            Program.weather[i].Perssure = Program.weather[i + 1].Perssure;
                            Program.weather[i + 1].Perssure = tempInt;

                            tempInt = Program.weather[i].Temperature;
                            Program.weather[i].Temperature = Program.weather[i + 1].Temperature;
                            Program.weather[i + 1].Temperature = tempInt;

                            tempInt = Program.weather[i].WindSpeed;
                            Program.weather[i].WindSpeed = Program.weather[i + 1].WindSpeed;
                            Program.weather[i + 1].WindSpeed = tempInt;
                        }
                    }
                }

                ++index;
            }

            Write(Program.weather);

            Key();
        }

        private static void Save(Weather s)
        {
            StreamWriter save = new StreamWriter("base.txt", true);

            save.WriteLine(s.Date.ToShortDateString());
            save.WriteLine(s.City);
            save.WriteLine(s.Perssure);
            save.WriteLine(s.Temperature);
            save.WriteLine(s.WindSpeed);

            save.Close();
        }

        public static void Parse(string[] elements, bool save)
        {
            int counter = 0;

            while (Program.weather[counter] != null)
            {
                ++counter;
            }

            for (int i = 0; i < elements.Length; i += 5)
            {
                Program.weather[counter + i / 5] = new Weather(DateTime.Parse(elements[i]), elements[i + 1], int.Parse(elements[ + 2]), int.Parse(elements[i + 3]), int.Parse(elements[i + 4]));
                if (save)
                {
                    Save(Program.weather[counter + i / 5]);
                }
            }
        }

        public static void Write(Weather[] s)
        {
            Console.WriteLine("{0,-15} {1, -15} {2, -30} {3, -30} {4, -15}", "Дата", "Мiсто", "Атмосферний тиск", "Температура повiтря", "Швидкiсть вiтру");

            for (int i = 0; i < s.Length; ++i)
            {
                if (s[i] != null)
                {
                    Console.WriteLine("{0,-15} {1, -15} {2, -30} {3, -30} {4, -15}", Program.weather[i].Date.ToShortDateString(), Program.weather[i].City, Program.weather[i].Perssure, Program.weather[i].Temperature, Program.weather[i].WindSpeed);
                }
            }
        }

        public static void Write(Weather[] s, bool[] write)
        {
            Console.WriteLine("{0,-15} {1, -15} {2, -30} {3, -30} {4, -15}", "Дата", "Мiсто", "Атмосферний тиск", "Температура повiтря", "Швидкiсть вiтру");

            for (int i = 0; i < s.Length; ++i)
            {
                if ((write[i]) && (!Program.delete[i]))
                {
                    Console.WriteLine("{0,-15} {1, -15} {2, -30} {3, -30} {4, -15}", Program.weather[i].Date.ToShortDateString(), Program.weather[i].City, Program.weather[i].Perssure, Program.weather[i].Temperature, Program.weather[i].WindSpeed);
                }
            }
        }
    }
}
