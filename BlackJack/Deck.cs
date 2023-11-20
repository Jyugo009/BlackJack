using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BlackJack.Card;

namespace BlackJack
{
    public class Deck
    {    
        private Card[] cards;

        string[] suits = { "Hearts", "Diamonds", "Clubs", "Spades" };

        string[] values = { "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };

        public Deck()
        {
            cards = new Card[36];
            
            int index = 0;
            foreach (var suit in suits)
            {
                foreach (var value in values)
                {
                    cards[index] = new Card(suit, value);
                    index++;
                }
            }
        }

        public void Shuffle()
        {
            Random random = new Random();
            int count = cards.Length;
            while (count > 1)
            {
                count--;

                int chosenCardIndex = random.Next(count + 1);

                Card value = cards[chosenCardIndex];

                cards[chosenCardIndex] = cards[count];

                cards[count] = value;
            }
            Console.WriteLine("Deck is shuffled!\n");
        }

        public Card DrawCard()
        {
            if (cards.Length == 0)
            {
               Console.WriteLine("No more cards in the deck.\n");
            }
            
            Card cardToDraw = cards[0];

            for (int i = 1; i < cards.Length; i++)
            {
                cards[i - 1] = cards[i];
            }
            Array.Resize(ref cards, cards.Length - 1);

            return cardToDraw;
        }

        public int[] FindAces()
        {
            List<int> acesPositions = new List<int>();

            for (int i = 0; i < cards.Length; i++)
            {
                if (cards[i]._value == "Ace")
                {
                    acesPositions.Add(i);
                }
            }
            Console.WriteLine("Aces was found!");

            return acesPositions.ToArray();
        }

        public void MoveSpadesToTop()
        {
            Card[] spadesCards = cards.Where(card => card._suit == SuitSymbols["Spades"]).ToArray();
            Card[] otherCards = cards.Where(card => card._suit != SuitSymbols["Spades"]).ToArray();

            Console.WriteLine("\nAll spades on top!\n");

            cards = spadesCards.Concat(otherCards).ToArray();
        }

        public void SortDeck()
        {
            var sortedCards = cards.OrderBy(card => card._suit).ThenBy(card => Array.IndexOf(values, card._value)).ToArray();

            cards = sortedCards;

            Console.WriteLine("Deck was sorted!\n");
        }
    }
}


