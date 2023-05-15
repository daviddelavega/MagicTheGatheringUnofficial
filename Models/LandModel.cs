using Color = MagicTheGathering.Cards.Color;

namespace MagicTheGathering.Models
{
    /*
     * Author: David DLVega
     * Date: May 13, 2023
     */
    public class LandModel : CardModel
    {
        public string LandType { get; set; }
        public Color Color { get; set; }
    }
}
