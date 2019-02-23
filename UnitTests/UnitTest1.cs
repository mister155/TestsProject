using System;
using Castle.DynamicProxy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestsProject;
using Moq;
using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace UnitTests
{
    [TestFixture]
    public class UnitTest1
    {
        private RootsResult _correctResult;
        private double _max_x, _max_y;


        [SetUp]
        public void SetUp()
        {
            _correctResult = new RootsResult();
            {
                _correctResult.X1 = -2;
                _correctResult.X2 = 0;
                _correctResult.Delta = 36;
                _max_y = Double.MaxValue;
                _max_x = Double.MaxValue;
            }
        }

        [TearDown]
        public void TearDown()
        {
            _correctResult = null;
            _max_y = _max_x = 0;
        }

        [Test]
        public void SumResult()
        {
            Assert.AreEqual(4, AddCompute.Adding(2, 2));
        }

        [Test]
        public void IsResultTooBig()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => AddCompute.Adding(_max_y, _max_x));
        }

        [Test]
        public void DeltaResult()
        {
            Assert.AreEqual(-8, DeltaCompute.Delta(1, 2, 3));
        }

//        [Test]
//        public void RootExists()
//        {
//            Assert.AreNotEqual(0, Program.Roots(1, 10, 3));
//        }

        [Test]
        public void AreRootsCalculatedCorrectly()
        {
            var result = Program.Roots(3, 6, 0);

            Assert.AreEqual(_correctResult.X1, result.X1);
            Assert.AreEqual(_correctResult.X2, result.X2);
            Assert.AreEqual(_correctResult.Delta, result.Delta);
        }
    }
}