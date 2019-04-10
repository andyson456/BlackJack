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
			Deck testDeck = new Deck();
			Hand testHand1 = new Hand(testDeck, 6);
		}

		[Test]
		public void TestAddCard()
		{

		}
    }
}
