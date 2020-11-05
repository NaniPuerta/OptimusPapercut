using System;
using AuxiliaryTools;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Collections;
using System.Runtime.CompilerServices;

namespace OptimizationCore
{
    public class OptimizationProblem
    {
        public (int length, int width, int cost) stock { get; private set; }
        public (int length, int width)[] pieces { get; private set; }
        public int[] demands { get; private set; }
        public int size { get; private set; }

        public CutPattern[] solution { get; }

        public OptimizationProblem(int stockLength, int stockWidth, int[] piecesLength, int[] piecesWidth, int[] piecesDemand)
        {
            this.size = piecesLength.Length;
            this.stock = (stockLength, stockWidth, 1);
            this.pieces = new (int, int)[this.size];
            for (int i = 0; i < this.size; i++)
            {
                pieces[i] = (piecesLength[i], piecesWidth[i]);
            }
            this.demands = new int[this.size];
            Array.Copy(piecesDemand, this.demands, this.size);
        }
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
        public double[] variant_vector { get; set; }
        public int cost { get; private set; }

        public int timesRepeated { get; private set; }

        //public List<(int cutPoint, int cutDir, int piece)> cutPoints { get; private set; }

        //public List<(int startPointX, int startPointY, int pieceIndex)> PieceDistribution { get; set; }

        //public List<Piece> PieceDistribution { get; set; }

        public CutTree cuts { get; private set; }
        
        //cutDir is 0 if it's a horizontal cut, 1 is it's vertical. piece is the index of the piece that fits the space before the cut point
        public CutPattern()
        {
            this.variant_vector = new double[0];
            //this.cutPoints = new List<(int cutPoint, int cutDir, int piece)>();
            //this.PieceDistribution = new List<Piece>();
        }

        public CutPattern(double[] variant, int cost)
        {
            this.variant_vector = new double[variant.Length];
            Array.Copy(variant, this.variant_vector, variant.Length);
            this.cost = cost;
            //this.cutPoints = new List<(int cutPoint, int cutDir, int piece)>();
            //this.PieceDistribution = new List<Piece>();        
        }

        //public void AddCutPoint(int point, int direction, int piece)
        //{
        //    this.cutPoints.Add((point, direction, piece));
        //}

        public void SetRepetition(int times)
        {
            this.timesRepeated = times;
        }
        public void AddRepetition(int times)
        {
            this.timesRepeated += times;
        }

        internal void SetCutsTree(CutTree tree)
        {
            this.cuts = tree;
        }
        public string PrintPattern()
        {
            string result = "repeat " + this.timesRepeated + " times: ";
            foreach (double item in variant_vector)
            {
                result += item + " ";
            }            
            return result;
        }
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
        //int index = 0;
        private int[] ReticularPointsL;
        private int[] ReticularPointsW;
        private List<(int value, int index)>[] partialPointsL;
        private List<(int value, int index)>[] partialPointsW;

        //public Simplex()
        //{

