﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class RulesFactory
    {
        public IHitStrategy GetHitRule()
        {
            // return new BasicHitStrategy();
            return new Soft17HitStrategy();
        }

        public INewGameStrategy GetNewGameRule()
        {
            return new InternationalNewGameStrategy();
            // return new AmericanNewGameStrategy();
        }

        public IWinnerStrategy GetWinnerRule()
        {
            return new DealerWinsOnEqual();
            // return new PlayerWinsOnEqual();
        }
    }
}
