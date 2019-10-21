using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bingo.Services.GameServices;
using Bingo.Services.Interfaces;
using BingoEngine.Engine;
using BingoEngine.Infrastructure;
using BingoEngine.Interfaces;
using BingoEngine.WinConditions;
using BingoEngine.WinConditions.Interfaces;
using Ninject.Modules;


namespace NinjectDI
{
    public class BingoGameNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IWinConditionProcessing<int>>().To<EquilateralBoardWinProcessing>();
            this.Bind<IBingoEngine<int>>().To<CommonBingoEngine>();
            this.Bind<IGameManagerService<int>>().To<BingoGameManagerService>();
        }
    }
}
