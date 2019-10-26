using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class AmericanNewGameStrategy : AbsDealCard, INewGameStrategy
    {
        public bool NewGame(Deck a_deck, Dealer a_dealer, Player a_player)
        {

            DealCard(a_deck, a_player, true);
            DealCard(a_deck, a_dealer, true);
            DealCard(a_deck, a_player, true);
            DealCard(a_deck, a_dealer, false);
            return true;
        }
    }
}
