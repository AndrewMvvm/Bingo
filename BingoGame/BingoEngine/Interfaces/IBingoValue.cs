using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingoEngine.Interfaces
{
    /// <summary>
    /// Represents bingo value and his environment
    /// </summary>
    /// <typeparam name="TValue"></typeparam>
    public interface IBingoValue<TValue>
    {
        /// <summary>
        /// X-Position
        /// </summary>
        int HorizontalPosition { get; }

        /// <summary>
        /// Y-Position
        /// </summary>
        int VerticalPosition { get; }

        /// <summary>
        /// Direclty bingo value
        /// </summary>
        TValue BingoValue { get; }
    }
}
