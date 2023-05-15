using MagicTheGathering.Cards;


namespace MagicTheGathering.Factories
{
    /*
     * Author: David DLVega
     * Date: May 13, 2023
     */
    class PlaneswalkerCardFactory : MagicCardFactory
    {
        public override MagicCard CreateMagicCard()
        {
            return new PlaneswalkerCard(CardType.Planeswalker);
        }
    }
}
