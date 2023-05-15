using MagicTheGathering.Cards;

namespace MagicTheGathering.Factories
{
    /*
     * Author: David DLVega
     * Date: May 13, 2023
     */
    class EnchantmentCardFactory : MagicCardFactory
    {
        public override BaseMagicCard CreateMagicCard()
        {
            return new EnchantmentCard();
        }
    }
}
