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
	public class BJHandTests
	{
		Hand def;
		BJHand sixC;
		Deck defD;
		Card aC;
		Card qH;
		Card d2;
		Card randC;
		BJHand BJDef;
		BJHand BJDefD;

		[SetUp]
		public void HandSetups()
		{
			def = new Hand();
			defD = new Deck();
			sixC = new BJHand(defD, 6);
			aC = new Card(1, 1);
			qH = new Card(12, 3);
			d2 = new Card(2, 2);
			randC = new Card(3, 3);
			BJDef = new BJHand();
			BJDefD = new BJHand(defD, 5);
		}

		[Test]
		public void TestingConstructor()
		{
			Assert.AreEqual(5, BJDefD.NumCards);
		}

		// Something is wrong in the card class
		// All cards that aren't an Ace are returning a value of 0
		[Test]
		public void TestingScore()
		{
			Assert.AreEqual(24, sixC.Score);
		}

		[Test]
		public void TestingHasAce()
		{
			BJDef.AddCard(aC);
			Assert.IsTrue(BJDef.HasAce);
			BJDef.Discard(BJDef.IndexOf(aC));
			Assert.IsFalse(BJDef.HasAce);
			BJDef.AddCard(qH);
			Assert.IsFalse(BJDef.HasAce);
		}

		[Test]
		public void TestingIsBusted()
		{
			BJDef.AddCard(aC);
			BJDef.AddCard(qH);
			BJDef.AddCard(d2);
			Assert.IsFalse(BJDef.IsBusted);
		}

		[Test]
		public void TestingCardValues()
		{
			Assert.AreEqual(12, qH.Value);
			Assert.AreEqual(2, d2.Value);
			Assert.AreNotEqual(4, d2.Value);
		}
	}
}
