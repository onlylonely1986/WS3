using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack.model.rules
{
    class PlayerWinsOnEqual : IWinnerStrategy
    {
        public bool IsWinner(int g_maxScore, model.Player a_dealer, model.Player a_player)
        {
            if (a_player.CalcScore() > g_maxScore)
            {
                return true;
            }
            else if (a_dealer.CalcScore() > g_maxScore)
            {
                return false;
            }
            if (a_player.CalcScore() >= a_dealer.CalcScore())
            {
                return false;
            }
            else return true;
        }
    }
}
