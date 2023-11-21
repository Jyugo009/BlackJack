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

        private Player _player;

        private Player _computer;

        public Game()
        {
            _player = new Player();

            _computer = new Player();
        }


        public void StartGame()
        {
            NewGame();

            DealInitialCards();

            if (_player.AcesWin == true || _computer.AcesWin == true) 
            {
                DetermineWinner();
                return;
            }
            

            while (_player.PlayerPoints < 21 && _computer.PlayerPoints < 21)
            {
                if (!_player.PlayerContinues && !_computer.PlayerContinues)
                {
                    break;
                }

                if (_player.PlayerContinues)
                {
                    PlayerTurn();

                    if (_player.PlayerPoints >= 21)
                    {
                        _player.PlayerContinues = false;
                    }
                }

                if (_computer.PlayerContinues)
                {
                    ComputerTurn();

                    if (_computer.PlayerPoints >= 21)
                    {
                        _computer.PlayerContinues = false;
                    }
                }
            }

            DetermineWinner();
        }

        private void DealInitialCards()
        {
            Console.WriteLine("Shuffling the deck and dealing the initial cards... \n");

            _player.PlayerCards.Add(_deck.DrawCard());

            _player.PlayerCards.Add(_deck.DrawCard());

            foreach (Card card in _player.PlayerCards)
            {
                _player.PlayerPoints += card.GetCardValue();

            }

            _player.AcesWin = IfAcesWin(_player.PlayerCards);

            string playerHand = string.Join(", ", _player.PlayerCards.Select(card => card.ToString()));

            if (_player.AcesWin == true)
            {
                Console.WriteLine($"You are dealt: {playerHand}. Your total points: {_player.PlayerPoints} \n");
                return;
            }

            Console.WriteLine($"You are dealt: {playerHand}. Your total points: {_player.PlayerPoints} \n");

            _computer.PlayerCards.Add(_deck.DrawCard());

            _computer.PlayerCards.Add(_deck.DrawCard());

            foreach (Card card in _computer.PlayerCards)
            {
                _computer.PlayerPoints += card.GetCardValue();
            }

            _computer.AcesWin = IfAcesWin(_computer.PlayerCards);

            if (_computer.AcesWin == true)
            {
                return;
            }

            Console.WriteLine($"Computer is dealt: {_computer.PlayerCards.Count()} cards. \n");

        }

        private void PlayerTurn()
        {
            Console.WriteLine("Do you want to get another one card? Y/N? \n");

            string playerChoice = Console.ReadLine().ToUpper();

            
            
            while (playerChoice != "Y" && playerChoice != "N")
            {
                
                
                    Console.WriteLine("Please enter 'Y' for Yes or 'N' for No. \n");

                    playerChoice = Console.ReadLine().ToUpper();
                    
                    break;
                
            }


            if (playerChoice == "Y")
            {
                Card newCard = _deck.DrawCard();

                _player.PlayerCards.Add(newCard);

                _player.PlayerPoints += newCard.GetCardValue();

                string playerHand = string.Join(", ", _player.PlayerCards.Select(card => card.ToString()));

                Console.WriteLine($"You drew: {newCard}. Your hand: {playerHand}. Your total points: {_player.PlayerPoints} \n");

                if (_player.PlayerPoints >= 21)
                {
                    _player.PlayerContinues = false;

                }
            }

            else
            {
                    _player.PlayerContinues = false;

            }
            
        }

        private void ComputerTurn()
        {
            if (_computer.PlayerContinues && _computer.PlayerPoints < 17)
            {
                Card newCard = _deck.DrawCard();

                _computer.PlayerCards.Add(newCard);

                _computer.PlayerPoints += newCard.GetCardValue();

                Console.WriteLine($"Computer draws. Computer's total cards: {_computer.PlayerCards.Count} \n");
            }

            else
            {
                    Console.WriteLine("The computer decides to stop drawing cards. \n");

                    _computer.PlayerContinues = false;
            }            
        }




        private void DetermineWinner()
        {

            if (_player.AcesWin == true)
            {
                _player.PlayerWins++;

                Console.WriteLine($"You win this round with TWO ACES! Your points: {_player.PlayerPoints}, Computer's points: {_computer.PlayerPoints} \n");
            }

            else if (_computer.AcesWin == true)
            {
                _computer.PlayerWins++;

                string computerHand = string.Join(", ", _computer.PlayerCards.Select(card => card.ToString()));

                Console.WriteLine($"Computer's hand: {computerHand} \n");

                Console.WriteLine($"Computer win this round with TWO ACES! Your points: {_player.PlayerPoints}, Computer's points: {_computer.PlayerPoints} \n");
            }

            else if (_player.PlayerPoints <= 21 && (_player.PlayerPoints > _computer.PlayerPoints || _computer.PlayerPoints > 21))
            {
                string computerHand = string.Join(", ", _computer.PlayerCards.Select(card => card.ToString()));

                Console.WriteLine($"Computer's hand: {computerHand} \n");

                _player.PlayerWins++;

                Console.WriteLine($"You win this round! Your points: {_player.PlayerPoints}, Computer's points: {_computer.PlayerPoints} \n");
            }

            else if (_computer.PlayerPoints <= 21 && (_computer.PlayerPoints > _player.PlayerPoints || _player.PlayerPoints > 21))
            {
                string computerHand = string.Join(", ", _computer.PlayerCards.Select(card => card.ToString()));

                Console.WriteLine($"Computer's hand: {computerHand} \n");

                _computer.PlayerWins++;

                Console.WriteLine($"Computer wins this round! Computer's points: {_computer.PlayerPoints}, Your points: {_player.PlayerPoints} \n");
            }
            else if (_player.PlayerPoints > 21 && _computer.PlayerPoints > 21)
            {
                if (_player.PlayerPoints < _computer.PlayerPoints)
                {
                    string computerHand = string.Join(", ", _computer.PlayerCards.Select(card => card.ToString()));

                    Console.WriteLine($"Computer's hand: {computerHand} \n");

                    _player.PlayerWins++;

                    Console.WriteLine($"You win this round! Your points: {_player.PlayerPoints}, Computer's points: {_computer.PlayerPoints} \n");
                }
                else if (_computer.PlayerPoints < _player.PlayerPoints)
                {
                    string computerHand = string.Join(", ", _computer.PlayerCards.Select(card => card.ToString()));

                    Console.WriteLine($"Computer's hand: {computerHand} \n");

                    _computer.PlayerWins++;

                    Console.WriteLine($"Computer wins this round! Computer's points: {_computer.PlayerPoints}, Your points: {_player.PlayerPoints} \n");
                }
            }
            else
            {
                string computerHand = string.Join(", ", _computer.PlayerCards.Select(card => card.ToString()));

                Console.WriteLine($"Computer's hand: {computerHand} \n");

                Console.WriteLine("It's a draw! \n");
            }
            

                Console.WriteLine($"Total victories - Player: {_player.PlayerWins}, Computer: {_computer.PlayerWins} \n");
        }

        private bool IfAcesWin(List<Card> playerCards) 
        {
            int playerAces = playerCards.Count(card => card.Value == CardValue.Ace);

            bool playerTwoAces = playerAces == 2 && playerCards.Count == 2;

            return playerTwoAces;
        }
        private void NewGame() 
        {
            _deck = new Deck();

            _deck.Shuffle();

            _player.PlayerCards.Clear();

            _computer.PlayerCards.Clear();

            _player.AcesWin = false;

            _computer.AcesWin = false;

            _player.PlayerPoints = 0;

            _computer.PlayerPoints = 0;

            _player.PlayerContinues = true;

            _computer.PlayerContinues = true;
        }
    } 
}
