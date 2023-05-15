using MagicTheGathering.Cards;
using MagicTheGathering.Engine;
using System.Linq;

namespace MagicTheGathering.Phases
{
    /*
     * Author: David DLVega
     * Date: May 13, 2023
     */
    public class CombatPhase : IPhase
    {
        private Planeswalker ActivePlayer;

        public CombatPhase(Planeswalker _activePlayer)
        {
            this.ActivePlayer = _activePlayer;
        }

        public void Begin()
        {
            var creatures = this.ActivePlayer.Battlefield.Cards
                .Where(
                    card => card.CardType == CardType.Creature
                    && !card.Tapped
                );

            foreach (var creature in creatures ?? Enumerable.Empty<BaseMagicCard>())
            {
                var creatureCard = creature as CreatureCard;
                creature.Attack();
                GameState.GetInstance.PlayerTwo().Damage(creatureCard);
            }
        }
    }
}
