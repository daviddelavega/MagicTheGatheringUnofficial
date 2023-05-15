using MagicTheGathering.Phases;
using MagicTheGathering.Utilities;
using System;
using System.Collections.Generic;

namespace MagicTheGathering.Engine
{
    /*
     * Author: David DLVega
     * Date: May 13, 2023
     */
    public class Turn
    {
        private Planeswalker Player;
        private IList<IPhase> Phases = new List<IPhase>();
        private IPhase CurrentPhase;
        private bool TurnEnded = false;

        public Turn(Planeswalker player)
        {
            Player = player;

            GameState.GetInstance.CurrentPlayer = Player;

            Phases.Add(new BeginningPhase(Player));
            Phases.Add(new MainPhase(Player));
            Phases.Add(new CombatPhase(Player));
            Phases.Add(new MainPhase(Player));
            Phases.Add(new EndingPhase(Player));

            CurrentPhase = Phases[0];
        }

        public void Begin()
        {
            CurrentPhase.Begin();
            NextPhase();
            if (TurnEnded)
            {
                return;
            }
            else
            {
                Begin();
            }
        }

        public void NextPhase()
        {
            var currentPhaseNum = Phases.IndexOf(CurrentPhase);

            if (currentPhaseNum == Phases.Count - 1)
            {
                TurnEnded = true;
                if (GameState.GetInstance.PlayerOne().HitPoints < 1 || GameState.GetInstance.PlayerTwo().HitPoints < 1)
                {
                    Console.WriteLine("\nUnofficial Magic The Gathering Simulated Game Results:");

                    Console.WriteLine($"Planeswalker {GameState.GetInstance.PlayerOne().PlayerName}'s HitPoints: {GameState.GetInstance.PlayerOne().HitPoints}.");

                    Console.WriteLine($"Planeswalker {GameState.GetInstance.PlayerTwo().PlayerName}'s HitPoints: {GameState.GetInstance.PlayerTwo().HitPoints}.");

                    var winner = GameState.GetInstance.PlayerOne().HitPoints > GameState.GetInstance.PlayerTwo().HitPoints ? GameState.GetInstance.PlayerOne().PlayerName : GameState.GetInstance.PlayerTwo().PlayerName;

                    ASCIIArt.DisplayEndGameMessage();
                    Console.WriteLine($"The Winner is Planeswalker {winner} ");
                    Console.WriteLine("Thank you for playing David DLVega's Unofficial Magic The Gathering Simulated Game Engine.");

                    ASCIIArt.DisplayThanks();
                    Environment.Exit(0);
                }
            }
            else
            {
                CurrentPhase = Phases[currentPhaseNum + 1];
            }
        }
    }
}
