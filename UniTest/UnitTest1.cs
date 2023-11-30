using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using App;

namespace UniTest
{
    [TestClass]
    public class HelperTest
    {
        [TestMethod]
        public void EllipsisTest()
        {
            Helper helper = new();
            Assert.IsNotNull(helper, "new helper() should not be null");
            Assert.AreEqual("He...", helper.Ellipsis("Hello, World", 5));
            Assert.AreEqual("Hel...", helper.Ellipsis("Hello, World", 6));
        }

        [TestMethod]
        public void FinalizeTest()
        {
            Helper helper = new();
            Assert.IsNotNull(helper, "new helper() should not be null");
            Assert.AreEqual("Hello, World.", helper.Finalize("Hello, World"));
            Assert.AreEqual("Hello, World.", helper.Finalize("Hello, World."));
        }
        [TestMethod]
        public void CombineUrlTest()
        {
            Helper helper = new();
            Dictionary<string[], string> testCases = new()
            {
                { new[] { "/home", "index" }, "/home/index" },
                { new[] { "/shop", "/cart" }, "/shop/cart" },
                { new[] { "auth/", "logout" }, "/auth/logout" },
                { new[] { "forum/", "topic/" }, "/forum/topic" },
                { new[] { "/home///", "index" }, "/home/index" },
                { new[] { "///home/", "/index" }, "/home/index" },
                { new[] { "home/", "////index" }, "/home/index" },
                { new[] { "///home/////", "////index///" }, "/home/index" },
            };
            foreach (var testCase in testCases)
            {
                Assert.AreEqual(
                    testCase.Value,
                    helper.CombineUrl(testCase.Key[0], testCase.Key[1]),
                    $"{testCase.Key[0]} - {testCase.Key[1]}"
                );
            }
        }
    }
}