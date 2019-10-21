using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BingoEngine.Interfaces;

namespace BingoGame.Areas.Bingo.ViewModels
{
    public class BingoGameSessionViewModel
    {
        public IBingoGameSession<int> GameSessionData { get; set; }
        public int RolledValue { get; set; }
    }
}