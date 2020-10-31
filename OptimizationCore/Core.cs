using System;
using AuxiliaryTools;
using System.Collections.Generic;
using System.Linq;

namespace OptimizationCore
{
    public class OptimizationProblem
    {
        public (int length, int width, int cost) stock { get; private set; }
        public (int length, int width)[] pieces { get; private set; }
        public int[] demands { get; private set; }
        public int size { get; private set; }

        public CutPattern[] solution { get; }

        public OptimizationProblem(int stockLength, int stockWidth, int stockCost, int[] piecesLength, int[] piecesWidth, int[] piecesDemand)
        {
            this.size = piecesLength.Length;
            this.stock = (stockLength, stockWidth, stockCost == 0 ? 1 : stockCost);
            this.pieces = new (int, int)[this.size];
            for (int i = 0; i < this.size; i++)
            {
                pieces[i] = (piecesLength[i], piecesWidth[i]);
            }
            this.demands = new int[this.size];
            Array.Copy(piecesDemand, this.demands, this.size);            
        }

    }
    public class CutPattern
    {
        public double[] variant_vector { get; private set; }
        public int cost { get; private set; }

        public int timesRepeated { get; private set; }

        public List<(int cutPoint, int cutDir, int piece)> cutPoints { get; private set; }

        //public List<(int startPointX, int startPointY, int pieceIndex)> PieceDistribution { get; set; }

        public List<Piece> PieceDistribution { get; set; }

        
        //cutDir is 0 if it's a horizontal cut, 1 is it's vertical. piece is the index of the piece that fits the space before the cut point
        public CutPattern()
        {
            this.variant_vector = new double[0];
            this.cutPoints = new List<(int cutPoint, int cutDir, int piece)>();
            this.PieceDistribution = new List<Piece>();
        }

        public CutPattern(double[] variant, int cost)
        {
            this.variant_vector = new double[variant.Length];
            Array.Copy(variant, this.variant_vector, variant.Length);
            this.cost = cost;
            this.cutPoints = new List<(int cutPoint, int cutDir, int piece)>();
            this.PieceDistribution = new List<Piece>();        
        }

        public void AddCutPoint(int point, int direction, int piece)
        {
            this.cutPoints.Add((point, direction, piece));
        }

        public void SetRepetition(int times)
        {
            this.timesRepeated = times;
        }
        public void AddRepetition(int times)
        {
            this.timesRepeated += times;
        }

        //public void AddPiece(int offsetX, int offsetY, int pieceIndx)
        //{
        //    this.PieceDistribution.Add((offsetX, offsetY, pieceIndx));
        //}

    }

    public class Simplex
    {
        private OptimizationProblem problem;
        private MyMatrix invB;
        private MyMatrix dt;
        private int[] varIndex;
        private double fovalue;
        private MyMatrix cb;
        private MyMatrix invBb;
        int index = 0;
        private int[] ReticularPointsL;
        private int[] ReticularPointsW;
        private List<(int value, int index)>[] partialPointsL;
        private List<(int value, int index)>[] partialPointsW;

        public Simplex()
        {

        }

        public Simplex(OptimizationProblem problem)
        {
            this.invB = new MyMatrix(problem.size, problem.size);
            this.problem = problem;
            this.dt = new MyMatrix(1, problem.size);
            this.varIndex = new int[problem.size];
            this.fovalue = 0;
            this.cb = new MyMatrix(1, problem.size);
            this.invBb = new MyMatrix(problem.size, 1);
        }

