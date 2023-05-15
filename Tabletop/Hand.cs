using MagicTheGathering.Cards;
using System;
using System.Collections.ObjectModel;

namespace MagicTheGathering
{
    /*
     * Author: David DLVega
     * Date: May 13, 2023
     */
    public class Hand : Collection<BaseMagicCard>
    {
        private Random Random = new Random();

        public void AddCard(BaseMagicCard card)
        {
            this.Add( card );
        }

        public BaseMagicCard Play(BaseMagicCard card)
        {
            this.Remove( card );
            return card;
        }

        internal BaseMagicCard Discard(BaseMagicCard card = null)
        {
            BaseMagicCard discard;

            if (card == null)
            {
                var randNum = this.Random.Next(8);
                discard = this.Items[randNum];
                this.Items.RemoveAt(randNum);
            } 
            else
            {
                discard = card;
                this.Items.Remove(card);
            }

            return discard;
        }
    }
}
