using System;
class GuessingGame
{
    static void Main4(string[] args)
    {
        GameEngine();
    }
    static void GameEngine()
    {
        double money = 100; // người chơi có 100$ ban đầu
        Console.WriteLine("=== Game Doan So ===");
        Console.WriteLine("Ban co 100$ de bat dau choi.");
        Console.WriteLine("Moi van: Thang +10$, Thua -10$.\n");
        do
        {
            Console.WriteLine($"So du hien tai: {money}$");
            // Chọn độ khó
            int level = 1;
            while (true)
            {
                Console.Write("Chon cap do (1 = De, 2 = Trung binh, 3 = Kho): ");
                if (int.TryParse(Console.ReadLine(), out level) && (level >= 1 && level <= 3))
                    break;
                Console.WriteLine("Nhap sai, vui long nhap 1, 2 hoac 3!");
            }
            int solanchoi = level == 1 ? 10 : (level == 2 ? 7 : 4);
            Random rnd = new Random();
            int comp_num = rnd.Next(1, 101); //[1,100]
            bool is_won = false;
            Console.WriteLine($"\nBan co {solanchoi} lan doan so may nghi (1-100).");
            for (int i = 1; i <= solanchoi; i++)
            {
                int man_num;
                while (true)
                {
                    Console.Write($"Lan {i}: Nhap so ban doan (1-100): ");
                    if (int.TryParse(Console.ReadLine(), out man_num) && man_num >= 1 && man_num <= 100)
                        break;
                    Console.WriteLine("Nhap khong hop le, vui long nhap so tu 1-100!");
                }
                if (man_num == comp_num)
                {
                    is_won = true;
                    Console.WriteLine("Chinh xac! Ban la thien tai!");
                    money += 10; // thắng cộng tiền
                    break;
                }
                else if (man_num > comp_num)
                {
                    Console.WriteLine("So ban doan lon hon so may nghi.");
                }
                else
                {
                    Console.WriteLine("So ban doan nho hon so may nghi.");
                }
            }
            if (!is_won)
            {
                Console.WriteLine($"Het luot! May nghi so {comp_num}. Ban da thua.");
                money -= 10; // thua trừ tiền
            }
            if (money <= 0)
            {
                Console.WriteLine("Ban da het tien! Game over.");
                break;
            }
            Console.Write("\nBan co muon choi tiep? (y/n): ");
            string ans = Console.ReadLine();
            if (ans.ToLower() != "y") break;
        } while (true);
        Console.WriteLine($"\nCam on da choi! So du cuoi cung cua ban: {money}$");
    }
}
