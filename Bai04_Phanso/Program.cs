namespace Bai04_Phanso
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Nhap phan so thu nhat: ");
            PhanSo a = new PhanSo();
            a.Import();

            Console.WriteLine("Nhap phan so thu hai: ");
            PhanSo b = new PhanSo();
            b.Import();

            Console.WriteLine();
            Console.Write("Phan so thu nhat: ");
            a.Export();
            Console.Write("Phan so thu hai: ");
            b.Export();

            Console.WriteLine();
            Console.Write("Tong cua hai phan so: ");
            PhanSo ans = a + b;
            ans.Export();

            Console.Write("Hieu cua hai phan so: ");
            ans = a - b;
            ans.Export();

            Console.Write("Tich cua hai phan so: ");
            ans = a * b;
            ans.Export();

            Console.Write("Thuong cua hai phan so: ");
            ans = a / b;
            ans.Export();
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
                Simplify();
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
                if (TuSo % MauSo == 0)
                    Console.WriteLine(TuSo / MauSo);
                else Console.WriteLine("{0}/{1}", TuSo, MauSo);
            }

            public void Simplify()
            {
                int gcd = GCD(Math.Abs(TuSo), Math.Abs(MauSo));
                TuSo /= gcd;
                MauSo /= gcd;

                if (MauSo < 0)
                {
                    TuSo *= -1;
                    MauSo *= -1;
                }
            }

            private int GCD(int a, int b)
            {
                while (b != 0)
                {
                    int r = a % b;
                    a = b;
                    b = r;
                }
                return a;
            }

            public static PhanSo operator +(PhanSo a, PhanSo b)
            {
                PhanSo res = new PhanSo();
                res.TuSo = a.TuSo * b.MauSo + b.TuSo * a.MauSo;
                res.MauSo = a.MauSo * b.MauSo;
                res.Simplify();
                return res;
            }

            public static PhanSo operator -(PhanSo a, PhanSo b)
            {
                PhanSo res = new PhanSo();
                res.TuSo = a.TuSo * b.MauSo - b.TuSo * a.MauSo;
                res.MauSo = a.MauSo * b.MauSo;
                res.Simplify();
                return res;
            }

            public static PhanSo operator *(PhanSo a, PhanSo b)
            {
                PhanSo res = new PhanSo();
                res.TuSo = a.TuSo * b.TuSo;
                res.MauSo = a.MauSo * b.MauSo;
                res.Simplify();
                return res;
            }

            public static PhanSo operator /(PhanSo a, PhanSo b)
            {
                PhanSo res = new PhanSo();
                res.TuSo = a.TuSo * b.MauSo;
                res.MauSo = a.MauSo * b.TuSo;
                res.Simplify();
                return res;
            }
        }
    }
}
