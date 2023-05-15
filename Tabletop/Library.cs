using MagicTheGathering.Cards;

namespace MagicTheGathering.Tabletop
{
    /*
     * Author: David DLVega
     * Date: May 13, 2023
     * The Library Class Manages each Players Library which is a term used in Magic The Gathering for a players "Card Deck"
     * The Library extends to Stack DataStructure LIFO is the order of popping a magic card just as you would in a real library.
     */
    public class Library : Stack<MagicCard>
    {
        public string UserName { get; set; }

        public IEnumerable<MagicCard> Cards { get; }

        public Library(IEnumerable<MagicCard> _cards) : base(_cards)
        {
            this.Cards = _cards;
        }

        public MagicCard Draw()
        {
            return this.Pop();
        }
    }
}
