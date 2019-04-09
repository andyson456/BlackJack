using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardClasses
{
    public class BJHand : Hand
    {
        public BJHand() : base() { }

        public BJHand(Deck d, int numCards) : base(d, numCards)
        { 
        }

		// for score...
		// foreach card in hand
		//   if card isAFaceCard
		//		score += 10
		//   else
		//      score += value of card

		// if HasAce and score <= 11
		//    score += 10
		public int Score
        {
            get 
            {
				int score = 0;
				foreach (Card card in cards)
					if (card.IsFaceCard())
						score += 10;
					else
						score += card.Value;
				if (HasAce && score <= 11)
					score += 10;

				return score;

            }
        }

        public bool HasAce
        {
            get 
            {
				return HasCard(1);
            }
        }

        public bool IsBusted
        {
            get 
            {
                return Score > 21;
            }
        }
    }
}
