using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using CardClasses;

namespace CarUnitTests
{
	[TestFixture]
    public class HandTests
    {
		[Test]
		public void TestConstructor()
		{

		}

		[Test]
		public void TestAddCard()
		{

		}

		[Test]
		public void TestNumberOfCards()
		{
			Deck testDeck = new Deck();
			Hand testHand = new Hand(testDeck, 5);

			Assert.AreEqual(5, testHand.NumCards);
		}
    }
}
