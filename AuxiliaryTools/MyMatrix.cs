using System;
using System.Collections;


namespace AuxiliaryTools
{
    public class MyMatrix : IEnumerable
    {        
        private double[,] elements;
        public int RowCount { get { return this.elements.GetLength(0); } }
        public int ColCount { get { return this.elements.GetLength(1); } }

        public int Count { get { return this.elements.Length; } }
        public int Rank { get { return this.elements.Rank; } }

        
        public MyMatrix(double[,] elems)
        {
            this.elements = new double[elems.GetLength(0), elems.GetLength(1)];
            Array.Copy(elems, elements, elems.Length);
            
        }

        public MyMatrix(int length1, int length2)
        {
            this.elements = new double[length1, length2];
        }

        public MyMatrix(double[] elems)
        {
            elements = new double[1, elems.Length];
            for (int i = 0; i < elems.Length; i++)
            {
                elements[1, i] = elems[i];
            }
        }

        public MyMatrix(int[] elems)
        {
            elements = new double[1, elems.Length];
            for (int i = 0; i < elems.Length; i++)
            {
                elements[1, i] = elems[i];
            }
        }

        public double this[int i, int j]
        {
            get { return elements[i, j]; }
            set { elements[i, j] = value; }
        }

        public static MyMatrix operator +(MyMatrix a) => a;
        
        public static MyMatrix operator -(MyMatrix a)
        {
            return Negate(a);
        }

        public static MyMatrix operator +(MyMatrix a, MyMatrix b)
        {
            return Sum(a, b);
        }

        public static MyMatrix operator -(MyMatrix a, MyMatrix b)
        {
            return Substract(a, b);
        }

        public static MyMatrix operator *(MyMatrix a, MyMatrix b)
        {
            return Multiply(a, b);
        }

        public static MyMatrix Negate(MyMatrix a)
        {
            int rows = a.RowCount;
            int cols = a.ColCount;
            MyMatrix result = new MyMatrix(rows, cols);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    result[i, j] = -a[i, j];
                }
            }
            return result;
        }

        public static MyMatrix Sum(MyMatrix a, MyMatrix b)
        {
            int rows = a.RowCount;
            int cols = a.ColCount;
            MyMatrix result = new MyMatrix(rows, cols);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    result[i, j] = a[i, j] + b[i, j];
                }
            }
            return result;
        }

        public static MyMatrix Substract(MyMatrix a, MyMatrix b)
        {
            int rows = a.RowCount;
            int cols = a.ColCount;
            MyMatrix result = new MyMatrix(rows, cols);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    result[i, j] = a[i, j] - b[i, j];
                }
            }
            return result;
        }

        public static MyMatrix Multiply(MyMatrix a, MyMatrix b)
        {
            int arows = a.RowCount;
            int cols = a.ColCount;
            int bcols = b.ColCount;
            MyMatrix result = new MyMatrix(arows, bcols);
            for (int i = 0; i < arows; i++)
            {
                for (int j = 0; j < bcols; j++)
                {
                    double temp = 0;
                    for (int k = 0; k < cols; k++)
                    {
                        temp += a[i, k] * b[k, j];
                    }
                    result[i, j] = temp;
                }
            }
            return result;
        }

        public static void Invert(MyMatrix a)
        {
            int rows = a.RowCount;
            int cols = a.ColCount;
            int i = 0;
            int j = 0;
            while (i < rows && j < cols)
            {
                try
                { 
                    a[i, j] = 1 / a[i, j];
                }
                catch (DivideByZeroException)
                {
                    a[i, j] = 0;  
                }
                i++;
                j++;
            }
        }

        public IEnumerator GetEnumerator()
        {
            return elements.GetEnumerator();
        }        
    }
}
