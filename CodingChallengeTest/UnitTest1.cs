using CodingChallenge;

namespace CodingChallengeTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void FACTORIAL_TEST()
        {
            var resp = Algorithms.GetFactorial(5);
            Assert.AreEqual(120, resp);
        }

        [TestMethod]
        public void FORMAT_SEPARATOR_TEST()
        {
            var resp = Algorithms.FormatSeparators(new []{"one","two","three"});
            Assert.AreEqual("one,two,three", resp);
        }

        [TestMethod]
        public void AFRICAN_SWALLOW_NO_LOAD_TEST()
        {
            var velocity = SwallowFactory.GetAirspeedVelocity(SwallowType.African,SwallowLoad.None);
            Assert.AreEqual(22, velocity);
        }

        [TestMethod]
        public void AFRICAN_SWALLOW_COCONUT_TEST()
        {
            var velocity = SwallowFactory.GetAirspeedVelocity(SwallowType.African, SwallowLoad.Coconut);
            Assert.AreEqual(18, velocity);
        }

        [TestMethod]
        public void EUROPEAN_SWALLOW_NO_LOAD_TEST()
        {
            var velocity = SwallowFactory.GetAirspeedVelocity(SwallowType.European, SwallowLoad.None);
            Assert.AreEqual(20, velocity);
        }

        [TestMethod]
        public void EUROPEAN_SWALLOW_COCONUT_TEST()
        {
            var velocity = SwallowFactory.GetAirspeedVelocity(SwallowType.European, SwallowLoad.Coconut);
            Assert.AreEqual(16, velocity);
        }

        [TestMethod]
        public void CanInitializeCollection()
        {
            var debug = new SyncDebug();
            var items = new List<string> { "one", "two" };
            var result = debug.InitializeList(items);
            Assert.AreEqual(items.Count, result.Count);
        }

        [TestMethod]
        public void ItemsOnlyInitializeOnce()
        {
            var debug = new SyncDebug();
            var count = 0;
            var dictionary = debug.InitializeDictionary(i =>
            {
                Thread.Sleep(1);
                Interlocked.Increment(ref count);
                return i.ToString();
            });

            Assert.AreEqual(100, count);
            Assert.AreEqual(100, dictionary.Count);
        }
    }
}
