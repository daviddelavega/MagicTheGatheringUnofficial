using System.Collections.Generic;

namespace MagicTheGathering.Cards
{
    /*
     * Author: David DLVega
     * Date: May 13, 2023 
     * The Single Responsibility of the Magic Card Type class is
     * To store all the common attributes of a standard Magic card into one object
     * This design supports the inheritance design pattern.
     * that child classes don't have to duplicate code
     * This class also supports the Open/Close principle in SOLID.
     * The class is open to extend, but closed to changes.
     */
    public abstract class BaseMagicCard : MagicCard
    {
        //a debug flag to display library card data. false = library card data will not be displayed.
        public bool ShowLibrary = false;
        /* 
         * common attributes found in Standard Magic Cards
         * Along with compiler generated getter and setter methods.
         */
        public bool Tapped { get; private set; } = false;
        public string Name { get; set; }
        public Dictionary<Mana, byte> ManaCost { get; set; }
        public CardType CardType { get; set; }
        private protected Dictionary<CardText, string> CardText { get; set; }
        private protected string Edition { get; set; }
        private protected uint CollectorNumber { get; set; }
        private protected CardRarity CardRarity { get; set; }
        private protected string ArtistInfo { get; set; }

        public void Untap()
        {
            this.Tapped = false;
        }

        public void Tap()
        {
            this.Tapped = true;
        }

        public void Attack()
        {           
            this.Tapped = true;
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
        public BaseMagicCard SetName(string _name) 
        {
            this.Name = _name;
            return this;
        }

        public BaseMagicCard SetManaCost(Dictionary<Mana, byte> _manaCost)
        {
            this.ManaCost = _manaCost;
            return this;
        }

        public BaseMagicCard SetCardType(CardType _cardType)
        {
            this.CardType = _cardType;
            return this;
        }

        public BaseMagicCard SetCardText(Dictionary<CardText, string> _cardText)
        {
            this.CardText = _cardText;
            return this;
        }

        public BaseMagicCard SetExpansionSymbol(string _edition)
        {
            this.Edition = _edition; 
            return this;    
        }

        public BaseMagicCard SetCollectorNumber(uint _collectorNumber)
        {
            this.CollectorNumber = _collectorNumber; 
            return this;
        }

        public BaseMagicCard SetCardRarity(CardRarity _cardRarity)
        {
            this.CardRarity = _cardRarity;
            return this;
        }

        public BaseMagicCard SetArtistInfo(string _artistInfo)
        {
            this.ArtistInfo = _artistInfo;
            return this;
        }

        public abstract MagicCard Build();

        public abstract void Display();

        public MagicCard WithName(string cardName)
        {
            this.Name = cardName;
            return this;
        }

        public abstract void ResolveSpecialAbilities();
    }
}
