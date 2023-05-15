using System;
using MagicTheGathering.Zones;
using System.Collections.ObjectModel;
using System.Linq;
using MagicTheGathering.Cards;
using System.Collections.Generic;
using MagicTheGathering.Tabletop;

namespace MagicTheGathering.Engine
{
    /*
     * Author: David DLVega
     * Date: May 13, 2023
     * The Single Responsibility of the GameEngine class is to facilitate a Player's Game Actions
     */
    public class GameEngine : Planeswalker
    {
        public Battlefield Battlefield { get; set; } = new Battlefield();
        public IEnumerable<MagicCard> Deck { get; set; }
        public Library Library { get; set; }
        public Hand Hand { get; set; }
        public Graveyard Graveyard { get; set; }
        private Random Random = new Random();
        public sbyte HitPoints { get; private set; } = 20;
        private bool HasPlayedLand = false;
        public string PlayerName { get; set; }
        public int Wins { get; set; }

        public GameEngine(IEnumerable<MagicCard> deck, string Name)
        {
            Deck = deck;
            this.PlayerName = Name;           
        }

        public void CreateLibrary()
        {
            Library = new Library(
                Deck.OrderBy(item => Random.Next()));
        }

        public void Reset()
        {
            CreateLibrary();
            Hand = new Hand();
            Graveyard = new Graveyard();
            DrawCards(7);
            HitPoints = 20;
        }

        public void Untap()
        {
            Battlefield.Untap();
        }

        public void DoMainPhaseActions()
        {
            if (CanPlayLand())
            {
                PlayLand();
            }

            var playableSpells = PlayableSpells();
            while (playableSpells.Count > 0)
            {
                PlaySpell(playableSpells);
                playableSpells = PlayableSpells();
            }
        }

        public void Damage(CreatureCard card)
        {
            HitPoints -= card.Power;
            Console.WriteLine($"Planeswalker {GameState.GetInstance.PlayerOne().PlayerName}'s CreatureCard:\n");
            card.Display();
            Console.WriteLine($"afflicted DAMAGE of {card.Power} to Planeswalker {PlayerName}.");
            Console.Write("Current GameState:\n");
            Console.WriteLine($"Planeswalker {GameState.GetInstance.PlayerOne().PlayerName} Current HitPoints: {GameState.GetInstance.PlayerOne().HitPoints} " +
                $"\nPlaneswalker {GameState.GetInstance.PlayerTwo().PlayerName} Current HitPoints: {GameState.GetInstance.PlayerTwo().HitPoints}");
            Console.WriteLine("Press enter to continue the battle...");
            Console.ReadLine();
        }

        private void PlaySpell(Collection<MagicCard> playableCards)
        {
            var rand = Random.Next(playableCards.Count);
            MagicCard magicCard = playableCards[rand];

            if (magicCard.CardType == CardType.Creature)
            {                
                Battlefield.Play(Hand.Play(magicCard));
            }
            else
            {
                Cast(Hand.Play(magicCard));
            }

            Console.WriteLine($"{this.PlayerName} Tapped Card: {magicCard.Name}");
            Console.ReadLine();

            Console.WriteLine($"{this.PlayerName}'s Tapped Cards:");
            foreach (MagicCard _card in Battlefield.Cards)
            {
                Console.WriteLine($"{_card.Name}");
            }
        }

        public void Cast(MagicCard card)
        {
            card.ResolveSpecialAbilities();
        }

        private Collection<MagicCard> PlayableSpells()
        {
            Collection<MagicCard> cards = new Collection<MagicCard>();

            foreach (var card in Hand)
            {
                if (card.ManaCost == null)
                {
                    continue;
                }

                int sum = 0;
                foreach (byte value in card.ManaCost.Values)
                {
                    sum += value;
                }


                if (Battlefield.Cards
                    .Count(land => land.CardType == CardType.Land) >= sum)
                {
                    cards.Add(card);
                }
            }

            return cards;
        }

        private bool CanPlayLand()
        {
            return !HasPlayedLand
                && Hand.Any(card => card.CardType == CardType.Land);
        }

        private void PlayLand()
        {
            var landToPlay = Hand.First(card => card.CardType == CardType.Land);
            Battlefield.PlayLand(Hand.Play(landToPlay));

            Console.WriteLine($"{this.PlayerName} Tapped Land Card: {landToPlay.Name}");
            Console.ReadLine();

            Console.WriteLine($"{this.PlayerName}'s Tapped Cards:");
            foreach ( MagicCard card in Battlefield.Cards)
            {
                Console.WriteLine($"{card.Name}");
            }
        }

        public void DrawCards(int number)
        {
            Console.WriteLine($"{this.PlayerName} is Drawing {number} Card(s) from their library:");
            for (var i = 1; i <= number; i++)
            {
                Hand.AddCard(Library.Draw());
            }

            Console.WriteLine($"{this.PlayerName}'s Hand:");
            foreach (MagicCard card in Hand)
            {
                Console.WriteLine($"\t{card.Name}");
            }
        }
    }
}
