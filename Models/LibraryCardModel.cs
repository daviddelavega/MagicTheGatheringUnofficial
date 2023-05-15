using MagicTheGathering.Cards;

namespace MagicTheGathering.Models
{
    /*
    * Author: David DLVega
    * Date: May 13, 2023
    * Single Responsibility: Plain Ole' C# Obect (Poco) to facilitate the objectification of the yaml Library Card data 
    */
    public class LibraryCardModel
    {
        public CardType CardType { get; set; }

        public Dictionary<string, byte> Cards { get; set; }


    }
}