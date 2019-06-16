namespace MGU.Console.Tests.UtilitiesTests.InputPositionCalculatorTests
{
    using System.Collections.Generic;
    using System.Reflection;
    using Interfaces;
    using Interfaces.Input;
    using Mocks;
    using NUnit.Framework;
    using Utilities.Input;

    [TestFixture]
    public class CalculatePositionInInputBufferTests
    {
        private IInputBuffer CreateNewInputBuffer()
        {
            var rows = this.CreateRows(new[] { 11, 4, 5, 0 });
            var inputBuffer = new InputBuffer("");
            var rowsFieldInfo = inputBuffer.GetType().GetField("_rows", BindingFlags.NonPublic | BindingFlags.Instance);
            rowsFieldInfo.SetValue(inputBuffer, rows);
            return inputBuffer;
        }

        private readonly char[] _testCharacters = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O' };

        private List<List<char>> CreateRows(IReadOnlyList<int> columnCounts)
        {
            var rows = new List<List<char>>();
            for (var i = 0; i < columnCounts.Count; i++)
                rows.Add(new List<char>(new string(this._testCharacters[i], columnCounts[i]) + "\n"));
            return rows;
        }

        private IConsoleInformation CreateNewConsoleExtensionMock() => new ConsoleInformationMock(5);

        private IInputPositionCalculator CreateNewInputPositionCalculator()
        {
            var inputPositionCalculator = new InputPositionCalculator(this.CreateNewInputBuffer(), 0, this.CreateNewConsoleExtensionMock());
            return inputPositionCalculator;
        }

        #region FirstLine

        [Test]
        public void Position_0_0_InTestInputManger_1_EqualsPosition_0_0_InInputBuffer()
        {
            var inputPositionCalculator = this.CreateNewInputPositionCalculator();
            var (bufferRowIndex, bufferColumnIndex) = inputPositionCalculator.CalculatePositionInInputBuffer(0, 0);
            Assert.That(bufferRowIndex, Is.EqualTo(0));
            Assert.That(bufferColumnIndex, Is.EqualTo(0));
        }

        [Test]
        public void Position_0_1_InTestInputManger_1_EqualsPosition_0_1_InInputBuffer()
        {
            var inputPositionCalculator = this.CreateNewInputPositionCalculator();
            var (bufferRowIndex, bufferColumnIndex) = inputPositionCalculator.CalculatePositionInInputBuffer(0, 1);
            Assert.That(bufferRowIndex, Is.EqualTo(0));
            Assert.That(bufferColumnIndex, Is.EqualTo(1));
        }

        [Test]
        public void Position_0_2_InTestInputManger_1_EqualsPosition_0_2_InInputBuffer()
        {
            var inputPositionCalculator = this.CreateNewInputPositionCalculator();
            var (bufferRowIndex, bufferColumnIndex) = inputPositionCalculator.CalculatePositionInInputBuffer(0, 2);
            Assert.That(bufferRowIndex, Is.EqualTo(0));
            Assert.That(bufferColumnIndex, Is.EqualTo(2));
        }

        [Test]
        public void Position_0_3_InTestInputManger_1_EqualsPosition_0_3_InInputBuffer()
        {
            var inputPositionCalculator = this.CreateNewInputPositionCalculator();
            var (bufferRowIndex, bufferColumnIndex) = inputPositionCalculator.CalculatePositionInInputBuffer(0, 3);
            Assert.That(bufferRowIndex, Is.EqualTo(0));
            Assert.That(bufferColumnIndex, Is.EqualTo(3));
        }

        [Test]
        public void Position_0_4_InTestInputManger_1_EqualsPosition_0_4_InInputBuffer()
        {
            var inputPositionCalculator = this.CreateNewInputPositionCalculator();
            var (bufferRowIndex, bufferColumnIndex) = inputPositionCalculator.CalculatePositionInInputBuffer(0, 4);
            Assert.That(bufferRowIndex, Is.EqualTo(0));
            Assert.That(bufferColumnIndex, Is.EqualTo(4));
        }

        [Test]
        public void Position_1_0_InTestInputManger_1_EqualsPosition_0_5_InInputBuffer()
        {
            var inputPositionCalculator = this.CreateNewInputPositionCalculator();
            var (bufferRowIndex, bufferColumnIndex) = inputPositionCalculator.CalculatePositionInInputBuffer(1, 0);
            Assert.That(bufferRowIndex, Is.EqualTo(0));
            Assert.That(bufferColumnIndex, Is.EqualTo(5));
        }

        [Test]
        public void Position_1_1_InTestInputManger_1_EqualsPosition_0_6_InInputBuffer()
        {
            var inputPositionCalculator = this.CreateNewInputPositionCalculator();
            var (bufferRowIndex, bufferColumnIndex) = inputPositionCalculator.CalculatePositionInInputBuffer(1, 1);
            Assert.That(bufferRowIndex, Is.EqualTo(0));
            Assert.That(bufferColumnIndex, Is.EqualTo(6));
        }

        [Test]
        public void Position_1_2_InTestInputManger_1_EqualsPosition_0_7_InInputBuffer()
        {
            var inputPositionCalculator = this.CreateNewInputPositionCalculator();
            var (bufferRowIndex, bufferColumnIndex) = inputPositionCalculator.CalculatePositionInInputBuffer(1, 2);
            Assert.That(bufferRowIndex, Is.EqualTo(0));
            Assert.That(bufferColumnIndex, Is.EqualTo(7));
        }

        [Test]
        public void Position_1_3_InTestInputManger_1_EqualsPosition_0_8_InInputBuffer()
        {
            var inputPositionCalculator = this.CreateNewInputPositionCalculator();
            var (bufferRowIndex, bufferColumnIndex) = inputPositionCalculator.CalculatePositionInInputBuffer(1, 3);
            Assert.That(bufferRowIndex, Is.EqualTo(0));
            Assert.That(bufferColumnIndex, Is.EqualTo(8));
        }

        [Test]
        public void Position_1_4_InTestInputManger_1_EqualsPosition_0_9_InInputBuffer()
        {
            var inputPositionCalculator = this.CreateNewInputPositionCalculator();
            var (bufferRowIndex, bufferColumnIndex) = inputPositionCalculator.CalculatePositionInInputBuffer(1, 4);
            Assert.That(bufferRowIndex, Is.EqualTo(0));
            Assert.That(bufferColumnIndex, Is.EqualTo(9));
        }

        [Test]
        public void Position_2_0_InTestInputManger_1_EqualsPosition_0_10_InInputBuffer()
        {
            var inputPositionCalculator = this.CreateNewInputPositionCalculator();
            var (bufferRowIndex, bufferColumnIndex) = inputPositionCalculator.CalculatePositionInInputBuffer(2, 0);
            Assert.That(bufferRowIndex, Is.EqualTo(0));
            Assert.That(bufferColumnIndex, Is.EqualTo(10));
        }

        [Test]
        public void Position_2_1_InTestInputManger_1_EqualsPosition_0_11_InInputBuffer()
        {
            var inputPositionCalculator = this.CreateNewInputPositionCalculator();
            var (bufferRowIndex, bufferColumnIndex) = inputPositionCalculator.CalculatePositionInInputBuffer(2, 1);
            Assert.That(bufferRowIndex, Is.EqualTo(0));
            Assert.That(bufferColumnIndex, Is.EqualTo(11));
        }

        [Test]
        public void Position_2_2_InTestInputManger_1_EqualsPosition_0_12_InInputBuffer()
        {
            var inputPositionCalculator = this.CreateNewInputPositionCalculator();
            var (bufferRowIndex, bufferColumnIndex) = inputPositionCalculator.CalculatePositionInInputBuffer(2, 2);
            Assert.That(bufferRowIndex, Is.EqualTo(0));
            Assert.That(bufferColumnIndex, Is.EqualTo(12));
        }

        #endregion

        #region SecondLine

        [Test]
        public void Position_3_0_InTestInputManger_1_EqualsPosition_1_0_InInputBuffer()
        {
            var inputPositionCalculator = this.CreateNewInputPositionCalculator();
            var (bufferRowIndex, bufferColumnIndex) = inputPositionCalculator.CalculatePositionInInputBuffer(3, 0);
            Assert.That(bufferRowIndex, Is.EqualTo(1));
            Assert.That(bufferColumnIndex, Is.EqualTo(0));
        }

        [Test]
        public void Position_3_1_InTestInputManger_1_EqualsPosition_1_1_InInputBuffer()
        {
            var inputPositionCalculator = this.CreateNewInputPositionCalculator();
            var (bufferRowIndex, bufferColumnIndex) = inputPositionCalculator.CalculatePositionInInputBuffer(3, 1);
            Assert.That(bufferRowIndex, Is.EqualTo(1));
            Assert.That(bufferColumnIndex, Is.EqualTo(1));
        }

        [Test]
        public void Position_3_2_InTestInputManger_1_EqualsPosition_1_2_InInputBuffer()
        {
            var inputPositionCalculator = this.CreateNewInputPositionCalculator();
            var (bufferRowIndex, bufferColumnIndex) = inputPositionCalculator.CalculatePositionInInputBuffer(3, 2);
            Assert.That(bufferRowIndex, Is.EqualTo(1));
            Assert.That(bufferColumnIndex, Is.EqualTo(2));
        }

        [Test]
        public void Position_3_3_InTestInputManger_1_EqualsPosition_1_3_InInputBuffer()
        {
            var inputPositionCalculator = this.CreateNewInputPositionCalculator();
            var (bufferRowIndex, bufferColumnIndex) = inputPositionCalculator.CalculatePositionInInputBuffer(3, 3);
            Assert.That(bufferRowIndex, Is.EqualTo(1));
            Assert.That(bufferColumnIndex, Is.EqualTo(3));
        }

        [Test]
        public void Position_3_4_InTestInputManger_1_EqualsPosition_1_4_InInputBuffer()
        {
            var inputPositionCalculator = this.CreateNewInputPositionCalculator();
            var (bufferRowIndex, bufferColumnIndex) = inputPositionCalculator.CalculatePositionInInputBuffer(3, 4);
            Assert.That(bufferRowIndex, Is.EqualTo(1));
            Assert.That(bufferColumnIndex, Is.EqualTo(4));
        }

        #endregion

        #region ThirdLine

        [Test]
        public void Position_4_0_InTestInputManger_1_EqualsPosition_2_0_InInputBuffer()
        {
            var inputPositionCalculator = this.CreateNewInputPositionCalculator();
            var (bufferRowIndex, bufferColumnIndex) = inputPositionCalculator.CalculatePositionInInputBuffer(4, 0);
            Assert.That(bufferRowIndex, Is.EqualTo(2));
            Assert.That(bufferColumnIndex, Is.EqualTo(0));
        }

        [Test]
        public void Position_4_1_InTestInputManger_1_EqualsPosition_2_1_InInputBuffer()
        {
            var inputPositionCalculator = this.CreateNewInputPositionCalculator();
            var (bufferRowIndex, bufferColumnIndex) = inputPositionCalculator.CalculatePositionInInputBuffer(4, 1);
            Assert.That(bufferRowIndex, Is.EqualTo(2));
            Assert.That(bufferColumnIndex, Is.EqualTo(1));
        }

        [Test]
        public void Position_4_2_InTestInputManger_1_EqualsPosition_2_2_InInputBuffer()
        {
            var inputPositionCalculator = this.CreateNewInputPositionCalculator();
            var (bufferRowIndex, bufferColumnIndex) = inputPositionCalculator.CalculatePositionInInputBuffer(4, 2);
            Assert.That(bufferRowIndex, Is.EqualTo(2));
            Assert.That(bufferColumnIndex, Is.EqualTo(2));
        }

        [Test]
        public void Position_4_3_InTestInputManger_1_EqualsPosition_2_3_InInputBuffer()
        {
            var inputPositionCalculator = this.CreateNewInputPositionCalculator();
            var (bufferRowIndex, bufferColumnIndex) = inputPositionCalculator.CalculatePositionInInputBuffer(4, 3);
            Assert.That(bufferRowIndex, Is.EqualTo(2));
            Assert.That(bufferColumnIndex, Is.EqualTo(3));
        }

        [Test]
        public void Position_4_4_InTestInputManger_1_EqualsPosition_2_4_InInputBuffer()
        {
            var inputPositionCalculator = this.CreateNewInputPositionCalculator();
            var (bufferRowIndex, bufferColumnIndex) = inputPositionCalculator.CalculatePositionInInputBuffer(4, 4);
            Assert.That(bufferRowIndex, Is.EqualTo(2));
            Assert.That(bufferColumnIndex, Is.EqualTo(4));
        }

        [Test]
        public void Position_5_0_InTestInputManger_1_EqualsPosition_2_5_InInputBuffer()
        {
            var inputPositionCalculator = this.CreateNewInputPositionCalculator();
            var (bufferRowIndex, bufferColumnIndex) = inputPositionCalculator.CalculatePositionInInputBuffer(5, 0);
            Assert.That(bufferRowIndex, Is.EqualTo(2));
            Assert.That(bufferColumnIndex, Is.EqualTo(5));
        }

        [Test]
        public void Position_5_1_InTestInputManger_1_EqualsPosition_2_6_InInputBuffer()
        {
            var inputPositionCalculator = this.CreateNewInputPositionCalculator();
            var (bufferRowIndex, bufferColumnIndex) = inputPositionCalculator.CalculatePositionInInputBuffer(5, 1);
            Assert.That(bufferRowIndex, Is.EqualTo(2));
            Assert.That(bufferColumnIndex, Is.EqualTo(6));
        }

        #endregion

        #region FourthLine

        [Test]
        public void Position_6_0_InTestInputManger_1_EqualsPosition_3_5_InInputBuffer()
        {
            var inputPositionCalculator = this.CreateNewInputPositionCalculator();
            var (bufferRowIndex, bufferColumnIndex) = inputPositionCalculator.CalculatePositionInInputBuffer(6, 0);
            Assert.That(bufferRowIndex, Is.EqualTo(3));
            Assert.That(bufferColumnIndex, Is.EqualTo(0));
        }

        #endregion
    }
}