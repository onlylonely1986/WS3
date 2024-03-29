﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model
{
    class Dealer : Player
    {
        private Deck m_deck = null;
        private const int g_maxScore = 21;

        private rules.INewGameStrategy m_newGameRule;
        private rules.IHitStrategy m_hitRule;
        private rules.IWinnerStrategy m_winnerRule;

        private List<IBlackJackObserver> m_observers;


        public Dealer(rules.RulesFactory a_rulesFactory)
        {
            m_newGameRule = a_rulesFactory.GetNewGameRule();
            m_hitRule = a_rulesFactory.GetHitRule();
            m_winnerRule = a_rulesFactory.GetWinnerRule();
            m_observers = new List<IBlackJackObserver>();
        }

        public void AddSubscriber(IBlackJackObserver a_sub)
        {
            m_observers.Add(a_sub);
        }

        public bool NewGame(Player a_player)
        {
            if (m_deck == null || IsGameOver())
            {
                m_deck = new Deck();
                ClearHand();
                a_player.ClearHand();
                return m_newGameRule.NewGame(this, a_player);
            }
            return false;
        }

        public void GiveCard(Player a_player, bool ShowCard)
        {
            Card c;
            c = m_deck.GetCard();
            c.Show(ShowCard);
            a_player.DealCard(c);
            foreach(IBlackJackObserver o in m_observers)
            {
                o.DealtCard();
            }
        }

        public bool Hit(Player a_player)
        {
            if (m_deck != null && a_player.CalcScore() < g_maxScore && !IsGameOver())
            {
                GiveCard(a_player, true);
                return true;
            }
            return false;
        }

        public bool Stand(Player a_player)
        {
            if (m_deck != null)
            {
                this.ShowHand();
                while (m_hitRule.DoHit(this))
                {
                    GiveCard(this, true);
                }
            }
            return false;
        }

        public bool IsDealerWinner(Player a_player)
        {
            return m_winnerRule.IsWinner(g_maxScore, this, a_player);
        }

        public bool IsGameOver()
        {
            if (m_deck != null && m_hitRule.DoHit(this) != true)
            {
                return true;
            }
            return false;
        }
    }
}