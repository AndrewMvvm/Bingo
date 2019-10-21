using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BingoEngine.Interfaces;

namespace BingoEngine.Infrastructure
{
    /// <summary>
    /// Default bingo value of integer type
    /// </summary>
    public class DefaultBingoValue : IBingoValue<int>
    {
        public int HorizontalPosition { get; private set; }

        public int VerticalPosition { get; private set; }

        public int BingoValue { get; private set; }

        public DefaultBingoValue(int horizontalPos, int verticalPos, int value)
        {
            this.HorizontalPosition = horizontalPos;
            this.VerticalPosition = verticalPos;
            this.BingoValue = value;
        }
    }
}
