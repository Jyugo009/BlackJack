using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    public class Player
    {
        public List<Card> PlayerCards { get; set; }

        public int PlayerPoints {  get; set; }

        public int PlayerWins {  get; set; }

        public bool PlayerContinues { get; set; }

        public bool AcesWin {  get; set; }

        public Player() 
        { 
            PlayerCards = new List<Card>();

            PlayerPoints = 0;

            PlayerWins = 0;

            PlayerContinues = true;
        }
    }
}
