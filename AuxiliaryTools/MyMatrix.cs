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
        public int Rank 
        { 
            get 
            {
                if (RowCount == 1 || ColCount == 1)
                { return 1; }
                else { return 2; }
            } 
        }
        
        
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
        //creates a column vector, if a row vector is what's necessary apply transpose
        {
            elements = new double[1, elems.Length];
            for (int i = 0; i < elems.Length; i++)
            {
                elements[i, 0] = elems[i];
            }
        }

        public MyMatrix(int[] elems)
        {
            elements = new double[1, elems.Length];
            for (int i = 0; i < elems.Length; i++)
            {
                elements[i, 0] = elems[i];
            }
        }

        public double this[int i]
        {
            get {
                if (ColCount == 1)
                {
                    return elements[i, 0];
                }
                else
                { return elements[0, i]; }
            }
            set {
                if (ColCount == 1)
                {
                    elements[i, 0] = value;
                }
                else
                { elements[0, i] = value; }
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

        public static MyMatrix operator *(MyMatrix a, double[] b)
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
            if (a.RowCount != b.RowCount || a.ColCount != b.ColCount)
            { 
                throw new InvalidOperationException();
            }
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
            if (a.RowCount != b.RowCount || a.ColCount != b.ColCount)
            {
                throw new InvalidOperationException();
            }
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
            if (a.ColCount != b.RowCount)
            {
                throw new InvalidOperationException();
            }
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

        public static MyMatrix Multiply(MyMatrix a, double[] b)
        {
            if (a.ColCount != b.Length)
            {
                throw new InvalidOperationException();
            }

            int rows = a.RowCount;
            MyMatrix result = new MyMatrix(rows, 1);
            for (int i = 0; i < rows; i++)
            {
                double temp = 0;
                for (int j = 0; j < b.Length; j++)
                {
                    temp += a[i, j] * b[j];
                }
                result[i, 0] = temp;
            }
            return result;
        }

        public static void Invert(MyMatrix a)
        {
            int rows = a.RowCount;
            int cols = a.ColCount;
            int i = 0;
            //int j = 0;
            while (i < rows)// && j < cols)
            {

                //try
                //{ 
                //    a[i, j] = 1 / a[i, j];
                //}
                //catch (DivideByZeroException)
                //{
                //    a[i, j] = 0;  
                //}
                if(a[i,i] != 0)
                { a[i, i] = 1 / a[i, i]; }
                i++;
                //j++;
            }
        }

        public static MyMatrix Transpose(MyMatrix a)
        {
            int rows = a.RowCount;
            int cols = a.ColCount;
            MyMatrix result = new MyMatrix(cols, rows);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    result[j, i] = a[i, j];
                }
            }
            return result;
        }

        public void Transpose()
        {
            MyMatrix tranpose = Transpose(this);
            this.elements = tranpose.elements;
        }
        public IEnumerator GetEnumerator()
        {
            return elements.GetEnumerator();
        }

        public override string ToString()
        {
            string result = "";
            for (int i = 0; i < RowCount; i++)
            {
                for (int j = 0; j < ColCount; j++)
                {
                    result += elements[i, j].ToString();
                    result += " ";
                }
                result += "\n";
            }
            return result;
        }

        //public MyMatrix ExtendInColumns(MyMatrix columns)
        //{
        //    MyMatrix result = new MyMatrix(this.RowCount, this.ColCount + columns.ColCount);

        //}
    }
}
