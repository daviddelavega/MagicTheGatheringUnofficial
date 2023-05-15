using MagicTheGathering.Cards;

namespace MagicTheGathering.Models
{
    /*
     * Author: David DLVega
     * Date: May 13, 2023
     * Single Responsibility: Plain Ole' C# Obect (Poco) to facilitate the objectification of the yaml creature data 
     */
    public class CreatureCardModel : MagicCardModel
    {           
        public List<CreatureTypes> CreatureTypes { get; set; }
        public sbyte Power { get; set; }
        public byte Toughness { get; set; }
        public bool HasVariableToughness { get; set; } = false;
        public bool HasVariablePower { get; set; } = false;
    }
}
