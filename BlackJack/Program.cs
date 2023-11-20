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
                    Console.WriteLine("Please enter 'Y' for Yes or 'N' for No.");
                    playerChoice = Console.ReadLine().ToUpper();
                    continue;
                }

                if (playerChoice == "Y")
                {
                    game.StartGame();
                    break;
                }

                else
                {
                    Console.WriteLine("Ok, good luck!");
                    break;
                }
            }

            //Добавить победу за 2 Туза и Вскрывание карт у Компа в конце игры.
            

            
        }
    }
}