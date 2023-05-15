using MagicTheGathering.Models;
using System;
using System.Collections.Generic;
using MagicTheGathering.Utilities;

namespace MagicTheGathering.Cards
{
    /* 
    * Author: David DLVega
    * Date: May 13, 2023
    * The Single Responsibility of this Class is to Build a Magic Artifact Card Object:
    * The ArtifactCard class can represent any Magic Card that is of Type Artifact. 
    * All Artifact Card attributes come from the Parent MagicCard class.
    */
    public class ArtifactCard : MagicCard
    {
        public ArtifactCard(CardType _cardType) : base(_cardType) { }

        public override ICard Build()
        {         
            ArtifactCardModel artifactModel = (ArtifactCardModel)CardStore.Instance.getMagicCardModel(this.CardType, this.Name);

            this            
            .SetName(artifactModel.Name)
            .SetManaCost(artifactModel.ManaCost)
            .SetCardText(artifactModel.CardText)
            .SetExpansionSymbol(artifactModel.Edition)
            .SetCollectorNumber(artifactModel.CollectorNumber)
            .SetCardRarity(artifactModel.CardRarity)
            .SetArtistInfo(artifactModel.ArtistInfo);

            if (this.ShowLibrary)
            {
                Display();
            }

            return this;
        }

        public override void Display()
        {
            Console.Write($"ArtifactCard:\n\tName: {this.Name}");
            Console.Write($"\n\tManaCost: ");
            foreach (KeyValuePair<Mana, byte> manaCost in this.ManaCost)
            {
                Console.Write($"{manaCost.Key.ToString()}:");
                Console.Write($"{manaCost.Value.ToString()} ");
            }

            Console.Write($"\n\tCardText:\n");
            foreach (KeyValuePair<CardText, string> cardText in this.CardText)
            {
                Console.Write($"\t{cardText.Key.ToString()}: ");
                Console.Write($"{cardText.Value.ToString()}\n");
            }
            Console.WriteLine($"\n\tEdition: {this.Edition}" +
                $"\n\tCollectorNumber: {this.CollectorNumber} " +
                $"\n\tCardRarity: {this.CardRarity}" +
                $"\n\tArtistInfo: {this.ArtistInfo} ...");
        }

        public override void ResolveSpecialAbilities()
        {
            if (this.ShowLibrary)
            {
                Console.WriteLine("Need to resolve special abilities for this card:");
                Display();
            }
        }
    }
}
