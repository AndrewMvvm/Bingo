using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingoEngine.Interfaces
{
    /// <summary>
    /// Represents Game Engnine for bingo
    /// </summary>
    /// <typeparam name="TValue"></typeparam>
    public interface IBingoEngine<TValue>
    {
        /// <summary>
        /// Initialize new Data of Game Session
        /// </summary>
        /// <returns></returns>
        IBingoGameSession<TValue> InitializeGameSession();

        /// <summary>
        /// Processing of one roll step
        /// </summary>
        /// <param name="sessionData">data of game session</param>
        /// <returns>generated new value</returns>
        TValue GameStepProcessing(IBingoGameSession<TValue> sessionData);

        /// <summary>
        /// Notify if any of win conditions is observed
        /// </summary>
        /// <param name="sessionData">data of game session</param>
        /// <returns>(If win condition observed, Values that represents win condition)</returns>
        (bool, IEnumerable<IBingoValue<TValue>>) IsWinConditionFound(IBingoGameSession<TValue> sessionData);
    }
}
