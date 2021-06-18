using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Hang_Man_Game
{
    class HangMan
    {
        private string guessWord;
        public string GuessWord { 
            get { return guessWord; }
            set { guessWord = value; } 
        }                               //0    1    2    3    4    5    6   
        private static char[] wrong = new char[] { ' ', ' ', ' ', ' ', ' ', ' ', ' ' };
        private static char[] fillW = new char[] { '|', 'O', '/', '|', '\\', '/', '\\' };
        private static int hangCount = 0;
        public static void GameBoard()
        {
            Console.WriteLine("       ___      ");
            Console.WriteLine("      |  {0}       ", wrong[0]);
            Console.WriteLine("      |  {0}      ", wrong[1]);
            Console.WriteLine("      | {0}{1}{2}      ", wrong[2], wrong[3], wrong[4]);
            Console.WriteLine("      | {0} {1}      ", wrong[5], wrong[6]);
            Console.WriteLine("      |______");

        }
        public int CheckWin(char[] check, char[] guess, char[] blank)
        {
            string checking = new string(check);
            string guessing = new string(guess);

            if (wrong[6] == '\\')
            {
                Console.Clear();
                Console.WriteLine(blank);
                HangMan.GameBoard();
                Console.WriteLine("GAME OVER");
                Thread.Sleep(3000);
               return -1;

            }
            else if (checking == guessing)
            {
                Console.Clear();
                Console.WriteLine(blank);
                HangMan.GameBoard();
                Console.WriteLine("CONGRADULATIONS YOU WIN!");
                Thread.Sleep(3000);
                return 1;
            }
            else
            {
                return 0;
            }
        }
        public bool CheckForNumsAndSpaces()
        {
            if (guessWord.Any(char.IsDigit)|| guessWord.Any(char.IsSeparator)) 
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool GuessRight(char letter, string guessWord)
        {
            if (guessWord.Contains(letter))
            {
                Console.WriteLine("\nCorrect! ");
                Thread.Sleep(500);
                return true;
            }
            else
            {
                Console.WriteLine("\nIncorrect! ");
                Thread.Sleep(500);
                wrong[hangCount] = fillW[hangCount];
                hangCount++;
                return false;
            }
        }
    }
}
