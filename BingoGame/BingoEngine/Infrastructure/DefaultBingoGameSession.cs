using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BingoEngine.Interfaces;
using BingoEngine.StaticData;

namespace BingoEngine.Infrastructure
{
    /// <summary>
    /// Default game session data for integers bingo values
    /// </summary>
    public class DefaultBingoGameSession : IBingoGameSession<int>
    {
        public ICollection<IBingoValue<int>> MatchesValues { get; set; }

        public ICollection<int> SessionExistingValues { get; set; }

        public IBoard<int> Board { get; set; }

        public DefaultBingoGameSession()
        {
            this.MatchesValues = new List<IBingoValue<int>>();
            this.SessionExistingValues = new List<int>();
        }

        public DefaultBingoGameSession(int boardWidth, int boardHeight)
        {
            this.MatchesValues = new List<IBingoValue<int>>();
            this.SessionExistingValues = new List<int>();
            this.Board = new DefaultBingoBoard(boardWidth, boardHeight);
        }
    }
}
