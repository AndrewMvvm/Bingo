using System;
using System.Collections.Generic;
using BingoEngine.Infrastructure;
using BingoEngine.Interfaces;
using BingoEngine.StaticData;
using BingoEngine.WinConditions.Interfaces;

namespace BingoEngine.Engine
{
    /// <summary>
    /// Standart bingo engine for integer bingo values
    /// </summary>
    public class CommonBingoEngine : IBingoEngine<int>
    {
        private Random randomizer;
        private IWinConditionProcessing<int> winProcessing;

        public CommonBingoEngine(IWinConditionProcessing<int> winProcessing)
        {
            this.winProcessing = winProcessing;
            this.randomizer = new Random();
        }

        private int[,] CreateUniqueValuesArray(int width, int height)
        {
            int[,] array = new int[width, height];
            List<int> existingValues = new List<int>();
            for (int posX = 0; posX < width; posX++)
            {
                for (int posY = 0; posY < height; posY++)
                {
                    int randomValue = this.randomizer.Next(BingoStaticData.DefaultBingoMinValue, BingoStaticData.DefaultBingoMaxValue);
                    while (existingValues.Contains(randomValue))
                    {
                        randomValue = this.randomizer.Next(BingoStaticData.DefaultBingoMinValue, BingoStaticData.DefaultBingoMaxValue);
                    }

                    array[posX, posY] = randomValue;
                    existingValues.Add(randomValue);
                }
            }

            return array;
        }

        public int GameStepProcessing(IBingoGameSession<int> sessionData)
        {
            int randomValue = this.randomizer.Next(BingoStaticData.DefaultBingoMinValue, BingoStaticData.DefaultBingoMaxValue);
            while (sessionData.SessionExistingValues.Contains(randomValue))
            {
                randomValue = this.randomizer.Next(BingoStaticData.DefaultBingoMinValue, BingoStaticData.DefaultBingoMaxValue);
            }

            sessionData.SessionExistingValues.Add(randomValue);
            for(int posX = 0; posX < sessionData.Board.BoardWidth; posX++)
            {
                for(int posY = 0; posY < sessionData.Board.BoardHeight; posY++)
                {
                    if(sessionData.Board.BoardRepresentation[posX, posY] == randomValue)
                    {
                        var bingoPoint = new DefaultBingoValue(posX, posY, sessionData.Board.BoardRepresentation[posX, posY]);
                        sessionData.MatchesValues.Add(bingoPoint);
                    }
                }
            }

            return randomValue;
        }

        public IBingoGameSession<int> InitializeGameSession()
        {
            var gameSessionData = new DefaultBingoGameSession(BingoStaticData.DefaultBingoBoardWidht, BingoStaticData.DefaultBingoBoardHeight);
            var boardRepresentation = this.CreateUniqueValuesArray(gameSessionData.Board.BoardWidth, gameSessionData.Board.BoardHeight);
            gameSessionData.Board.BoardRepresentation = boardRepresentation;
            return gameSessionData;
        }

        public (bool, IEnumerable<IBingoValue<int>>) IsWinConditionFound(IBingoGameSession<int> sessionData)
        {
            var winResult = this.winProcessing.WinConditionProcessing(sessionData);
            return winResult;
        }
    }
}
