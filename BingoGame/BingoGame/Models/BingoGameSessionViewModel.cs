using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BingoEngine.Interfaces;

namespace BingoGame.Models
{
    public class BingoGameSessionViewModel
    {
        public IBingoGameSession<int> SessionData { get; set; }
        public int RolledValue { get; set; }
    }
}