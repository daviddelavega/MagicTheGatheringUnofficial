﻿using MagicTheGathering.Cards;

namespace MagicTheGathering.Factories
{
    /*
     * Author: David DLVega
     * Date: May 13, 2023
     * Follows the Abstract Factory Design Pattern:
     * This class is the Concrete Factory portion of the design pattern.
     * This abstract class facilitates the creation of all Artifact Magic Card Objects without specifying the concrete type until run-time.
     * Also supports Single Responsibility principle.
     */
    class ArtifactCardFactory : MagicCardFactory
    {
        public override MagicCard CreateMagicCard()
        {
            return new ArtifactCard(CardType.Artifact);
        }
    }
}
