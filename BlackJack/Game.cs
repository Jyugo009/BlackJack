using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    public class Game
    {
        private Deck _deck;

        private List<Card> _playerCards;

        private List<Card> _computerCards;

        private int _playerPoints;

        private int _computerPoints;

        private int _playerWins;

        private int _computerWins;

        private bool _playerContinues = true;

        private bool _computerContinues = true;

        public Game()
        {
            _deck = new Deck();

            _playerCards = new List<Card>();

            _computerCards = new List<Card>();

            _playerPoints = 0;

            _computerPoints = 0;

            _deck.Shuffle();
        }


        public void StartGame()
        {
            DealInitialCards();

            while (_playerPoints < 21 && _computerPoints < 21)
            {
                if (_playerContinues)
                {
                    PlayerTurn();

                    if (_playerPoints >= 21)
                    {
                        _playerContinues = false;
                    }
                }

                if (_computerContinues)
                {
                    ComputerTurn();

                    if (_computerPoints >= 21)
                    {
                        _computerContinues = false;
                    }
                }

                if (!_playerContinues && !_computerContinues)
                {
                    break;
                }
            }




            DetermineWinner();
        }

        private void DealInitialCards()
        {
            Console.WriteLine("Shuffling the deck and dealing the initial cards...\n");

            _playerCards.Add(_deck.DrawCard());
            _playerCards.Add(_deck.DrawCard());

            foreach (Card card in _playerCards)
            {
                _playerPoints += card.GetCardValue();

            }

            string playerHand = string.Join(", ", _playerCards.Select(card => card.ToString()));

            Console.WriteLine($"You are dealt: {playerHand}. Your total points: {_playerPoints}\n");


            _computerCards.Add(_deck.DrawCard());
            _computerCards.Add(_deck.DrawCard());

            foreach (Card card in _computerCards)
            {
                _computerPoints += card.GetCardValue();
            }

            Console.WriteLine($"Computer is dealt: {_computerCards.Count()} cards.\n");

        }

        private bool GameOver()
        {
            if (_playerPoints >= 21)
            {
                return true;
            }
            else if (_computerPoints >= 21)
            {
                return true;
            }
            else
            {
                return false;
            }


        }

        private void PlayerTurn()
        {
            Console.WriteLine("Do you want to get another one card? Y/N?\n");

            string playerChoice = Console.ReadLine().ToUpper();

            while (true)
            {
                if (playerChoice == "Y")
                {
                    Card newCard = _deck.DrawCard();

                    _playerCards.Add(newCard);

                    _playerPoints += newCard.GetCardValue();

                    string playerHand = string.Join(", ", _playerCards.Select(card => card.ToString()));

                    Console.WriteLine($"You drew: {newCard}. Your hand: {playerHand}. Your total points: {_playerPoints}\n");

                    if (_playerPoints >= 21)
                    {
                        _playerContinues = false;
                        break;
                    }

                    break;

                }
                else if (playerChoice == "N")
                {
                    _playerContinues = false;

                    break;
                }
                else
                {
                    Console.WriteLine("Please enter 'Y' for Yes or 'N' for No.\n");

                    playerChoice = Console.ReadLine().ToUpper();
                }
            }
        }

        private void ComputerTurn()
        {
            while (_computerContinues && _computerPoints < 17)
            {
                Card newCard = _deck.DrawCard();

                _computerCards.Add(newCard);

                _computerPoints += newCard.GetCardValue();

                Console.WriteLine($"Computer draws. Computer's total cards: {_computerCards.Count}");

                if (_computerPoints >= 17)
                {
                    Console.WriteLine("The computer decides to stop drawing cards.\n");

                    _computerContinues = false;

                    break;
                }

                if (_computerPoints >= 21)
                {
                    break;
                }
            }
        }




        private void DetermineWinner()
        {
            int playerAces = _playerCards.Count(card => card._value == "Ace");
            int computerAces = _computerCards.Count(card => card._value == "Ace");

            bool playerTwoAces = playerAces == 2 && _playerCards.Count == 2;
            bool computerTwoAces = computerAces == 2 && _computerCards.Count == 2;

            if (playerTwoAces)
            {

                string computerHand = string.Join(", ", _computerCards.Select(card => card.ToString()));

                Console.WriteLine($"Computer's hand: {computerHand}");

                _playerWins++;

                Console.WriteLine($"You win this round with 2 ACES! Your points: {_playerPoints}, Computer's points: {_computerPoints}");

            }

            else if (computerTwoAces)
            {
                string computerHand = string.Join(", ", _computerCards.Select(card => card.ToString()));

                Console.WriteLine($"Computer's hand: {computerHand}");

                _computerWins++;

                Console.WriteLine($"Computer wins this round with 2 ACES! Computer's points: {_computerPoints}, Your points: {_playerPoints}");
            }

            else if (_playerPoints <= 21 && (_playerPoints > _computerPoints || _computerPoints > 21))
            {
                string computerHand = string.Join(", ", _computerCards.Select(card => card.ToString()));

                Console.WriteLine($"Computer's hand: {computerHand}");

                _playerWins++;

                Console.WriteLine($"You win this round! Your points: {_playerPoints}, Computer's points: {_computerPoints}");
            }
            else if (_computerPoints <= 21 && (_computerPoints > _playerPoints || _playerPoints > 21))
            {
                string computerHand = string.Join(", ", _computerCards.Select(card => card.ToString()));

                Console.WriteLine($"Computer's hand: {computerHand}");

                _computerWins++;

                Console.WriteLine($"Computer wins this round! Computer's points: {_computerPoints}, Your points: {_playerPoints}");
            }
            else if (_playerPoints > 21 && _computerPoints > 21)
            {
                if (_playerPoints < _computerPoints)
                {
                    string computerHand = string.Join(", ", _computerCards.Select(card => card.ToString()));

                    Console.WriteLine($"Computer's hand: {computerHand}");

                    _playerWins++;

                    Console.WriteLine($"You win this round! Your points: {_playerPoints}, Computer's points: {_computerPoints}");
                }
                else if (_computerPoints < _playerPoints)
                {
                    string computerHand = string.Join(", ", _computerCards.Select(card => card.ToString()));

                    Console.WriteLine($"Computer's hand: {computerHand}");

                    _computerWins++;

                    Console.WriteLine($"Computer wins this round! Computer's points: {_computerPoints}, Your points: {_playerPoints}");
                }
            }
            else
            {
                string computerHand = string.Join(", ", _computerCards.Select(card => card.ToString()));

                Console.WriteLine($"Computer's hand: {computerHand}");

                Console.WriteLine("It's a draw!");
            }
            

                Console.WriteLine($"Total victories - Player: {_playerWins}, Computer: {_computerWins}\n");

                Console.WriteLine("Would you like to test your fate once more? Y/N?");

                string playerChoice = Console.ReadLine().ToUpper();

                while (true)
                {

                    if (playerChoice == "Y")
                    {
                        ResetGame();
                        StartGame();
                        break;
                    }

                    else if (playerChoice == "N")
                    {
                        Console.WriteLine("Thank you for playing!");
                        Environment.Exit(0);
                    }

                    else
                    {
                        Console.WriteLine("Please enter 'Y' for Yes or 'N' for No.\n");

                        playerChoice = Console.ReadLine().ToUpper();

                        continue;
                    }
                }
            
        }
            private void ResetGame()
            {
                _playerCards.Clear();
                _computerCards.Clear();

                _playerPoints = 0;
                _computerPoints = 0;

                _playerContinues = true;
                _computerContinues = true;

                _deck = new Deck();

                _deck.Shuffle();
            }

        
    } 
}
