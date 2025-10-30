using System.Xml.Serialization;

namespace Bai04_DayPhanSo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n;
            while (true)
            {
                Console.Write("Nhap so phan tu cua day: ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out n) && n > 0)
                    break;
                Console.WriteLine("Du lieu khong lop le, vui long nhap lai.");
            }

            PhanSo[] lists = new PhanSo[n];
            ListImport(lists, n);

            Console.WriteLine();

            Console.Write("Day phan so la: ");
            ListExport(lists, n);
            Console.WriteLine();

            Console.Write("Phan so lon nhat trong day la: ");
            MaxPS(lists, n).Export();
            Console.WriteLine();

            Console.Write("Day phan so sau khi sap xep tang dan: ");
            ReArrange(lists, n);
            ListExport(lists, n);
            Console.WriteLine();
        }

        class PhanSo
        {
            public int TuSo;
            public int MauSo;

            public PhanSo(int Tu = 0, int Mau = 1)
            {
                if (Mau == 0)
                    throw new ArgumentException("Mau so khong duoc bang 0!");
                TuSo = Tu;
                MauSo = Mau;
            }

            public void Import()
            {
                while (true)
                {
                    Console.Write("Tu so: ");
                    string ipTu = Console.ReadLine();

                    if (!int.TryParse(ipTu, out TuSo) || ipTu.Contains(".") || ipTu.Contains(","))
                        Console.WriteLine("Du lieu khong lop le, vui long nhap lai.");
                    else break;
                }

                while (true)
                {
                    Console.Write("Mau so: ");
                    string ipMau = Console.ReadLine();

                    if (!int.TryParse(ipMau, out MauSo) || MauSo == 0 || ipMau.Contains(".") || ipMau.Contains(","))
                        Console.WriteLine("Du lieu khong lop le, vui long nhap lai.");
                    else break;
                }
            }

            public void Export()
            {
                Console.Write("{0}/{1} ", TuSo, MauSo);
            }

            public static bool operator >(PhanSo a, PhanSo b)
            {
                if (a.TuSo * b.MauSo > b.TuSo * a.MauSo) return true;
                return false;
            }

            public static bool operator <(PhanSo a, PhanSo b)
            {
                if (a.TuSo * b.MauSo < b.TuSo * a.MauSo) return true;
                return false;
            }
        }
        static void ListImport(PhanSo[] list, int n)
        {
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Nhap phan so thu {0}:", i + 1);
                list[i] = new PhanSo();
                list[i].Import();
            }
        }

        static void ListExport(PhanSo[] list, int n)
        {
            for (int i = 0; i < n; i++)
            {
                list[i].Export();
            }
        }

        static PhanSo MaxPS(PhanSo[] list, int n)
        {
            PhanSo res = list[0];
            for (int i = 0; i < n; i++)
            {
                if (res < list[i])
                    res = list[i];
            }

            return res;
        }

        static void ReArrange(PhanSo[] list, int n)
        {
            void swap(ref PhanSo a, ref PhanSo b)
            {
                PhanSo temp = a;
                a = b;
                b = temp;
            }

            for (int i = 0; i < n - 1; i++)
                for (int j = i + 1; j < n; j++)
                    if (list[i] > list[j])
                        swap(ref list[i], ref list[j]);
        }

    }
}
