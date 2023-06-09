﻿using MagicTheGathering.Models;
using MagicTheGathering.Utilities;

namespace MagicTheGathering.Cards
{
    /*
     * Author: David DLVega
     * Date: May 13, 2023
     */
    public class InstantCard : MagicCard
    {
        public InstantCard(CardType _cardType) : base(_cardType) { }

        public override ICard Build()
        {
            InstantCardModel instantModel = (InstantCardModel)CardStore.Instance.getMagicCardModel(this.CardType, this.Name);

            this
            .SetName(instantModel.Name)
            .SetManaCost(instantModel.ManaCost)
            .SetCardText(instantModel.CardText)
            .SetExpansionSymbol(instantModel.Edition)
            .SetCollectorNumber(instantModel.CollectorNumber)
            .SetCardRarity(instantModel.CardRarity)
            .SetArtistInfo(instantModel.ArtistInfo);

            if (this.ShowLibrary)
            {
                Display();
            }

            return this;
        }

        public override void Display()
        {
            Console.Write($"InstantCard:\n\tName: {this.Name}");
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
