using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingoEngine.Interfaces
{
    /// <summary>
    /// Data of one bingo game session
    /// </summary>
    /// <typeparam name="TValue">Bingo value type</typeparam>
    public interface IBingoGameSession<TValue>
    {
        /// <summary>
        /// Player matches values
        /// </summary>
        ICollection<IBingoValue<TValue>> MatchesValues { get; }

        /// <summary>
        /// Existing bingo values in certain game session
        /// </summary>
        ICollection<TValue> SessionExistingValues { get; }

        /// <summary>
        /// Bingo board
        /// </summary>
        IBoard<TValue> Board { get; }
    }
}
