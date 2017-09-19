namespace MainApp.Command.Tests
{
    using System;

    using NUnit.Framework;

    [TestFixture()]
    public class RowerCommandTests
    {
        private IRower rower;

        private IPlateau plateau;

        [SetUp]
        public void Init()
        {
            this.rower = new Rower(1, 1, 1, new East());
            this.plateau = new MarsPlateau(5, 5);
        }

        [TestCase('L')]
        [TestCase('R')]
        [TestCase('M')]
        public void When_call_CreateCommand_valid_commands(char command)
        {
            //Arrange
            Strategy strategy = new Strategy(this.plateau, 1);

            //Act
            var sut = RowerCommand.CreateCommand(command, this.rower, strategy);

            //Assert
            Assert.NotNull(sut);
        }

        [TestCase('T')]
        [TestCase('F')]
        [TestCase('i')]
        public void When_call_CreateCommand_invalid_command(char command)
        {
            //Arrange
            Strategy strategy = new Strategy(this.plateau, 1);

            Assert.Throws(Is.TypeOf<ArgumentOutOfRangeException>(),
                delegate
                {
                    RowerCommand.CreateCommand(command, this.rower, strategy);
                });
        }
    }
}