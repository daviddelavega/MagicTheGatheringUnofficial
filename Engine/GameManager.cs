using System.Collections.ObjectModel;
using MagicTheGathering.Factories;
using MagicTheGathering.Tabletop;
using MagicTheGathering.Utilities;

namespace MagicTheGathering.Engine
{
    /*
     * Author: David DLVega
     * Date: May 13, 2023
     * The single responsibility of the GameManager class is to coordinate the Game's progress from start thru each player's turn.
     */
    public class GameManager
    {
        private Game currentGame;
        private ICollection<Planeswalker> players = new Collection<Planeswalker>();
        private string LibraryDataFile;

        public GameManager(string _libraryDataFile)
        {
            this.LibraryDataFile = _libraryDataFile;
        }

        public void StartGame()
        {
            ASCIIArt.DisplayStartGameMessage();
            do
            {
                List<Library> libraries =
                    new LibraryBuilder()
                    .WithLibraryData(this.LibraryDataFile)
                    .Build();

                Console.WriteLine($"{libraries[0].UserName} Versus {libraries[1].UserName}\n");

                players.Add(new GameEngine(libraries[0].Cards, libraries[0].UserName));
                players.Add(new GameEngine(libraries[1].Cards, libraries[1].UserName));

                foreach (var player in players)
                {
                    player.Reset();
                }

                GameState.GetInstance.AddPlayers(players);

                currentGame = new Game(players);

                while (!currentGame.gameIsOver)
                {
                    MoveToNextTurn();
                    BeginTurn();
                }
            } while (!MatchIsOver());

            var winningPlayer = players.First(player => player.HitPoints > 0);

            Console.ReadLine();
        }

        private bool MatchIsOver()
        {
            return players.Any(player => player.Wins > 1);
        }

        private void MoveToNextTurn()
        {
            currentGame.NextTurn();
        }

        private void BeginTurn()
        {
            currentGame.StartTurn();
        }
    }
}
