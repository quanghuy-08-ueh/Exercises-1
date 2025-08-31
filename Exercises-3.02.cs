using System;
class TaiXiuGame
{
    static void Main(string[] args)
    {
        double money = 100;
        int totalGames = 0, winCount = 0, loseCount = 0, fiveGuessCount = 0;
        Random rnd = new Random();
        Console.WriteLine("=== Tro choi TAI - XIU ===");
        Console.WriteLine("Ban bat dau voi 100$");
        Console.WriteLine("Quy tac: TAI (>5), XIU (<5), SO 5 (dac biet)");
        do
        {
            Console.WriteLine($"So du hien tai: {money}$");
            string choice;
            while (true)
            {
                Console.Write("Ban doan gi? (tai/xiu/5): ");
                choice = Console.ReadLine().Trim().ToLower();
                if (choice == "tai" || choice == "xiu" || choice == "5") break;
                Console.WriteLine("Lua chon khong hop le. Vui long nhap 'tai', 'xiu' hoac '5'.");
            }
            int dice1 = rnd.Next(1, 7);
            int dice2 = rnd.Next(1, 7);
            int sum = dice1 + dice2;
            Console.WriteLine($"Xuc xac: {dice1} + {dice2} = {sum}");
            string result = sum > 5 ? "tai" : (sum < 5 ? "xiu" : "5");
            totalGames++;
            if (choice == "5") fiveGuessCount++;
            if (choice == result)
            {
                if (result == "5")
                {
                    money += 15;
                    Console.WriteLine("Chuc mung! Ban doan dung '5' dac biet (+15$).");
                }
                else
                {
                    money += 5;
                    Console.WriteLine($"Chuc mung! Ban doan dung {result.ToUpper()} (+5$).");
                }
                winCount++;
            }
            else
            {
                money -= 5;
                Console.WriteLine($"Ban doan sai! (-5$). Ket qua la {result.ToUpper()}.");
                loseCount++;
            }
            if (money <= 0)
            {
                Console.WriteLine("Ban da het tien! Game over.");
                break;
            }
            Console.Write("Ban co muon choi tiep? (y/n): ");
            string ans = Console.ReadLine().Trim().ToLower();
            if (ans != "y") break;
        } while (true);
        Console.WriteLine("=== BAO CAO TONG KET ===");
        Console.WriteLine($"Tong so van choi: {totalGames}");
        Console.WriteLine($"So lan thang: {winCount}");
        Console.WriteLine($"So lan thua: {loseCount}");
        Console.WriteLine($"So lan doan '5': {fiveGuessCount}");
        Console.WriteLine($"So du cuoi cung: {money}$");
        Console.WriteLine("Cam on ban da choi!");
    }
}