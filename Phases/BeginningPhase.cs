using MagicTheGathering.Engine;

namespace MagicTheGathering.Phases
{
    /*
     * Author: David DLVega
     * Date: May 13, 2023
     * The Single responsibility of the BeginningPhase class is to define the portion of the Turn called Beginning phase.
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