        public CutPattern[] Solve()
        {
            CutPattern[] solution = GenerateInitialSolution();
            for (int i = 0; i < this.problem.size; i++)
            {
                this.cb[i] = solution[i].cost;
                this.varIndex[i] = i;
                for (int j = 0; j < this.problem.size; j++)
                {
                    this.invB[i, j] = solution[i].variant_vector[j];
                }
            }
            MyMatrix.Invert(this.invB);
            for (int i = 0; i < this.problem.size; i++)
            {
                this.invBb[i] = this.invB[i, i] * this.problem.demands[i];
            }

            this.fovalue = (this.cb * invBb)[0];
            this.dt = cb * invB;

            PreparForColumnGeneration();
            while (true)
            {
                Console.WriteLine(PrintMatrix());
                CutPattern entering = GenerateColumn();
                if (entering == null)
                { break; }
                double newcost = entering.cost - (dt * entering.variant_vector)[0];
                if (newcost >= 0)
                {
                    break;
                }
                else
                {
                    MyMatrix atemp = (-invB) * entering.variant_vector;
                    int pivot = FindPivot(invBb, atemp);
                    TransformMatrix(pivot, atemp, newcost);
                    solution[pivot] = new CutPattern(entering.variant_vector, entering.cost);
                    cb[pivot] = entering.cost;
                }
            }
            for (int i = 0; i < solution.Length; i++)
            {
                solution[i].SetRepetition((int)Math.Ceiling(invBb[i]));
            }
            return solution;
        }

        private void TransformMatrix(int pivot, MyMatrix atemp, double newcost)
        {
            for (int j = 0; j < invB.ColCount; j++)
            {
                invB[pivot, j] = -(invB[pivot, j]) / atemp[pivot];
                dt[j] += invB[pivot, j] * newcost;
            }
            invBb[pivot] = -(invBb[pivot]) / atemp[pivot];
            fovalue += invBb[pivot] * newcost;

            for (int i = 0; i < invB.RowCount; i++)
            {
                if (i == pivot)
                { continue; }
                for (int j = 0; j < invB.ColCount; j++)
                {
                    invB[i, j] += invB[pivot, j] * atemp[i];
                }
                invBb[i] += invBb[pivot] * atemp[i];
            }
        }
        private int FindPivot(MyMatrix b, MyMatrix atemp)
        {
            int pivot = -1;
            double temp = double.MaxValue;
            for (int i = 0; i < b.Count; i++)
            {
                if (atemp[i] >= 0) { continue; }
                double res = b[i] / -atemp[i];
                if (res < temp)
                {
                    temp = res;
                    pivot = i;
                }
            }
            return pivot;
        }

        private string PrintMatrix()
        {
            string result = "";
            for (int i = 0; i < invB.RowCount; i++)
            {
                for (int j = 0; j < invB.ColCount; j++)
                {
                    result += invB[i, j].ToString() + " ";
                }
                result += invBb[i] + "\n";
            }
            for (int j = 0; j < invB.ColCount; j++)
            {
                result += dt[j] + " ";
            }
            result += fovalue + "\n";

            return result;
        }

        private CutPattern[] GenerateInitialSolution()
        {
            int pieces = problem.size;
            CutPattern[] result = new CutPattern[pieces];
            for (int i = 0; i < pieces; i++)
            {
                int ammInL = problem.stock.length / problem.pieces[i].length;
                int ammInW = problem.stock.width / problem.pieces[i].width;
                int totalAmmount = ammInL * ammInW;
                double[] variant = new double[pieces];
                variant[i] = totalAmmount;
                result[i] = new CutPattern(variant, problem.stock.cost);
                for (int j = 1; j <= ammInL; j++)
                {
                    result[i].AddCutPoint(j * problem.pieces[i].length, 1, i);
                }
                for (int j = 0; j < ammInW; j++)
                {
                    result[i].AddCutPoint(j * problem.pieces[i].width, 0, i);
                }
                for (int j = 0; j <= ammInL; j++)
                {
                    for (int k = 0; k <= ammInW; k++)
                    {
                        int l = problem.pieces[i].length;
                        int w = problem.pieces[i].width;
                        result[i].PieceDistribution.Add(new Piece(j * l, k * w, l, w, i));
                    }
                }
            }
            return result;
        }

        private CutPattern GenerateColumn()
        {
            int j = ReticularPointsL.Length - 1;
            int k = ReticularPointsW.Length - 1;
            SolutionCell[,] solutionMatrix = new SolutionCell[j + 1, k + 1];
            SolutionCell result = SolveRecurrence(j, k, solutionMatrix, 0,0);

            double[] variant = new double[problem.pieces.Length];
            CutPattern pattern = new CutPattern(variant, 1);
            ExtractPiecePattern(solutionMatrix, j, k, pattern.PieceDistribution, variant);
            return pattern;
        }

