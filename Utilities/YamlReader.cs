using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;
using MagicTheGathering.Models;

namespace MagicTheGathering.Utilities
{
    /*
     * Author: David DLVega
     * Date: May 13, 2023
     * The Single Responsibility of this class: A Yaml Reader to read Magic _Card Data, and return a Magic _Card
     */
    public static class YamlReader
    {
        private static string CreatureFilePath = "creatureCardData.yml";
        private static string BasicLandCardFilePath = "landCardData.yml";
        private static string SorceryCardFilePath = "sorceryCardData.yml";
        private static string InstantCardFilePath = "instantCardData.yml";
        private static string ArtifactCardFilePath = "artifactCardData.yml";
        private static IDeserializer Deserializer;

        static YamlReader()
        {
            Deserializer =
                new DeserializerBuilder()
                .WithNamingConvention(CamelCaseNamingConvention.Instance)
                .Build();
        }

        public static List<CreatureCardModel> ReadCreatureCardData()
        {
            using (var reader = new StreamReader(CreatureFilePath))
            {
                return Deserializer.Deserialize<List<CreatureCardModel>>(reader);                         
            }             
        }

        public static List<LandModel> ReadBasicLandCardData()
        {            
            using (var reader = new StreamReader(BasicLandCardFilePath))
            {
                return Deserializer.Deserialize<List<LandModel>>(reader);               
            }
        }

        public static List<SorceryCardModel> ReadSorceryCardData()
        {
            using (var reader = new StreamReader(SorceryCardFilePath))
            {
                return Deserializer.Deserialize<List<SorceryCardModel>>(reader);               
            }
        }

        public static List<ArtifactCardModel> ReadArtifactCardData()
        {
            using (var reader = new StreamReader(ArtifactCardFilePath))
            {
                return Deserializer.Deserialize<List<ArtifactCardModel>>(reader);                
            }
        }

        public static List<InstantCardModel> ReadInstantCardData()
        {
            using (var reader = new StreamReader(InstantCardFilePath))
            {
                return Deserializer.Deserialize<List<InstantCardModel>>(reader);               
            }
        }

        public static List<PlayerModel> ReadPlayerData(string yamlFilePath)
        {
            using (var reader = new StreamReader(yamlFilePath))
            {
                return Deserializer.Deserialize<List<PlayerModel>>(reader);               
            }
        }
    }
}
