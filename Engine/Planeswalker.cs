using System.Collections.Generic;
using MagicTheGathering.Cards;
using MagicTheGathering.Tabletop;
using MagicTheGathering.Zones;

namespace MagicTheGathering.Engine
{
    /*
     * Author: David DLVega
     * Date: May 13, 2023
     * This Interface is secluded to definining all the attributes of a Player i.e. Planeswalker
     */
    public interface Planeswalker
    {
        Battlefield Battlefield { get; set; }
        IEnumerable<MagicCard> Deck { get; set; }
        Graveyard Graveyard { get; set; }
        Hand Hand { get; set; }
        sbyte HitPoints { get; }
        Library Library { get; set; }
        int Wins { get; set; }
        string PlayerName { get; set; }

        void Cast(MagicCard card);
        void CreateLibrary();
        void Damage(CreatureCard card);
        void DoMainPhaseActions();
        void DrawCards(int number);
        void Reset();
        void Untap();
    }
}