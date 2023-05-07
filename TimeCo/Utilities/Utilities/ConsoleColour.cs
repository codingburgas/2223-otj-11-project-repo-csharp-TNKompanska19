using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeCo.Utilities
{
    public class ConsoleColour
    {
        public static ConsoleColor TextColour(string colorString)
        { 
            ConsoleColor color;
            switch (colorString.ToLower())
            {
                case "red":
                    color = ConsoleColor.Red;
                    break;
                case "green":
                    color = ConsoleColor.Green;
                    break;
                case "blue":
                    color = ConsoleColor.Blue;
                    break;
                case "yellow":
                    color = ConsoleColor.Yellow;
                    break;
                case "magenta":
                    color = ConsoleColor.Magenta;
                    break;
                case "cyan":
                    color = ConsoleColor.Cyan;
                    break;
                case "white":
                    color = ConsoleColor.White;
                    break;
                default:
                    color = ConsoleColor.Gray;
                    break;
            }
            return color;
        }

    }
}
