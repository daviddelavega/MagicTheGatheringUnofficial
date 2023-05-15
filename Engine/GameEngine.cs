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
     */
    public class GameEngine : Planeswalker
    {
        public Battlefield Battlefield { get; set; } = new Battlefield();
        public IEnumerable<MagicCard> Deck { get; set; }
        public Library Library { get; set; }
        public Hand Hand { get; set; }
        public Graveyard Graveyard { get; set; }
        private Random random = new Random();
        public sbyte HitPoints { get; private set; } = 20;
        private bool hasPlayedLand = false;
        public string Name { get; set; }
        public int Wins { get; set; }

        public GameEngine(IEnumerable<MagicCard> deck, string Name)
        {
            Deck = deck;
            this.Name = Name;
            Reset();
        }

        public void CreateLibrary()
        {
            Library = new Library(
                Deck.OrderBy(item => random.Next()));
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
            Console.WriteLine($"Planeswalker {GameState.GetInstance.PlayerOne().Name}'s CreatureCard:\n");
            card.Display();
            Console.WriteLine($"afflicted DAMAGE of {card.Power} to Planeswalker {Name}.");
            Console.Write("Current GameState:\n");
            Console.WriteLine($"Planeswalker {GameState.GetInstance.PlayerOne().Name} Current HitPoints: {GameState.GetInstance.PlayerOne().HitPoints} " +
                $"\nPlaneswalker {GameState.GetInstance.PlayerTwo().Name} Current HitPoints: {GameState.GetInstance.PlayerTwo().HitPoints}");
            Console.WriteLine("Press enter to continue the battle...");
            Console.ReadLine();
        }

        private void PlaySpell(Collection<MagicCard> playableCards)
        {
            var rand = random.Next(playableCards.Count);

            if (playableCards[rand].CardType == CardType.Creature)
            {
                Battlefield.Play(Hand.Play(playableCards[rand]));
            }
            else
            {
                Cast(Hand.Play(playableCards[rand]));
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
            return !hasPlayedLand
                && Hand.Any(card => card.CardType == CardType.Land);
        }

        private void PlayLand()
        {
            var landToPlay = Hand.First(card => card.CardType == CardType.Land);
            Battlefield.PlayLand(Hand.Play(landToPlay));
        }

        public void DrawCards(int number)
        {
            for (var i = 1; i <= number; i++)
            {
                Hand.AddCard(Library.Draw());
            }
        }
    }
}
