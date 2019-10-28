using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class Soft17HitStrategy : IHitStrategy
    {
        private const int g_hitLimit = 17;

        public bool DoHit(model.Player a_dealer)
        {
            if (a_dealer.CalcScore() == g_hitLimit)
            {
                foreach (Card c in a_dealer.GetHand())
                {
                    if (c.GetValue() == Card.Value.Ace)
                    {
                        if(a_dealer.CalcScoreSoft17())
                        {
                            return true;
                        }
                    }
                }
            }
            return a_dealer.CalcScore() < g_hitLimit;
        }
    }
}
