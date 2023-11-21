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
        private List<Card> cards;

        public Deck()
        {
            cards = new List<Card>();

            foreach (CardSuit suit in Enum.GetValues(typeof(CardSuit)))
            {
                foreach (CardValue value in Enum.GetValues(typeof(CardValue)))
                {
                    cards.Add(new Card(suit, value));
                }
            }
        }

        public void Shuffle()
        {
            Random random = new Random();

            int count = cards.Count;

            while (count > 1)
            {
                count--;

                int chosenCardIndex = random.Next(count + 1);

                Card value = cards[chosenCardIndex];

                cards[chosenCardIndex] = cards[count];

                cards[count] = value;
            }

            Console.WriteLine($"Deck was shuffled!\n");
        }

        public Card DrawCard()
        {
            if (cards.Count == 0)
            {
                Console.WriteLine("No more cards in the deck.\n");
            }

            Card cardToDraw = cards[0];

            cards.RemoveAt(0);

            return cardToDraw;
        }

        public int[] FindAces()
        {
            List<int> acesPositions = new List<int>();

            for (int i = 0; i < cards.Count; i++)
            {
                if (cards[i].Value == CardValue.Ace)
                {
                    acesPositions.Add(i);
                }
            }
            Console.WriteLine("Aces was found!");

            return acesPositions.ToArray();
        }

        public void MoveSpadesToTop()
        {
            int startIndex = 0;

            for (int i = 0; i < cards.Count; i++)
            {
                if (cards[i].Suit == CardSuit.Spades)
                {
                    Card temp = cards[i];

                    cards[i] = cards[startIndex];

                    cards[startIndex] = temp;

                    startIndex++;
                }
            }

            Console.WriteLine("\nAll spades on top!\n");
        }

        public void SortDeck()
        {
            var sortedCards = cards.OrderBy(card => card.Suit).ThenBy(card => card.Value).ToList();

            cards = sortedCards;

            Console.WriteLine("Deck was sorted!\n");
        }
    }
}


