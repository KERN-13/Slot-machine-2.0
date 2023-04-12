using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Welcome to the slot machine game!");
            Console.WriteLine($"You have 50 coins to start with.");
            
            int coins = 50;
            Random random = new Random();

            while (coins > 0)
            {
                Console.WriteLine("Enter your bet: ");
                int bet = Convert.ToInt32(Console.ReadLine());
                if (bet > coins)
                {
                    Console.WriteLine("You do not have enough coins for that bet.");
                    continue;
                }
                coins -= bet;

                int[,] grid = new int[3, 3];

                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        grid[i, j] = random.Next(2);
                    }
                }

                Console.WriteLine("Grid: ");
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        Console.Write(grid[i, j] + " ");
                    }
                    Console.WriteLine();
                }

                int numLinesWon = 0;
                for (int i = 0; i < 3; i++)
                {
                    if (grid[i, 0] == grid[i, 1] && grid[i, 1] == grid[i, 2])
                    {
                        numLinesWon++;
                    }
                    if (grid[0, i] == grid[1, i] && grid[1, i] == grid[2, i])
                    {
                        numLinesWon++;
                    }
                }
                if (grid[0, 0] == grid[1, 1] && grid[1, 1] == grid[2, 2])
                {
                    numLinesWon++;
                }
                if (grid[0, 2] == grid[1, 1] && grid[1, 1] == grid[2, 0])
                {
                    numLinesWon++;
                }

                if (numLinesWon > 0)
                {
                    int reward = bet * (int)Math.Pow(2, numLinesWon);
                    Console.WriteLine("Congratulations! You won " + reward + " coins on " + numLinesWon + " line(s)!");
                    coins += reward;
                }
                else
                {
                    Console.WriteLine("Sorry, you lost " + bet + " coins.");
                }
                Console.WriteLine("You now have " + coins + " coins.");
                Console.WriteLine("Would you like to play again? (y/n)");
                if (Console.ReadLine().ToLower() != "y")
                {
                    break;
                }
            }
            Console.WriteLine("Thanks for playing! You leave with " + coins + " coins.");
            Console.ReadLine();
        }
    }
}