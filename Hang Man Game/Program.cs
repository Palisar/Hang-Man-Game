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
            char[] checkArr; //Our blank array will populate with '*' then correct letters as they come. To show player progess
            char[] guessArr; //Will contain the word input by our player.

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
                Console.WriteLine("Word must not contain numbers or spaces.");
                Console.Write("Please enter a  word: ");
                Game.GuessWord = Console.ReadLine().ToLower() ;
            }

            checkArr = Game.GuessWord.ToCharArray();
            guessArr = new char[Game.GuessWord.Length];
            int flag;

            /* added this fucntion to present the word as a blank string of '*'
               in the game to help player know how many characters they are dealing with 
               and where they have guessed correctly */
            for(int i = 0; i < Game.GuessWord.Length; i++)
            {
                guessArr[i] = '*';
            }
            //  ----------------------------------------------------------------------------------------

            //MAIN GAME LOOP
            do
            {
                Console.Clear();
                Console.WriteLine(guessArr);
                HangMan.GameBoard();
                Console.Write("Please enter a letter: ");
                char key = Console.ReadKey(false).KeyChar;
                while (char.IsDigit(key))      // This While Loop is just to check if the user inputs a single letter and also if its a number
                {
                    Console.Clear();
                    Console.WriteLine(guessArr);
                    HangMan.GameBoard();
                    Console.Write("Invalid Input. Please enter a letter: ");
                    key = Console.ReadKey(false).KeyChar;
                    
                }

                if (Game.GuessRightOrWrong(key, Game.GuessWord))
                {
                    for (int i = 0; i < Game.GuessWord.Length  ; i++)
                    {
                        if(key == checkArr[i])
                        {
                            guessArr[i] = key;  
                        }
                    }   
                }

                //Check if the game is Won/Lost/Still going
                flag = Game.CheckWin(checkArr, guessArr);

            } while (flag == 0);

            
        }
    }
}