        private void PreparForColumnGeneration()
        {
            List<int> lengths = new List<int>();
            List<int> widths = new List<int>();
            foreach (var item in problem.pieces)
            {
                lengths.Add(item.length);
                widths.Add(item.width);
            }
            lengths.Sort();
            widths.Sort();

            
            LinkedList<int> tempL = new LinkedList<int>();
            LinkedList<int> tempW = new LinkedList<int>();
            tempL.AddFirst(0);
            tempW.AddFirst(0);
            FindReticularPoints(0, 0, tempL, lengths, problem.stock.length);
            FindReticularPoints(0, 0, tempW, widths, problem.stock.width);

            ReticularPointsL = tempL.ToArray<int>();
            ReticularPointsW = tempW.ToArray<int>();

            ReticularPointsL = ConstructReducedSet(ReticularPointsL, this.problem.stock.length);
            ReticularPointsW = ConstructReducedSet(ReticularPointsW, this.problem.stock.width);

            partialPointsL = ConstructParcialPointsSet(ReticularPointsL);
            partialPointsW = ConstructParcialPointsSet(ReticularPointsW);
        }

        private void FindReticularPoints(int count, int index, LinkedList<int> points, List<int> values, int MaxValue)//, List<(int,int)> control)
        {
            int temp_count = count + values[index];
            if (temp_count <= MaxValue)
            {
                InsertPoint(points, temp_count);
                FindReticularPoints(temp_count, index, points, values, MaxValue);//, control);
            }
            if (index + 1 == values.Count) return;
            FindReticularPoints(count, index + 1, points, values, MaxValue);//, control);            
        }

        private void InsertPoint(LinkedList<int> points, int value)
        {
            LinkedListNode<int> node = points.First;
            while (node != null)
            {
                if (value == node.Value)
                    return;
                if (value < node.Value)
                {
                    points.AddBefore(node, value);
                    return;
                }
                node = node.Next;
            }
            points.AddLast(value);
        }

        private int[] ConstructReducedSet(int[] reticularPointsArray, int maxLength)
        {
            LinkedList<int> result = new LinkedList<int>();
            result.AddFirst(0);
            for (int i = 0; i < reticularPointsArray.Length; i++)
            {
               InsertPoint(result, GetConditionedMax(reticularPointsArray, maxLength - reticularPointsArray[i]).valueOfPoint);
            }
            
            return result.ToArray<int>();
        }

        private List<(int valueOfPoint, int indexOfPoint)>[] ConstructParcialPointsSet(int[] reducedSet)
        {
            List<(int, int)>[] result = new List<(int, int)>[reducedSet.Length];
            for (int j = 0; j < reducedSet.Length; j++)
            {
                int rj = reducedSet[j];
                for (int p = 0; p <= j ; p++)
                {
                    int rp = reducedSet[p];
                    result[j].Add(GetConditionedMax(reducedSet, rj - rp));
                }
            }
            return result;
        }

        private (int valueOfPoint, int indexOfPoint) GetConditionedMax(IEnumerable<int> collectionOfPoints, int top)
        {
            int temp = -1;
            int index = -1;
            foreach (int point in collectionOfPoints)
            {
                if (temp <= top)
                {
                    temp = point;
                    index++;
                }
                else break;
            }
            return (temp,index);
        }

