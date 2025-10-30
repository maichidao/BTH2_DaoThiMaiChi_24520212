using System.Drawing;

namespace Bai05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int k;
            while (true)
            {
                Console.Write("Nhap so luong khu dat: ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out k) && k > 0)
                    break;
                Console.WriteLine("Du lieu khong lop le, vui long nhap lai.");
            }
            KhuDat[] K = new KhuDat[k];

            int n;
            while (true)
            {
                Console.Write("Nhap so luong nha pho: ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out n) && n > 0)
                    break;
                Console.WriteLine("Du lieu khong lop le, vui long nhap lai.");
            }
            NhaPho[] N = new NhaPho[n];

            int c;
            while (true)
            {
                Console.Write("Nhap so luong chung cu: ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out c) && c > 0)
                    break;
                Console.WriteLine("Du lieu khong lop le, vui long nhap lai.");
            }
            ChungCu[] C = new ChungCu[c];

            Choose(K, N, C);
        }

        public class KhuDat
        {
            protected string DiaDiem;
            protected long GiaBan;
            protected double DienTich;

            public string getDiaDiem
            {
                get
                {
                    return DiaDiem;
                }
            }

            public long getGiaBan
            {
                get
                {
                    return GiaBan;
                }
            }

            public double getDienTich
            {
                get
                {
                    return DienTich;
                }
            }

            public void KDImport()
            {
                Console.Write("Dia diem: ");
                DiaDiem = Console.ReadLine();

                while (true)
                {
                    Console.Write("Gia ban: ");
                    string input = Console.ReadLine();

                    if (long.TryParse(input, out GiaBan) && GiaBan > 0)
                        break;
                    Console.WriteLine("Du lieu khong lop le, vui long nhap lai.");
                }

                while (true)
                {
                    Console.Write("Dien tich: ");
                    string input = Console.ReadLine();

                    if (double.TryParse(input, out DienTich) && DienTich > 0)
                        break;
                    Console.WriteLine("Du lieu khong lop le, vui long nhap lai.");
                }

                moreImport();
            }

            public void KDExport()
            {
                Console.WriteLine("Dia diem: {0}", DiaDiem);
                Console.WriteLine("Gia ban: {0}", GiaBan);
                Console.WriteLine("Dien tich: {0}", DienTich);
                moreExport();
            }

            virtual public void moreImport() { }
            virtual public void moreExport() { }
        }

        public class NhaPho : KhuDat
        {
            private int NamXD;
            private int SoTang;

            public int getNamXD
            {
                get
                {
                    return NamXD;
                }
            }
            public int getSoTang()
            {
                return SoTang;
            }

            public override void moreImport()
            {
                //base.moreImport();
                while (true)
                {
                    Console.Write("Nam xay dung: ");
                    string input = Console.ReadLine();

                    if (int.TryParse(input, out NamXD) && NamXD > 0)
                        break;
                    Console.WriteLine("Du lieu khong lop le, vui long nhap lai.");
                }

                while (true)
                {
                    Console.Write("So tang: ");
                    string input = Console.ReadLine();

                    if (int.TryParse(input, out SoTang) && SoTang > 0)
                        break;
                    Console.WriteLine("Du lieu khong lop le, vui long nhap lai.");
                }
            }

            public override void moreExport()
            {
                //   base.moreExport();
                Console.WriteLine("Nam xay dung: {0}", NamXD);
                Console.WriteLine("So tang: {0}", SoTang);
            }
        }

        public class ChungCu : KhuDat
        {
            private int Tang;

            public int getTang
            {
                get
                {
                    return Tang;
                }
            }

            public override void moreImport()
            {
                //base.moreImport();
                while (true)
                {
                    Console.Write("Thuoc tang: ");
                    string input = Console.ReadLine();

                    if (int.TryParse(input, out Tang) && Tang > 0)
                        break;
                    Console.WriteLine("Du lieu khong lop le, vui long nhap lai.");
                }
            }

            public override void moreExport()
            {
                //   base.moreExport();
                Console.WriteLine("Thuoc tang: {0}", Tang);
            }
        }

        static void Menu()
        {
            Console.WriteLine("-------------------------------------------------------------------");
            Console.WriteLine(" (1) Nhap va xuat thong tin");
            Console.WriteLine(" (2) Xuat tong gia ban ba loai");
            Console.WriteLine(" (3) Xuat danh sach khu dat co dien tich tren 100 m2 hoac nha pho co dien tich tren 60m2 va nam xay dung bat dau tu 2019");
            Console.WriteLine(" (4) Tim thong tin danh sach tat ca cac nha pho hoac chung cu phu hop yeu cau ");
            Console.WriteLine(" (5) Thoat");
            Console.WriteLine("-------------------------------------------------------------------");
        }

        static void Choose(KhuDat[] ListKhuDat, NhaPho[] ListNhaPho, ChungCu[] ListChungCu)
        {
            Menu();
            Console.Write("Lua chon cua ban (1-5): ");
            int res = int.Parse(Console.ReadLine());
            switch (res)
            {
                case 1:
                    Import(ListKhuDat, ListNhaPho, ListChungCu);
                    Export(ListKhuDat, ListNhaPho, ListChungCu);
                    Choose(ListKhuDat, ListNhaPho, ListChungCu);
                    break;

                case 2:
                    TotalGiaBan(ListKhuDat, ListNhaPho, ListChungCu);
                    Choose(ListKhuDat, ListNhaPho, ListChungCu);
                    break;

                case 3:
                    FindListExport(ListKhuDat, ListNhaPho, ListChungCu);
                    Choose(ListKhuDat, ListNhaPho, ListChungCu);
                    break;

                case 4:
                    FindListInfo(ListKhuDat, ListNhaPho, ListChungCu);
                    Choose(ListKhuDat, ListNhaPho, ListChungCu);
                    break;

                case 5:
                    break;

                default:
                    Console.WriteLine("Lua chon khong hop le, vui long chon lai.");
                    Choose(ListKhuDat, ListNhaPho, ListChungCu);
                    break;
            }
        }

        static void Import(KhuDat[] ListKhuDat, NhaPho[] ListNhaPho, ChungCu[] ListChungCu)
        {
            for (int i = 0; i < ListKhuDat.Length; i++)
            {
                Console.WriteLine("Khu dat thu {0}:", i + 1);
                ListKhuDat[i] = new KhuDat();
                ListKhuDat[i].KDImport();
            }

            Console.WriteLine();
            for (int i = 0; i < ListNhaPho.Length; i++)
            {
                Console.WriteLine("Nha pho thu {0}:", i + 1);
                ListNhaPho[i] = new NhaPho();
                ListNhaPho[i].KDImport();
            }

            Console.WriteLine();
            for (int i = 0; i < ListChungCu.Length; i++)
            {
                Console.WriteLine("Chung cu thu {0}:", i + 1);
                ListChungCu[i] = new ChungCu();
                ListChungCu[i].KDImport();
            }
            Console.WriteLine();
        }

        static void Export(KhuDat[] ListKhuDat, NhaPho[] ListNhaPho, ChungCu[] ListChungCu)
        {
            for (int i = 0; i < ListKhuDat.Length; i++)
            {
                Console.WriteLine("Khu dat thu {0}:", i + 1);
                ListKhuDat[i].KDExport();
            }

            Console.WriteLine();
            for (int i = 0; i < ListNhaPho.Length; i++)
            {
                Console.WriteLine("Nha pho thu {0}:", i + 1);
                ListNhaPho[i].KDExport();
            }

            Console.WriteLine();
            for (int i = 0; i < ListChungCu.Length; i++)
            {
                Console.WriteLine("Chung cu thu {0}:", i + 1);
                ListChungCu[i].KDExport();
            }
        }

        static void TotalGiaBan(KhuDat[] ListKhuDat, NhaPho[] ListNhaPho, ChungCu[] ListChungCu)
        {
            long SumKhuDat = 0;
            for (int i = 0; i < ListKhuDat.Length; i++)
                SumKhuDat += ListKhuDat[i].getGiaBan;

            long SumNhaPho = 0;
            for (int i = 0; i < ListNhaPho.Length; i++)
                SumNhaPho += ListNhaPho[i].getGiaBan;

            long SumChungCu = 0;
            for (int i = 0; i < ListChungCu.Length; i++)
                SumChungCu += ListChungCu[i].getGiaBan;

            Console.WriteLine("Tong gia ban khu dat la: {0}", SumKhuDat);
            Console.WriteLine("Tong gia ban nha pho la: {0}", SumNhaPho);
            Console.WriteLine("Tong gia ban chung cu la: {0}", SumChungCu);
        }

        static void FindListExport(KhuDat[] ListKhuDat, NhaPho[] ListNhaPho, ChungCu[] ListChungCu)
        {
            bool CheckKhuDat()
            {
                for (int i = 0; i < ListKhuDat.Length; i++)
                    if (ListKhuDat[i].getDienTich > 100)
                        return true;
                return false;
            }

            bool CheckNhaPho()
            {
                for (int i = 0; i < ListNhaPho.Length; i++)
                    if (ListNhaPho[i].getDienTich > 60 && ListNhaPho[i].getNamXD >= 2019)
                        return true;
                return false;
            }

            if (!CheckKhuDat())
                Console.WriteLine("Khong co khu dat nao dien tich lon hon 100m2");
            else
            {
                Console.WriteLine("Khu dat co dien tich lon hon 100m2 la: ");
                for (int i = 0; i < ListKhuDat.Length; i++)
                    if (ListKhuDat[i].getDienTich > 100)
                    {
                        ListKhuDat[i].KDExport();
                        Console.WriteLine();
                    }
            }

            if (!CheckNhaPho())
                Console.WriteLine("Khong co nha pho nao dien tich lon hon 60m2 va nam xay dung >= 2019");
            else
            {
                Console.WriteLine("Cac nha pho thoa dieu kien la: ");
                for (int i = 0; i < ListNhaPho.Length; i++)
                    if (ListNhaPho[i].getDienTich > 60 && ListNhaPho[i].getNamXD >= 2019)
                    {
                        ListNhaPho[i].KDExport();
                        Console.WriteLine();
                    }
            }
        }

        static void FindListInfo(KhuDat[] ListKhuDat, NhaPho[] ListNhaPho, ChungCu[] ListChungCu)
        {
            Console.Write("Dia diem can tim: ");
            string keyDiaDiem = Console.ReadLine();

            long keyGiaBan;
            double keyDienTich;
            while (true)
            {
                Console.Write("Tam gia can tim: ");
                string input = Console.ReadLine();

                if (long.TryParse(input, out keyGiaBan) && keyGiaBan > 0)
                    break;
                Console.WriteLine("Du lieu khong lop le, vui long nhap lai.");
            }

            while (true)
            {
                Console.Write("Dien tich can tim: ");
                string input = Console.ReadLine();

                if (double.TryParse(input, out keyDienTich) && keyDienTich > 0)
                    break;
                Console.WriteLine("Du lieu khong lop le, vui long nhap lai.");
            }

            bool CheckInfo(dynamic [] list)
            {
                for (int i = 0; i < list.Length; i++)                
                    if (list[i].getDiaDiem.ToLower() == keyDiaDiem.ToLower()
                        && list[i].getGiaBan <= keyGiaBan && list[i].getDienTich >= keyDienTich)
                        return true;
                    return false;                
            }

            void InforExport(dynamic [] list)
            {
                for (int i = 0; i < list.Length; i++)                
                    if (list[i].getDiaDiem.ToLower() == keyDiaDiem.ToLower()
                        && list[i].getGiaBan <= keyGiaBan && list[i].getDienTich >= keyDienTich)
                        list[i].KDExport();

                Console.WriteLine();
            }

            if (!CheckInfo(ListNhaPho))
                Console.WriteLine("Khong co nha pho nao thoa man thong tin tim kiem");
            else
            {
                Console.WriteLine("Thong tin cac nha pho thoa man thong tin tim kiem:");
                InforExport(ListNhaPho);
            }

            if (!CheckInfo(ListChungCu))
                Console.WriteLine("Khong co chung cu nao thoa man thong tin tim kiem");
            else
            {
                Console.WriteLine("Thong tin cac chung cu thoa man thong tin tim kiem:");
                InforExport(ListChungCu);
            }
        }
    }
}
