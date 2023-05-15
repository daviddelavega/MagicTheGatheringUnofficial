using MagicTheGathering.Models;
using MagicTheGathering.Utilities;
using System;

namespace MagicTheGathering.Cards
{
    /*
     * Author: David DLVega
     * Date: May 13, 2023
     */
    public class LandCard : MagicCard
    {       
        private protected string LandType { get; set; }

        private protected Color Color { get; set; }

        public LandCard(CardType cardType) : base(cardType) { }

        public override ICard Build()
        {
            LandModel basicLandModel = (LandModel)CardStore.Instance.getMagicCardModel(this.CardType, this.Name);

            this
            .SetBasicLandType(basicLandModel.LandType)
            .SetColor(basicLandModel.Color)
            .SetName(basicLandModel.Name);

            if (this.ShowLibrary)
            {
                Display();
            }

            return this;
        }

        public LandCard SetBasicLandType(string _basicLandType)
        {
            this.LandType = _basicLandType;
            return this;
        }

        public LandCard SetColor(Color _color)
        {
            this.Color = _color;
            return this;
        }

        public override void Display()
        {
            Console.WriteLine($"LandCard: {this.Name}");
            Console.WriteLine($"\tLandType: {this.LandType}");
            Console.WriteLine($"\tColor: {this.Color.ToString()}");      
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
