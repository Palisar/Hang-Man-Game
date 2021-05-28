using System;
using System.Linq;
using System.Threading;

namespace Hang_Man_Game
{
    class Program
    {
        
        static int hangCount = 0;
        static bool correct;
        static char guessLetter;
        static string guessWord;
        static string checkWord;          //0    1    2    3    4    5    6   
        static char[] wrong = new char[] { ' ', ' ', ' ', ' ', ' ', ' ', ' ' };
        static char[] fillW = new char[] { '|','O', '/', '|', '\\', '/', '\\' };

        static void GameBoard()
        {
            Console.WriteLine("       ___      ");
            Console.WriteLine("      |  {0}       ", wrong[0]);
            Console.WriteLine("      |  {0}      ", wrong[1]);
            Console.WriteLine("      | {0}{1}{2}      ",wrong[2], wrong[3], wrong[4]);
            Console.WriteLine("      | {0} {1}      ", wrong[5], wrong[6]);
            Console.WriteLine("      |______");
         /*  ___
            |  
            | \O/
            |  |
            | /_\
            ||___|
         */
        }
         static int CheckWin(char[] check, char[] guess)
        {
            string ch = new string(check);
            string gu = new string(guess);

            if(wrong[6] == '\\')
            {
                return -1;
                
            }
            else if(ch == gu)
            {

                return 1;
            }
            else
            {
                return 0;
            }    
        }

       
        static bool GuessRight(char letter)
        {
            if (guessWord.Contains(letter))
            {
                Console.WriteLine("Correct! ");
                Thread.Sleep(700);
                return true;
            }
            else
            {
                
                return false;
            }
        }
       
        
        static void Main(string[] args)
        {           //GAME OPENED
            Console.WriteLine("Welcome To HangMan");
            Thread.Sleep(2000);
            Console.Clear();
            Console.Write("Please enter a  word: ");
            guessWord = Console.ReadLine();
            /*Added this While Loop to make sure the person entering a word
             does not use numbers.*/
            bool noNumbers = guessWord.Any(char.IsDigit);
            while (noNumbers)
            {
                Console.Clear();
                Console.WriteLine("Word must not contain Numbers.");
                Console.Write("Please enter a  word: ");
                guessWord = Console.ReadLine();
                noNumbers = guessWord.Any(char.IsDigit);
            }
            char[] blankArr = new char[guessWord.Length];
            char[] checkArr = guessWord.ToCharArray();
            char[] guessArr = new char[guessWord.Length ];
            int flag = 0;

            /* added this fucntion to present the word as a blank string of '*'
               in the game to help player know how many characters they are dealing with 
               and where they have guessed correctly */
            for (int c = 0; c < checkArr.Length; c++)
            {
                blankArr[c] = '*';
            }
          //  --------------------------------------------

            //MAIN GAME LOOP
            do
            {

               flag = CheckWin(checkArr, guessArr);

                if (flag == -1)   //GAME OVER CONDITION
                {
                    Console.Clear();
                    GameBoard();
                    Console.WriteLine("GAME OVER");   
                    Thread.Sleep(3000);
                    break;

                }
                else if (flag == 1)   //WIN CONDITION
                {
                   
                    Console.WriteLine("CONGRADULATIONS YOU WIN!");
                    Thread.Sleep(3000);
                    break;
                }


                Console.Clear();
                Console.WriteLine(blankArr);
                GameBoard();
                Console.Write("Please enter a letter: ");

                bool intCheck = false;  //Added This to check for numbers
                string str = Console.ReadLine();
                intCheck = str.Any(char.IsDigit);
                while (str.Length != 1 ||  intCheck)      // This While Loop is just to check if the user inputs a single letter and also if its a number
                {
                    Console.Clear();
                    Console.WriteLine(blankArr);
                    GameBoard();
                    intCheck = false;
                    Console.Write("Invalid Input. Please enter a letter: ");
                    str = Console.ReadLine();
                    intCheck = str.Any(char.IsDigit);
                }
                guessLetter = Convert.ToChar(str);

                correct = GuessRight(guessLetter);

                if (correct)
                {
                    for (int i = 0; i < guessWord.Length  ; i++)
                    {
                        if(guessLetter == checkArr[i])
                        {
                            guessArr[i] = guessLetter;
                            blankArr[i] = guessLetter;
                        }
                     
                    }   
                }
                else
                {
                    wrong[hangCount] = fillW[hangCount];
                    Console.WriteLine("Incorrect!");
                    Thread.Sleep(500);
                    hangCount++;

                }

            } while (flag == 0);

            
        }
    }
}
