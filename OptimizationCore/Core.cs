using System;
using System.Numerics;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace OptimizationCore
{
    public class OptimizationProblem
    {
        public (int, int, int) stock { get; private set; }
        public (int, int)[] pieces { get; private set; }
        public int[] demands { get; private set; }
        public int size { get; private set; }

        public CutPattern[] solution { get; }

        public OptimizationProblem(int stockLength, int stockWidth, int stockCost, int[] piecesLength, int[] piecesWidth, int[] piecesDemand)
        {
            this.size = piecesLength.Length;
            this.stock = (stockWidth, stockLength, stockCost == 0 ? 1 : stockCost);
            this.pieces = new (int, int)[this.size];
            for (int i = 0; i < this.size; i++)
            {
                pieces[i] = (piecesWidth[i], piecesLength[i]);
            }
            this.demands = new int[this.size];
            Array.Copy(piecesDemand, this.demands, this.size);
        }

    }
    public class CutPattern
    {
        public double[] variant_vector { get; private set; }
        public int cost { get; private set; }
        public CutPattern()
        {
            this.variant_vector = new double[0];
        }

        public CutPattern(double[] variant, int cost)
        {
            this.variant_vector = new double[variant.Length];
            Array.Copy(variant, this.variant_vector, variant.Length);
            this.cost = cost;
        }
    }

    public class Simplex
    {
        private OptimizationProblem problem;
        private double[,] invB;
        private double[] dt;
        private int[] varIndex;
        private double fovalue;
        private int[] cb;
        private double[] invBb;

        public Simplex()
        {

        }

        public Simplex(OptimizationProblem problem)
        {
            this.invB = new double[problem.size,problem.size];
            this.problem = problem;
            this.dt = new double[problem.size];
            this.varIndex = new int[problem.size];
            this.fovalue = 0;
            this.cb = new int[problem.size];
            this.invBb = new double[problem.size];
        }

        public CutPattern[] Solve( CutPattern[] initialsolution)
        {
            for (int i = 0; i < this.problem.size; i++)
            {
                this.cb[i] = initialsolution[i].cost;
                this.varIndex[i] = i;
                for (int j = 0; j < this.problem.size; j++)
                {
                    this.invB[i, j] = initialsolution[i].variant_vector[j];
                }

                this.invBb[i] = this.invB[i,i] * this.problem.demands[i];
            }
            this.fovalue = MultiplyColumns(this.cb, this.invBb);

            while (true)
            {
                CutPattern entering = GenerateColumn();
                double newcost = entering.cost - MultiplyColumns(this.dt, entering.variant_vector);
                if (newcost >= 0)
                {
                    break;
                }

            }

            return null;
        }

        private CutPattern[] GenerateInitialSolution()
        {
            throw new NotImplementedException();
        }

        private CutPattern GenerateColumn()
        { throw new NotImplementedException(); }

        private double MultiplyColumns(double[] column1, double[] column2)
        {
            double value = 0;
            for (int i = 0; i < column1.Length; i++)
            {
                value += column1[i] * column2[i];
            }
            return value;
        }

        private double MultiplyColumns(int[] column1, double[] column2)
        {
            double value = 0;
            for (int i = 0; i < column1.Length; i++)
            {
                value += column1[i] * column2[i];
            }
            return value;
        }
    }

    public class Knapsack
    {
        public Knapsack()
        {

        }
    }
}
