namespace example_web_app_tests
{
    [TestClass]
    public sealed class ExampleTests
    {
        [TestMethod]
        public void TestMethod01()
        {
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void TestMethod02()
        {
            Assert.AreEqual(1, 1);
        }

        [TestMethod]
        public void TestMethod03()
        {
            Assert.IsNotNull(new object());
        }

        [TestMethod]
        public void TestMethod04()
        {
            Assert.IsInstanceOfType("string", typeof(string));
        }

        [TestMethod]
        public void TestMethod05()
        {
            Assert.IsTrue(5 > 1);
        }

        [TestMethod]
        public void TestMethod06()
        {
            Assert.AreNotEqual(1, 2);
        }

        [TestMethod]
        public void TestMethod07()
        {
            Assert.IsNull(null);
        }

        [TestMethod]
        public void TestMethod08()
        {
            Assert.IsFalse(false);
        }

        [TestMethod]
        public void TestMethod09()
        {
            Assert.AreSame("test", "test");
        }

        [TestMethod]
        public void TestMethod10()
        {
            Assert.IsTrue(true);
        }
       
    }
}
