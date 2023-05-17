﻿using ClickerWithoutAnEngine.Math;
using NUnit.Framework;

namespace ClickerWithoutAnEngine.Tests.IdleNumber
{
    public sealed class NegateTests
    {
        [Test]
        public void IsNegateCorrect1()
        {
            var first = new Math.IdleNumber(10, -2);
            var result = first.Negate();
            Assert.That(result.Number == -1 && result.Exponent == -1);
        }
        
        [Test]
        public void IsNegateCorrect2()
        {
            var value = new Math.IdleNumber(-10, 2);
            var result = value.Negate();
            Assert.That(result.Number == 1 && result.Exponent == 3);
        }
        
        [Test]
        public void IsNegateCorrect3()
        {
            var value = new Math.IdleNumber();
            var result = value.Negate();
            Assert.That(result.Number == 0 && result.Exponent == 0);
        }
    }
}