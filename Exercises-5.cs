using System;
namespace EXs05;
class Program
{
    //  Helpers 
    static void Print<T>(IEnumerable<T> xs, string label = "")
    {
        if (!string.IsNullOrEmpty(label)) Console.Write(label + ": ");
        Console.WriteLine(string.Join(" ", xs));
    }
    static int ReadInt(string prompt)
    {
        Console.Write(prompt);
        int v;
        while (!int.TryParse(Console.ReadLine(), out v))
            Console.Write("Invalid. Enter an integer: ");
        return v;
    }
    static int[] ReadIntArray(string prompt, int count)
    {
        Console.WriteLine(prompt);
        var a = new int[count];
        for (int i = 0; i < count; i++) a[i] = ReadInt($"  #{i + 1}: ");
        return a;
    }
    static int[] CreateRandomArray(int size, int minInclusive, int maxInclusive, int? seed = null)
    {
        if (maxInclusive < minInclusive) (minInclusive, maxInclusive) = (maxInclusive, minInclusive);
        var rnd = seed.HasValue ? new Random(seed.Value) : new Random();
        return Enumerable.Range(0, size).Select(_ => rnd.Next(minInclusive, maxInclusive + 1)).ToArray();
    }
    //  1) to calculate the average value of array elements.
    static double Average(int[] a)
    {
        if (a == null || a.Length == 0) return 0;
        long sum = 0;
        foreach (var v in a) sum += v;
        return (double)sum / a.Length;
    }
    //  2) to test if an array contains a specific value. 
    static bool Contains(int[] a, int value)
    {
        foreach (var v in a) if (v == value) return true;
        return false;
    }
    //  3) to find the index of an array element.
    static int IndexOf(int[] a, int value)
    {
        for (int i = 0; i < a.Length; i++)
            if (a[i] == value) return i;
        return -1;
    }
    //  4) to remove a specific element from an array. 
    static int[] RemoveValue(int[] a, int value)
    {
        int idx = IndexOf(a, value);
        if (idx == -1) return (int[])a.Clone();
        var b = new int[a.Length - 1];
        for (int i = 0, j = 0; i < a.Length; i++)
            if (i != idx) b[j++] = a[i];
        return b;
    }
    //  5) to find the maximum and minimum value of an array.
    static (int max, int min) MaxMin(int[] a)
    {
        if (a == null || a.Length == 0) throw new ArgumentException("Array is empty.");
        int max = a[0], min = a[0];
        for (int i = 1; i < a.Length; i++)
        {
            if (a[i] > max) max = a[i];
            if (a[i] < min) min = a[i];
        }
        return (max, min);
    }
    //  6) to reverse an array of integer values.
    static void ReverseInPlace(int[] a)
    {
        for (int i = 0, j = a.Length - 1; i < j; i++, j--)
            (a[i], a[j]) = (a[j], a[i]);
    }
    //  7) to find duplicate values in an array of values. 
    static int[] FindDuplicates(int[] a)
    {
        var seen = new HashSet<int>();
        var dups = new HashSet<int>();
        foreach (var v in a)
            if (!seen.Add(v)) dups.Add(v);
        return dups.OrderBy(x => x).ToArray();
    }
    //  8) to remove duplicate elements from an array.
    static int[] RemoveDuplicates(int[] a)
    {
        var seen = new HashSet<int>();
        var res = new List<int>(a.Length);
        foreach (var v in a)
            if (seen.Add(v)) res.Add(v);
        return res.ToArray();
    }
    //  requests 10 integers from the user and orders them by implementing the bubble sort algorithm.
    static void BubbleSort(int[] a)
    {
        for (int pass = 0; pass < a.Length - 1; pass++)
        {
            bool swapped = false;
            for (int i = 0; i < a.Length - 1 - pass; i++)
            {
                if (a[i] > a[i + 1])
                {
                    (a[i], a[i + 1]) = (a[i + 1], a[i]);
                    swapped = true;
                }
            }
            if (!swapped) break; // already sorted
        }
    }

