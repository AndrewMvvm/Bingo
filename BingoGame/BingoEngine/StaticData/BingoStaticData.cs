using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingoEngine.StaticData
{
    public static class BingoStaticData
    {
        public const string VerticalWinConditionName = "VerticalWinCondition";
        public const string HorizontalWinConditionName = "HorizontalWinCondition";
        public const string DiagonalWinConditionName = "DiagonalWinCondition";

        public const int DefaultBingoBoardWidht = 5;
        public const int DefaultBingoBoardHeight = 5;

        public const int DefaultBingoMinValue = 1;
        public const int DefaultBingoMaxValue = 52;
    }
}
