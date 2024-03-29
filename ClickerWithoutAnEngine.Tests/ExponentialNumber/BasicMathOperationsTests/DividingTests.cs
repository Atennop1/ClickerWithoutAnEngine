﻿using ClickerWithoutAnEngine.Math;
using NUnit.Framework;

namespace ClickerWithoutAnEngine.Tests.ExponentialNumber.BasicMathOperationsTests
{
    public sealed class DividingTests
    {
        [Test]
        public void IsDividingCorrect1()
        {
            var first = new Math.ExponentialNumber(1.2f, 100);
            var second = new Math.ExponentialNumber(100);

            var result = first.Divide(second);
            Assert.That(result is { Number: 1.2f, Exponent: 98 });
        }
        
        [Test]
        public void IsDividingCorrect2()
        {
            var first = new Math.ExponentialNumber(12);
            var second = new Math.ExponentialNumber(-1, 25);

            var result = first.Divide(second);
            Assert.That(result is { Number: -1.2d, Exponent: -24 });
        }
        
        [Test]
        public void IsDividingCorrect3()
        {
            var first = new Math.ExponentialNumber(-12, -100);
            var second = 100f;

            var result = first.Divide(second);
            Assert.That(result is { Number: -1.2d, Exponent: -101 });
        }
        
        [Test]
        public void IsDividingCorrect4()
        {
            var first = new Math.ExponentialNumber(-12, -12);
            var second = new Math.ExponentialNumber(-1, -23);

            var result = first.Divide(second);
            Assert.That(result is { Number: 1.2d, Exponent: 12 });
        }
        
        [Test]
        public void IsDividingCorrect5()
        {
            var first = new Math.ExponentialNumber();
            var second = -100f;

            var result = first.Divide(second);
            Assert.That(result is { Number: 0f, Exponent: 0 });
        }
        
        [Test]
        public void IsDividingCorrect6()
        {
            var first = new Math.ExponentialNumber();
            var second = 100f;

            var result = first.Divide(second);
            Assert.That(result is { Number: 0f, Exponent: 0 });
        }
    }
}