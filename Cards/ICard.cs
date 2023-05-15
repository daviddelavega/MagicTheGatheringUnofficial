﻿namespace MagicTheGathering.Cards
{
     /*
      * Author: David DLVega
      * Date: May 13, 2023
      * Magic Card interface created to support the Liskov Substitution Principal throught the design
      * For example the Abstract Magic _Card Factory is utilizing this interface.
      */
    public interface ICard
    {
        ICard Build();    
        
        ICard WithName(string cardName);

        void ResolveSpecialAbilities();       

        void Display();
    }  
}
