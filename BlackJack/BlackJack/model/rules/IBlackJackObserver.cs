using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack.model.rules
{
    interface IBlackJackObserver
    {
        void DealCard(Card c);
    }
}
