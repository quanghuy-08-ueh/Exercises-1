using System;
namespace _10ex
{
    class Program2
    {
        static void Main2()
        {
            int choice;
            do
            {
                switch (Menu())
                {
                    case 1:Ex01();break;
                    case 2:Ex02();break;
                    case 3:Ex03();break;
                    case 4:Ex04();break;
                    case 5:Ex05();break;
                    case 0:return;
                    default:Console.WriteLine("Invalid choice, please try again.");break;
                }
            } while (true);
        }
        static int Menu()
        {
            Console.WriteLine("\n(^_^) MENU ");
            Console.WriteLine("1. Calculator (+, -, *, /, %)");
            Console.WriteLine("2. Function x = y^2 + 2y + 1 (y from -5 to 5)");
            Console.WriteLine("3. Speed calculator (km/h & miles/h)");
            Console.WriteLine("4. Sphere surface area & volume");
            Console.WriteLine("5. Character check (vowel, digit, symbol)");
            Console.WriteLine("0. Exit");
            Console.Write("Choose an option: ");
            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice))
                choice = -1; // nếu nhập sai thì gán tạm giá trị không hợp lệ
            return choice;
        }
        // 1. Takes two numbers as input and performs an operation (+,-,*,/,%)
        static void Ex01()
        {
            Console.Write("Enter first number: ");
            double num1 = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter second number: ");
            double num2 = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter operator (+, -, *, /, %): ");
            char op = Convert.ToChar(Console.ReadLine());
            double result = 0;
            switch (op)
            {
                case '+': result = num1 + num2; break;
                case '-': result = num1 - num2; break;
                case '*': result = num1 * num2; break;
                case '/':
                    if (num2 != 0) result = num1 / num2;
                    else Console.WriteLine("Division by zero not allowed.");
                    break;
                case '%': result = num1 % num2; break;
                default: Console.WriteLine("Invalid operator."); break;
            }

            Console.WriteLine("Result: " + result);
        }
        // 2. To display certain values of the function
        static void Ex02()
        {
            for (int y = -5; y <= 5; y++)
            {
                int x = y * y + 2 * y + 1;
                Console.WriteLine("y = {0}, x = {1}", y, x);
            }
        }
        // 3. Takes distance and time (hours, minutes, seconds) as input and displays speed in kilometers per hour (km/h) and miles per hour (miles/h).
        static void Ex03()
        {
            Console.Write("Enter distance (km): ");
            double distance = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter time (hours): ");
            int hours = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter time (minutes): ");
            int minutes = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter time (seconds): ");
            int seconds = Convert.ToInt32(Console.ReadLine());
            double timeInHours = hours + (minutes / 60.0) + (seconds / 3600.0);
            double speedKmh = distance / timeInHours;
            double speedMph = speedKmh / 1.609;
            Console.WriteLine("Speed in km/h: " + speedKmh);
            Console.WriteLine("Speed in miles/h: " + speedMph);
        }
        // 4. Takes the radius of a sphere as input and calculates and displays the surface and volume of the sphere.
        static void Ex04()
        {
            Console.Write("Enter radius of sphere: ");
            double r = Convert.ToDouble(Console.ReadLine());
            double surface = 4 * Math.PI * r * r;
            double volume = (4.0 / 3.0) * Math.PI * Math.Pow(r, 3);
            Console.WriteLine("Surface Area = " + surface);
            Console.WriteLine("Volume = " + volume);
        }
        // 5. Takes a character as input and checks if it is a vowel, a digit, or any other symbol.
        static void Ex05()
        {
            Console.Write("Enter a character: ");
            char ch = Console.ReadKey().KeyChar;
            Console.WriteLine();

            if ("aeiouAEIOU".IndexOf(ch) >= 0)
            {
                Console.WriteLine("It is a vowel.");
            }
            else if (Char.IsDigit(ch))
            {
                Console.WriteLine("It is a digit.");
            }
            else if (Char.IsLetter(ch))
            {
                Console.WriteLine("It is a consonant.");
            }
            else
            {
                Console.WriteLine("It is a symbol.");
            }
        }
    }
}