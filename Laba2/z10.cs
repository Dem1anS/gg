using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace matrix
{
    class z10
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите размерность n: ");
            int nn = Convert.ToInt32(Console.ReadLine());

            Matrix mass1 = new Matrix(nn);
            Matrix mass2 = new Matrix(nn);
            Matrix mass3 = new Matrix(nn);
            Matrix mass4 = new Matrix(nn);
            Matrix mass5 = new Matrix(nn);
            Matrix mass6 = new Matrix(nn);
            Matrix mass7 = new Matrix(nn);
            Console.WriteLine("Ввод Матрица А: ");
            mass1.WriteMat();
            Console.WriteLine("----------------------");
            Console.WriteLine("Ввод Матрица B: ");
            mass2.WriteMat();
            Console.WriteLine("----------------------");

            Console.WriteLine("Матрица А: ");
            mass1.ReadMat();
            Console.WriteLine();
            Console.WriteLine("Матрица В: ");
            Console.WriteLine();
            mass2.ReadMat();
            Console.WriteLine("----------------------");

            Console.WriteLine("Сложение матриц А и Б: ");
            mass3 = (mass1 + mass2);
            mass3.ReadMat();
            Console.WriteLine("----------------------");

            Console.WriteLine("Вычитание матриц А и Б: ");
            mass5 = (mass1 - mass2);
            mass5.ReadMat();
            Console.WriteLine("----------------------");

            Console.WriteLine("Умножение матриц А и Б: ");
            mass7 = (mass1 * mass2);
            mass7.ReadMat();
            Console.WriteLine("----------------------");

            Console.WriteLine("Введите число, на которое умножить матрицу А:");
            int d = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Умножение матрицы А на число {0}: ", d);
            mass4 = (mass1 * d);
            mass4.ReadMat();
            Console.WriteLine("----------------------");

            Console.WriteLine("Введите строку искомого элемента матрицы: ");
            int v = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите столбец искомого элемента матрицы: ");
            int c = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Искомый элемент матрицы: ");
            mass1.SearchElement(v, c);
            Console.WriteLine("----------------------");
            Console.WriteLine("Введите номер столбца матрицы: ");
            int k = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Искомый столбец матрицы: ");
            mass1.Stolbets(k);
            Console.WriteLine("----------------------");
            Console.WriteLine("Введите номер строки матрицы: ");
            int f = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Искомая строка матрицы: ");
            mass1.Stroka(f);
            Console.ReadKey();
        }
    }
}

namespace matrix
{
    class Matrix
    {
        private int[,] mass;
        private int n;

        // Конструктор, св-во n и св-во матрицы
        public int N
        {
            get { return n; }
            set { if (value > 0) n = value; }
        }

        public Matrix(int n)
        {
            this.n = n;
            mass = new int[this.n, this.n];
        }
        public int this[int i, int j]
        {
            get
            {
                return mass[i, j];
            }
            set
            {
                mass[i, j] = value;
            }
        }

        // Ввод матрицы с клавиатуры
        public void WriteMat()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.WriteLine("Введите элемент матрицы {0}:{1}", i + 1, j + 1);
                    mass[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }
        }

        // Вывод матрицы с клавиатуры
        public void ReadMat()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(mass[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
        //Поиск по индексу
        public void SearchElement(int i, int j)
        {
            Console.WriteLine(mass[i, j]);
        }

        //Поиск столбца
        public void Stolbets(int k)
        {
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(mass[i, k]);
            }
        }

        //Поиск строки
        public void Stroka(int f)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write(mass[f, j]);
            }
        }

        // Умножение матрицы А на число
        public static Matrix umnch(Matrix a, int ch)
        {
            Matrix resMass = new Matrix(a.N);
            for (int i = 0; i < a.N; i++)
            {
                for (int j = 0; j < a.N; j++)
                {
                    resMass[i, j] = a[i, j] * ch;
                }
            }
            return resMass;
        }

        // Умножение матрицы А на матрицу Б
        public static Matrix umn(Matrix a, Matrix b)
        {
            Matrix resMass = new Matrix(a.N);
            for (int i = 0; i < a.N; i++)
                for (int j = 0; j < b.N; j++)
                    for (int k = 0; k < b.N; k++)
                        resMass[i, j] += a[i, k] * b[k, j];

            return resMass;
        }

        // перегрузка оператора умножения
        public static Matrix operator *(Matrix a, Matrix b)
        {
            return Matrix.umn(a, b);
        }

        public static Matrix operator *(Matrix a, int b)
        {
            return Matrix.umnch(a, b);
        }


        // Метод вычитания матрицы Б из матрицы А
        public static Matrix razn(Matrix a, Matrix b)
        {
            Matrix resMass = new Matrix(a.N);
            for (int i = 0; i < a.N; i++)
            {
                for (int j = 0; j < b.N; j++)
                {
                    resMass[i, j] = a[i, j] - b[i, j];
                }
            }
            return resMass;
        }

        // Перегрузка оператора вычитания
        public static Matrix operator -(Matrix a, Matrix b)
        {
            return Matrix.razn(a, b);
        }
        // Метод сложения матрицы А и матрицы Б
        public static Matrix Sum(Matrix a, Matrix b)
        {
            Matrix resMass = new Matrix(a.N);
            for (int i = 0; i < a.N; i++)
            {
                for (int j = 0; j < b.N; j++)
                {
                    resMass[i, j] = a[i, j] + b[i, j];
                }
            }
            return resMass;
        }
        // Перегрузка сложения
        public static Matrix operator +(Matrix a, Matrix b)
        {
            return Matrix.Sum(a, b);
        }
        // Деструктор Matrix
        ~Matrix()
        {
            Console.WriteLine("Очистка");
        }
    }


}
