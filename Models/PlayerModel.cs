namespace MagicTheGathering.Models
{
    /*
    * Author: David DLVega
    * Date: May 13, 2023
    * Single Responsibility: Plain Ole' C# Obect (Poco) to facilitate the objectification of the yaml Player Library Card data 
    */
    public class PlayerModel
    {
        public string UserName { get; set; }
        public List<LibraryCardModel> Library { get; set; }
    }
}
