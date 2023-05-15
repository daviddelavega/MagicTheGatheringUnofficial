using MagicTheGathering.Cards;
using System.Collections.Generic;

namespace MagicTheGathering.Models
{
    /*
     * Author: David DLVega
     * Date: May 13, 2023 
     * Single Responsibility: Plain Ole' C# Obect (Poco) to facilitate the objectification of the yaml common Magic _Card attributes data 
     * Promotes Inheritance pillar, which supports code re-use and eliminates code duplication.
     */
    public class BaseMagicCardModel : CardModel
    {       
        public Dictionary<Mana, byte> ManaCost { get; set; }
        public Dictionary<CardText, string> CardText { get; set; }
        public string Edition { get; set; }
        public uint CollectorNumber { get; set; }
        public CardRarity CardRarity { get; set; }
        public string ArtistInfo { get; set; }
    }
}
