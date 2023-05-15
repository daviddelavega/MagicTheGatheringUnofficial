using MagicTheGathering.Cards;
using MagicTheGathering.Models;
using MagicTheGathering.Tabletop;
using MagicTheGathering.Utilities;

namespace MagicTheGathering.Factories
{
    /*
     * Author: David DLVega
     * Date: May 13, 2023
     * The Single Responsibility of the Library builder is to
     * fully build and shuffle each Player's Magic The Gathering Library by working with the proper Concrete factory.
     */
    public class LibraryBuilder
    {
        private List<PlayerModel> Players;

        public LibraryBuilder WithLibraryData(string librariesFile)
        {
            this.Players = YamlReader.ReadPlayerData(librariesFile);        
            
            return this;
        }

        public List<Library> Build()
        {
            MagicCardFactory magicCardFactory = null;
            List<Library> libraries = new();

            foreach (var playerModel in this.Players) 
            {
                List<MagicCard> magicCards = new();                

                foreach (var libraryCardModel in playerModel.Library)
                {
                    switch(libraryCardModel.CardType) 
                    {
                        case (CardType.Creature):                            
                            magicCardFactory = new CreatureCardFactory();
                            break;
                        case (CardType.Land):
                            magicCardFactory = new LandCardFactory();
                            break;
                        case (CardType.Sorcery):
                            magicCardFactory = new SorceryCardFactory();
                            break;
                        case (CardType.Enchantment):
                            magicCardFactory = new EnchantmentCardFactory();
                            break;
                        case (CardType.Instant):
                            magicCardFactory = new InstantCardFactory();
                            break;
                        case (CardType.Artifact):
                            magicCardFactory = new ArtifactCardFactory();
                            break;
                        case (CardType.Planeswalker):
                            magicCardFactory = new PlaneswalkerCardFactory();
                            break;
                        default:
                            throw new ArgumentNullException($"No such CardType:{libraryCardModel.CardType}");                           
                    }
                    
                    foreach (KeyValuePair<string, byte> kvp in libraryCardModel.Cards)
                    {
                        string cardName = kvp.Key;
                        byte cardCount = kvp.Value;

                        for(byte i = 0; i < cardCount; i++)
                        {
                            var card = magicCardFactory.CreateMagicCard();
                            card
                                .WithName(cardName)
                                .Build();
                           
                            magicCards.Add(card);
                        }                        
                    }                                        
                }

                //shuffle the library
                Library library = new(magicCards.OrderBy(card => new Random().Next()));

                //set userName on the library
                library.UserName = playerModel.UserName;

                //Add the library to the list of libraries.
                libraries.Add(library);
            }

            //print a message about each library            
            Console.WriteLine($"\nMagic The Gathering Libraries Have been Shuffled and are Ready for Action!");
            libraries.ForEach(library => 
                Console.WriteLine($"Planeswalker: {library.UserName}'s Library has {library.Count} Magic The Gathering Cards")
            );
            Console.WriteLine($"\nLet the Battle Begin!\n");

            return libraries;
        }
    }
}
