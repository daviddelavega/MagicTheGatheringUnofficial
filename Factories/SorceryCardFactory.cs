using MagicTheGathering.Cards;

namespace MagicTheGathering.Factories
{
    /*
     * Author: David DLVega
     * Date: May 13, 2023
     */
    class SorceryCardFactory : MagicCardFactory
    {
        public override MagicCard CreateMagicCard()
        {
            return new SorceryCard(CardType.Sorcery);
        }
    }
}
