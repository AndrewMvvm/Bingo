using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BingoEngine.Interfaces;

namespace BingoEngine.WinConditions.Interfaces
{
    /// <summary>
    /// Member of win conditions
    /// </summary>
    /// <typeparam name="TValue">type of bingo value</typeparam>
    public interface IWinConditionProcessing<TValue>
    {
        /// <summary>
        /// Is win founded any win conditions
        /// </summary>
        /// <param name="gameSession">bingo game session data</param>
        /// <returns>Tupple of IsWinCondition Result (bool) + Win Value-Set</returns>
        (bool, IEnumerable<IBingoValue<TValue>>) WinConditionProcessing(IBingoGameSession<TValue> gameSession);
    }
}
