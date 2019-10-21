using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BingoEngine.Interfaces;
using BingoEngine.StaticData;
using BingoEngine.WinConditions.Interfaces;

namespace BingoEngine.WinConditions
{
    /// <summary>
    /// Win conditions for equilateral bingo boards
    /// </summary>
    public class EquilateralBoardWinProcessing : IWinConditionProcessing<int>
    {
        /// <summary>
        /// Encapsulates delegates for all win conditions for this board type
        /// </summary>
        private Dictionary<string, Func<IBingoGameSession<int>, IEnumerable<IBingoValue<int>>>> DefaultWinConditions { get; set; } =
            new Dictionary<string, Func<IBingoGameSession<int>, IEnumerable<IBingoValue<int>>>>
            {
                [BingoStaticData.DiagonalWinConditionName] = new Func<IBingoGameSession<int>, IEnumerable<IBingoValue<int>>>(gameData => 
                {
                    IEnumerable<IBingoValue<int>> winElements = null;
                    var matchesLeftToRigthDiagonal = gameData.MatchesValues.Where(val => val.HorizontalPosition == val.VerticalPosition);
                    var matchesRightToLeftDiagonal = gameData.MatchesValues.Where(val => val.HorizontalPosition + val.VerticalPosition == gameData.Board.BoardWidth);
                    if (matchesLeftToRigthDiagonal.Count() >= gameData.Board.BoardHeight)
                    {
                        winElements = matchesLeftToRigthDiagonal;
                    }

                    if(matchesRightToLeftDiagonal.Count() >= gameData.Board.BoardWidth)
                    {
                        winElements = matchesRightToLeftDiagonal;
                    }

                    return winElements;
                }),

                [BingoStaticData.VerticalWinConditionName] = new Func<IBingoGameSession<int>, IEnumerable<IBingoValue<int>>>(gameData =>
                {
                    var groupedValues = gameData.MatchesValues.GroupBy(val => val.VerticalPosition);
                    var conditionResult = groupedValues.FirstOrDefault(gr => gr.Count() >= gameData.Board.BoardHeight);
                    return conditionResult;
                }),

                [BingoStaticData.HorizontalWinConditionName] = new Func<IBingoGameSession<int>, IEnumerable<IBingoValue<int>>>(gameData =>
                {
                    var groupedValues = gameData.MatchesValues.GroupBy(val => val.HorizontalPosition);
                    var conditionResult = groupedValues.FirstOrDefault(gr => gr.Count() >= gameData.Board.BoardWidth);
                    return conditionResult;
                })
            };

        /// <summary>
        /// Repesents diagonal win condition delegate
        /// </summary>
        /// <param name="gameData">game session data</param>
        /// <returns></returns>
        private IEnumerable<IBingoValue<int>> DiagonalWinConditionCheck(IBingoGameSession<int> gameData)
        {
            IEnumerable<IBingoValue<int>> winElements = null;
            var matches = gameData.MatchesValues.Where(val => val.HorizontalPosition == val.VerticalPosition);
            if(matches.Count() >= gameData.Board.BoardHeight)
            {
                winElements = matches;
            }

            return winElements;
        }

        /// <summary>
        /// Repersent horizontal win condition delegate
        /// </summary>
        /// <param name="gameData"></param>
        /// <returns></returns>
        private IEnumerable<IBingoValue<int>> HorizontalWinConditionCheck(IBingoGameSession<int> gameData)
        {
            var groupedValues = gameData.MatchesValues.GroupBy(val => val.HorizontalPosition);
            var conditionResult = groupedValues.FirstOrDefault(gr => gr.Count() >= gameData.Board.BoardWidth);
            return conditionResult;
        }

        /// <summary>
        /// Represent vertical win condition delegate
        /// </summary>
        /// <param name="gameData"></param>
        /// <returns></returns>
        private IEnumerable<IBingoValue<int>> VerticalWinConditionCheck(IBingoGameSession<int> gameData)
        {
            var groupedValues = gameData.MatchesValues.GroupBy(val => val.VerticalPosition);
            var conditionResult = groupedValues.FirstOrDefault(gr => gr.Count() >= gameData.Board.BoardHeight);
            return conditionResult;
        }

        /// <summary>
        /// Find of any win conditions results that satisfy the conditions
        /// </summary>
        /// <param name="gameSession">game session data</param>
        /// <returns>Tuple of (if win conditions founded + win values if they exists)</returns>
        public (bool, IEnumerable<IBingoValue<int>>) WinConditionProcessing(IBingoGameSession<int> gameSession)
        {
            (bool, IEnumerable<IBingoValue<int>>) winConditionResult = (false, null);
            var invokedProcessingResult = this.DefaultWinConditions.Select(condition => condition.Value.Invoke(gameSession));
            var winValues = invokedProcessingResult.FirstOrDefault(res => res != null);
            winConditionResult.Item1 = winValues != null;
            winConditionResult.Item2 = winValues;
            return winConditionResult;
        }
    }
}
