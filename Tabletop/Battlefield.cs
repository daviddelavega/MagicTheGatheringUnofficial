using MagicTheGathering.Cards;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace MagicTheGathering.Zones
{
    /*
     * Author: David DLVega
     * Date: May 13, 2023
     */
    public class Battlefield
    {
        public ICollection<BaseMagicCard> Cards = new Collection<BaseMagicCard>();

        public void Untap()
        {
            foreach (var card in this.Cards)
            {
                card.Untap();
            }
        }

        public void Play(BaseMagicCard card)
        {
            this.Cards.Add( card );

            int cost = 0;
            foreach (byte value in card.ManaCost.Values)
            {
                cost += value;
            }
       
            var landsToTap = this.Cards.Where(land => land.CardType == CardType.Land).Take(cost);
            foreach(var land in landsToTap)
            {
                land.Tap();
            }
        }

        public void PlayLand(BaseMagicCard card)
        {
            this.Cards.Add(card);
        }
    }
}
