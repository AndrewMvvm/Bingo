using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bingo.Services.Interfaces;
using BingoEngine.Interfaces;
using BingoEngine.StaticData;

namespace Bingo.Services.GameServices
{
    public class BingoGameManagerService : IGameManagerService<int>
    {
        private Random randomizer = new Random();
        public IBingoEngine<int> GameEngnine { get; private set; }

        public BingoGameManagerService(IBingoEngine<int> gameEngine)
        {
            this.GameEngnine = gameEngine;
        }

        public int Roll(IBingoGameSession<int> gameSessionData)
        {
            int generatedValue = this.GameEngnine.GameStepProcessing(gameSessionData);
            return generatedValue;
        }

        public IBingoGameSession<int> CreatePlayerSessionData()
        {
            IBingoGameSession<int> generatedData = null;
            try
            {
                generatedData = this.GameEngnine.InitializeGameSession();
            }
            catch(Exception ex)
            {
                this.Log(ex.Message);
                throw;
            }

            return generatedData;
        }

        public (bool, IEnumerable<int>) CheckOnWin(IBingoGameSession<int> gameSessionData)
        {
            (bool, IEnumerable<int>) result = (false, null);
            var winConditionResult = this.GameEngnine.IsWinConditionFound(gameSessionData);
            result.Item1 = winConditionResult.Item1;
            result.Item2 = winConditionResult.Item2?.Select(item => item.BingoValue);
            return result;
        }

        private void Log(string message)
        {
            Debug.WriteLine($"[Log Message] - {message}");
        }
    }
}
