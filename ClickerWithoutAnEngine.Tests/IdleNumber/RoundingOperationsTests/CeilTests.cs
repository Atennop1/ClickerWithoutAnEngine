﻿using ClickerWithoutAnEngine.Math;
using NUnit.Framework;

namespace ClickerWithoutAnEngine.Tests.IdleNumber.RoundingOperationsTests
{
    public sealed class CeilTests
    {
        [Test]
        public void IsCeilCorrect1()
        {
            var value = new Math.IdleNumber(512, -2);
            var result = value.Ceil();
            Assert.That(result is { Number: 6f, Exponent: 0 });
        }
        
        [Test]
        public void IsCeilCorrect2()
        {
            var value = new Math.IdleNumber(20);
            var result = value.Ceil();
            Assert.That(result is { Number: 2f, Exponent: 1 });
        }
        
        [Test]
        public void IsCeilCorrect3()
        {
            var value = new Math.IdleNumber(-512, -2);
            var result = value.Ceil();
            Assert.That(result is { Number: -5f, Exponent: 0 });
        }
        
        [Test]
        public void IsCeilCorrect4()
        {
            var value = new Math.IdleNumber(-12, -1);
            var result = value.Ceil();
            Assert.That(result is { Number: -1f, Exponent: 0 });
        }
        
        [Test]
        public void IsCeilCorrect5()
        {
            var value = new Math.IdleNumber();
            var result = value.Ceil();
            Assert.That(result is { Number: 0f, Exponent: 0 });
        }
    }
}