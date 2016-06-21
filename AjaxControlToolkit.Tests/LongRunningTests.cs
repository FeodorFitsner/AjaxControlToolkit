using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace AjaxControlToolkit.Tests {
    [TestFixture]
    public class LongRunningTests {

        [Test]
        public void TestThatRuns5Minutes() {
            Thread.Sleep(TimeSpan.FromMinutes(5));

            Assert.True(true);
        }
    }
}
