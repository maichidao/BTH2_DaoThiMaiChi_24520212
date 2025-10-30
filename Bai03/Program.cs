namespace Bai03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            int row, column;

            while (true)
            {
                Console.Write("So hang cua ma tran: ");
                string iprow = Console.ReadLine();

                if (int.TryParse(iprow, out row) && row > 0)
                    break;
                Console.WriteLine("Du lieu khong lop le, vui long nhap lai.");
            }

            while (true)
            {
                Console.Write("So cot cua ma tran: ");
                string ipcolumn = Console.ReadLine();

                if (int.TryParse(ipcolumn, out column) && column > 0)
                    break;
                Console.WriteLine("Du lieu khong lop le, vui long nhap lai.");
            }
                        
            int[,] matrix = new int[row, column];
            Choose(row, column, matrix);
        }

        static void matrixImport(int row, int column, int[,] matrix)
        {
            Random rand = new Random();
            for (int i = 0; i < row; i++)
                for (int j = 0; j < column; j++)
                    matrix[i, j] = rand.Next(-100, 100);
                
        }

        static void matrixExport(int row, int column, int[,] matrix)
        {
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }

                Console.WriteLine();
            }
        }

        static void Find(int row, int column, int[,] matrix)
        {
            int x;
            while (true)
            {
                Console.Write("Nhap phan tu can tim: ");
                string ipx = Console.ReadLine();

                if (int.TryParse(ipx, out x))
                    break;
                Console.WriteLine("Du lieu khong lop le, vui long nhap lai.");
            }

            bool found = false; 
            for (int i = 0;i < row; i++)
                for (int j = 0;j < column; j++)
                    if (matrix[i,j] == x)
                    {
                        found = true;
                        Console.WriteLine("Tim thay {0} tai vi tri [{1}, {2}]", x, i, j);
                    }

            if (!found)
                Console.WriteLine("Khong tim thay {0} trong ma tran", x);
        }

        static bool IsPrime(int arr)
        {
            if (arr < 2) return false;
            for (int j = 2; j <= Math.Sqrt(arr); j++)
            {
                if (arr % j == 0)
                {
                    return false;
                }
            }
            return true;
        }


        static void PrimeExport(int row, int column, int[,] matrix)
        {
            Console.Write("Cac so nguyen to trong ma tran: ");
            for (int i = 0; i < row; i++)
                for (int j = 0; j < column; j++)
                    if (IsPrime(matrix[i,j])) 
                        Console.Write(matrix[i,j] + " ");

            Console.WriteLine();
        }


        static void MaxPrimeRow(int row, int column, int[,] matrix)
        {
            int Count(int row)
            {
                int count = 0;
                for (int i = 0; i < column; i++)
                {
                    if (IsPrime(matrix[row,i]))
                        count++;
                }
                return count;
            }

            int ans = 0;
            for (int i = 0; i < row; i++)
                if (Count(i) > Count(ans))
                    ans = i;

            Console.Write("Dong co nhieu so nguyen to nhat la: ");
            for (int i = 0; i < row; i++)
                if (Count(i) == Count(ans))
                    Console.Write(i + " ");

            Console.WriteLine();
        }

        static void Menu()
        {
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine("  (1) Tao va xuat ma tran ngau nhien");
            Console.WriteLine("  (2) Tim vi tri cua phan tu x");
            Console.WriteLine("  (3) Xuat cac phan tu la so nguyen to");
            Console.WriteLine("  (4) Cho biet dong nao co nhieu so nguyen to nhat");
            Console.WriteLine("  (5) Thoat");
            Console.WriteLine("-------------------------------------------------------");
        }


        static void Choose(int row, int column, int[,] matrix)
        {
            Menu();
            Console.Write("Lua chon cua ban (1-5): ");
            int res = int.Parse(Console.ReadLine());

            switch (res)
            {
                case 1:
                    matrixImport(row, column, matrix);
                    matrixExport(row, column, matrix);
                    Choose(row, column, matrix);
                    break;

                case 2:
                    Find(row, column, matrix);
                    Choose(row, column, matrix);
                    break;

                case 3:
                    PrimeExport(row, column, matrix);
                    Choose(row, column, matrix);
                    break;

                case 4:
                    MaxPrimeRow(row, column, matrix);
                    Choose(row, column, matrix);
                    break;

                case 5:
                    break;

                default:
                    Console.WriteLine("Lua chon khong hop le. Moi chon lai:");
                    Choose(row, column, matrix);
                    break;
            }
        }
    }
}
