using System;
class Program
{
    // BÀI 1 
    // Phiên bản 1: to ind the largest number of the three numbers.
    static int LargestOfThree(int a, int b, int c)
    {
        return Math.Max(a, Math.Max(b, c));
    }

    // Phiên bản 2: accept at least 1 parameter
    static int Largest(params int[] numbers)
    {
        if (numbers == null || numbers.Length == 0)
            throw new ArgumentException("Phải nhập ít nhất 1 số.");
        return numbers.Max();
    }

    //BÀI 2: to calculate the factorial of a number (a non-negative integer). The function accepts the number as an argument.
    static long Factorial(int n)
    {
        if (n < 0) throw new ArgumentException("Number must be non-negative.");
        long result = 1;
        for (int i = 2; i <= n; i++) result *= i;
        return result;
    }

    //BÀI 3: takes a number as a parameter and checks whether the number is prime or not.
    static bool IsPrime(int n)
    {
        if (n <= 1) return false;
        if (n == 2) return true;
        if (n % 2 == 0) return false;
        for (int i = 3; i <= Math.Sqrt(n); i += 2)
            if (n % i == 0) return false;
        return true;
    }

    //BÀI 4.1: to print all prime numbers that less than a number(enter prompt keyboard).
    static void PrintPrimesLessThan(int limit)
    {
        for (int i = 2; i < limit; i++)
            if (IsPrime(i)) Console.Write(i + " ");
        Console.WriteLine();
    }
    //BÀI 4.2: to print the first N prime numbers
    static void PrintFirstNPrimes(int n)
    {
        int count = 0, num = 2;
        while (count < n)
        {
            if (IsPrime(num))
            {
                Console.Write(num + " ");
                count++;
            }
            num++;
        }
        Console.WriteLine();
    }

    //BÀI 5: to check whether a number is "Perfect" or not. Then print all perfect number that less than 1000.
    static bool IsPerfect(int n)
    {
        int sum = 0;
        for (int i = 1; i <= n / 2; i++)
            if (n % i == 0) sum += i;
        return sum == n;
    }
    static void PrintPerfectNumbers(int limit)
    {
        for (int i = 2; i < limit; i++)
            if (IsPerfect(i)) Console.WriteLine(i);
    }

    //BÀI 6: to check whether a string is a pangram or not.
    static bool IsPangram(string sentence)
    {
        string lower = sentence.ToLower();
        for (char c = 'a'; c <= 'z'; c++)
            if (!lower.Contains(c)) return false;
        return true;
    }

    //MENU
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n   MENU   ");
            Console.WriteLine("1. Bài 1: Largest number (3 số và varargs)");
            Console.WriteLine("2. Bài 2: Factorial");
            Console.WriteLine("3. Bài 3: Prime check");
            Console.WriteLine("4. Bài 4: Print primes");
            Console.WriteLine("5. Bài 5: Perfect numbers");
            Console.WriteLine("6. Bài 6: Pangram check");
            Console.WriteLine("0. Thoát");
            Console.Write("Chọn bài: ");

            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("1) Largest of 3 numbers");
                    Console.WriteLine("2) Largest with varargs");
                    Console.Write("Chọn: ");
                    string c1 = Console.ReadLine();

                    if (c1 == "1")
                    {
                        Console.Write("Nhập số thứ 1: ");
                        int a = int.Parse(Console.ReadLine());
                        Console.Write("Nhập số thứ 2: ");
                        int b = int.Parse(Console.ReadLine());
                        Console.Write("Nhập số thứ 3: ");
                        int c = int.Parse(Console.ReadLine());
                        Console.WriteLine("Số lớn nhất: " + LargestOfThree(a, b, c));
                    }
                    else
                    {
                        Console.Write("Nhập các số cách nhau bằng khoảng trắng: ");
                        int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
                        Console.WriteLine("Số lớn nhất: " + Largest(nums));
                    }
                    break;

                case "2":
                    Console.Write("Nhập n: ");
                    int n = int.Parse(Console.ReadLine());
                    Console.WriteLine($"{n}! = " + Factorial(n));
                    break;

                case "3":
                    Console.Write("Nhập số cần kiểm tra: ");
                    int x = int.Parse(Console.ReadLine());
                    Console.WriteLine(IsPrime(x) ? "Là số nguyên tố" : "Không phải số nguyên tố");
                    break;

                case "4":
                    Console.WriteLine("1) In tất cả số nguyên tố nhỏ hơn N");
                    Console.WriteLine("2) In N số nguyên tố đầu tiên");
                    Console.Write("Chọn: ");
                    string c4 = Console.ReadLine();
                    if (c4 == "1")
                    {
                        Console.Write("Nhập N: ");
                        int limit = int.Parse(Console.ReadLine());
                        PrintPrimesLessThan(limit);
                    }
                    else
                    {
                        Console.Write("Nhập N: ");
                        int count = int.Parse(Console.ReadLine());
                        PrintFirstNPrimes(count);
                    }
                    break;

                case "5":
                    Console.WriteLine("Các số hoàn hảo < 1000:");
                    PrintPerfectNumbers(1000);
                    break;

                case "6":
                    Console.Write("Nhập chuỗi: ");
                    string s = Console.ReadLine();
                    Console.WriteLine(IsPangram(s) ? "Là Pangram" : "Không phải Pangram");
                    break;

                case "0":
                    return;

                default:
                    Console.WriteLine("Lựa chọn không hợp lệ!");
                    break;
            }
        }
    }
}
