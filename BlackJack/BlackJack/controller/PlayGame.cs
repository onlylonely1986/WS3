using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.controller
{
    class PlayGame : model.IBlackJackObserver
    {
        private view.IView m_view;
        private model.Game m_game;
        public PlayGame (view.IView a_view, model.Game a_game)
        {
            m_view = a_view;
            m_game = a_game;
            a_game.AddSubscriber(this);
        }
        public bool Play() 
        {
            PrintView();
            if (m_game.IsGameOver())
            {
                m_view.DisplayGameOver(m_game.IsDealerWinner());
            }

            BlackJack.view.MenuEvent.Event e;

            e = m_view.GetEvent();
            if (e == BlackJack.view.MenuEvent.Event.Quit)
            {
                return false;
            }
            if (e == BlackJack.view.MenuEvent.Event.Start)
            {
                m_game.NewGame();

            }
            if (e == BlackJack.view.MenuEvent.Event.Hit)
            {
                m_game.Hit();
            }
            if (e == BlackJack.view.MenuEvent.Event.Stand)
            {
                m_game.Stand();
            }

            return true;
        }


        public void DealtCard()
        {
            PrintView();
            // fix a metod in view for that
            System.Threading.Thread.Sleep(1000);
        }

        public void PrintView()
        {
            m_view.DisplayWelcomeMessage();
            m_view.DisplayDealerHand(m_game.GetDealerHand(), m_game.GetDealerScore());
            m_view.DisplayPlayerHand(m_game.GetPlayerHand(), m_game.GetPlayerScore());
        }
    }
}