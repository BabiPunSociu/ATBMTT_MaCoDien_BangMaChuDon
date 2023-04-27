using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ma_bang_chu_don
{
    class Program
    {
        static string Key_Default = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"; // Bảng chữ cái

        string Key; // 1 hoán vị của bảng chữ cái, do người dùng nhập vào

        int index_(string s, char x)
        {
            for (int i = 0; i < s.Length; i++)
            {
                if (x == s[i]) return i;
            }
            return -1;
        }
        string ma_hoa(string mes)
        {
            string result = string.Empty;
            for (int i = 0; i < mes.Length; i++)
            {
                // mes[i] không phải chữ cái thì index = -1
                int index = index_(Key_Default, mes[i]);
                if (index == -1)
                    result += mes[i];
                else result += Key[index];
            }
            return result;
        }

        string giai_ma(string mes)
        {
            string result = string.Empty;
            for (int i = 0; i < mes.Length; i++)
            {
                // mes[i] không phải chữ cái thì index = -1
                int index = index_(Key, mes[i]);
                if (index == -1)
                    result += mes[i];
                else result += Key_Default[index];
            }
            return result;
        }

        public int show_menu()
        {
            Console.WriteLine("Chon mot trong cac chuc nang sau:");
            Console.WriteLine("1. Ma hoa");
            Console.WriteLine("2. Giai ma");
            Console.WriteLine("0. Thoat");
            while (true)
            {
                Console.Write("Lua chon cua ban la: ");
                int luaChon = Convert.ToInt32(Console.ReadLine());
                if (luaChon >= 0 && luaChon <= 2)
                    return luaChon;
                Console.WriteLine("\nBan chi duoc chon trong [0,2]");
            }
        }

        static void Main(string[] args)
        {
            Program subjec = new Program();
            while (true)
            {
                int luaChon = subjec.show_menu();
                if (luaChon == 0) break;
                else if (luaChon == 1)  // Mã hóa
                {
                    // Nhap ban ro
                    Console.Write("Nhap van ban can ma hoa (ban ro): ");
                    string Plaintext = Console.ReadLine().ToUpper();
                    // Nhap khoa
                    Console.Write("Nhap khoa: là 1 hoán vị của 26 chữ cái trong bảng chữ cái: K = ");
                    subjec.Key = Console.ReadLine().ToUpper();

                    string result = subjec.ma_hoa(Plaintext);
                    Console.WriteLine("\nBan ro: "+Plaintext);
                    Console.WriteLine("Ban ma: " + result);
                }
                else
                {   // giải mã
                    // Nhap ban ma
                    Console.Write("Nhap van ban can giai ma (ban ma): ");
                    string Ciphertext = Console.ReadLine().ToUpper();
                    // Nhap khoa
                    Console.Write("Nhap khoa: là 1 hoán vị của 26 chữ cái trong bảng chữ cái: K = ");
                    subjec.Key = Console.ReadLine().ToUpper();

                    string result = subjec.giai_ma(Ciphertext);
                    Console.WriteLine("\nBan ma: " + Ciphertext);
                    Console.WriteLine("Ban ro: " + result);
                }    
            }
        }
    }
}
