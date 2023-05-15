using MagicTheGathering.Engine;

namespace MagicTheGathering
{
    /* Author: David DLVega
     * Date: May 13, 2023
     * This class's single responsibility is to start the game.
     * It provides the location of the Player's library data File
     * to the GameManager Object and Starts the game.
     */
    class GameProgram
    {
        private static string LibraryDataFile = "libraries.yml";
        static void Main(string[] args)
        {            
            new GameManager().StartGame(LibraryDataFile);             
        }        
    }
}
