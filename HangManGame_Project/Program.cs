using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangManGame_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            PlayGame();
            Console.ReadKey();
        }

        static void PlayGame()
        {
            int lives = 6;
            char easterEgg = '@';
            char specialLetter = '$';
            int usedDollar = 0;
            bool easerEggisUsed = false;
            Random rnd = new Random();
            List<string> words = new List<string> {"forward" , "expertise", "classified", "association", "helpless", "displace", "stadium", "vegetarian", "projection",
                "offspring", "eccidental" , "liability", "registration"};
            string hiddenWord = words[rnd.Next(words.Count)];

            char[] stars = new char[hiddenWord.Length];
            List<string[]> images = new List<string[]> {
            new string[] {
                    "  +----+\n",
                    "  |    |\n",
                    "       |\n",
                    "       |\n",
                    "       |\n",
                    "       |\n",
                    "=========\n"
                },
                new string[] {
                    "  +----+\n",
                    "  |    |\n",
                    "  O    |\n",
                    "       |\n",
                    "       |\n",
                    "       |\n",
                    "=========\n"
                },
                new string[] {
                    "  +----+\n",
                    "  |    |\n",
                    "  O    |\n",
                    "  |    |\n",
                    "       |\n",
                    "       |\n",
                    "=========\n"
                },
                new string[] {
                    "  +----+\n",
                    "  |    |\n",
                    "  O    |\n",
                    " /|    |\n",
                    "       |\n",
                    "       |\n",
                    "=========\n"
                },
                new string[] {
                    "  +----+\n",
                    "  |    |\n",
                    "  O    |\n",
                    " /|\\   |\n",
                    "       |\n",
                    "       |\n",
                    "=========\n"
                },
                new string[] {
                    "  +----+\n",
                    "  |    |\n",
                    "  O    |\n",
                    " /|\\   |\n",
                    " /     |\n",
                    "       |\n",
                    "=========\n"
                },
                new string[] {
                    "  +----+\n",
                    "  |    |\n",
                    "  O    |\n",
                    " /|\\   |\n",
                    " / \\   |\n",
                    "       |\n",
                    "=========\n"
                }
               };
            for (int i = 0; i < stars.Length; i++)
            {
                stars[i] = '*';
            }
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Welcome to HangMan");
            bool playAgain = false;
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"The today's word is: {string.Join("", stars)}");

                Console.WriteLine("Guess the Letter: ");
                char letter = char.Parse(Console.ReadLine());
                letter = char.ToLower(letter);

                bool isLetterFound = false;
                if (letter == easterEgg && easerEggisUsed == false)
                {
                    isLetterFound = true;
                    lives += 3;
                    easerEggisUsed = true;
                }
                if (letter == specialLetter)
                {
                    for (int i = 0; i < stars.Length; i++)
                    {
                        int index = rnd.Next(stars.Length);
                        if (stars[index] == '*' && usedDollar < 2)
                        {
                            isLetterFound = true;
                            stars[index] = hiddenWord[index];
                            usedDollar++;
                            break;
                        }
                    }
                }
                for (int i = 0; i < hiddenWord.Length; i++)
                {
                    if (hiddenWord[i] == letter)
                    {
                        isLetterFound = true;
                        stars[i] = letter;
                    }
                }
                if (isLetterFound == false)
                {
                    foreach (var item in images[0])
                    {
                        Console.WriteLine(item);
                    }
                    images.RemoveAt(0);
                    lives--;
                    Console.WriteLine($"Wrong letter, you have only {lives} lives left");
                }
                if (lives <= 0)
                {
                    Console.WriteLine("You're hanged!");
                    Console.WriteLine("\nWanna play again? press Y for yes, or any key for no.");
                    char choice = char.Parse(Console.ReadLine());
                    if (choice == 'y')
                    {
                        playAgain = true;
                    }
                    else
                    {
                        break;
                    }
                }
                if (string.Join("", stars) == hiddenWord)
                {
                    Console.WriteLine("You guessed");
                    Console.WriteLine("\nWanna play again? press Y for yes, or any key for no.");
                    char choice = char.Parse(Console.ReadLine());
                    if (choice == 'y')
                    {
                        playAgain = true;
                    }
                    else
                    {
                        break;
                    }
                }
                if (playAgain)
                {
                    PlayGame();
                }
            }
        }
    }
}
