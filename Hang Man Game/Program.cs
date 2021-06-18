using System;
using System.Linq;
using System.Threading;

namespace Hang_Man_Game
{
    class Program
    {
        static void Main(string[] args)
        {           //---GAME OPENED---
            HangMan Game = new HangMan();
            char[] blankArr;
            char[] checkArr;
            char[] guessArr;    

            Console.WriteLine("Welcome To HangMan");
            Thread.Sleep(1000);
            Console.Clear();
            Console.Write("Please enter a  word: ");
            Game.GuessWord = Console.ReadLine().ToLower();
            /*Added this While Loop to make sure the person entering a word
             does not use numbers.*/
            
            while (Game.CheckForNumsAndSpaces())
            {
                Console.Clear();
                Console.WriteLine("Word must not contain Numbers.");
                Console.Write("Please enter a  word: ");
                Game.GuessWord = Console.ReadLine().ToLower() ;
            }

            blankArr = new char[Game.GuessWord.Length];
            checkArr = Game.GuessWord.ToCharArray();
            guessArr = new char[Game.GuessWord.Length];
            int flag = 0;

            /* added this fucntion to present the word as a blank string of '*'
               in the game to help player know how many characters they are dealing with 
               and where they have guessed correctly */
            for(int i = 0; i < Game.GuessWord.Length; i++)
            {
                blankArr[i] = '*';
            }
            //  ----------------------------------------------------------------------------------------

            //MAIN GAME LOOP
            do
            {
                Console.Clear();
                Console.WriteLine(blankArr);
                HangMan.GameBoard();
                Console.Write("Please enter a letter: ");
                char key = Console.ReadKey(false).KeyChar;
                while (char.IsDigit(key))      // This While Loop is just to check if the user inputs a single letter and also if its a number
                {
                    Console.Clear();
                    Console.WriteLine(blankArr);
                    HangMan.GameBoard();
                    Console.Write("Invalid Input. Please enter a letter: ");
                    key = Console.ReadKey(false).KeyChar;
                    
                }

                if (Game.GuessRight(key, Game.GuessWord))
                {
                    for (int i = 0; i < Game.GuessWord.Length  ; i++)
                    {
                        if(key == checkArr[i])
                        {
                            guessArr[i] = key;
                            blankArr[i] = key;
                        }
                     
                    }   
                }

                //Check if the game is Won/Lost/Still going
                flag = Game.CheckWin(checkArr, guessArr, blankArr);

            } while (flag == 0);

            
        }
    }
}
