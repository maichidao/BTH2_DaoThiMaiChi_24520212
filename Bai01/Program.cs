using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Bai01
{
    internal class Program
    {

        static void Main(string[] args)
        {
            int month, year;
                    
            while (true)
            {
                Console.Write("Thang: ");
                string ipmonth = Console.ReadLine();

                if (int.TryParse(ipmonth, out month) && month > 0 && month < 13)
                    break;
                Console.WriteLine("Du lieu khong lop le, vui long nhap lai.");
            }


            while (true)
            {
                Console.Write("Nam: ");
                string ipyear = Console.ReadLine();

                if (int.TryParse(ipyear, out year) && year > 0)
                    break;
                Console.WriteLine("Du lieu khong lop le, vui long nhap lai.");
            }

            Console.WriteLine();

            DateTime firstDay = new DateTime(year, month, 1);
            printDayOfWeek();
            printDate(firstDay, month, year);
            Console.WriteLine();
        }

        static void printDate(DateTime x, int month, int year)
        {
            int[] daysInMonth = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            
            if (year % 4 == 0 && year % 100 != 0 || year % 400 == 0)
                daysInMonth[1] = 29;

            int start = (int)x.DayOfWeek;

            for (int i = 0; i < start; i++)
            {
                Console.Write("     ");
            }

            for (int i = 1; i <= daysInMonth[month-1]; i++)
            {
                Console.Write($"{i,-5}");
                if ((start + i) % 7 == 0)
                    Console.WriteLine();
            }
        }

        static void printDayOfWeek()
        {
            Console.WriteLine("Sun  Mon  Tue  Wed  Thu  Fri  Sat");
        }
    }
}
