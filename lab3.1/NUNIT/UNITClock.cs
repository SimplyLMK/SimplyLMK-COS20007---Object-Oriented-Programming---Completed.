

namespace Clock
{
    public class ClockTest
    {
       

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Clock_Initialize()
        {
            Assert.AreEqual("00:00:00", Clock.Show());
        }

        [Test]
        public void TestReset()
        {
            int i = 0;
            while(i<86340)
            {
                Clock.Tick();
            }
            //Clock.ResetCounter();
        }

        [TestCase(0, "00:00:00")]
        [TestCase(60, "00:01:00")]
        [TestCase(120, "00:02:00")]
        [TestCase(86400, "23:59:00")]

        public void TestShow(int tick, string show_time)
        {
            int i;
            for (i = 0; i < 10; i++)
            {
                Clock.Tick();
            }
            Assert.AreEqual(show_time, Clock.Show());

        }

        [TestCase("00:01:00", "00:00:59")] 
        [TestCase("01:00:00", "00:59:59")] 
        [TestCase("00:00:00", "23:59:59")]

        
        [Test]
        [TestCase("00:01:00", "00:00:59")]
        public void TestClockRollover(string real, string expected)
        {
            
            Clock.GetCounter(0).Set(59);
            Clock.GetCounter(1).Set(59);
            Clock.GetCounter(2).Set(23);


            Clock.Tick();


            Assert.AreEqual("00:00:00", Clock.Show());


            int hours = int.Parse(expected.Substring(0, 2));
            int minutes = int.Parse(expected.Substring(3, 2));
            int seconds = int.Parse(expected.Substring(6, 2));
            Clock.GetCounter(0).Set(seconds);
            Clock.GetCounter(1).Set(minutes);
            Clock.GetCounter(2).Set(hours);


            Clock.Tick();


            Assert.AreEqual(real, Clock.Show());
        }

    }
}
