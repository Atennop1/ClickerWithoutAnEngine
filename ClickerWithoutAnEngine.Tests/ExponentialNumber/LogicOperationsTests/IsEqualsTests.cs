﻿using ClickerWithoutAnEngine.Math;
using NUnit.Framework;

namespace ClickerWithoutAnEngine.Tests.ExponentialNumber.LogicOperationsTests
{
    public sealed class IsEqualsTests
    {
        [Test]
        public void IsEqualsCorrect1()
        {
            var first = new Math.ExponentialNumber(0.5f, 2);
            var second = new Math.ExponentialNumber(5f, 1);
            Assert.That(first.IsEquals(second));
        }
        
        [Test]
        public void IsEqualsCorrect2()
        {
            var first = new Math.ExponentialNumber(0.5f, 2);
            var second = 50;
            Assert.That(first.IsEquals(second));
        }
        
        [Test]
        public void IsEqualsCorrect3()
        {
            var first = new Math.ExponentialNumber(0.5f, 2);
            var second = 50f;
            Assert.That(first.IsEquals(second));
        }
        
        [Test]
        public void IsEqualsCorrect4()
        {
            var first = new Math.ExponentialNumber(0.5f, 2);
            var second = 60f;
            Assert.That(!first.IsEquals(second));
        }
    }
}