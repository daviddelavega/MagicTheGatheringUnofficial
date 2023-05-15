using MagicTheGathering.Engine;

namespace MagicTheGathering.Phases
{
    /*
     * Author: David DLVega
     * Date: May 13, 2023
     * The Single responsibility of the EndingPhase class is to define the portion of the Turn called Ending phase
     * It facilitates the hand size rule of no more than 7 and discards extras at this phase
     */
    public class EndingPhase : IPhase
    {
        private Planeswalker ActivePlayer;

        public EndingPhase(Planeswalker _activePlayer)
        {
            this.ActivePlayer = _activePlayer;
        }

        public void Begin()
        {
            if ( this.ActivePlayer.Hand.Count > 7 )
            {
                var discard = this.ActivePlayer.Hand.Discard();
                this.ActivePlayer.Graveyard.Add(discard);                               
            }
        }
    }
}
