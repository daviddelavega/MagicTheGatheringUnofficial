using MagicTheGathering.Engine;

namespace MagicTheGathering.Phases
{
    /*
     * Author: David DLVega
     * Date: May 13, 2023
     * The main Phase class facilitates the current Players phase actions.
     */
    public class MainPhase : IPhase
    {
        private Planeswalker currentPlayer;

        public MainPhase(Planeswalker _activePlayer)
        {
            this.currentPlayer = _activePlayer;
        }

        public void Begin()
        {
            this.currentPlayer.DoMainPhaseActions();
        }
    }
}
