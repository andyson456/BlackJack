using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using CardClasses;

namespace CardUnitTests
{
	[TestFixture]
    public class HandTests
	{
		Hand def;
		Hand sixC;
		Deck defD;
		Card aC;
		Card qH;
		Card randC;

		[SetUp]
		public void HandSetups()
		{
			def = new Hand();
			defD = new Deck();
			sixC = new Hand(defD, 6);
			aC = new Card(1, 1);
			qH = new Card(12, 3);
			randC = new Card(3, 3);
		}
	
		[Test]
		public void TestConstructor()
		{
			Assert.AreEqual(6, sixC.NumCards);
		}

		[Test]
		public void TestAddCard()
		{
			List<Card> cards = new List<Card>();
			Hand testHand = new Hand();
			Card testCard = new Card(1, 1);
		}

		[Test]
		public void TestIndexOfMethods()
		{
			sixC.AddCard(aC);
			sixC.AddCard(qH);
			sixC.AddCard(randC);
			Assert.AreEqual(9, sixC.NumCards);
			Assert.AreEqual(0, sixC.IndexOf(aC));
			Assert.AreEqual(7, sixC.IndexOf(qH));
			Assert.AreEqual(8, sixC.IndexOf(randC));
			Assert.AreEqual(9, sixC.NumCards);
			Assert.AreEqual(sixC.IndexOf(1, 1), aC.Value, aC.Suit);
		}

		[Test]
		public void TestNumberOfCards()
		{
			Deck testDeck = new Deck();
			Hand testHand = new Hand(testDeck, 5);

			Assert.AreEqual(5, testHand.NumCards);
		}

		[Test]
		public void TestingHasCard()
		{
			sixC.AddCard(qH);
			Assert.IsTrue(sixC.HasCard(qH));
		}

		[Test]
		public void TestDiscard()
		{
			Card card = new Card(5, 5);
			sixC.AddCard(card);
			Assert.IsTrue(sixC.HasCard(card));
			sixC.Discard(sixC.IndexOf(card));
			Assert.IsFalse(sixC.HasCard(card));

		}
    }
}
