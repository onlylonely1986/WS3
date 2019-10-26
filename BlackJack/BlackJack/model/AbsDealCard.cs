using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack.model
{
    class AbsDealCard
    {
        public void DealCard(Deck a_deck, Player a_player, bool showCard)
        {
            Card c = a_deck.GetCard();
            c.Show(showCard);
            a_player.DealCard(c);
        }
    }
}
