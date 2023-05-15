using MagicTheGathering.Cards;
using System.Collections.Generic;

namespace MagicTheGathering.Tabletop
{
    /*
     * Author: David DLVega
     * Date: May 13, 2023
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
