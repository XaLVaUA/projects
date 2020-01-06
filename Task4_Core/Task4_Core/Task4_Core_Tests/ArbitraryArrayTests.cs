using System;
using NUnit.Framework;
using NUnit.Framework.Internal;
using Task4_Core;

namespace Task4_Core_Tests
{
    [TestFixture]
    public class ArbitraryArrayTests
    {
        private int[] _intArray = { 2, 4, 3, 7, 9, 4 };

        [Test]
        public void ElementValidArgumentGetTest()
        {
            //arrange
            var intArbitraryArray = new ArbitraryArray<int>(-2, _intArray);

            //act
            var result = true;
            {
                int i = -2;
                foreach (var number in _intArray)
                {
                    if (number != intArbitraryArray[i])
                    {
                        result = false;
                        break;
                    }
                    ++i;
                }
            }

            //assert
            Assert.AreEqual(true, result);
        }

        [Test]
        public void ElementInvalidArgumentGetTest([Values(-3, 4)]int index)
        {
            var intArbitraryArray = new ArbitraryArray<int>(-2, _intArray);
            Assert.Throws(typeof(ArgumentOutOfRangeException), () => intArbitraryArray.GetElement(index));
        }

        [Test]
        public void ElementSetElement()
        {
            //arrange
            var intArbitraryArray = new ArbitraryArray<int>(-2, 3);

            //act
            intArbitraryArray[-1] = 8;
            var item = intArbitraryArray[-1];

            //assert
            Assert.AreEqual(8, item);
        }
    }
}