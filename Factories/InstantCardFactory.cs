using MagicTheGathering.Cards;

namespace MagicTheGathering.Factories
{
    /*
     * Author: David DLVega
     * Date: May 13, 2023
     */
    class InstantCardFactory : MagicCardFactory
    {
        public override MagicCard CreateMagicCard()
        {
            return new InstantCard(CardType.Instant);
        }
    }
}
