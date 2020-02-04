using System;

namespace Lab_4_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Grand Circus Casino!");

            int numSides = GetInt("How many sides should each die have? ");

            int count = 1;
            do
            {
                int die1 = GetRandomNumber(numSides);
                int die2 = GetRandomNumber(numSides);

                Console.WriteLine($"\nRoll: {count}");
                DiceOutput(die1,die2,numSides);
                count++;

            } while (UserContinue());

        }

        static void DiceOutput(int d1, int d2, int sides)
        {
            int diceTotal = d1 + d2;
            Console.WriteLine($"You rolled {d1} and a {d2} ({diceTotal} total)");

            if (sides == 6)
            {
                if (d1 == 1 && d2 == 1)
                {
                    Console.WriteLine("Snake Eyes");
                }
                else if ((d1 == 1 && d2 ==2)||(d2 == 1 && d1 == 2))
                {
                    Console.WriteLine("Ace Deuce");
                }
                else if ((d1 == 6) && (d2 == 6))
                {
                    Console.WriteLine("Box Cars");
                }
                if ((diceTotal == 7) || (diceTotal == 11))
                {
                    Console.WriteLine("Win!");
                }
                else if ((diceTotal == 2) || (diceTotal == 3) || (diceTotal == 12))
                {
                    Console.WriteLine("Craps");
                }
            }
        }

        static int GetInt(string prompt)
        {
            string input;
            int number;
            bool worked;

            Console.Write(prompt);
            input = Console.ReadLine();
            worked = int.TryParse(input, out number);

            while (worked == false || number < 0)
            {
                Console.WriteLine("Let's try again.");
                Console.Write("\nEnter a positive whole number. How many sides should each die have? ");
                input = Console.ReadLine();

                worked = int.TryParse(input, out number);
            }

            return number;

        }
        static int GetRandomNumber(int num)
        {
            Random rnd = new Random();
            int dice = rnd.Next(1, num+1);
            return dice;
        }

        static bool UserContinue()
        {
            char key;
            do
            {
                Console.Write("\nRoll again? (y/n) ");
                key = Console.ReadKey().KeyChar;
                key = char.ToLower(key);
                if (key == 'n')
                {
                    return false;
                }
                Console.WriteLine();

            } while (key != 'y');
            return true;
        }
    }
}
