using System.Security.Cryptography.X509Certificates;

namespace BlackJack
{
    internal class Program
    {
        static void Main(string[] args)
        {   //1 Task
            Deck deck = new Deck();

            //2 Task
            deck.Shuffle();

            //3 Task
            int[] acePositions = deck.FindAces();

            foreach (int ace in acePositions)
            {
                Console.WriteLine(ace);
            }

            //4 Task
            deck.MoveSpadesToTop();

            //5 Task
            deck.SortDeck();

            //6 Task           
            Game game = new Game();

            string playerChoice;

            Console.WriteLine("Do you want to play in \"Twenty-One\"?");

            Console.WriteLine("Y\\N?\n");

            playerChoice = Console.ReadLine().ToUpper();
            while (true)
            {
                if (playerChoice != "Y" && playerChoice != "N")
                {
                    Console.WriteLine("Please enter 'Y' for Yes or 'N' for No.\n");

                    playerChoice = Console.ReadLine().ToUpper();
                    
                    continue;
                }

                else if (playerChoice == "Y")
                {
                    game.StartGame();

                    break;
                }

                else
                {
                    Console.WriteLine("Ok, good luck!");

                    Environment.Exit(0);
                }


            }

            while (true)
            {
                Console.WriteLine("Would you like to test your fate once more? Y/N?\n");

                string newGameChoice = Console.ReadLine().ToUpper();

                if (newGameChoice != "N" && newGameChoice != "Y")
                {
                    Console.WriteLine("Please enter 'Y' for Yes or 'N' for No.\n");

                    newGameChoice = Console.ReadLine().ToUpper();

                    continue;
                }


                else if (newGameChoice == "Y")
                {
                    game.StartGame();
                }

                else
                {
                    Console.WriteLine("Thank you for playing!");

                    Environment.Exit(0);
                }
            }
        }
    }
}