namespace MainApp.Tests
{
    using System;

    using NUnit.Framework;

    [TestFixture()]
    public class DirectionStateTests
    {
        [TestCase("N")]
        [TestCase("W")]
        [TestCase("S")]
        [TestCase("E")]
        public void When_call_CreateCommand_4_direction(string commandText)
        {
            //Arrange

            //Act
            var sut = DirectionState.CreateCommand(commandText);
            //Assert
            Assert.NotNull(sut);
        }

        [TestCase("invalid")]
        public void When_call_CreateCommand_invalid_command(string commandText)
        {
            Assert.Throws(Is.TypeOf<ArgumentOutOfRangeException>(),
                delegate
                {
                    DirectionState.CreateCommand(commandText);
                });
        }
    }
}