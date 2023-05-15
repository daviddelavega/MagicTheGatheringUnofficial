namespace MagicTheGathering.Engine
{
    /*
     * Author: David DLVega
     * Date: May 13, 2023
     * The single responsibility of the TurnOrder class is to coordinate the the Game's Turn Order for each player.
     */
    public class TurnOrder
    {
        private IList<Planeswalker> PlayerOrder;
        private int ListCounter = 0;

        public TurnOrder(IEnumerable<Planeswalker> players)
        {
            PlayerOrder = players.ToList();
        }

        public Planeswalker NextPlayer()
        {
            var player = PlayerOrder[ListCounter];
            ListCounter = ListCounter >= PlayerOrder.Count - 1
                ? 0
                : ListCounter + 1;

            return player;
        }
    }
}
