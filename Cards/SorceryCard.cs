using MagicTheGathering.Models;
using MagicTheGathering.Utilities;
using System;
using System.Collections.Generic;

namespace MagicTheGathering.Cards
{
    /*
     * Author: David DLVega
     * Date: May 13, 2023
     */
    public class SorceryCard : BaseMagicCard
    {
        public override MagicCard Build()
        {
            this.CardType = CardType.Sorcery;
            var sorceryModels = CardStore.Instance.getSorceryModels();
            SorceryCardModel sorceryModel = sorceryModels.Find(item => item.Name == this.Name);

            this
            .SetName(sorceryModel.Name)
            .SetManaCost(sorceryModel.ManaCost)
            .SetCardText(sorceryModel.CardText)
            .SetExpansionSymbol(sorceryModel.Edition)
            .SetCollectorNumber(sorceryModel.CollectorNumber)
            .SetCardRarity(sorceryModel.CardRarity)
            .SetArtistInfo(sorceryModel.ArtistInfo);

            if (this.ShowLibrary)
            {
                Display();
            }

            return this;
        }

        public override void Display()
        {
            Console.Write($"SorceryCard:\n\tName: {this.Name}");
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
            if(this.ShowLibrary)
            {
                Console.WriteLine("Need to resolve special abilities for this card:");
                Display();
            }           
        }
    }
}
