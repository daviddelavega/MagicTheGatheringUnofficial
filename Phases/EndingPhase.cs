using MagicTheGathering.Engine;

namespace MagicTheGathering.Phases
{
    /*
     * Author: David DLVega
     * Date: May 13, 2023
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
