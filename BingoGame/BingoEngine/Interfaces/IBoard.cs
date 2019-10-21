using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingoEngine.Interfaces
{
    /// <summary>
    /// Represents board of dingo
    /// </summary>
    /// <typeparam name="TValue">type of bingo value</typeparam>
    public interface IBoard<TValue>
    {
        /// <summary>
        /// Count positions on X
        /// </summary>
        int BoardWidth { get; }

        /// <summary>
        /// Count positions on Y
        /// </summary>
        int BoardHeight { get; }

        /// <summary>
        /// Board with values
        /// </summary>
        TValue[,] BoardRepresentation { get; set; }
    }
}
