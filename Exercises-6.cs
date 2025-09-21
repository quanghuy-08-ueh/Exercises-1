using System;
namespace EXs06;
// Dữ liệu cho Ex 02
public record Member(string Id, string FullName, int Tasks);
class Program
{
    // Helpers dùng chung
    static int ReadInt(string prompt)
    {
        Console.Write(prompt);
        int v;
        while (!int.TryParse(Console.ReadLine(), out v))
            Console.Write("Invalid. Enter an integer: ");
        return v;
    }
    static string ReadNonEmpty(string prompt)
    {
        Console.Write(prompt);
        string s = Console.ReadLine() ?? "";
        while (string.IsNullOrWhiteSpace(s))
        {
            Console.Write("Empty. Enter again: ");
            s = Console.ReadLine() ?? "";
        }
        return s.Trim();
    }
    static bool IsPrime(int x)
    {
        if (x < 2) return false;
        if (x % 2 == 0) return x == 2;
        for (int d = 3; d * d <= x; d += 2)
            if (x % d == 0) return false;
        return true;
    }
    // EX 01: Jagged Array
    // 1) Mẫu đề: 
    // Row0: 1 1 1 1 1
    // Row1: 2 2
    // Row2: 3 3 3 3
    // Row3: 4 4
    static int[][] CreateFixedJagged_Ex01()
    {
        return new int[][]
        {
            new int[] {1,1,1,1,1},
            new int[] {2,2},
            new int[] {3,3,3,3},
            new int[] {4,4}
        };
    }
    static void PrintJagged(int[][] j, string title = "Jagged")
    {
        Console.WriteLine($"-- {title} --");
        for (int i = 0; i < j.Length; i++)
            Console.WriteLine($"Row {i}: " + string.Join(" ", j[i]));
    }
    // 2) Tạo jagged theo user input hoặc random
    static int[][] CreateRandomJaggedFromUser()
    {
        int rows = ReadInt("Number of rows: ");
        var j = new int[rows][];
        var rnd = new Random();
        for (int i = 0; i < rows; i++)
        {
            int cols = ReadInt($"  Row {i} - columns: ");
            j[i] = new int[cols];
            Console.Write($"  Fill row {i} with random? (y/n): ");
            string yn = (Console.ReadLine() ?? "").Trim().ToLowerInvariant();
            if (yn.StartsWith("y"))
            {
                int lo = ReadInt("    Random min: ");
                int hi = ReadInt("    Random max: ");
                if (hi < lo) (lo, hi) = (hi, lo);
                for (int c = 0; c < cols; c++)
                    j[i][c] = rnd.Next(lo, hi + 1);
            }
            else
            {
                for (int c = 0; c < cols; c++)
                    j[i][c] = ReadInt($"    Row {i} Col {c} = ");
            }
        }
        return j;
    }
    // 2.1) In số lớn nhất mỗi hàng & lớn nhất toàn mảng
    static (int[] rowMax, int globalMax) RowMaxAndGlobalMax(int[][] j)
    {
        int[] rowMax = new int[j.Length];
        int global = int.MinValue;
        for (int i = 0; i < j.Length; i++)
        {
            if (j[i].Length == 0) { rowMax[i] = int.MinValue; continue; }
            int mx = j[i][0];
            for (int c = 1; c < j[i].Length; c++)
                if (j[i][c] > mx) mx = j[i][c];
            rowMax[i] = mx;
            if (mx > global) global = mx;
        }
        return (rowMax, global);
    }
    // 2.2) Sắp xếp tăng dần từng hàng
    static void SortEachRowAscending(int[][] j)
    {
        for (int i = 0; i < j.Length; i++)
            Array.Sort(j[i]);
    }
    // 2.3) In phần tử là số nguyên tố
    static void PrintPrimes(int[][] j)
    {
        Console.WriteLine("-- Prime items --");
        for (int i = 0; i < j.Length; i++)
        {
            var primes = j[i].Where(IsPrime).ToArray();
            Console.WriteLine($"Row {i}: {(primes.Length == 0 ? "(none)" : string.Join(" ", primes))}");
        }
    }
    // 2.4) Tìm v in mọi vị trí của một số x
    static List<(int r, int c)> FindPositions(int[][] j, int x)
    {
        var res = new List<(int, int)>();
        for (int i = 0; i < j.Length; i++)
            for (int c = 0; c < j[i].Length; c++)
                if (j[i][c] == x) res.Add((i, c));
        return res;
    }
    // EX 02: Company X – 3 groups (jagged of Members)
    static Member[][] CreateGroups(bool usePreset = true)
    {
        if (usePreset)
        {
            return new Member[][]
            {
                // group 1: 5 members
                new Member[]
                {
                    new("G1-01","An",10), new("G1-02","Binh",7), new("G1-03","Chi",12),
                    new("G1-04","Dung",9), new("G1-05","Em",15)
                },
                // group 2: 3 members
                new Member[]
                {
                    new("G2-01","Ha",11), new("G2-02","Khanh",6), new("G2-03","Lan",8)
                },
                // group 3: 6 members
                new Member[]
                {
                    new("G3-01","Mai",9), new("G3-02","Nam",14), new("G3-03","Oanh",4),
                    new("G3-04","Phuc",7), new("G3-05","Quan",13), new("G3-06","Rin",5)
                }
            };
        }
        else
        {
            // Nhập tay: 5,3,6 theo đề
            var sizes = new[] { 5, 3, 6 };
            var g = new Member[3][];
            for (int gi = 0; gi < 3; gi++)
            {
                Console.WriteLine($"\n-- Enter Group {gi + 1} ({sizes[gi]} members) --");
                g[gi] = new Member[sizes[gi]];
                for (int i = 0; i < sizes[gi]; i++)
                {
                    string id = ReadNonEmpty("  ID: ");
                    string name = ReadNonEmpty("  Full name: ");
                    int tasks = ReadInt("  Completed tasks: ");
                    g[gi] = g[gi].Append(new Member(id, name, tasks)).ToArray();
                }
            }
            return g;
        }
    }
    static void PrintAllMembers(Member[][] groups)
    {
        Console.WriteLine("-- All Members --");
        for (int gi = 0; gi < groups.Length; gi++)
        {
            Console.WriteLine($"Group {gi + 1}:");
            foreach (var m in groups[gi])
                Console.WriteLine($"  {m.Id,-6} | {m.FullName,-12} | Tasks: {m.Tasks}");
        }
    }
    static Member? FindById(Member[][] groups, string id)
    {
        for (int gi = 0; gi < groups.Length; gi++)
        {
            foreach (var m in groups[gi])
                if (m.Id.Equals(id, StringComparison.OrdinalIgnoreCase))
                    return m;
        }
        return null;
    }
    static Member TopPerformer(Member[][] groups)
    {
        // Lấy người có Tasks cao nhất
        Member? best = null;
        foreach (var g in groups)
            foreach (var m in g)
                if (best is null || m.Tasks > best.Tasks)
                    best = m;
        return best!;
    }