        //}

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
                    solution[pivot] = entering;
                    cb[pivot] = entering.cost;
                }
            }
            for (int i = 0; i < solution.Length; i++)
            {                
                solution[i].SetRepetition(RoundSolution(invBb[i]));
            }
            PostOptimize(solution);
            return solution;
        }

        private void PostOptimize(CutPattern[] solution)
        {
            int[] totalByPieces = GetTotalObtainedByPieces(solution);
            List<int> pats = new List<int>();
            for (int i = 0; i < solution.Length; i++)
            {
                for (int j = 0; j < solution[i].timesRepeated; j++)
                {
                    pats.Add(i);
                }
            }

            for (int i = 0; i < pats.Count; i++)
            {
                int index = pats[i];
                if (solution[index].timesRepeated == 0) continue;
                if (CanEliminatePattern(totalByPieces, solution[index].variant_vector, problem.demands))
                {
                    solution[index].AddRepetition(-1);
                    UpdateTotal(totalByPieces, solution[index].variant_vector);
                }
            }

        }

        private bool CanEliminatePattern(int[] totalPieces, double[] patVariant, int[] demands)
        {
            for (int i = 0; i < totalPieces.Length; i++)
            {
                if (totalPieces[i] - (int)patVariant[i] < demands[i])
                    return false;
            }
            return true;
        }

        private void UpdateTotal(int[] total, double[] variant)
        {
            for (int i = 0; i < total.Length; i++)
            {
                total[i] -= (int)variant[i];
            }
        }
        private int[] GetTotalObtainedByPieces(CutPattern[] solution)
        {
            int[] result = new int[solution.Length];
            foreach (CutPattern pat in solution)
            {
                for (int i = 0; i < pat.variant_vector.Length; i++)
                {
                    result[i] += (int)pat.variant_vector[i]*pat.timesRepeated;
                }
            }
            return result;
        }

        private int RoundSolution(double value)
        {
            int result = (int)Math.Floor(value);
            if (value - result < 0.05)
                return result;
            else return (int)Math.Ceiling(value);
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
            (int slength, int swidth, int scost) = problem.stock;
            CutPattern[] result = new CutPattern[pieces];
            for (int i = 0; i < pieces; i++)
            {
                int plength = problem.pieces[i].length;
                int ammInL = slength / plength;
                int pwidth = problem.pieces[i].width;
                int ammInW = swidth / pwidth;
                int totalAmmount = ammInL * ammInW;
                //double[] variant = new double[pieces];
                //variant[i] = totalAmmount;
                result[i] = new CutPattern(new double[pieces], scost);
                result[i].variant_vector[i] = totalAmmount;
                //result[i].variant_vector[i] = 1;
                //for (int j = 1; j <= ammInL; j++)
                //{
                //    result[i].AddCutPoint(j * problem.pieces[i].length, 1, i);
                //}
                //for (int j = 0; j < ammInW; j++)
                //{
                //    result[i].AddCutPoint(j * problem.pieces[i].width, 0, i);
                //}
                //for (int j = 0; j <= ammInL; j++)
                //{
                //    for (int k = 0; k <= ammInW; k++)
                //    {
                //        int l = problem.pieces[i].length;
                //        int w = problem.pieces[i].width;
                //        result[i].PieceDistribution.Add(new Piece(j * l, k * w, l, w, i));
                //    }
                //}
                result[i].SetCutsTree(CutTreeForInitialPattern(slength, swidth, new Piece(plength, pwidth, i)));
            }
            return result;
        }

        private CutPattern GenerateColumn()
        {
            int j = ReticularPointsL.Length - 1;
            int k = ReticularPointsW.Length - 1;
            SolutionCell[,] solutionMatrix = new SolutionCell[j + 1, k + 1];
            InitializeSolMatrix(solutionMatrix);
            CalculateSolMatrix(solutionMatrix);
            CutPattern pattern = new CutPattern(new double[problem.pieces.Length], 1);
            CutTree cuts = ExtractCutTree(solutionMatrix, j, k, ReticularPointsL[j], ReticularPointsW[k], pattern);
            pattern.SetCutsTree(cuts);
            //ExtractPiecePattern(solutionMatrix, j, k, pattern);
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

            //List<(int,int)> parameterControl = new List<(int, int)>();

            LinkedList<int> tempL = new LinkedList<int>();
            LinkedList<int> tempW = new LinkedList<int>();
            tempL.AddFirst(0);
            tempW.AddFirst(0);
            //FindReticularPoints(0, 0, tempL, lengths, problem.stock.length);//, parameterControl);
            //FindReticularPoints(0, 0, tempW, widths, problem.stock.width);//, parameterControl);

            ReticularPointsL = FindReticularPoints(lengths, problem.stock.length);
            ReticularPointsW = FindReticularPoints(widths, problem.stock.width);

            ReticularPointsL = ConstructReducedSet(ReticularPointsL, this.problem.stock.length);
            ReticularPointsW = ConstructReducedSet(ReticularPointsW, this.problem.stock.width);

            partialPointsL = ConstructParcialPointsSet(ReticularPointsL);
            partialPointsW = ConstructParcialPointsSet(ReticularPointsW);
        }

        //private void FindReticularPoints(int count, int index, LinkedList<int> points, List<int> values, int MaxValue)//, List<(int,int)> control)
        //{

        //    int temp_count = count + values[index];
        //    if (temp_count <= MaxValue)
        //    {
        //        InsertPoint(points, temp_count);
        //        FindReticularPoints(temp_count, index, points, values, MaxValue);//, control);
        //    }
        //    if (index + 1 == values.Count) return;
        //    FindReticularPoints(count, index + 1, points, values, MaxValue);//, control);            
        //}

        private int[] FindReticularPoints(List<int> values, int maxValue)
        {
            BitArray tempPoints = new BitArray(maxValue + values.Max());
            tempPoints[0] = true;
            List<int> result = new List<int>();
            for (int i = 0; i <= maxValue; i++)
            {
                if (!tempPoints[i]) continue;
                else result.Add(i);
                for (int j = 0; j < values.Count; j++)
                {
                    try
                    {
                        tempPoints[i + values[j]] = true;
                    }
                    catch (Exception)
                    {
                        break;
                    }
                }
            }
            return result.ToArray();
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
            //List<int> result = new List<int>();
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
                    (result[j] = result[j] ?? new List<(int, int)>()).Add(GetConditionedMax(reducedSet, rj-rp));
                    //result[j].Add(GetConditionedMax(reducedSet, rj - rp));
                }
            }
            return result;
        }

        private (int valueOfPoint, int indexOfPoint) GetConditionedMax(int[] collectionOfPoints, int top)
        {
            int max = -1;
            int index = -1;
            for (int i = 0; i < collectionOfPoints.Length; i++)
            {
                int temp = collectionOfPoints[i];
                if (temp <= top)
                {
                    max = temp;
                    index = i;
                }
                else break;
            }
            return (max, index);
        }

        private void InitializeSolMatrix(SolutionCell[,] solMatrix)
        {
            for (int j = 0; j < solMatrix.GetLength(0); j++)
            {
                for (int k = 0; k < solMatrix.GetLength(1); k++)
                {
                    double max = 0;
                    int ind = -1;
                    for (int m = 0; m < problem.pieces.Length; m++)
                    {
                        if (problem.pieces[m].length > ReticularPointsL[j] || problem.pieces[m].width > ReticularPointsW[k])
                            continue;
                        double tempmax = dt[m];
                        if(tempmax>max)
                        {
                            max = tempmax;
                            ind = m;
                        }
                    }
                    TypeOfCell type = ind < 0 ? TypeOfCell.Waste : TypeOfCell.Piece;
                    solMatrix[j, k] = new SolutionCell(max, type, ind, DirectionOfCut.None, 0, 0, 0);
                }
            }
        }

        private void CalculateSolMatrix(SolutionCell[,] solMatrix)
        {
            int le = solMatrix.GetLength(0);
            int wi = solMatrix.GetLength(1);

            for (int j = 0; j < le; j++)
            {
                for (int k = 0; k < wi; k++)
                {
                    GetVerticalMax(j, k, solMatrix);
                    GetHorizontalMax(j, k, solMatrix);
                }
            }
        }

        private void GetVerticalMax(int j, int k, SolutionCell[,] solutionMatrix)
        {
            double max = solutionMatrix[j, k].Value;
            int cutIndex = -1;
            int nextcut = -1;
            bool changed = false;
            for (int p = 0; p < j/2; p++)
            {
                nextcut = GetIndexOfPartialPoint(DirectionOfCut.Vertical, j, p);
                double temp = solutionMatrix[p, k].Value + solutionMatrix[nextcut, k].Value;
                if(temp > max)
                {
                    max = temp;
                    cutIndex = p;
                    changed = true;
                }
            }
            if (changed)
                solutionMatrix[j, k].UpdateCell(max, cutIndex, DirectionOfCut.Vertical, cutIndex, k, nextcut);
            else solutionMatrix[j,k].UpdateCell(j, k);
        }

        private void GetHorizontalMax(int j, int k, SolutionCell[,] solutionMatrix)
        {
            double max = solutionMatrix[j, k].Value;
            int cutIndex = -1;
            int nextcut = -1;
            bool changed = false;
            for (int q = 0; q < k / 2; q++)
            {
                nextcut = GetIndexOfPartialPoint(DirectionOfCut.Horizontal, k, q);
                double temp = solutionMatrix[j, q].Value + solutionMatrix[j, nextcut].Value;
                if (temp > max)
                {
                    max = temp;
                    cutIndex = q;
                    changed = true;
                }
            }
            if (changed)
                solutionMatrix[j, k].UpdateCell(max, cutIndex, DirectionOfCut.Horizontal, j, cutIndex, nextcut);
            else solutionMatrix[j, k].UpdateCell(j, k);

        }

        private int GetIndexOfPartialPoint(DirectionOfCut dir, int j, int p)
        {
            switch (dir)
            {
                case DirectionOfCut.Vertical:
                    return partialPointsL[j][p].index;
                case DirectionOfCut.Horizontal:
                    return partialPointsW[j][p].index;                
            }
            return -1;
        }
               
        private CutTree ExtractCutTree(SolutionCell[,] solutionMatrix, int j, int k, int rectL, int rectW, CutPattern pattern)
        {   
            SolutionCell temp = solutionMatrix[j, k];
            //int length = ReticularPointsL[j];
            //int width = ReticularPointsW[k];

            switch (temp.Type)
            {
                case TypeOfCell.Cut:
                    switch (temp.DirOfCut)
                    {
                        case DirectionOfCut.Vertical:
                            int rightrect = partialPointsL[j][temp.Index].index;
                            int length = ReticularPointsL[temp.Index];
                            int rigthL = rectL - length;
                            return new CutTree(rectL, rectW, temp.Type, ReticularPointsL[temp.Index], temp.DirOfCut, ExtractCutTree(solutionMatrix, temp.Index, k, length, rectW, pattern), ExtractCutTree(solutionMatrix, rightrect, k, rigthL, rectW, pattern));                            
                        case DirectionOfCut.Horizontal:
                            int downrect = partialPointsW[k][temp.Index].index;
                            int width = ReticularPointsW[temp.Index];
                            int rigthW = rectW - width;
                            return new CutTree(rectL, rectW, temp.Type, ReticularPointsW[temp.Index], temp.DirOfCut, ExtractCutTree(solutionMatrix, j, temp.Index, rectL, width, pattern), ExtractCutTree(solutionMatrix, j, downrect, rectL, rigthW, pattern));                           
                    }
                    return null;
                
                case TypeOfCell.Piece:
                    pattern.variant_vector[temp.Index]++;
                    return new CutTree(rectL, rectW, temp, null, null);
                
                case TypeOfCell.Waste:
                    return new CutTree(rectL, rectW, temp, null, null);
                
                default:
                    return null;
            }

        }

        private CutTree CutTreeForInitialPattern(int maxlength, int maxwidth, Piece piece)
        {
            List<int> temp2 = new List<int>();
            temp2.Add(piece.length);
            int[] retPointsL = FindReticularPoints(temp2, maxlength);
            temp2.Clear();
            temp2.Add(piece.width);
            int[] retPointsW = FindReticularPoints(temp2, maxwidth);
            return ExtractVert(retPointsL, retPointsW, retPointsL.Length - 1, retPointsW.Length - 1, piece);
            //return new CutTree(piece.length, piece.width, TypeOfCell.Piece, piece.index, DirectionOfCut.None, null, null);
        }
        
        private CutTree ExtractVert(int[] r, int[] s, int j, int k, Piece p)
        {
            if (j == 0)
                return null;
            int rlen = r[j] - r[j - 1];
            if (rlen == p.length)
            {
                return new CutTree(r[j], s[k], TypeOfCell.Cut, r[j - 1], DirectionOfCut.Vertical, ExtractVert(r, s, j - 1, k, p), ExtractHorz(rlen, s, k, p));
            }
            if (rlen != p.length)
            {
                return new CutTree(r[j], s[k], TypeOfCell.Cut, r[j - 1], DirectionOfCut.Vertical, ExtractVert(r, s, j - 1, k, p), new CutTree(rlen, s[k], TypeOfCell.Waste, -1, DirectionOfCut.None, null, null));
            }
            return null;
        }

        private CutTree ExtractHorz(int rectlen, int[] s, int k, Piece p)
        {
            if (k == 0)
                return null;
            int rwidth = s[k] - s[k - 1];
            if (rwidth == p.width)
            {
                return new CutTree(rectlen, s[k], TypeOfCell.Cut, s[k - 1], DirectionOfCut.Horizontal, ExtractHorz(rectlen, s, k - 1, p), new CutTree(rectlen, s[k] - s[k - 1], TypeOfCell.Piece, p.index, DirectionOfCut.None, null, null));
            }
            if (rwidth != p.width)
            {
                return new CutTree(rectlen, s[k], TypeOfCell.Cut, s[k - 1], DirectionOfCut.Horizontal, ExtractHorz(rectlen, s, k - 1, p), new CutTree(rectlen, s[k] - s[k - 1], TypeOfCell.Waste, -1, DirectionOfCut.None, null, null));
            }
            return null;
        }
        //private void ExtractPiecePattern(SolutionCell[,] solutionMatrix, int j, int k, CutPattern pattern)
        //{
        //    SolutionCell temp = solutionMatrix[j, k];

        //    switch (temp.Type)
        //    {
        //        case TypeOfCell.Cut:
        //            switch (temp.DirOfCut)
        //            {
        //                case DirectionOfCut.Vertical:
        //                    ExtractPiecePattern(solutionMatrix, temp.Index, k, pattern);
        //                    ExtractPiecePattern(solutionMatrix, partialPointsL[j][temp.Index].index, k, pattern);
        //                    break;
        //                case DirectionOfCut.Horizontal:
        //                    ExtractPiecePattern(solutionMatrix, j, temp.Index, pattern);
        //                    ExtractPiecePattern(solutionMatrix, j, partialPointsW[k][temp.Index].index, pattern);
        //                    break;
        //            }
        //            break;
        //        case TypeOfCell.Piece:
        //            pattern.PieceDistribution.Add(new Piece(temp.OffsetL, temp.OffsetW, ReticularPointsL[j], ReticularPointsW[k], temp.Index));
        //            pattern.variant_vector[temp.Index]++;
        //            break;
        //        case TypeOfCell.Waste:
        //            pattern.PieceDistribution.Add(new Piece(temp.OffsetL, temp.OffsetW, ReticularPointsL[j], ReticularPointsW[k], temp.Index));
        //            break;
        //    }            
        //}
    }

    internal class Piece
    {
        //internal int startX;
        //internal int startY;
        internal int length;
        internal int width;
        internal int index;

        internal Piece(int length, int width, int index)
        {
            //this.startX = startx;
            //this.startY = starty;
            this.length = length;
            this.width = width;
            this.index = index;
        }
    }
    internal class SolutionCell
    {
        internal double Value { get; private set; }
        internal bool IsCut { get { return this.Type == TypeOfCell.Cut; } }

        internal TypeOfCell Type { get; private set; }
        internal int Index { get; private set; }
        internal DirectionOfCut DirOfCut { get; private set; }
        internal int NextCut { get; private set; }
        internal int OffsetL { get; private set; }
        internal int OffsetW { get; private set; }

        internal SolutionCell(double value, TypeOfCell type, int indx, DirectionOfCut dir, int offs1, int offs2, int nextCut)
        {
            this.Value = value;
            this.Type = type;
            this.Index = indx;
            this.DirOfCut = dir;
            this.OffsetL = offs1;
            this.OffsetW = offs2;
            this.NextCut = nextCut;
        }
        internal SolutionCell((double value, TypeOfCell type, int index, DirectionOfCut dir, int offs1, int offs2, int nextCut) cell)
        {
            this.Value = cell.value;
            this.Type = cell.type;
            this.Index = cell.index;
            this.DirOfCut = cell.dir;
            this.OffsetL = cell.offs1;
            this.OffsetW = cell.offs2;
            this.NextCut = cell.nextCut;
        }

        internal void UpdateCell (double newValue, TypeOfCell newType, int newIndex, DirectionOfCut newDir, int newOffset1, int newOffset2, int nextCut)
        {
            InternalUpdate(newValue, newIndex, newDir, newOffset1, newOffset2, nextCut);
            this.Type = newType;
        }

        internal void UpdateCell(double newValue, int newIndex, DirectionOfCut newDir, int newOffset1, int newOffset2, int nextCut)
        {
            InternalUpdate(newValue, newIndex, newDir, newOffset1, newOffset2, nextCut);
            if (newIndex < 0) this.Type = TypeOfCell.Waste;
            else if (newDir == DirectionOfCut.None) this.Type = TypeOfCell.Piece;
            else this.Type = TypeOfCell.Cut;
        }

        internal void UpdateCell(double newValue)
        {
            this.Value = newValue;
        }

        internal void UpdateCell(int newOffset1, int newOffset2)
        {
            this.OffsetL = newOffset1;
            this.OffsetW = newOffset2;
        }
        internal void SetToNone()
        {
            InternalUpdate(-1, -1, DirectionOfCut.None, -1, -1, -1);
            this.Type = TypeOfCell.None;
        }
        private void InternalUpdate(double newValue, int newIndex, DirectionOfCut newDir, int newOffset1, int newOffset2, int nextCut)
        {
            this.Value = newValue;
            this.Index = newIndex;
            this.DirOfCut = newDir;
            this.OffsetL = newOffset1;
            this.OffsetW = newOffset2;
            this.NextCut = nextCut;
        }

        internal string PrintCell()
        {
            string result = "";

            if (this.IsCut) result += "C: " + this.Index;
            else if (this.Type == TypeOfCell.Piece) result += "P: " + this.Index;
            else result += "W: " + this.Index;

            result += " n: " + this.NextCut;
            return result;
        }
    }

    //internal class SolutionCell2
    //{
    //    internal double Value { get; }
    //    internal bool IsCut { get; }
    //    internal int Index { get; }
    //    internal DirectionOfCut DirOfCut { get; }


    //    public SolutionCell2(double value, bool isCut, int indx, DirectionOfCut dir)
    //    {
    //        this.Value = value;
    //        this.IsCut = isCut;
    //        this.Index = indx;
    //        this.DirOfCut = dir;
    //    }
    //    public SolutionCell2((double value, bool isCut, int index, DirectionOfCut dir) cell)
    //    {
    //        this.Value = cell.value;
    //        this.IsCut = cell.isCut;
    //        this.Index = cell.index;
    //        this.DirOfCut = cell.dir;
    //    }
    //}


    public enum TypeOfCell
    {
        Cut,
        Piece,
        Waste,
        None
    }
    public enum DirectionOfCut
    {
        Vertical,
        Horizontal,
        None
    }

    public class CutTree
    {
        public int Length { get; private set; }
        public int Width { get; private set; }
        public TypeOfCell Kind { get; private set; }
        public DirectionOfCut CutDirection { get; private set; }
        public int IndexOfPieceOrValueOfCut { get; private set; }

        public CutTree Left { get; private set; }
        public CutTree Right { get; private set; }

        public CutTree(int rectLength, int rectWidth, TypeOfCell kind, int index, DirectionOfCut dir, CutTree left, CutTree right)
        {
            this.Length = rectLength; this.Width = rectWidth; this.IndexOfPieceOrValueOfCut = index;
            this.Kind = kind; this.CutDirection = dir;
            this.Left = left;
            this.Right = right;
        }

        internal CutTree(int rectLength, int rectWidth, SolutionCell cell, CutTree left, CutTree right)
        {
            this.Length = rectLength;
            this.Width = rectWidth;
            this.Kind = cell.Type;
            this.IndexOfPieceOrValueOfCut = cell.Index;
            this.CutDirection = cell.DirOfCut;
            this.Left = left;
            this.Right = right;
        }
    }

}
