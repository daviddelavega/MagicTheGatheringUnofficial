using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace MagicTheGathering.Engine
{
    /*
     * Author: David DLVega
     * Date: May 13, 2023
     */
    public class GameState
    {
        private IEnumerable<Planeswalker> players;
        public Planeswalker CurrentPlayer { private get; set; }
        private static GameState state;

        public static GameState GetInstance
        {
            get
            {
                if (state == null)
                {
                    state = new GameState();
                }
                return state;
            }
        }

        private GameState()
        {
        }

        public void ResetState()
        {
            state = null;
        }

        public void AddPlayers(ICollection<Planeswalker> players)
        {
            this.players = players;
        }

        public Planeswalker PlayerTwo()
        {
            return players.First(player => player != CurrentPlayer);
        }

        public Planeswalker PlayerOne()
        {
            return CurrentPlayer;
        }
    }
}
