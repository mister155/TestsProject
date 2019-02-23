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
            Assert.AreEqual(4, Program.Adding(2,2));
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
            Assert.AreEqual(-8, Program.Delta(1,2,3));
        }

        [Test]
        public void RootExists()
        {
            Assert.AreNotEqual(0, Program.Roots(1,10,3));
        }

        [Test]
        public void FirstRootResult()
        {
            Assert.AreEqual(-2,Program.Roots(3,6,0));
        }
    }
}
