using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BingoEngine.Interfaces;

namespace BingoGame.Areas.Bingo.ViewModels
{
    public class BingoWinViewModel
    {
        public IEnumerable<int> WinValues { get; set; }
        public IBingoGameSession<int> GameSessionData { get; set; }
    }
}