    // MENU
    static void MenuEx01()
    {
        int[][] jag = CreateFixedJagged_Ex01(); // khởi tạo mặc định đề bài 1.1
        Console.WriteLine("\n>>> EX 01 – Jagged Arrays");
        PrintJagged(jag, "Initial (fixed)");
        while (true)
        {
            Console.WriteLine("\n[EX01] Menu:");
            Console.WriteLine("1) Re-create jagged (random or input)");
            Console.WriteLine("2) Print biggest of each row + global max");
            Console.WriteLine("3) Sort ascending each row");
            Console.WriteLine("4) Print prime items");
            Console.WriteLine("5) Search a number and print all positions");
            Console.WriteLine("0) Back to main menu");
            int ch = ReadInt("Choose: ");
            if (ch == 0) return;
            switch (ch)
            {
                case 1:
                    jag = CreateRandomJaggedFromUser();
                    PrintJagged(jag, "New jagged");
                    break;

                case 2:
                    var (rowMax, global) = RowMaxAndGlobalMax(jag);
                    Console.WriteLine("Row max: " + string.Join(" | ", rowMax.Select((v, i) => $"r{i}:{v}")));
                    Console.WriteLine("Global max: " + global);
                    break;

                case 3:
                    SortEachRowAscending(jag);
                    PrintJagged(jag, "After sort");
                    break;

                case 4:
                    PrintPrimes(jag);
                    break;

                case 5:
                    int x = ReadInt("Number to search: ");
                    var pos = FindPositions(jag, x);
                    if (pos.Count == 0) Console.WriteLine("Not found.");
                    else
                    {
                        Console.WriteLine("Positions (row,col): " + string.Join(", ", pos.Select(p => $"({p.r},{p.c})")));
                    }
                    break;

                default:
                    Console.WriteLine("Invalid.");
                    break;
            }
        }
    }
    static void MenuEx02()
    {
        Console.WriteLine("\n>>> EX 02 – Company X (3 groups: 5, 3, 6)");
        Member[][] groups = CreateGroups(usePreset: true);
        while (true)
        {
            Console.WriteLine("\n[EX02] Menu:");
            Console.WriteLine("1) Initialize groups (preset)");
            Console.WriteLine("2) Initialize groups (enter manually)");
            Console.WriteLine("3) Print all members");
            Console.WriteLine("4) Print a member by ID");
            Console.WriteLine("5) Print top performer (max tasks)");
            Console.WriteLine("0) Back to main menu");
            int ch = ReadInt("Choose: ");
            if (ch == 0) return;
            switch (ch)
            {
                case 1:
                    groups = CreateGroups(usePreset: true);
                    Console.WriteLine("Initialized with preset data.");
                    break;
                case 2:
                    groups = CreateGroups(usePreset: false);
                    Console.WriteLine("Initialized with manual input.");
                    break;
                case 3:
                    PrintAllMembers(groups);
                    break;
                case 4:
                    {
                        string id = ReadNonEmpty("Enter ID: ");
                        var m = FindById(groups, id);
                        Console.WriteLine(m is null
                            ? "Not found."
                            : $"{m.Id,-6} | {m.FullName,-12} | Tasks: {m.Tasks}");
                        break;
                    }
                case 5:
                    {
                        var top = TopPerformer(groups);
                        Console.WriteLine($"Top performer: {top.FullName} ({top.Id}) – {top.Tasks} tasks");
                        break;
                    }
                default:
                    Console.WriteLine("Invalid.");
                    break;
            }
        }
    }
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        while (true)
        {
            Console.WriteLine("\n MAIN MENU ");
            Console.WriteLine("1) EX 01 – Jagged Arrays tasks");
            Console.WriteLine("2) EX 02 – Company X (3 groups) tasks");
            Console.WriteLine("99) Exit");
            int ch = ReadInt("Choose: ");
            if (ch == 99) return;
            switch (ch)
            {
                case 1: MenuEx01(); break;
                case 2: MenuEx02(); break;
                default: Console.WriteLine("Invalid."); break;
            }
        }
    }
}
