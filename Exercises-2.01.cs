using System;
namespace _10ex
{
    internal class Program
    {
        public static void Ex01()
        {
            Console.WriteLine("Enter degrees Celsius: ");
            if (double.TryParse(Console.ReadLine(), out double celsius))
            {
                double kelvin = celsius + 273;
                double fahrenheit = celsius * 18 / 10 + 32;

                Console.WriteLine($"Kelvin= {kelvin}");
                Console.WriteLine($"Fahrenheit = {fahrenheit}");
            }
            else
            {
                Console.WriteLine("Invalid input! Please enter a number.");
            }
        }
        public static void Ex02()
        {
            Console.WriteLine("Enter radius of the sphere: ");
            if (double.TryParse(Console.ReadLine(), out double radius))
            {
                double surface = 4 * Math.PI * Math.Pow(radius, 2);
                double volume = 4 / 3 * Math.PI * Math.Pow(surface, 3);
                Console.WriteLine($"Surface = {surface}");
                Console.WriteLine($"Volume = {volume}");
            }
            else
            {
                Console.WriteLine("Invalid input! Please enter a number.");
            }
        }
        public static void Ex03()
        {
            Console.WriteLine("Enter the first number: ");
            if (double.TryParse(Console.ReadLine(), out double a))
            {
                Console.WriteLine("Enter the second number: ");
                if (double.TryParse(Console.ReadLine(), out double b))
                {
                    double Sum = a + b;
                    double Difference = a - b;
                    double Product = a * b;
                    double Quotient = a / b;
                    double Surplus = a % b;
                    Console.WriteLine($"Sum = {Sum}");
                    Console.WriteLine($"Difference = {Difference}");
                    Console.WriteLine($"Product = {Product}");
                    Console.WriteLine($"Quotient = {Quotient}");
                    Console.WriteLine($"Surplus = {Surplus}");
                }
                else
                {
                    Console.WriteLine("Invalid input! Please enter a number.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input! Please enter a number.");
            }
        }
    }
    internal class Exercise
    {
        static void Main()
        {
            while (true)
            {
                Console.WriteLine("\n (^_^) Menu: ");
                Console.WriteLine("1. To convert from degrees Celsius to Kelvin and Fahrenheit");
                Console.WriteLine("2. Calculate the surface and volume of a sphere");
                Console.WriteLine("3. Calculates the result of adding, subtracting, multiplying and dividing two numbers");
                Console.WriteLine("0. Exit");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();
                Console.WriteLine();
                switch (choice)
                {
                    case "1": Program.Ex01(); break;
                    case "2": Program.Ex02(); break;
                    case "3": Program.Ex03(); break;
                    case "0": return;
                    default: Console.WriteLine("Invalid choice, please try again."); break;
                }

            }
        }
    }
}
