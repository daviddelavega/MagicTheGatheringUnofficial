using System.Collections.Generic;
using MagicTheGathering.Cards;
using MagicTheGathering.Tabletop;
using MagicTheGathering.Zones;

namespace MagicTheGathering.Engine
{
    /*
     * Author: David DLVega
     * Date: May 13, 2023
     */
    public interface Planeswalker
    {
        Battlefield Battlefield { get; set; }
        IEnumerable<BaseMagicCard> Deck { get; set; }
        Graveyard Graveyard { get; set; }
        Hand Hand { get; set; }
        sbyte HitPoints { get; }
        Library Library { get; set; }
        int Wins { get; set; }
        string Name { get; set; }

        void Cast(BaseMagicCard card);
        void CreateLibrary();
        void Damage(CreatureCard card);
        void DoMainPhaseActions();
        void DrawCards(int number);
        void Reset();
        void Untap();
    }
}