using System;
using System.Linq;
using System.Threading;

namespace Hang_Man_Game
{
    class Program
    {
        
        static int hangCount = 0;
        static bool correct;
        static bool run = true;
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
            |  O
            | /|\
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
            char[] checkArr = guessWord.ToCharArray();
            char[] guessArr = new char[guessWord.Length ];
            int flag = 0;
            
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
                    for (int i = 0; i < 3; i++)
                    {
                        Console.WriteLine("CONGRADULATIONS YOU WIN!");
                        Thread.Sleep(500);
                        Console.Clear();
                        
                    }
                    Console.WriteLine("CONGRADULATIONS YOU WIN!");
                    Thread.Sleep(3000);
                    break;
                }


                Console.Clear();
                Console.WriteLine(guessArr);
                GameBoard();
                Console.Write("Please enter a letter: ");

                bool intCheck = false;
                string str = Console.ReadLine();
                intCheck = str.Any(char.IsDigit);
                while (str.Length != 1 ||  intCheck)      // This While Loop is just to check if the user inputs a single letter and also if its a number
                {
                    Console.Clear();
                    Console.WriteLine(guessArr);
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
                        }
                     
                    }   
                }
                else
                {
                    wrong[hangCount] = fillW[hangCount];
                    Console.WriteLine("Incorrect!");
                    Thread.Sleep(700);
                    hangCount++;

                }

            } while (run);

            
        }
    }
}
