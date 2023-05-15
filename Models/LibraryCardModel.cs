using MagicTheGathering.Cards;
using System.Collections.Generic;

namespace MagicTheGathering.Models
{
    /*
     * Author: David DLVega
     * Date: May 13, 2023
     */
    public class LibraryCardModel
    {
        public CardType CardType { get; set; }

        public Dictionary<string, byte> Cards { get; set; }


    }
}