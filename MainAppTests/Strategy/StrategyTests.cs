namespace MainApp.Tests
{
    using NUnit.Framework;

    [TestFixture()]
    public class StrategyTests
    {
        private IPlateau plateau;

        [SetUp]
        public void Init()
        {
            var rower = new Rower(1, 1, 1, new East());
            this.plateau = new MarsPlateau(5, 5);
            this.plateau.RowerList.AddItem(rower);
        }

        [TestCase(5, 5)]
        [TestCase(4, 5)]
        [TestCase(3, 5)]
        [TestCase(2, 5)]
        [TestCase(1, 5)]
        [TestCase(0, 5)]
        public void When_call_IsOutOfMap_must_return_false(int finalValue, int controlValue)
        {
            var strategy = new Strategy(this.plateau, 1);

            var sut = strategy.IsOutOfMap(finalValue, controlValue);

            Assert.IsFalse(sut);
        }

        [TestCase(6, 5)]
        [TestCase(-1, 5)]
        public void When_call_IsOutOfMap_must_return_true(int finalValue, int controlValue)
        {
            var strategy = new Strategy(this.plateau, 1);

            var sut = strategy.IsOutOfMap(finalValue, controlValue);

            Assert.IsTrue(sut);
        }

        [TestCase(1, 1)]
        public void When_call_IsCollisionCase_must_return_true(int rowerX, int rowerY)
        {
            var newRower = new Rower(2, rowerX, rowerY, new West());
            var strategy = new Strategy(this.plateau, 1);

            var sut = strategy.IsCollisionCase(newRower);

            Assert.IsTrue(sut);
        }

        [TestCase(2, 1)]
        public void When_call_IsCollisionCase_must_return_false(int rowerX, int rowerY)
        {
            var newRower = new Rower(2, rowerX, rowerY, new West());
            var strategy = new Strategy(this.plateau, 1);

            var sut = strategy.IsCollisionCase(newRower);

            Assert.IsFalse(sut);
        }
    }
}