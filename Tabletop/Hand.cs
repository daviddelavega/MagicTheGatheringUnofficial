using MagicTheGathering.Cards;
using System.Collections.ObjectModel;

namespace MagicTheGathering
{
    /*
     * Author: David DLVega
     * Date: May 13, 2023
     * The Hand class manages each players Card Hand throughout the game.
     */
    public class Hand : Collection<MagicCard>
    {
        private Random Random = new Random();

        public void AddCard(MagicCard card)
        {
            this.Add( card );
        }

        public MagicCard Play(MagicCard card)
        {
            this.Remove( card );
            return card;
        }

        internal MagicCard Discard(MagicCard card = null)
        {
            MagicCard discard;

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
