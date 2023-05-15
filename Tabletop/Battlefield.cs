﻿using MagicTheGathering.Cards;
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
        public ICollection<MagicCard> Cards = new Collection<MagicCard>();

        public void Untap()
        {
            foreach (var card in this.Cards)
            {
                card.Untap();
            }
        }

        public void Play(MagicCard card)
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

        public void PlayLand(MagicCard card)
        {
            this.Cards.Add(card);
        }
    }
}
