using System;
using NUnit.Framework;
using Moq;

namespace EsiTest.StringReverser.UnitTests
{
    public class InputHandlerTests
    {
        private Mock<IStringReverser> _stringReverserMock;
        private Mock<IConsoleReader> _consoleReaderMock;
        private InputHandler _inputHandler;

        [SetUp]
        public void Setup()
        {
            _stringReverserMock = new Mock<IStringReverser>(MockBehavior.Strict);
            _consoleReaderMock = new Mock<IConsoleReader>(MockBehavior.Strict);
            _inputHandler = new InputHandler(_stringReverserMock.Object, _consoleReaderMock.Object);
        }

        /// <summary>
        /// We are verifying input to the string reverser class,
        /// and that what is being input is also being passed down properly.
        /// </summary>
        [Test]
        public void ParseInput_VerifyInputStringIsSameAsPassed()
        {
            //Setup:
            const string inputString = "MyInputIsHere";
            _stringReverserMock.Setup(t => t.ParseInputValue(inputString));
            _stringReverserMock.Setup(t => t.DisplayResults());
            _consoleReaderMock.Setup(t => t.ReadLine()).Returns(inputString);
            _consoleReaderMock.Setup(t => t.ReadKey()).Returns(null);

            //Execute:
            _inputHandler.ParseInput();

            //Assert:
            _stringReverserMock.VerifyAll();
            _consoleReaderMock.VerifyAll();
        }

        /// <summary>
        /// This method is only verifying that the exception is caught because that's the only type
        /// of exception that should be thrown at this point.
        /// </summary>
        [Test]
        public void ParseInput_OutOfRangeException()
        {
            //Setup:
            const string inputString = "MyInputIsHere";
            var testArgumentOutOfRangeException = new ArgumentOutOfRangeException();
            _consoleReaderMock.Setup(t => t.ReadLine()).Throws(testArgumentOutOfRangeException);

            //Execute:
            _inputHandler.ParseInput();

            //Assert:
            _stringReverserMock.VerifyAll();
            _consoleReaderMock.VerifyAll();
        }

        /// <summary>
        /// This method is only verifying that the exception is caught because that's the only type
        /// of exception that should be thrown at this point.
        /// </summary>
        [Test]
        public void ParseInput_UnhandledException()
        {
            //Setup:
            const string inputString = "MyInputIsHere";
            var testException = new Exception();
            _consoleReaderMock.Setup(t => t.ReadLine()).Throws(testException);

            //Execute:
            Exception thrownException = null;
            try
            {
                _inputHandler.ParseInput();
            }
            catch (Exception ex)
            {
                thrownException = ex;
            }

            //Assert:
            _stringReverserMock.VerifyAll();
            _consoleReaderMock.VerifyAll();
            Assert.That(thrownException, Is.Not.Null);
            Assert.That(thrownException, Is.SameAs(testException));
        }
    }
}