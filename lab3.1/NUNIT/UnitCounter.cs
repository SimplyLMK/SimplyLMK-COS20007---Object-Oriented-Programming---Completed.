



namespace Clock
{
    public class Tests
    {
        private Counter _counter;

        [SetUp]
        public void Setup()
        {
            _counter = new Counter("Test counter");
        }

        [Test]
        public void TestName()
        {
            Assert.AreEqual("Test counter", _counter.Name);
        }

        [TestCase(60, 60)]
        [TestCase(100, 100)]

        [Test]
        public void TestIncrement(int tick, int result)
        {
        
            int i;
            for (i = 0; i < tick; i++)
            {
                _counter.Increment();
            }

            Assert.AreEqual(result, _counter.Ticks);
        }

        [Test]
        public void  TestReset()
        {
            _counter.Increment();
            _counter.Reset();
            Assert.AreEqual(0, _counter.Ticks);
        }


    }
}
