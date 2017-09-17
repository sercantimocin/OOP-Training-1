namespace MainApp.Tests
{
    using Moq;

    using NUnit.Framework;

    /// <summary>
    /// The nasa tests.
    /// </summary>
    [TestFixture()]
    public class NasaTests
    {
        /// <summary>
        /// The create map test.
        /// </summary>
        [Test]
        public void CreateMapTest()
        {
            var result = Nasa.CreateMap(4, 4);
            Assert.IsAssignableFrom(typeof(MarsPlateau), result);
        }

        /// <summary>
        /// The add rower test.
        /// </summary>
        [Test]
        public void AddRowerTest()
        {
            Mock<MarsPlateau> marsMap = new Mock<MarsPlateau>(2, 2);
            Mock<MoveOneStepStrategy> mockStrategy = new Mock<MoveOneStepStrategy>(marsMap.Object);

            CreateMapTest();

            //var resultRower = Nasa.AddRower(1, 6, 10, Direction.South, mockStrategy.Object);
            //Assert.IsNotNull(resultRower);
        }
    }
}
