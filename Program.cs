using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dania_Basis_programering_aflevering_Variabler___Datatyper
{
    internal class Program
    {
        static Random Random = new Random();
        static string Name;
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            StageBreak();

            SayLine("Hello, and welcome to my guessing game!");
            StageBreak();

            SayLine("Let's start off with your name. What is it?");
            Wait(1000);
            SayLine("Go on, i don't bite.");

            while (true)
            {
                Name = GetResponds();
                if (Name == "")
                {
                    SayLine("What?");
                    Wait(1000);
                    SayLine("You don't have a name?");
                    Wait(1000);
                    SayLine("That can't be right, try again.");
                    continue;
                }
                break;
            }

            SayLine($"Okay {Name}, now it's time to play the game.");
            Wait(1000);
            SayLine("\nThe rules are pretty simple.");
            Wait(500);
            SayLine("First, i will pick a random number between 1 and 100, and then you try to guess it.");
            Wait(1000);
            SayLine("Let's give it a try!");
            StageBreak();

            while (true)
            {
                int randomNumber = Random.Next(1,101);
                SayLine("I have a number in mind, let's see if you can guess it.");

                string guessedNumberString = GetResponds();
                int guessedNumber;

                try
                {
                    guessedNumber = Convert.ToInt16(guessedNumberString);
                }
                catch
                {
                    WrongGameInput();
                    continue;
                }

                if (guessedNumber <= 0 | guessedNumber > 100)
                {
                    WrongGameInput();
                    continue;
                }

                int difference = Math.Abs(guessedNumber - randomNumber);
                if (difference == 0)
                    SayLine("WOW! You actually guessed it!");
                else if (difference <= 10)
                    SayLine($"Unfortunate, you were only {difference} off.");
                else if (difference <= 30)
                    SayLine($"Not bad, you were {difference} away from the right number");
                else if (difference <= 60)
                    SayLine($"No luck this time, you were {difference} away from the right number.");
                else
                    SayLine($"HAHA! That was a bad guess, you were {difference} off, that's more than half");
                SayLine($"I picked {randomNumber}.");

                Wait(2000);
                TryAgain:
                SayLine("\n\nDo you want to play again? (Y/N)");
                string responds = GetResponds().ToLower();
                if (responds == "y")
                {
                    continue;
                }
                else if (responds == "n")
                {
                    Say("That's fine, i hope you had fun.");
                    Wait(1000);
                    Say(".");
                    Wait(1000);
                    Say(".");
                    Wait(1000);
                    Console.Clear();
                    Wait(1000);
                    Say("Bye.");
                    Wait(1000);
                    Environment.Exit(0);
                }
                else
                {
                    Console.Clear();
                    goto TryAgain;
                }
            }
        }

        public static void SayLine(string text)
        {
            Say(text);
            Console.WriteLine();
        }
        public static void Say(string text)
        {
            int waitTime = 20;
            foreach (char letter in text)
            {
                Thread.Sleep(waitTime);
                Console.Write(letter);
                waitTime = letter == ',' ? 500 : 20;
            }
        }

        public static void StageBreak()
        {
            Console.WriteLine("[Press Enter]");
            Console.ReadKey();
            Console.Beep(100, 60);
            Console.Clear();
        }
        public static string GetResponds()
        {
            Console.CursorVisible = true;
            string responds = Console.ReadLine();
            Console.CursorVisible = false;
            Console.Beep(100, 60);
            Console.Clear();

            return responds;
        }

        public static void WrongGameInput()
        {
            SayLine("That's not how you play, you're supposed to guess a number between 1 and 100.");
            Wait(500);
            SayLine("Let's try again.");
            StageBreak();
        }

        public static void Wait(int time)
        {
            Thread.Sleep(time);
        }
    }
}
