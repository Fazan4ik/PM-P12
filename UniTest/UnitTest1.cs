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
            Dictionary<String[], String> testCases = new()
            {
                {new[]{"/home","index" }, "/home/index"},
                {new[]{"/home/","/index" } ,"/home/index"},
                {new[]{"home/","index" }, "/home/index"},
                {new[]{"/home///","index" }, "/home/index"},
                {new[]{"////home/","/index" } ,"/home/index"},
                {new[]{"home/","////index" }, "/home/index"},
                {new[]{"/shop/cart/user/../123", "" }, "/shop/cart/123"}
            };
            foreach (var testCase in testCases)
            {
                Assert.AreEqual(
                    testCase.Value,
                    helper.CombineUrl(testCase.Key[0], testCase.Key[1]), $"{testCase.Value} -- {testCase.Key[0]} + {testCase.Key[1]}");
            }
        }
        [TestMethod]
        public void CombineUrlMultiTest()
        {
            Helper helper = new();
            Dictionary<String[], String> testCases = new()
            {
                { new[] { "/home",  "/index", "/123"  }, "/home/index/123"  },
                { new[] { "/shop/", "/cart/", "123/"  }, "/shop/cart/123"   },
                { new[] { "auth/",  "logout", "/123/" }, "/auth/logout/123" },
                { new[] { "forum",  "topic/", "123"   }, "/forum/topic/123" },
            };
            foreach (var testCase in testCases)
            {
                Assert.AreEqual(
                    testCase.Value,
                    helper.CombineUrl(testCase.Key),
                    $"{testCase.Value} -- {testCase.Key[0]} + {testCase.Key[1]}"
                );
            }
        }

        [TestMethod]
        public void CombineUrlExceptionTest()
        {
            Helper helper = new();
            Assert.AreEqual("/home", helper.CombineUrl("/home", null!));

            var ex = Assert.ThrowsException<ArgumentException>(
                () => helper.CombineUrl(null!, null!)
            );
            Assert.AreEqual("All arguments are null", ex.Message);

            Assert.AreEqual(
                "Non-Null argument after Null one",
                Assert.ThrowsException<ArgumentException>(
                    () => helper.CombineUrl(null!, "/subsection")
                ).Message);
        }
    }
}