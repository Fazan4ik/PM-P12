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
        public void TestEscapeHtml()
        {
            Helper helper = new();
            Assert.IsNotNull(helper, "new Helper() should not be null");
            Assert.AreEqual(
                "&lt;div class=\"container\"&gt;&lt;p&gt;Hello, &amp; world!&lt;/p&gt;&lt;/div&gt;",
                helper.EscapeHtml("<div class=\"container\"><p>Hello, & world!</p></div>")
            );
            Assert.AreEqual("&lt;p&gt;Hello &amp; Goodbye&lt;/p&gt;", helper.EscapeHtml("<p>Hello & Goodbye</p>"));

            Assert.AreEqual("&lt;Hello world!&gt;", helper.EscapeHtml("<Hello world!>"));
            Assert.AreEqual("&lt;&lt;&lt;&lt;Hellooo&gt;", helper.EscapeHtml("<<<<Hellooo>"));
            Assert.AreEqual("Mark&amp;", helper.EscapeHtml("Mark&"));
        }
        [TestMethod]
        public void EscapeHtmlTestEx()
        {
           /* Helper helper = new();
            Assert.IsNotNull(helper, "new Helper() should not be null");
            var ex = Assert.ThrowsException<ArgumentNullException>(
    () => helper.EscapeHtml(null!)
    );
            Assert.IsTrue(ex.Message.Contains("HTML"), "HTML should not be null");
            var ex1 = Assert.ThrowsException<ArgumentNullException>(
                () => helper.EscapeHtml("<<<<html>ndjngjdn</html>")
                );
            Assert.IsTrue(ex1.Message.Contains("correct"), "This should be a correct html file");
            var ex2 = Assert.ThrowsException<ArgumentNullException>(
                () => helper.EscapeHtml("p>dvd<////p>>>>")
                );
            Assert.IsTrue(ex2.Message.Contains("correct"), "This should be a correct html file");*/
        }
        [TestMethod]
        public void ContainsAttributesTest()
        {
            Helper helper = new();
            Assert.IsNotNull(helper, "new Helper() should not be null");
            Assert.IsTrue(helper.ContainsAttributes("<div style=\"\"></div>"));
            Assert.IsFalse(helper.ContainsAttributes("<div></div>"));
        }

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