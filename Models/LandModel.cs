using MagicTheGathering.Cards;

namespace MagicTheGathering.Models
{
    /*
    * Author: David DLVega
    * Date: May 13, 2023
    * Single Responsibility: Plain Ole' C# Obect (Poco) to facilitate the objectification of the yaml Land Card data 
    */
    public class LandModel : CardModel
    {
        public string LandType { get; set; }
        public Mana Color { get; set; }
    }
}
