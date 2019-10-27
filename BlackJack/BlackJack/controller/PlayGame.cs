using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.controller
{
    class PlayGame : model.rules.IBlackJackObserver
    {
        private view.IView m_view;
        public PlayGame (view.IView a_view)
        {
            m_view = a_view;
        }
        public bool Play(model.Game a_game) 
        {
            a_game.AddSubscriber(this);
            m_view.DisplayWelcomeMessage();
            m_view.DisplayDealerHand(a_game.GetDealerHand(), a_game.GetDealerScore());
            m_view.DisplayPlayerHand(a_game.GetPlayerHand(), a_game.GetPlayerScore());

            if (a_game.IsGameOver())
            {
                m_view.DisplayGameOver(a_game.IsDealerWinner());
            }

            BlackJack.view.MenuEvent.Event e;

            e = m_view.GetEvent();
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


        public void DealCard(model.Card c)
        {
            m_view.DisplayCardValue(c);
            System.Threading.Thread.Sleep(1000);
        }
    }
}