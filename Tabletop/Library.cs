using MagicTheGathering.Cards;
using System.Collections.Generic;

namespace MagicTheGathering.Tabletop
{
    /*
     * Author: David DLVega
     * Date: May 13, 2023
     */
    public class Library : Stack<BaseMagicCard>
    {
        public string UserName { get; set; }

        public IEnumerable<BaseMagicCard> Cards { get; }

        public Library(IEnumerable<BaseMagicCard> _cards) : base(_cards)
        {
            this.Cards = _cards;
        }

        public BaseMagicCard Draw()
        {
            return this.Pop();
        }
    }
}
