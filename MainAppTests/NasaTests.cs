namespace MainApp.Tests
{
    using System.Linq;

    using MainApp.CircularLinkedList;

    using Moq;

    using NUnit.Framework;

    [TestFixture()]
    public class NasaTests
    {
        private Mock<IPlateau> mockPlatau;

        private Nasa nasa;

        [SetUp]
        public void Init()
        {
            this.mockPlatau = new Mock<IPlateau>() { CallBase = true };
            this.mockPlatau.Setup(x => x.RowerList).Returns(new SimpleCircularList<IRower>());
            this.nasa = new Nasa(this.mockPlatau.Object);
        }

        [Test]
        public void When_call_AddRower_success()
        {
            var sut = this.nasa.AddRower(1, 6, 10, new South());

            Assert.IsNotNull(this.mockPlatau.Object.RowerList);
            Assert.Greater(this.mockPlatau.Object.RowerList.Count(), 0);
            Assert.IsTrue(this.mockPlatau.Object.RowerList.Contains(sut));
        }

        [TestCase("LMRRRM")]
        public void when_call_ExecuteCommands_is_12(string commandText)
        {
            var rower = new Rower(1, 2, 3, new North());
            var plateau = new MarsPlateau(5, 5);
            plateau.RowerList.AddItem(rower);
            var strategy = new Strategy(plateau, 1);
            var nasa =new Nasa(plateau);

            nasa.ExecuteCommands(commandText, strategy);

            Assert.AreEqual(rower.X, 1);
            Assert.AreEqual(rower.Y, 2);
        }
    }
}


//var commands = new List<RowerCommand>()
//                               {
//                                   new LeftCommand(rower),
//                                   new MoveCommand(rower, strategy),
//                                   new RightCommand(rower),
//                                   new RightCommand(rower),
//                                   new RightCommand(rower),
//                                   new MoveCommand(rower, strategy)
//                               };