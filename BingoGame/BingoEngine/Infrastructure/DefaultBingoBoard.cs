using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BingoEngine.Interfaces;

namespace BingoEngine.Infrastructure
{
    /// <summary>
    /// Represents default board on Bingo with integers value
    /// </summary>
    public class DefaultBingoBoard : IBoard<int>
    {
        public int BoardWidth { get; private set; }

        public int BoardHeight { get; private set; }

        public int[,] BoardRepresentation { get; set; }

        public DefaultBingoBoard(int boardWidth, int boardHeight)
        {
            this.BoardWidth = boardWidth;
            this.BoardHeight = boardHeight;
            this.BoardRepresentation = new int[this.BoardWidth, this.BoardHeight];
        }
    }
}
