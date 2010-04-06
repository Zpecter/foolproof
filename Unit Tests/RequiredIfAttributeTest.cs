﻿using Foolproof;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Foolproof.UnitTests
{
    [TestClass()]
    public class RequiredIfAttributeTest
    {
        private class Model : ModelBase<RequiredIfAttribute>
        {
            public string Value1 { get; set; }

            [RequiredIf("Value1", "hello")]
            public string Value2 { get; set; }
        }

        [TestMethod()]
        public void IsValidTest()
        {
            var model = new Model() { Value1 = "hello", Value2 = "hello" };
            Assert.IsTrue(model.IsValid("Value2"));
        }

        [TestMethod()]
        public void IsNotValidTest()
        {
            var model = new Model() { Value1 = "hello", Value2 = "" };
            Assert.IsFalse(model.IsValid("Value2"));
        }

        [TestMethod()]
        public void IsNotValidWithValue2NullTest()
        {
            var model = new Model() { Value1 = "hello", Value2 = null };
            Assert.IsFalse(model.IsValid("Value2"));
        }

        [TestMethod()]
        public void IsNotRequiredTest()
        {
            var model = new Model() { Value1 = "goodbye" };
            Assert.IsTrue(model.IsValid("Value2"));
        }

        [TestMethod()]
        public void IsNotRequiredWithValue1NullTest()
        {
            var model = new Model() { Value1 = null };
            Assert.IsTrue(model.IsValid("Value2"));
        }
    }
}
