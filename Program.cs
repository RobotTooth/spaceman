using System;

namespace Spaceman
{
    class Program
    {
        static void Main(string[] args)
        {
            Game n1 = new Game();
            n1.Greet();

            do
            {
                
                n1.Ask();
                n1.Display();
            } while (n1.DidWin() != true && n1.DidLoose() != true);

            if (n1.DidWin())
            {
                Console.WriteLine("Congratulations, you survived the invasion, hooray!");
                n1.DisplayWin();
            }
            else
            {
                n1.Display();
                Console.WriteLine("You have been body snatched, bad luck.");
            }

        }
    }
}
