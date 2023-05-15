using MagicTheGathering.Engine;

namespace MagicTheGathering.Phases
{
    /*
     * Author: David DLVega
     * Date: May 13, 2023
     */
    public class BeginningPhase : IPhase
    {
        private Planeswalker ActivePlayer;

        public BeginningPhase(Planeswalker _activePlayer)
        {
            this.ActivePlayer = _activePlayer;
        }

        public void Begin()
        {
            this.ActivePlayer.Untap();
            this.ActivePlayer.DrawCards(1);
        }
    }
}
