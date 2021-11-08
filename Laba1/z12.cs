using System;

namespace _ERW
{
    class Program
    {
        static void Main(string[] args)
        {

        }
    }

    class Something
    {

        public int a;

        public int b;

        public int B
        {
            get
            {
                return Something.Cash(b);
            }

            set
            {
                b = Something.Cash(value);
            }
        }
        public int A
        {
            get
            {
                return Something.Cash(a);
            }

            set
            {
                a = Something.Cash(value);
            }
        }



        public Something(int a, int b)
        {

            this.A = a;

            this.B = b;
        }

        static public int Cash(int C)
        {

            return C;

        }

    }
}