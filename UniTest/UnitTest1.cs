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
            Assert.IsNotNull(helper,"new helper() should not be null");
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
    }
}