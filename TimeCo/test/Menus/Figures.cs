using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeCo.Utilities;
namespace test.Menus
{
    public class Figures
    {
        private TimeCo.Utilities.ConsoleColour _consoleColour;

        public Figures() 
        {
            _consoleColour = new TimeCo.Utilities.ConsoleColour();
        }
        public void ComputerFigure(int x, int y)
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.SetCursorPosition(x, y);
            Console.WriteLine("     ____________________________");
            Console.SetCursorPosition(x, y + 1);
            Console.WriteLine ("    !\\_________________________/!");
            Console.SetCursorPosition(x, y + 2);
            Console.WriteLine ("    !!                         !! \\");
            Console.SetCursorPosition(x, y + 3);
            Console.WriteLine ("    !!                         !!  \\");
            Console.SetCursorPosition(x, y + 4);
            Console.WriteLine ("    !!                         !!  !");
            Console.SetCursorPosition(x, y + 5);
            Console.WriteLine ("    !!                         !!  !");
            Console.SetCursorPosition(x, y + 6);
            Console.WriteLine ("    !!                         !!  !");
            Console.SetCursorPosition(x, y + 7);
            Console.WriteLine ("    !!                         !!  !");
            Console.SetCursorPosition(x, y + 8);
            Console.WriteLine ("    !!                         !!  !");
            Console.SetCursorPosition(x, y + 9);
            Console.WriteLine ("    !!                         !!  /");
            Console.SetCursorPosition(x, y + 10);
            Console.WriteLine ("    !!_________________________!! /");
            Console.SetCursorPosition(x, y + 11);
            Console.WriteLine ("    !/_________________________\\!/");
            Console.SetCursorPosition(x, y + 12);
            Console.WriteLine ("       __\\_________________/__/!_");
            Console.SetCursorPosition(x, y + 13);
            Console.WriteLine ("      !_______________________!/");
            Console.SetCursorPosition(x, y + 14);
            Console.WriteLine ("    ________________________");
            Console.SetCursorPosition(x, y + 15);
            Console.WriteLine ("   /oooo  oooo  oooo  oooo /!");
            Console.SetCursorPosition(x, y + 16);
            Console.WriteLine ("  /ooooooooooooooooooooooo/ /");
            Console.SetCursorPosition(x, y + 17);
            Console.WriteLine (" /ooooooooooooooooooooooo/ /");
            Console.SetCursorPosition(x, y + 18);
            Console.WriteLine ("/C=_____________________/_/");
        }

        public void TimeCoLabel(int x, int y)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(x, y);
            Console.WriteLine("  _______ _                 _____      ");
            Console.SetCursorPosition(x, y + 1);
            Console.WriteLine(" |__   __(_)               / ____|     ");
            Console.SetCursorPosition(x, y + 2);
            Console.WriteLine("    | |   _ _ __ ___   ___| |     ___  ");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.SetCursorPosition(x, y + 3);
            Console.WriteLine("    | |  | | '_ ` _ \\ / _ \\ |    / _ \\ ");
            Console.SetCursorPosition(x, y + 4);
            Console.WriteLine("    | |  | | | | | | |  __/ |___| (_) |");
            Console.SetCursorPosition(x, y + 5);
            Console.WriteLine("    |_|  |_|_| |_| |_|\\___|\\_____\\___/ ");
        }

        public void TeamFigure(int x, int y)
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.SetCursorPosition(x, y);
            Console.WriteLine("      @@@@    @@@@@@@    @@@@");
            Console.SetCursorPosition(x, y + 1);
            Console.WriteLine( "     @@@@@@  @@@@@@@@@  @@@@@@");
            Console.SetCursorPosition(x, y + 2);
            Console.WriteLine( "     @@@@@@#  @@@@@@@  @@@@@@@");
            Console.SetCursorPosition(x, y + 3);
            Console.WriteLine( "       %@        @#       @#");
            Console.SetCursorPosition(x, y + 4);
            Console.WriteLine( "   @@@@@@@@ @@@@@@@@@@@ @@@@@@@@");
            Console.SetCursorPosition(x, y + 5);
            Console.WriteLine( "   @@@@@@@.@@@@@@@@@@@@@ @@@@@@@");
            Console.SetCursorPosition(x, y + 6);
            Console.WriteLine( "  @@ @@@@@@@@@@@@@@@@@@@@@@@@@ @@");
            Console.SetCursorPosition(x, y + 7);
            Console.WriteLine( " @@  @@@@ @@ @@@@@@@@@ @@ @@@@  @@");
            Console.SetCursorPosition(x, y + 8);
            Console.WriteLine( " @@  @&@ @@  @@@@@@@@@  @@ @@@  @@");
            Console.SetCursorPosition(x, y + 9);
            Console.WriteLine( "@@   @@@@@@@ @@@@@@@@@ @@@@@@@   @@");
            Console.SetCursorPosition(x, y + 10);
            Console.WriteLine( "     @@   @@ @@@@@@@@@ @@   @@");
            Console.SetCursorPosition(x, y + 11);
            Console.WriteLine( "     @@  @@@ @@@@ @@@@ @@@  @@");
            Console.SetCursorPosition(x, y + 12);
            Console.WriteLine( "     @@  @@@ @@@@ @@@@ @@@  @@");
            Console.SetCursorPosition(x, y + 13);
            Console.WriteLine( "     @@  @@@ @@@@ @@@@ @@@  @@");
            Console.SetCursorPosition(x, y + 14);
            Console.WriteLine( "     @@  @@@ @@@@ @@@@ @@@  @@");
            Console.SetCursorPosition(x, y + 15);
            Console.WriteLine( "     @&   @  @@@@ @@@@  @   @&");
            Console.SetCursorPosition(x, y + 16);
            Console.WriteLine( "             @@@@ @@@@");
        }

        public void Button(int x, int y, string colour)
        {
            Console.ForegroundColor = _consoleColour.TextColour(colour);
            Console.SetCursorPosition(x, y);
            Console.WriteLine("  ___________________");
            Console.SetCursorPosition(x, y + 1);
            Console.WriteLine(" /                   \\");  
            Console.SetCursorPosition(x, y + 2);
            Console.WriteLine("|                     | "); 
            Console.SetCursorPosition(x, y + 3);
            Console.WriteLine(" \\___________________/");
        }

        public void TextInButton(int x, int y, string text, string colour)
        {
            Console.ForegroundColor = _consoleColour.TextColour(colour);
            Console.SetCursorPosition(x, y);
            Console.WriteLine(text);
        }
        public void Border(int x, int y, int n)
        {

            for (int i = 0; i < n; i++)
            {
                Console.SetCursorPosition(x, y);
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("(*)");
                y++;
            }
        }
    }
}
