using MagicTheGathering.Models;
using MagicTheGathering.Utilities;
using System;
using System.Collections.Generic;

namespace MagicTheGathering.Cards
{
    /* Author: David DLVega
     * Date: May 13, 2023
     * The Single Responsibility of this Class is to Build a Magic Creature Card Object:
     * The CreatureCard class can represent characters, creatures, monsters or any 
     * Magic _Card that is of Type Creature. Creature Magic Cards have Power, Toughness values.
     * Creatures can attack, block, and posses various abilities( abilites are stored in the _Card Text).
     */
    public class CreatureCard : MagicCard, Tappable, Attacks, Blocks
    {
        private protected List<CreatureTypes> CreatureTypes { get; set; }

        public sbyte Power { get; set; }

        private protected byte Toughness { get; set; }

        private protected bool HasVariableToughness { get; set; } = false;

        private protected bool HasVariablePower { get; set; } = false;

        public CreatureCard(CardType _cardType) : base(_cardType)
        {           
        }      

        public void Block()
        {
            throw new NotImplementedException();
        }        

        /*
        * The set methods below Facilitate the Fluent Design Pattern for callers of this class.
        * One of the many reasons I chose to use the Fluent Design pattern here is so that my Abstract Magic _Card Factory 
        * can chain the methods together to create the _Card object. Also I decided to go with the fluent design, 
        * rather than other alternative designs such as having a constructor with many parameters.
        * Added benefits: These set methods also allow me to add protective code when making assignments if and when needed.
        * Also please note the method parameters start with an underscore, I did this as a simple way to prevent a group of bugs
        * where I might set the class variable to itself, Also a fun note: my MTGA userName is Underscore :)
        */       
        public CreatureCard SetCreatureTypes(List<CreatureTypes> _creatureTypes)
        {
            this.CreatureTypes = _creatureTypes; 
            return this;
        }

        public CreatureCard SetPower(sbyte _power)
        {
            this.Power = _power; 
            return this;   
        }

        public CreatureCard SetToughness(byte _toughness)
        {
            this.Toughness = _toughness;
            return this;
        }

        public CreatureCard SetHasVariableToughness(bool _hasVariableToughness)
        {
            this.HasVariableToughness = _hasVariableToughness;
            return this;
        }

        public CreatureCard SetHasVariablePower(bool _hasVariablePower)
        {
            this.HasVariablePower = _hasVariablePower;
            return this;
        }

        public override CreatureCard Build()
        {           
            CreatureCardModel creatureModel = (CreatureCardModel)CardStore.Instance.getMagicCardModel(this.CardType, this.Name);                     

            this            
            .SetCreatureTypes(creatureModel.CreatureTypes)
            .SetPower(creatureModel.Power)
            .SetToughness(creatureModel.Toughness)
            .SetHasVariableToughness(creatureModel.HasVariableToughness)
            .SetHasVariablePower(creatureModel.HasVariablePower)
            .SetManaCost(creatureModel.ManaCost)
            .SetName(creatureModel.Name)
            .SetCardText(creatureModel.CardText)
            .SetExpansionSymbol(creatureModel.Edition)
            .SetCollectorNumber(creatureModel.CollectorNumber)
            .SetCardRarity(creatureModel.CardRarity)
            .SetArtistInfo(creatureModel.ArtistInfo);

            if (this.ShowLibrary)
            {
                Display();
            }

            return this;
        }

        public override void Display()
        {       
            Console.Write($"CreatureCard:\n\tName: {this.Name}");
            Console.Write($"\n\tManaCost: ");
            foreach (KeyValuePair<Mana, byte> manaCost in this.ManaCost) 
            {
                Console.Write($"{manaCost.Key.ToString()}:");
                Console.Write($"{manaCost.Value.ToString()} ");
            }
            Console.Write($"\n\tCreatureType(s): ");
            this.CreatureTypes.ForEach(type => Console.Write($"{type} "));
            Console.Write($"\n\tCardText:\n");
            foreach (KeyValuePair<CardText, string> cardText in this.CardText)
            {
                Console.Write($"\t{cardText.Key.ToString()}: ");
                Console.Write($"{cardText.Value.ToString()}\n");
            }
            Console.Write($"\tPower\\Toughness: {this.Power}\\{this.Toughness}" +
                $"\n\tEdition: {this.Edition}" +
                $"\n\tHasVariableToughness: {this.HasVariableToughness}" +
                $"\n\tHasVariablePower: {this.HasVariablePower}" +
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
