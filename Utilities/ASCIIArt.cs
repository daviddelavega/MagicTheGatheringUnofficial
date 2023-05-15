﻿using System;

namespace MagicTheGathering.Utilities
{
    /*
     * Author: David DLVega
     * Date: May 13, 2023
     */
    public class ASCIIArt
    {
        public static void DisplayStartGameMessage()
        {
            string[] dotMatrix = new string[]
            {                                                                                                                                                                        
  
               "███    ███  █████   ██████  ██  ██████     ████████ ██   ██ ███████      ██████   █████  ████████ ██   ██ ███████ ██████  ██ ███    ██  ██████  ",
               "████  ████ ██   ██ ██       ██ ██             ██    ██   ██ ██          ██       ██   ██    ██    ██   ██ ██      ██   ██ ██ ████   ██ ██       ",
               "██ ████ ██ ███████ ██   ███ ██ ██             ██    ███████ █████       ██   ███ ███████    ██    ███████ █████   ██████  ██ ██ ██  ██ ██   ███ ",
               "██  ██  ██ ██   ██ ██    ██ ██ ██             ██    ██   ██ ██          ██    ██ ██   ██    ██    ██   ██ ██      ██   ██ ██ ██  ██ ██ ██    ██ ",
               "██      ██ ██   ██  ██████  ██  ██████        ██    ██   ██ ███████      ██████  ██   ██    ██    ██   ██ ███████ ██   ██ ██ ██   ████  ██████  ",                                                                                                                                                                                                                                                           
               "__________________________________________________________________________________________________________________________________________________________________",
               "                     __====-_  _-====___",
               "             _--^^^#####//      \\#####^^^--_",
               "           _-^##########// (    ) \\##########^-_",
               "          -############//  |\\^^/|  \\############-",
               "        _/############//   (@::@)   \\############\\_",
               "       /#############((     \\\\//     ))#############\\",
               "      -###############\\     (oo)    //###############-",
               "     -#################\\   /    \\  //#################-",
               "    -###################\\/  \\ /  \\//###################-",
               "   _#/|##########/\\######(   V    )######/\\##########|\\#_",
               "  |/ |#/\\#/\\#/\\/  \\#/\\#/| \\       / |#/\\/  \\#/\\#/\\#/\\| |",
               "  |/  |/  V  | |  |  | |  | |       | |  |  | |  |  | | |",
               "  |  |       | |  |  | |  | |       | |  |  | |  |  | | |",
               "  |  |       |_|  |_|  |_|  |_|       |_|  |_|  |_|  | |",
               "__________________________________________________________________________________________________________________________________________________________________",

               };

            foreach (string line in dotMatrix)
            {
                Console.WriteLine(line);
            }
            Console.ReadLine();
        }

        public static void DisplayEndGameMessage()
        {
            string[] dotMatrix = new string[]
            {

                " ██████   █████  ███    ███ ███████      ██████  ██    ██ ███████ ██████ ",
                "██       ██   ██ ████  ████ ██          ██    ██ ██    ██ ██      ██   ██  ",
                "██   ███ ███████ ██ ████ ██ █████       ██    ██ ██    ██ █████   ██████   ",
                "██    ██ ██   ██ ██  ██  ██ ██          ██    ██  ██  ██  ██      ██   ██  ",
                " ██████  ██   ██ ██      ██ ███████      ██████    ████   ███████ ██   ██  ",
            };
           
            foreach (string line in dotMatrix)
            {
                Console.WriteLine(line);
            }
            Console.ReadLine();
        }

        public static void DisplayThanks()
        {
            string[] dotMatrix = new string[]
            {
              " ████████ ██   ██  █████  ███    ██ ██   ██   ██    ██  ██████  ██    ██ ",
              "    ██    ██   ██ ██   ██ ████   ██ ██  ██     ██  ██  ██    ██ ██    ██ ",
              "    ██    ███████ ███████ ██ ██  ██ █████       ████   ██    ██ ██    ██ ",
              "    ██    ██   ██ ██   ██ ██  ██ ██ ██  ██       ██    ██    ██ ██    ██ ",
              "    ██    ██   ██ ██   ██ ██   ████ ██   ██      ██     ██████   ██████ ",
            };

            foreach (string line in dotMatrix)
            {
                Console.WriteLine(line);
            }
            Console.ReadLine();
        }
    }
}
