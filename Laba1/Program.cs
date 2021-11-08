using System;

namespace _423432423
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите начало отрезка :");

            string strA = Console.ReadLine();

            int A = Int32.Parse(strA);

            Console.WriteLine("Введите конец отрезка :");

            string strB = Console.ReadLine();

            int B = Int32.Parse(strB);

            Console.WriteLine("Введите точку для проверки :");

            string strC = Console.ReadLine();

            int C = Int32.Parse(strC);

            Range myrange = new Range(A, B);

            bool info = myrange.inRange(C);

            if (info)
            {
                Console.WriteLine($"точка {C} принадлежит отрезку [{A};{B}]");
            }
            else
            {
                Console.WriteLine($"точка {C} не принадлежит отрезку [{A};{B}]");
            }
        }
    }

    class Range
    {

        public int A;

        public int B;

        public Range(int a, int b)
        {

            this.A = a;

            this.B = b;
        }

        public bool inRange(int C)
        {

            bool i = (A <= C && C <= B) ? true : false;

            return i;

        }

    }
}