        private SolutionCell SolveRecurrence(int j, int k, SolutionCell[,] solutionMatrix, int offsetL, int offsetW)
        {
            if (solutionMatrix[j, k] != null)
            {
                return solutionMatrix[j, k];
            }
            else
            {
                double max = -1;
                (double value, bool isCut, int index, DirectionOfCut dir, int offs1, int offs2) maxL = (-1, false, -1, DirectionOfCut.None, offsetL, offsetW);
                for (int i = 0; i <= j / 2; i++)
                {
                    double tempmax = SolveRecurrence(i, k, solutionMatrix, offsetL, offsetW).Value + SolveRecurrence(partialPointsL[j][i].index, k, solutionMatrix, offsetL + ReticularPointsL[i], offsetW).Value;
                    if (tempmax > max)
                    {
                        max = tempmax;
                        maxL = (max, true, i, DirectionOfCut.Vertical, offsetL, offsetW);
                    }
                }
                max = -1;
                (double value, bool isCut, int index, DirectionOfCut dir, int offs1, int offs2) maxW = (-1, false, -1, DirectionOfCut.None, offsetL, offsetW);
                for (int i = 0; i <= k / 2; i++)
                {
                    double tempmax = SolveRecurrence(j, i, solutionMatrix, offsetL, offsetW).Value + SolveRecurrence(j, partialPointsW[k][i].index, solutionMatrix, offsetL, offsetW + ReticularPointsW[i]).Value;
                    if (tempmax > max)
                    {
                        max = tempmax;
                        maxW = (max, true, i, DirectionOfCut.Horizontal, offsetL, offsetW);
                    }
                }
                (double value, bool isCut, int index, DirectionOfCut dir, int offs1, int offs2) maxP = (-1, false, -1, DirectionOfCut.None, offsetL, offsetW);
                max = double.MinValue;
                double ptempmax = double.MinValue;
                for (int i = 0; i < problem.pieces.Length; i++)
                {
                    if (problem.pieces[j].length > ReticularPointsL[i] || problem.pieces[k].width > ReticularPointsW[k])
                        continue;
                    ptempmax = dt[i];
                    if (ptempmax > max)
                    {
                        max = ptempmax;
                        maxP = (max, false, i, DirectionOfCut.None, offsetL, offsetW);
                    }
                }
                (double value, bool isCut, int index, DirectionOfCut dir, int offs1, int offs2) maxOverall = (0, false, -1, DirectionOfCut.None, offsetL, offsetW);
                if (maxL.value > maxOverall.value)
                    maxOverall = maxL;
                if (maxW.value > maxOverall.value)
                    maxOverall = maxW;
                if (maxP.value > maxOverall.value)
                    maxOverall = maxP;

                solutionMatrix[j, k] = new SolutionCell(maxOverall);
                return solutionMatrix[j, k];
            }
        }

        private SolutionCell2 SolveRecurrence2(int j, int k, SolutionCell2[,] solutionMatrix)
        {
            if (solutionMatrix[j, k] != null)
            {
                return solutionMatrix[j, k];
            }
            else
            {
                double max = -1;
                (double value, bool isCut, int index, DirectionOfCut dir) maxL = (-1, false, -1, DirectionOfCut.None);
                for (int i = 0; i <= j / 2; i++)
                {
                    double tempmax = SolveRecurrence2(i, k, solutionMatrix).Value + SolveRecurrence2(partialPointsL[j][i].index, k, solutionMatrix).Value;
                    if (tempmax > max)
                    {
                        max = tempmax;
                        maxL = (max, true, i, DirectionOfCut.Vertical);
                    }
                }
                max = -1;
                (double value, bool isCut, int index, DirectionOfCut dir) maxW = (-1, false, -1, DirectionOfCut.None);
                for (int i = 0; i <= k/2; i++)
                {
                    double tempmax = SolveRecurrence2(j, i, solutionMatrix).Value + SolveRecurrence2(j, partialPointsW[k][i].index, solutionMatrix).Value;
                    if(tempmax > max)
                    {
                        max = tempmax;
                        maxW = (max, true, i, DirectionOfCut.Horizontal);
                    }
                }
                (double value, bool isCut, int index, DirectionOfCut dir) maxP = (-1, false, -1, DirectionOfCut.None);
                max = double.MinValue;
                double ptempmax = double.MinValue;
                for (int i = 0; i < problem.pieces.Length; i++)
                {
                    if (problem.pieces[j].length > ReticularPointsL[i] || problem.pieces[k].width > ReticularPointsW[k])
                        continue;
                    ptempmax = dt[i];
                    if(ptempmax > max)
                    {
                        max = ptempmax;
                        maxP = (max, false, i, DirectionOfCut.None);
                    }
                }
                (double value, bool isCut, int index, DirectionOfCut dir) maxOverall = (0, false, -1, DirectionOfCut.None);
                if (maxL.value > maxOverall.value)
                    maxOverall = maxL;
                if (maxW.value > maxOverall.value)
                    maxOverall = maxW;
                if (maxP.value > maxOverall.value)
                    maxOverall = maxP;

                solutionMatrix[j, k] = new SolutionCell2(maxOverall);
                return solutionMatrix[j, k];
            }
        }

