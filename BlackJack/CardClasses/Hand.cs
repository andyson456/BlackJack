using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardClasses
{
    public class Hand
    {
		protected List<Card> cards = new List<Card>();

        public Hand() { }
        public Hand(Deck d, int numCards)
        {
			for (int i = 1; i <= numCards; i++)
				cards.Add(d.Deal());
        }

        public int NumCards
        {
            get
            {
                return cards.Count();
            }
        }

        public void AddCard(Card c)
        {
			cards.Add(c);
        }

        public Card GetCard(int index)
        {
			Card card = new Card();
			for (index = 0; index < cards.Count; index++)
			{
				return cards[index];
			}
            return null;
        }

        public int IndexOf(Card c)
        {
            return cards.IndexOf(c);
        }

        public int IndexOf(int value)
        {
			for (int i = 0; i < cards.Count; i++)
			{
				if (cards[i].Value == value)
					return i;
			}
			return -1;
		}

        public int IndexOf(int value, int suit)
        {
			value = IndexOf(value);
			for (int i = 0; i < cards.Count; i++)
			{
				if (cards[i].Suit == suit)
					return i;
			}
            return -1;
        }

        public bool HasCard(Card c)
        {
			if (cards.Contains(c))
				return true;
			else
				return false;
        }

        public bool HasCard(int value)
        {
            return IndexOf(value) != -1;
        }

        public bool HasCard(int value, int suit)
        {
            return false;
        }

        public Card Discard(int index)
        {
            return null;
        }

        public override string ToString()
        {
            string output = "";
            return output;
        }
    }
}
