using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BingoEngine.Interfaces;

namespace Bingo.Services.Interfaces
{
    public interface IGameManagerService<TValue>
    {
        /// <summary>
        /// Accessor for used engine
        /// </summary>
        IBingoEngine<TValue> GameEngnine { get; }

        /// <summary>
        /// Generate new value + processing game session data
        /// </summary>
        /// <param name="gameSessionData"></param>
        /// <returns></returns>
        TValue Roll(IBingoGameSession<TValue> gameSessionData);

        /// <summary>
        /// Generate game data for player
        /// </summary>
        /// <returns></returns>
        IBingoGameSession<TValue> CreatePlayerSessionData();

        /// <summary>
        /// Check if Player win
        /// </summary>
        /// <param name="gameSessionData">game session data for check</param>
        /// <returns>(win result, Win Values)</returns>
        (bool, IEnumerable<TValue>) CheckOnWin(IBingoGameSession<TValue> gameSessionData);
    }
}
