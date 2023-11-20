using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{

     public struct Card
    {
        public string _value { get; set; }

        public string _suit { get; set; }

        public static readonly Dictionary<string, string> SuitSymbols = new Dictionary<string, string>
        {
            ["Hearts"] = "\u2665", 

            ["Diamonds"] = "\u2666",

            ["Clubs"] = "\u2663", 

            ["Spades"] = "\u2660" 
        };

        public Card(string suit, string value)
        {
            if (!SuitSymbols.ContainsKey(suit))
                throw new ArgumentException("Invalid suit.", nameof(suit));

            _suit = SuitSymbols[suit];
            _value = value;
        }

        public int GetCardValue()
        {
            switch (_value)
            {
                case "Ace": return 11;

                case "King": return 4;

                case "Queen": return 3;

                case "Jack": return 2;

                default: return int.Parse(_value);
            }
        }

        public override string ToString()
        {
            return $"{_value} {_suit}";
        }
    }
}
