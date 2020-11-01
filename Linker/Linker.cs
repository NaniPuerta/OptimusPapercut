using System;
using System.Collections.Generic;
using System.Linq;
using OptimizationCore;

namespace Linker
{
    public static class Linker
    {
        

        public static CutPattern[] FindSolution(IEnumerable<int> pieceLengths, IEnumerable<int> pieceWidths, IEnumerable<int> pieceDemands, int stockLength, int stockWidth, int stockCost)
        {
            int[] pLengths = pieceLengths.ToArray<int>();
            int[] pWidths = pieceWidths.ToArray<int>();
            int[] pDemands = pieceDemands.ToArray<int>();

            OptimizationProblem problem = new OptimizationProblem(stockLength, stockWidth, stockCost, pLengths, pWidths, pDemands);
            Simplex simp = new Simplex(problem);
            CutPattern[] solution = simp.Solve();
            return solution;
        }
    }
}
