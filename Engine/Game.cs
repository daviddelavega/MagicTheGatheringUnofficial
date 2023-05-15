using System;
using System.Collections.Generic;

namespace MagicTheGathering.Engine
{
    /*
     * Author: David DLVega
     * Date: May 13, 2023
     */
    public class Game
    {
        private TurnOrder turnOrder;
        private Turn currentTurn;
        public bool gameIsOver = false;

        public Game(ICollection<Planeswalker> players)
        {
            turnOrder = new TurnOrder(players);
        }

        public void NextTurn()
        {
            var player = turnOrder.NextPlayer();
            currentTurn = new Turn(player);
        }

        public void StartTurn()
        {
            currentTurn.Begin();
            if (GameState.GetInstance.PlayerOne().HitPoints < 1)
            {
                gameIsOver = true;
                GameState.GetInstance.PlayerOne().Wins += 1;
                Console.WriteLine($"{GameState.GetInstance.PlayerOne().PlayerName} HitPoints: {GameState.GetInstance.PlayerOne().HitPoints}.");

            }
            else if (GameState.GetInstance.PlayerTwo().HitPoints < 1)
            {
                gameIsOver = true;
                GameState.GetInstance.PlayerTwo().Wins += 1;
                Console.WriteLine($"{GameState.GetInstance.PlayerOne().PlayerName} HitPoints: {GameState.GetInstance.PlayerTwo().HitPoints}.");

            }
        }
    }
}
