using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class RulesFactory
    {
        // TODO här väljs det vilka regler som spelas med
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
    }
}
