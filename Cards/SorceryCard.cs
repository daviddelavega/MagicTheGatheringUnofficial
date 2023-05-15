using MagicTheGathering.Models;
using MagicTheGathering.Utilities;

namespace MagicTheGathering.Cards
{
    /*
     * Author: David DLVega
     * Date: May 13, 2023
     */
    public class SorceryCard : MagicCard
    {
        public SorceryCard(CardType _cardType) : base(_cardType) { }

        public override ICard Build()
        {           
            SorceryCardModel sorceryModel = (SorceryCardModel)CardStore.Instance.getMagicCardModel(this.CardType, this.Name);

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
