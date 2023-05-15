using MagicTheGathering.Cards;
using MagicTheGathering.Models;

namespace MagicTheGathering.Utilities
{
    /*
     * Author: David DLVega
     * Date: May 13, 2023
     * The Single Responsibility of the CardStore class is to
     * Manage All Magic Card Models and return the requested Model Type to the caller
     */
    public sealed class CardStore
    {
        private static CardStore? _instance;
        private List<CreatureCardModel> CreatureCardModels;
        private List<LandModel> BasicLandCardModels;
        private List<SorceryCardModel> SorceryCardModels;
        private List<InstantCardModel> InstantCardModels;
        private List<ArtifactCardModel> ArtifactCardModels;

        private CardStore()
        {
            CreatureCardModels = YamlReader.ReadCreatureCardData();
            BasicLandCardModels = YamlReader.ReadBasicLandCardData();
            SorceryCardModels = YamlReader.ReadSorceryCardData();
            InstantCardModels = YamlReader.ReadInstantCardData();
            ArtifactCardModels = YamlReader.ReadArtifactCardData();
        }

        public static CardStore Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CardStore();
                }
                return _instance;
            }
        }

        public CardModel getMagicCardModel(CardType cardType, string cardName)
        {
            CardModel? cardModel = null;

            switch(cardType)
            {
                case CardType.Creature:
                    cardModel = CreatureCardModels.Find(item => item.Name == cardName);
                    break;
                case CardType.Land:
                    cardModel = BasicLandCardModels.Find(item => item.Name == cardName);
                    break;
                case CardType.Sorcery:
                    cardModel = SorceryCardModels.Find(item => item.Name == cardName);
                    break;
                case CardType.Instant:
                    cardModel = InstantCardModels.Find(item => item.Name == cardName);
                    break;
                case CardType.Artifact:
                    cardModel = ArtifactCardModels.Find(item => item.Name == cardName);
                    break;
                default:
                    throw new ArgumentNullException($"No such CardType:{cardType}");
            }

            return cardModel;
        }

        public List<LandModel> getBasicLandModels()
        {
            return BasicLandCardModels;
        }

        public List<SorceryCardModel> getSorceryModels()
        {
            return SorceryCardModels;
        }

        public List<InstantCardModel> getInstantModels()
        {
            return InstantCardModels;
        }

        public List<ArtifactCardModel> getArtifactModels()
        {
            return ArtifactCardModels;
        }
    }
}
