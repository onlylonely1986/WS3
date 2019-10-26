using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack.model.rules
{
    interface IWinnerStrategy
    {
        bool IsWinner(int g_maxScore, model.Player a_dealer, model.Player a_player);
    }
}
