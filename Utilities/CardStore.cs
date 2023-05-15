using MagicTheGathering.Models;
using System.Collections.Generic;

namespace MagicTheGathering.Utilities
{
    /*
     * Author: David DLVega
     * Date: May 13, 2023
     */
    public class CardStore
    {
        private static CardStore _instance;
        private List<CreatureModel> CreatureModels;
        private List<LandModel> BasicLandModels;
        private List<SorceryCardModel> SorceryCardModels;
        private List<InstantCardModel> InstantCardModels;
        private List<ArtifactCardModel> ArtifactCardModels;

        private CardStore()
        {
            CreatureModels = YamlReader.ReadCreatureCardData();
            BasicLandModels = YamlReader.ReadBasicLandCardData();
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

        public List<CreatureModel> getCreatureModels()
        {
            return CreatureModels;
        }

        public List<LandModel> getBasicLandModels()
        {
            return BasicLandModels;
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
