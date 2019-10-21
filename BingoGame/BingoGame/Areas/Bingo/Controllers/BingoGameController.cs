using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Bingo.Services.Interfaces;
using BingoEngine.Infrastructure;
using BingoEngine.Interfaces;
using BingoGame.Areas.Bingo.ViewModels;

namespace BingoGame.Areas.Bingo.Controllers
{
    public class BingoGameController : Controller
    {
        private IGameManagerService<int> gameManager;

        public BingoGameController(IGameManagerService<int> gameManager)
        {
            this.gameManager = gameManager;
        }

        // GET: Bingo/BingoGame
        public ActionResult Index(bool isNewGameSession = true)
        {
            if (isNewGameSession)
            {
                Session["GameSessionData"] = null;
                Session["GameSessionWinValues"] = null;
            }

            return View();
        }

        public ActionResult BingoSessionProcessing()
        {
            var viewModel = Session["GameSessionData"] as BingoGameSessionViewModel;
            if (viewModel == null)
            {
                viewModel = new BingoGameSessionViewModel();
                Session["GameSessionData"] = viewModel;
            }

            if (viewModel.GameSessionData == null)
            {
                viewModel.GameSessionData = this.gameManager.CreatePlayerSessionData();
            }

            int rolledValue = this.gameManager.Roll(viewModel.GameSessionData);
            viewModel.RolledValue = rolledValue;
            var winResult = this.gameManager.CheckOnWin(viewModel.GameSessionData);
            if (winResult.Item1)
            {
                Session["GameSessionWinValues"] = winResult.Item2;
                return RedirectToAction("BingoWin");
            }

            return PartialView(viewModel);
        }

        public ActionResult BingoWin()
        {
            var gameSessionData = Session["GameSessionData"] as BingoGameSessionViewModel;
            var winValues = Session["GameSessionWinValues"] as IEnumerable<int>;
            var winViewModel = new BingoWinViewModel
            {
                GameSessionData = gameSessionData.GameSessionData,
                WinValues = winValues
            };

            return View(winViewModel);
        }
    }
}