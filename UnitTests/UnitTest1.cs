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
        [Test]
        public void SumResult()
        {
            Assert.AreEqual(4,AddCompute.Adding(2, 2));
        }

        //        [Test]
        //        public void FirstDigitIsNull()
        //        {
        //            Assert.That(() => Program.Adding(null, 2), Throws.ArgumentNullException);
        //
        //        }

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

        private RootsResult _correctResult;

        [SetUp]
        public void SetUp()
        {
            _correctResult.X1 = -2;
            _correctResult.X2 = 0;
            _correctResult.Delta = 36;
        }

        [Test]
        public void AreRootCalculatedCorrectly()
        {
            Assert.AreEqual(_correctResult, Program.Roots(3,6,0));
        }
        

        [TearDown]
        public void TearDown()
        {
            _correctResult = null;
        }
    }
}