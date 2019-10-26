using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.controller
{
    class PlayGame
    {
        public bool Play(model.Game a_game, view.IView a_view)
        {
            a_view.DisplayWelcomeMessage();

            a_view.DisplayDealerHand(a_game.GetDealerHand(), a_game.GetDealerScore());
            a_view.DisplayPlayerHand(a_game.GetPlayerHand(), a_game.GetPlayerScore());

            if (a_game.IsGameOver())
            {
                a_view.DisplayGameOver(a_game.IsDealerWinner());
            }

            BlackJack.view.MenuEvent.Event e;

            e = a_view.GetEvent();
            if (e == BlackJack.view.MenuEvent.Event.Quit)
            {
                return false;
            }
            if (e == BlackJack.view.MenuEvent.Event.Start)
            {
                a_game.NewGame();

            }
            if (e == BlackJack.view.MenuEvent.Event.Hit)
            {
                a_game.Hit();
            }
            if (e == BlackJack.view.MenuEvent.Event.Stand)
            {
                a_game.Stand();
            }

            return true;
        }
    }
}