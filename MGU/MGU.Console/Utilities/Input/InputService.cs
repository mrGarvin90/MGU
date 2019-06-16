namespace MGU.Console.Utilities.Input
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Core.Extensions.If;
    using InputRange;
    using Interfaces.Input;

    public static class InputService
    {
        private static IInputBuffer _buffer;
        private static ICursorInformation _information;
        private static ICursorNavigation _navigation;
        private static IInputPositionCalculator _positionCalculator;
        private static IRange _range;
        private static InsertValidator _inputValidator;
        private static Type _returnType;

        private static int _storedRow;
        private static int _storedColumn;

        private static (int bufferRowIndex, int bufferColumnIndex) CurrentPositionInBuffer() => _positionCalculator
            .CalculatePositionInInputBuffer(Console.CursorTop, Console.CursorLeft);

        private static readonly IReadOnlyDictionary<Type, Type> TypeRangeMapper = new Dictionary<Type, Type>
        {
            { typeof(DateTime), typeof(DateRange) },
            { typeof(decimal), typeof(DecimalRange) },
            { typeof(double), typeof(DoubleRange) },
            { typeof(string), typeof(StringLengthRange) },
            { typeof(int), typeof(IntRange) },
            { typeof(TimeSpan), typeof(TimeSpanRange) },
            { typeof(uint), typeof(UIntRange) }
        };

        private static readonly IReadOnlyDictionary<Type, Type> TypeValidatorMapper = new Dictionary<Type, Type>
        {
            {typeof(DateTime), typeof(DateValidator)},
            {typeof(decimal), typeof(DecimalValidator)},
            {typeof(double), typeof(DoubleValidator)},
            {typeof(int), typeof(IntValidator)},
            {typeof(string), typeof(StringValidator)},
            {typeof(TimeSpan), typeof(TimeSpanValidator)},
            {typeof(uint), typeof(UIntValidator)}
        };

        public static bool PrintNewLineBeforeReturn { get; set; } = true;
        public static bool ClearConsoleBeforeReturn { get; set; }

        static InputService()
        {
            var inputDependenciesFactory = new InputDependenciesFactory(new ConsoleInformation());
            _buffer = inputDependenciesFactory.CreateInputBuffer("");
            _information = inputDependenciesFactory.CreateCursorInformation(_buffer, 0);
            _navigation = inputDependenciesFactory.CreateCursorNavigation(_information);
            _positionCalculator = inputDependenciesFactory.CreateInputPositionCalculator(_buffer, 0);
        }

        private static void SetupFor<T>(string prompt, IRange range)
            where T : IComparable<T>
        {
            _returnType = typeof(T);
            _range = range ?? CreateRange<T>();
            _inputValidator = CreateInputValidator<T>();
            _buffer = _buffer.Reset(prompt.If().Null.Throw().Null(nameof(prompt)));
            _information = _information.Reset(_buffer, Console.CursorTop);
            _navigation = _navigation.Rest(_information);
            _positionCalculator = _positionCalculator.Reset(_buffer, Console.CursorTop);
            Console.Write(prompt);
        }

        private static IRange CreateRange<T>()
            where T : IComparable<T>
        {
            return (BaseRange<T>) Activator.CreateInstance(TypeRangeMapper[typeof(T)]);
        }

        private static InsertValidator CreateInputValidator<T>()
            where T : IComparable<T>
        {
            return (InsertValidator) Activator.CreateInstance(TypeValidatorMapper[typeof(T)]);
        }

        public static bool GetBool(string prompt, bool trueAsDefault = true) => GetNullableBool(prompt, trueAsDefault, false).Value;

        public static bool? GetNullableBool(string prompt, bool trueAsDefault = true) => GetNullableBool(prompt, trueAsDefault, true);

        private static bool? GetNullableBool(string prompt, bool trueAsDefault, bool allowNull)
        {
            Console.Write(prompt);
            while (true)
            {
                var input = Console.ReadKey(true);
                switch (input.Key)
                {
                    case ConsoleKey.Escape:
                        if (allowNull)
                            return Return(null);
                        break;
                    case ConsoleKey.Enter:
                        return Return(trueAsDefault);
                    case ConsoleKey.Y:
                        return Return(true);
                    case ConsoleKey.N:
                        return Return(false);
                }
            }

            bool? Return(bool? output)
            {
                if (output.HasValue)
                {
                    char answerChar;
                    if (output.Value)
                        answerChar = trueAsDefault ? 'Y' : 'y';
                    else
                        answerChar = trueAsDefault ? 'n' : 'N';
                    Console.Write(answerChar);
                }
                return TearDown(output);
            }
        }
        
        public static DateTime GetDate(string prompt, DateRange range = null) => GetStructWithFormat(prompt, range, false).Value;

        public static DateTime? GetNullableDate(string prompt, DateRange range = null) => GetStructWithFormat(prompt, range, true);

        public static TimeSpan GetTimeSpan(string prompt, TimeSpanRange range = null) => GetStructWithFormat(prompt, range, false).Value;

        public static TimeSpan? GetNullableTimeSpan(string prompt, TimeSpanRange range = null) => GetStructWithFormat(prompt, range, true);

        private static T? GetStructWithFormat<T>(string prompt, BaseRange<T> range, bool allowNull)
            where T : struct, IComparable<T>
        {
            SetupFor<T>(prompt, range);
            InsertFormatInBuffer();
            return GetInput<T?>(false, allowNull);

            void InsertFormatInBuffer()
            {
                var format = _range.MinValueToString();
                var (bufferrowindex, buffercolumnindex) = CurrentPositionInBuffer();
                for (var index = 0; index < format.Length; index++)
                    _buffer.Insert(bufferrowindex, buffercolumnindex + index, format[index]);
                ReprintAll();
            }
        }

        public static decimal GetDecimal(string prompt, DecimalRange range = null) => GetNumber(prompt, range, false).Value;

        public static decimal? GetNullableDecimal(string prompt, DecimalRange range = null) => GetNumber(prompt, range, true);

        public static double GetDouble(string prompt, DoubleRange range = null) => GetNumber(prompt, range, false).Value;

        public static double? GetNullableDouble(string prompt, DoubleRange range = null) => GetNumber(prompt, range, true);

        public static int GetInt(string prompt, IntRange range = null) => GetNumber(prompt, range, false).Value;

        public static int? GetNullableInt(string prompt, IntRange range = null) => GetNumber(prompt, range, true);

        public static uint GetUInt(string prompt, UIntRange range = null) => GetNumber(prompt, range, false).Value;

        public static uint? GetNullableUInt(string prompt, UIntRange range = null) => GetNumber(prompt, range, true);

        public static string GetString(string prompt, StringLengthRange range = null, bool allowNewLine = true, bool allowNull = true)
        {
            SetupFor<string>(prompt, range);
            return GetInput<string>(allowNewLine, allowNull);
        }

        private static T? GetNumber<T>(string prompt, BaseRange<T> range, bool allowNull)
            where T : struct, IComparable<T>
        {
            SetupFor<T>(prompt, range);

            return GetInput<T?>(false, allowNull);
        }

        private static T GetInput<T>(bool allowNewLine, bool allowNull)
        {
            while (true)
            {
                var keyInfo = Console.ReadKey(true);
                switch (keyInfo.Key)
                {
                    case ConsoleKey.Escape:
                        if (allowNull)
                            return TearDown(default(T));
                        break;
                    case ConsoleKey.Enter:
                        if (allowNewLine && keyInfo.Modifiers == ConsoleModifiers.Shift)
                        {
                            InsertNewLine();
                            break;
                        }
                        if (InputIsValid(out var validInput))
                            return TearDown((T)validInput);
                        break;
                    default:
                        if (IsRemoveKey(keyInfo.Key))
                            continue;
                        if (IsMoveKey(keyInfo.Key))
                            continue;
                        if (_inputValidator.CanInsert(keyInfo.KeyChar))
                            InsertChar(keyInfo.KeyChar);
                        break;
                }
            }
        }

        private static bool TryParseInput(out object result)
        {
            var input = _buffer.InputToString();
            try
            {
                var tryParseMethod = _returnType.GetMethod("TryParse",
                    new[] { typeof(string), _returnType.MakeByRefType() });
                if (tryParseMethod is null)
                {
                    result = Convert.ChangeType(input, _returnType);
                    return true;
                }
                var parameters = new object[] { input, null };
                var parseWasSuccessful = (bool)tryParseMethod.Invoke(null, parameters);
                result = parseWasSuccessful ? parameters[1] : null;
                return parseWasSuccessful;
            }
            catch
            {
                result = null;
                return false;
            }
        }

        private static bool IsMoveKey(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.LeftArrow:
                    _navigation.MoveLeft();
                    break;
                case ConsoleKey.RightArrow:
                    _navigation.MoveRight();
                    break;
                case ConsoleKey.UpArrow:
                    _navigation.MoveUp();
                    break;
                case ConsoleKey.DownArrow:
                    _navigation.MoveDown();
                    break;
                case ConsoleKey.Home:
                    _navigation.MoveToStartOfRow();
                    break;
                case ConsoleKey.End:
                    _navigation.MoveToEndOfRow();
                    break;
                case ConsoleKey.PageUp:
                    _navigation.MoveToTopRow();
                    break;
                case ConsoleKey.PageDown:
                    _navigation.MoveToBottomRow();
                    break;
                default:
                    return false;
            }
            return true;
        }

        private static bool IsRemoveKey(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.Backspace:
                    if (_information.AtFirstColumn)
                        return true;
                    _navigation.MoveLeft();
                    break;
                case ConsoleKey.Delete:
                    if (_information.AtLastColumn)
                        return true;
                    break;
                default:
                    return false;
            }
            if (!_buffer.ContainsInput || !_inputValidator.CanRemove())
                return true;
            var (bufferrowindex, buffercolumnindex) = CurrentPositionInBuffer();
            _buffer.RemoveAt(bufferrowindex, buffercolumnindex);
            ReprintAll();
            return true;
        }

        private static void InsertNewLine()
        {
            var (bufferrowindex, buffercolumnindex) = CurrentPositionInBuffer();
            _buffer.Insert(bufferrowindex, buffercolumnindex, '\n');
            Console.CursorVisible = false;
            Console.CursorTop++;
            Console.CursorLeft = 0;
            ReprintAll();
        }

        private static void InsertChar(char character)
        {
            var (bufferRowIndex, bufferColumnIndex) = CurrentPositionInBuffer();
            _buffer.Insert(bufferRowIndex, bufferColumnIndex, character);
            _navigation.MoveRight();
            ReprintAll();
        }

        private static void ReprintAll()
        {
            Console.CursorVisible = false;
            StoreCurrentPosition();

            ClearAllLines();
            Console.Write(_buffer.ToString());

            if (_buffer.ContainsInput)
                ValidateInput();

            GoToStoredPosition();
            Console.CursorVisible = true;
        }

        private static void ValidateInput() => InputIsValid(out var validInput);

        private static bool InputIsValid(out object validInput)
        {
            if (!TryParseInput(out validInput))
                return TearDown($"Can not parse to {_returnType.Name}.");
            if (!_range.WithinRange(validInput))
            {
                validInput = null;
                return TearDown(_range.ErrorMessage);
            }
            return true;

            bool TearDown(string errorMessage)
            {
                PrintError(errorMessage);
                return false;
            }
        }

        private static void ClearAllLines()
        {
            SetCursorPosition(_information.TopRow, 0);

            var rowCount = _information.BottomRow - Console.CursorTop + 3;
            Console.Write(new string('\0', Console.BufferWidth * rowCount));

            SetCursorPosition(_information.TopRow, 0);
        }

        private static void PrintError(string message)
        {
            int top = Console.CursorTop,
                left = Console.CursorLeft;
            SetCursorPosition(_information.BottomRow + 1, 0);
            Print.Error(message, PostPrintOption.None);
            SetCursorPosition(top, left);
        }

        private static void ClearErrorMessage()
        {
            Console.CursorVisible = false;
            StoreCurrentPosition();

            SetCursorPosition(_information.BottomRow + 1, 0);
            Console.Write(new string('\0', Console.BufferWidth));

            GoToStoredPosition();
            Console.CursorVisible = true;
        }

        private static void StoreCurrentPosition()
        {
            _storedRow = Console.CursorTop;
            _storedColumn = Console.CursorLeft;
        }

        private static void GoToStoredPosition()
        {
            Console.CursorTop = _storedRow;
            Console.CursorLeft = _storedColumn;
        }

        private static void SetCursorPosition(int top, int left)
        {
            Console.SetCursorPosition(left, top);
        }

        private static T TearDown<T>(T value)
        {
            if (typeof(T) != typeof(bool))
                ClearErrorMessage();
            if (PrintNewLineBeforeReturn)
                Console.WriteLine();
            if (ClearConsoleBeforeReturn)
                Console.Clear();
            return value;
        }

        private abstract class InsertValidator
        {
            public abstract bool CanInsert(char character);
            public virtual bool CanRemove() => true;
        }

        private abstract class FloatValidator<T> : InsertValidator
            where T : IComparable<T>
        {
            private readonly bool _minValueIsPositive;

            private char FirstCharacter => _buffer[_buffer.TopRowIndex, _buffer.FirstColumnIndex];

            protected FloatValidator(bool minValueIsPositive)
            {
                this._minValueIsPositive = minValueIsPositive;
            }

            public override bool CanInsert(char character)
            {
                if (!this.IsValidChar(character))
                    return false;
                if (character == '-' && !this.CanInsertMinusChar())
                    return false;
                if (character == '.' && !this.CanInsertPeriod())
                    return false;
                return true;
            }

            private bool IsValidChar(char character) => character == '-' || character == '.' || char.IsDigit(character);

            private bool CanInsertMinusChar()
            {
                if (this._minValueIsPositive)
                    return false;
                if (!_information.AtFirstColumn)
                    return false;
                if (this.FirstCharacter == '-')
                    return false;
                return true;
            }

            private bool CanInsertPeriod() => !_buffer.InputToString().Contains('.');
        }

        private abstract class FormatValidator : InsertValidator
        {
            protected char SeparatorCharacter { get; }

            protected FormatValidator(char separatorCharacter)
            {
                this.SeparatorCharacter = separatorCharacter;
            }

            protected int GetCurrentIndexIn(string input)
            {
                var (bufferRowIndex, bufferColumnIndex) = CurrentPositionInBuffer();
                var columnIndex = bufferColumnIndex - _information.FirstColumn;
                if (bufferRowIndex == 0)
                    return columnIndex;
                var buffer = input.Split('\n');
                for (var rowIndex = 1; rowIndex < buffer.Length; rowIndex++)
                {
                    columnIndex += buffer[rowIndex].Length;
                    if (rowIndex == bufferRowIndex)
                        return columnIndex;
                }
                throw new OperationCanceledException($"Could not calculate the index in {input}.");
            }

            protected bool InFirstSection(string input, int index, out string firstSection)
            {
                var lastIndexInSection = input.IndexOf(this.SeparatorCharacter);
                firstSection = null;
                if (index > lastIndexInSection)
                    return false;
                firstSection = input.Substring(0, lastIndexInSection);
                return true;
            }

            protected bool InSecondSection(string input, int index, out string secondSection)
            {
                var firstIndexInSection = input.IndexOf(this.SeparatorCharacter);
                var lastIndexInSection = input.LastIndexOf(this.SeparatorCharacter);
                secondSection = null;
                if (firstIndexInSection > index || index > lastIndexInSection)
                    return false;
                secondSection = input.Remove(lastIndexInSection);
                secondSection = secondSection.Remove(0, firstIndexInSection + 1);
                return true;
            }

            protected bool InThirdSection(string input, int index, out string thirdSection)
            {
                var firstIndexInSection = input.LastIndexOf(this.SeparatorCharacter);
                thirdSection = null;
                if (index < firstIndexInSection)
                    return false;
                thirdSection = input.Substring(firstIndexInSection).Remove(0, 1);
                return true;
            }
        }

        private class DateValidator : FormatValidator
        {
            public DateValidator()
                : base('-')
            {
            }

            public override bool CanInsert(char character) => char.IsDigit(character);

            public override bool CanRemove()
            {
                var input = _buffer.InputToString();
                var index = this.GetCurrentIndexIn(input);
                if (input[index] == this.SeparatorCharacter)
                    return false;
                if (this.InFirstSection(input, index, out var firstSection) && firstSection.Length > 1)
                    return true;
                if (this.InSecondSection(input, index, out var secondSection) && secondSection.Length > 1)
                    return true;
                if (this.InThirdSection(input, index, out var thirdSection) && thirdSection.Length > 1)
                    return true;
                return false;
            }
        }

        private class DecimalValidator : FloatValidator<decimal>
        {
            public DecimalValidator()
                : base(((DecimalRange)_range).MinValue > -1)
            {
            }
        }

        private class DoubleValidator : FloatValidator<double>
        {
            public DoubleValidator()
                : base(((DoubleRange) _range).MinValue > -1)
            {
            }
        }

        private class IntValidator : InsertValidator
        {
            private readonly IntRange _intRange;

            public IntValidator()
            {
                this._intRange = (IntRange)_range;
            }

            private char FirstCharacter => _buffer[_buffer.TopRowIndex, _buffer.FirstColumnIndex];

            public override bool CanInsert(char character)
            {
                if (!this.IsValidChar(character))
                    return false;
                if (character == '-' && !this.CanInsertMinusChar())
                    return false;
                return true;
            }

            private bool IsValidChar(char character) => character == '-' || char.IsDigit(character);

            private bool CanInsertMinusChar()
            {
                if (this._intRange.MinValue > -1)
                    return false;
                if (!_information.AtFirstColumn)
                    return false;
                if (this.FirstCharacter == '-')
                    return false;
                return true;
            }
        }

        private class StringValidator : InsertValidator
        {
            public override bool CanInsert(char character)
            {
                return char.IsLetterOrDigit(character) || char.IsSymbol(character) ||
                       char.IsPunctuation(character) || char.IsSeparator(character);
            }
        }

        private class TimeSpanValidator : FormatValidator
        {
            private readonly TimeSpanRange _timeSpanRange;

            public TimeSpanValidator()
                : base(':')
            {
                this._timeSpanRange = (TimeSpanRange)_range;
            }

            private char FirstCharacter => _buffer[_buffer.TopRowIndex, _buffer.FirstColumnIndex];

            public override bool CanInsert(char character)
            {
                if (!this.IsValidChar(character))
                    return false;
                if (character == '-' && !this.CanInsertMinusChar())
                    return false;
                if (character == '.' && !this.CanInsertPeriod())
                    return false;
                if (!this.CanInsertDigit())
                    return false;
                return true;
            }

            public override bool CanRemove()
            {
                var input = _buffer.InputToString();
                var index = this.GetCurrentIndexIn(input);
                if (input[index] == this.SeparatorCharacter)
                    return false;
                if (this.InFirstSection(input, index, out var firstSection) && firstSection.Length > 1)
                    return true;
                if (this.InSecondSection(input, index, out var secondSection) && secondSection.Length > 1)
                    return true;
                if (this.InThirdSection(input, index, out var thirdSection) && thirdSection.Length > 1)
                    return true;
                return false;
            }

            private bool IsValidChar(char character) => character == '-' || character == '.' || char.IsDigit(character);

            private bool CanInsertMinusChar()
            {
                if (!_information.AtFirstColumn)
                    return false;
                if (this._timeSpanRange.MinValue >= TimeSpan.Zero)
                    return false;
                if (this.FirstCharacter == '-')
                    return false;
                return true;
            }

            private bool CanInsertPeriod()
            {
                var input = _buffer.InputToString();
                var index = this.GetCurrentIndexIn(input);
                if (this.InFirstSection(input, index, out var firstSection) && !firstSection.Contains('.'))
                    return true;
                if (this.InThirdSection(input, index, out var thirdSection) && !thirdSection.Contains('.'))
                    return true;
                return false;
            }

            private bool CanInsertDigit()
            {
                if (_information.AtFirstColumn && _buffer[_buffer.TopRowIndex, _buffer.FirstColumnIndex] == '-')
                    return false;
                return true;
            }
        }

        private class UIntValidator : InsertValidator
        {
            public override bool CanInsert(char character) => char.IsDigit(character);
        }
    }
}