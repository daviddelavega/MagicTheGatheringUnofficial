using System.Collections.Generic;

namespace MagicTheGathering.Models
{
    /*
     * Author: David DLVega
     * Date: May 13, 2023
     */
    public class PlayerModel
    {
        public string UserName { get; set; }
        public List<LibraryCardModel> Library { get; set; }
    }
}
