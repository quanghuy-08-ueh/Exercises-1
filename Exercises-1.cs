using System;
namespace BTVN
{
    internal class Exercises
    {
        public static void Ex01()
        {
            //1. to Add / Sum Two Numbers.
            Console.WriteLine("Enter the first number: ");
            double a = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter the second number: ");
            double b = Convert.ToDouble(Console.ReadLine());
            double sum = a + b;
            Console.WriteLine("{0} + {1} = {2}", a, b, sum);
        }
        public static void Ex02()
        {
            //2.to Swap Values of Two Variables.
            Console.WriteLine("Enter the first number: ");
            double a = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter the second number: ");
            double b = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine($"Before a la {a}, b la {b}");
            double Tam = a;
            a = b;
            b = Tam;
            Console.WriteLine($"After a la {a}, b la {b}");
        }
        public static void Ex03()
        {
            //3.to Multiply two Floating Point Numbers
            Console.Write("Enter the first number: ");
            float.TryParse(Console.ReadLine(), out float num1);
            Console.Write("Enter the second number: ");
            float.TryParse(Console.ReadLine(), out float num2);
            Console.WriteLine($"Product: {num1 * num2}");
        }
        public static void Ex04()
        {
            //4. to convert feet to meter
            Console.Write("Enter length in feet: ");
            double.TryParse(Console.ReadLine(), out double feet);
            Console.WriteLine($"Answer: {feet * 0.3048}");
        }
        public static void Ex05()
        {
            //5.to convert Celsius to Fahrenheit and vice vers
            string option = "";
            while (option != "0" && option != "1")
            {
                Console.Write("Celsius to Fahrenheit [0] or Fahrenheit to Celsius [1]? ");
                option = Console.ReadLine();
                if (option != "0" && option != "1")
                {
                    Console.WriteLine("Invalid input, please enter 0 or 1.");
                }
            }

            if (option == "0")
            {
                Console.Write("Enter Celsius: ");
                if (double.TryParse(Console.ReadLine(), out double c))
                {
                    Console.WriteLine($"Answer: {c * 9 / 5 + 32}");
                }
                else
                {
                    Console.WriteLine("Invalid number input!");
                }
            }
            else // option == "1"
            {
                Console.Write("Enter Fahrenheit: ");
                if (double.TryParse(Console.ReadLine(), out double f))
                {
                    Console.WriteLine($"Answer: {(f - 32) * 5 / 9}");
                }
                else
                {
                    Console.WriteLine("Invalid number input!");
                }
            }
        }
        public static void Ex06()
        {
            //6. to find the Size of data types
            Console.WriteLine("Size of int: " + sizeof(int) + " bytes");
            Console.WriteLine("Size of float: " + sizeof(float) + " bytes");
            Console.WriteLine("Size of double: " + sizeof(double) + " bytes");
            Console.WriteLine("Size of char: " + sizeof(char) + " bytes");
            Console.WriteLine("Size of long: " + sizeof(long) + " bytes");
            Console.WriteLine("Size of bool: " + sizeof(bool) + " bytes");
        }
        public static void Ex07()
        {
            //7. to Print ASCII Value
            Console.WriteLine("Enter a character: ");
            char ch = Console.ReadKey().KeyChar;
            int asciiValue = (int)ch;
            Console.WriteLine($"\nThe ASCII Value is {asciiValue}");
        }
        public static void Ex08()
        {
            //8. to Calculate Area of Circle
            Console.WriteLine("Enter the radius of the circle: ");
            double radius = Convert.ToDouble(Console.ReadLine());
            double area = Math.PI * radius * radius;
            Console.WriteLine($"Answer: {area}");
        }
        public static void Ex09()
        {
            //9. to Calculate Area of Square
            Console.WriteLine("Enter the side of the square: ");
            double side = Convert.ToDouble(Console.ReadLine());
            double area = side * side;
            Console.WriteLine($"Answer: {area}");
        }
        public static void Ex10()
        {
            //10. to convert days to years, weeks and days
            Console.Write("Enter total days: ");
            int.TryParse(Console.ReadLine(), out int totalDays);
            int years = totalDays / 365;
            int remainingDays = totalDays % 365;
            int months = remainingDays / 30;
            remainingDays %= 30;
            int weeks = remainingDays / 7;
            int days = remainingDays % 7;
            Console.WriteLine($"Answer: {days} days, {weeks} weeks, {months} months, {years} years");
        }
    }
    internal class Program
    {
        static void Main()
        {
            while (true)
            {
                //To choose one out of ten options 
                Console.WriteLine("\n(^-^) MENU:");
                Console.WriteLine("1. To Add / Sum Two Numbers");
                Console.WriteLine("2. To Swap Values of Two Variables");
                Console.WriteLine("3. To Multiply two Floating Point Numbers");
                Console.WriteLine("4. To convert feet to meter");
                Console.WriteLine("5. To convert Celsius to Fahrenheit and vice versa");
                Console.WriteLine("6. To find the Size of data types");
                Console.WriteLine("7. To Print ASCII Value");
                Console.WriteLine("8. To Calculate Area of Circle");
                Console.WriteLine("9. To Calculate Area of Square");
                Console.WriteLine("10. To convert days to years, weeks and days");
                Console.WriteLine("0. Exit");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();
                Console.WriteLine(); 
                switch (choice)
                {
                    case "1": Exercises.Ex01(); break;
                    case "2": Exercises.Ex02(); break;
                    case "3": Exercises.Ex03(); break;
                    case "4": Exercises.Ex04(); break;
                    case "5": Exercises.Ex05(); break;
                    case "6": Exercises.Ex06(); break;
                    case "7": Exercises.Ex07(); break;
                    case "8": Exercises.Ex08(); break;
                    case "9": Exercises.Ex09(); break;
                    case "10": Exercises.Ex10(); break;
                    case "0": return;
                    default: Console.WriteLine("Invalid choice, please try again."); break;
                }
            }
        }
    }
}