    //  Request a sentence from the user, then ask to enter a word. Search if the word appears in the phrase using the linear search algorithm.
    static bool LinearSearchWord(string sentence, string word)
    {
        if (string.IsNullOrWhiteSpace(word)) return false;
        var target = word.Trim().ToLowerInvariant();
        string token = "";
        foreach (char ch in sentence)
        {
            if (char.IsLetterOrDigit(ch))
                token += char.ToLowerInvariant(ch);
            else
            {
                if (token.Length > 0)
                {
                    if (token == target) return true;
                    token = "";
                }
            }
        }
        if (token.Length > 0 && token == target) return true;
        return false;
    }

    //  MENU 
    static void Main000()
    {
        // Mảng ngẫu nhiên khởi tạo ban đầu
        int[] arr = CreateRandomArray(size: 12, minInclusive: 0, maxInclusive: 50, seed: 0);
        Console.WriteLine("Array Toolkit App – All-in-one\n");
        while (true)
        {
            Console.WriteLine(" MENU ");
            Console.WriteLine("0) Show current array");
            Console.WriteLine("1) Regenerate random array (size, min..max)");
            Console.WriteLine("2) Average of array");
            Console.WriteLine("3) Contains a value");
            Console.WriteLine("4) Index of a value (first occurrence)");
            Console.WriteLine("5) Remove a value (first occurrence)");
            Console.WriteLine("6) Max & Min");
            Console.WriteLine("7) Reverse array (in place)");
            Console.WriteLine("8) Find duplicates (unique values)");
            Console.WriteLine("9) Remove duplicates (keep first)");
            Console.WriteLine("10) Bubble sort 10 integers (user input)");
            Console.WriteLine("11) Linear search a word in a sentence");
            Console.WriteLine("99) Exit");

            int choice = ReadInt("Choose: ");
            Console.WriteLine();
            try
            {
                switch (choice)
                {
                    case 0:
                        Print(arr, "Current array");
                        break;
                    case 1:
                        {
                            int size = ReadInt("Size = ");
                            int lo = ReadInt("Min (inclusive) = ");
                            int hi = ReadInt("Max (inclusive) = ");
                            arr = CreateRandomArray(size, lo, hi);
                            Print(arr, "New random array");
                            break;
                        }
                    case 2:
                        Console.WriteLine($"Average = {Average(arr):F2}");
                        break;
                    case 3:
                        {
                            int x = ReadInt("Value to check: ");
                            Console.WriteLine(Contains(arr, x) ? "Found" : "Not found");
                            break;
                        }
                    case 4:
                        {
                            int x = ReadInt("Value to find index: ");
                            Console.WriteLine($"Index = {IndexOf(arr, x)}");
                            break;
                        }
                    case 5:
                        {
                            int x = ReadInt("Value to remove (first occurrence): ");
                            arr = RemoveValue(arr, x);
                            Print(arr, "After remove");
                            break;
                        }
                    case 6:
                        {
                            var (mx, mn) = MaxMin(arr);
                            Console.WriteLine($"Max = {mx}, Min = {mn}");
                            break;
                        }
                    case 7:
                        ReverseInPlace(arr);
                        Print(arr, "Reversed");
                        break;
                    case 8:
                        {
                            var d = FindDuplicates(arr);
                            Print(d, "Duplicates");
                            break;
                        }
                    case 9:
                        arr = RemoveDuplicates(arr);
                        Print(arr, "Distinct (order preserved)");
                        break;
                    case 10:
                        {
                            var user = ReadIntArray("Enter 10 integers:", 10);
                            Print(user, "Before");
                            BubbleSort(user);
                            Print(user, "After bubble sort");
                            break;
                        }
                    case 11:
                        {
                            Console.Write("Enter a sentence: ");
                            string sentence = Console.ReadLine() ?? "";
                            Console.Write("Enter a word to search: ");
                            string word = Console.ReadLine() ?? "";
                            bool found = LinearSearchWord(sentence, word);
                            Console.WriteLine(found
                                ? "The word appears in the sentence."
                                : "The word does NOT appear.");
                            break;
                        }
                    case 99:
                        return;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            Console.WriteLine();
        }
    }
}