        private void ExtractCutPattern(SolutionCell[,] solutionMatrix, int j, int k, List<SolutionCell> patternPath, double[] pieces)
        {
            SolutionCell temp = solutionMatrix[j, k];           
            patternPath.Add(temp);
            if(temp.IsCut)
            {
                if (temp.DirOfCut == DirectionOfCut.Vertical)
                {
                    ExtractCutPattern(solutionMatrix, temp.Index, k, patternPath, pieces);
                    ExtractCutPattern(solutionMatrix, partialPointsL[j][temp.Index].index, k, patternPath, pieces);
                }
                else
                {
                    ExtractCutPattern(solutionMatrix, j, temp.Index, patternPath, pieces);
                    ExtractCutPattern(solutionMatrix, j, partialPointsW[k][temp.Index].index, patternPath, pieces);
                }
            }
            else if(temp.Index > -1)
            {
                pieces[temp.Index]++;
            }
        }

        private void ExtractPiecePattern(SolutionCell[,] solutionMatrix, int j, int k, List<Piece> dist, double[] pieces)
        {
            SolutionCell temp = solutionMatrix[j, k];
            if(!temp.IsCut)
            {
                if (temp.Index > -1)
                {
                    pieces[temp.Index]++;
                }
                dist.Add(new Piece(temp.OffsetL, temp.OffsetW, ReticularPointsL[j], ReticularPointsW[k], temp.Index));
                return;
            }
            if (temp.DirOfCut == DirectionOfCut.Vertical)
            {
                ExtractPiecePattern(solutionMatrix, temp.Index, k, dist, pieces);
                ExtractPiecePattern(solutionMatrix, partialPointsL[j][temp.Index].index, k, dist, pieces);
            }
            else
            {
                ExtractPiecePattern(solutionMatrix, j, temp.Index, dist, pieces);
                ExtractPiecePattern(solutionMatrix, j, partialPointsW[k][temp.Index].index, dist, pieces);
            }

        }

        private void CalculateSolutionMatrix(int j, int k, SolutionCell2[,] solutionMatrix)
        {
            
        }
    }

    public class Piece
    {
        int startX;
        int startY;
        int length;
        int width;
        int index;

        public Piece(int startx, int starty, int length, int width, int index)
        {
            this.startX = startx;
            this.startY = starty;
            this.length = length;
            this.width = width;
            this.index = index;
        }
    }
    internal class SolutionCell
    {
        internal double Value { get; }
        internal bool IsCut  { get; }
        internal int Index { get; }
        internal DirectionOfCut DirOfCut { get; }
        
        internal int OffsetL { get; }
        internal int OffsetW { get; }

        public SolutionCell(double value, bool isCut, int indx, DirectionOfCut dir, int offs1, int offs2)
        {
            this.Value = value;
            this.IsCut = isCut;
            this.Index = indx;
            this.DirOfCut = dir;
            this.OffsetL = offs1;
            this.OffsetW = offs2;
        }
        public SolutionCell((double value, bool isCut, int index, DirectionOfCut dir, int offs1, int offs2) cell)
        {
            this.Value = cell.value;
            this.IsCut = cell.isCut;
            this.Index = cell.index;
            this.DirOfCut = cell.dir;
            this.OffsetL = cell.offs1;
            this.OffsetW = cell.offs2;
        }
    }

    internal class SolutionCell2
    {
        internal double Value { get; }
        internal bool IsCut { get; }
        internal int Index { get; }
        internal DirectionOfCut DirOfCut { get; }


        public SolutionCell2(double value, bool isCut, int indx, DirectionOfCut dir)
        {
            this.Value = value;
            this.IsCut = isCut;
            this.Index = indx;
            this.DirOfCut = dir;
        }
        public SolutionCell2((double value, bool isCut, int index, DirectionOfCut dir) cell)
        {
            this.Value = cell.value;
            this.IsCut = cell.isCut;
            this.Index = cell.index;
            this.DirOfCut = cell.dir;
        }
    }



    internal enum DirectionOfCut
    {
        Vertical,
        Horizontal,
        None
    }

}
