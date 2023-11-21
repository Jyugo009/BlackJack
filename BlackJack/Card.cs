using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    public enum CardValue
    {
        Jack = 2,
        Queen = 3,
        King = 4,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        Ten = 10,
        Ace = 11
    }

    public enum CardSuit
    {
        Hearts,
        Diamonds,
        Clubs,
        Spades
    }

    public struct Card
    {
        public CardValue Value { get; set; }
        public CardSuit Suit { get; set; }

        private static readonly Dictionary<CardSuit, string> SuitSymbols = new Dictionary<CardSuit, string>
        {
            [CardSuit.Hearts] = "\u2665", 

            [CardSuit.Diamonds] = "\u2666",

            [CardSuit.Clubs] = "\u2663", 

            [CardSuit.Spades] = "\u2660" 
        };

        public Card(CardSuit suit, CardValue value)
        {
            Suit = suit;

            Value = value;
        }

        public int GetCardValue()
        {
            return (int)Value;
        }

        public override string ToString()
        {
            return $"{Value} {SuitSymbols[Suit]}";
        }
    }
}
