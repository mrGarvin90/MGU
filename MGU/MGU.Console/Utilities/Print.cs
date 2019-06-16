namespace MGU.Console.Utilities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Core.Extensions.If;

    public static class Print
    {
        private static (int Top, int Left) _storedPosition;

        public static PrintSettings Settings { get; } = PrintSettings.Instance;

        static Print()
        {
            Settings.ResetToDefaultColors();
        }

        public static void Enumerable(IEnumerable<object> enumerable, ObjectSeparator objectSeparator, PostPrintOption postPrintOption = PostPrintOption.PrintNewLine)
        {
            Enumerable(enumerable, objectSeparator.ToCleanString(), postPrintOption);
        }

        public static void Enumerable(IEnumerable<object> enumerable, string objectSeparator = "\n", PostPrintOption postPrintOption = PostPrintOption.PrintNewLine)
        {
            objectSeparator.If().Null.Throw().Null(nameof(objectSeparator));

            if (enumerable is null)
            {
                Object(Settings.StringToPrintIfEnuamerableIsNull, PostPrintOption.PrintNewLine);
                return;
            }
            if (!enumerable.Any())
            {
                Object(Settings.StringToPrintIfEnuamerableIsEmpty, PostPrintOption.PrintNewLine);
                return;
            }

            var objects = enumerable as object[] ?? enumerable.ToArray();
            var lastIndex = objects.Length - 1;
            
            Settings.ToggleCursorVisibility();

            for (var index = 0; index <= lastIndex; index++)
            {
                if (index != lastIndex)
                    Object(objects[index] + objectSeparator, PostPrintOption.None);
                else
                    Object(objects[index], postPrintOption);
            }

            Settings.ToggleCursorVisibility();
        }

        public static void Objects(params object[] objects)
        {
            Enumerable(
                objects.If().Null.Throw().Null(nameof(objects)),
                ObjectSeparator.NewLine,
                PostPrintOption.PrintNewLine);
        }

        public static void Objects(PostPrintOption postPrintOption, params object[] objects)
        {
            Enumerable(
                objects.If().Null.Throw().Null(nameof(objects)),
                ObjectSeparator.NewLine,
                postPrintOption);
        }

        public static void Objects(ObjectSeparator objectSeparator, params object[] objects)
        {
            Enumerable(
                objects.If().Null.Throw().Null(nameof(objects)),
                objectSeparator,
                PostPrintOption.PrintNewLine);
        }

        public static void Objects(ObjectSeparator objectSeparator, PostPrintOption postPrintOption, params object[] objects)
        {
            Enumerable(
                objects.If().Null.Throw().Null(nameof(objects)),
                objectSeparator,
                postPrintOption);
        }

        public static void Object(object obj, PostPrintOption postPrintOption = PostPrintOption.None)
        {
            var output = obj is null ? Settings.StringToPrintIfObjectIsNull : obj.ToString();
            switch (postPrintOption)
            {
                case PostPrintOption.None:
                    Console.Write(output);
                    break;
                case PostPrintOption.PrintNewLine:
                    Console.WriteLine(output);
                    break;
                case PostPrintOption.WaitForKeyPress:
                    Console.Write(output);
                    Console.ReadKey(true);
                    break;
                case PostPrintOption.PrintNewLineAndWaitForKeyPress:
                    Console.WriteLine(output);
                    Console.ReadKey(true);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(postPrintOption), postPrintOption, null);
            }
        }

        public static void ReturningToMenu(string message = null, MessageType messageType = MessageType.Basic)
        {
            if (!(message is null))
            {
                switch (messageType)
                {
                    case MessageType.Basic:
                        Message(message, PostPrintOption.PrintNewLine);
                        break;
                    case MessageType.Success:
                        Success(message, PostPrintOption.PrintNewLine);
                        break;
                    case MessageType.Warning:
                        Warning(message, PostPrintOption.PrintNewLine);
                        break;
                    case MessageType.Error:
                        Error(message, PostPrintOption.PrintNewLine);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(messageType), messageType, null);
                }
            }
            Message("Returning to menu...", PostPrintOption.WaitForKeyPress);
        }

        public static void Success(string message, PostPrintOption postPrintOption = PostPrintOption.PrintNewLine)
        {
            Message(message, MessageType.Success, postPrintOption);
        }

        public static void Warning(string message, PostPrintOption postPrintOption = PostPrintOption.PrintNewLine)
        {
            Message(message, MessageType.Warning, postPrintOption);
        }

        public static void Warning(string message, Exception exception, PostPrintOption postPrintOption = PostPrintOption.PrintNewLine)
        {
            Warning(message, PostPrintOption.PrintNewLine);
            Exception(exception, postPrintOption);
        }

        public static void Error(string message, PostPrintOption postPrintOption = PostPrintOption.PrintNewLine)
        {
            Message(message, MessageType.Error, postPrintOption);
        }

        public static void Error(string mesage, Exception exception, PostPrintOption postPrintOption = PostPrintOption.PrintNewLine)
        {
            Error(mesage, PostPrintOption.PrintNewLine);
            Exception(exception, postPrintOption);
        }

        private static void Message(string message, MessageType messageType, PostPrintOption postPrintOption)
        {
            message.If().Null.Throw().Null(nameof(message));

            switch (messageType)
            {
                case MessageType.Success:
                    Settings.SetSuccessColors();
                    break;
                case MessageType.Warning:
                    Settings.SetWarningColors();
                    break;
                case MessageType.Error:
                    Settings.SetErrorColors();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(messageType), messageType, null);
            }

            Object(message, postPrintOption);
            Settings.ResetToDefaultColors();
        }

        public static void Message(string message, PostPrintOption postPrintOption = PostPrintOption.PrintNewLine)
        {
            Object(
                message.If().Null.Throw().Null(nameof(message)),
                postPrintOption);
        }

        public static void Exception(Exception exception, PostPrintOption postPrintOption = PostPrintOption.PrintNewLine)
        {
            exception.If().Null.Throw().Null(nameof(exception));
            var (postPrintChar, waitForKeyPress) = postPrintOption.Divide();

            Settings.ToggleCursorVisibility();

            Separator();
            Object($"{exception}{postPrintChar}", PostPrintOption.None);
            Separator();

            Settings.ToggleCursorVisibility();

            if (waitForKeyPress)
                Console.ReadKey(true);
        }

        public static void Header(string text, int emptyLinesFollowing = 1, char borderChar = '=')
        {
            text
                .If().Null.Throw().Null(nameof(text))
                .If().Empty.Throw().Argument("Cannot be empty", nameof(text));

            Settings.ToggleCursorVisibility();

            var borderLength = text.Length;
            Separator(borderLength, borderChar);
            Settings.SetHeaderColors();
            Object(text, PostPrintOption.PrintNewLine);
            Settings.ResetToDefaultColors();
            Separator(borderLength, borderChar);
            if (emptyLinesFollowing > 0)
                EmptyLines(emptyLinesFollowing);
            Settings.ToggleCursorVisibility();
        }

        public static void Separator(char separatorChar = '-')
        {
            Object(new string(separatorChar, Console.BufferWidth), PostPrintOption.PrintNewLine);
        }

        public static void Separator(int length, char separatorChar = '-')
        {
            Object(new string(separatorChar, length), PostPrintOption.PrintNewLine);
        }

        public static void EmptyLines(int count)
        {
            Object(new string('\n', count), PostPrintOption.None);
        }

        public static void ClearLine(bool fromCurrentPosition = false)
        {
            var cursorLeft = fromCurrentPosition ? Console.CursorLeft : 0;
            var count = Console.BufferWidth - Console.CursorLeft;
            StoreCurrentPosition();
            ClearFrom(Console.CursorTop, cursorLeft, count);
            GoToStoredPosition();
        }

        public static void ClearLineAt(int cursorTop)
        {
            cursorTop.If().LessThan(0).Throw().OutOfRange(nameof(cursorTop), cursorTop, "Cannot be less than 0.");

            StoreCurrentPosition();
            ClearFrom(cursorTop, 0, Console.BufferWidth);
            GoToStoredPosition();
        }

        public static void ClearLines(int count)
        {
            count.If().LessThan(1).Throw().OutOfRange(nameof(count), count, "Cannot be less than 0");

            StoreCurrentPosition();
            ClearFrom(Console.CursorTop, Console.CursorLeft, count * Console.BufferWidth);
            GoToStoredPosition();
        }

        public static void ClearLinesFrom(int cursorTop, int count)
        {
            cursorTop.If().LessThan(0).Throw().OutOfRange(nameof(cursorTop), cursorTop, "Cannot be less than 0.");
            count.If().LessThan(1).Throw().OutOfRange(nameof(count), count, "Cannot be less than 0");

            StoreCurrentPosition();
            ClearFrom(cursorTop, Console.CursorLeft, count * Console.BufferWidth);
            GoToStoredPosition();
        }

        public static void ClearArea(int startTop, int startLeft, int endTop, int endLeft)
        {
            endTop.If().LessThan(0).Throw().OutOfRange(nameof(endTop), endTop, "Cannot be less than 0.");
            startTop
                .If().LessThan(0).Throw().OutOfRange(nameof(startTop), startTop, "Cannot be less than 0.")
                .If().GreaterThan(endTop).Throw().OutOfRange(nameof(startTop), startTop, $"Cannot be greater than {nameof(endTop)}.");

            endLeft.If().LessThan(0).Throw().OutOfRange(nameof(endLeft), endLeft, "Cannot be less than 0.");
            startLeft
                .If().LessThan(0).Throw().OutOfRange(nameof(startLeft), startLeft, "Cannot be less than 0.")
                .If().GreaterThan(endLeft).Throw().OutOfRange(nameof(startLeft), startLeft, $"Cannot be greater than {nameof(endLeft)}.");

            StoreCurrentPosition();
            ClearFrom(startTop, startLeft, CalculateCharCount());
            GoToStoredPosition();

            int CalculateCharCount()
            {
                var rowCount = endTop - startTop + 1;
                var firstRowCharCount = Console.BufferWidth - startLeft - 1;
                if (rowCount == 1)
                    return firstRowCharCount;
                var lastRowCharCount = Console.BufferWidth - endLeft - 1;
                if (rowCount == 2)
                    return firstRowCharCount + lastRowCharCount;
                rowCount -= 2;
                return firstRowCharCount + lastRowCharCount + Console.BufferWidth * rowCount;
            }
        }

        private static void ClearFrom(int cursorTop, int cursorLeft, int count)
        {
            Settings.ToggleCursorVisibility();

            Settings.SetCursorPosition(cursorTop, cursorLeft);
            Object(new string('\0', count), PostPrintOption.None);

            Settings.ToggleCursorVisibility();
        }

        private static void StoreCurrentPosition() => _storedPosition = (Console.CursorTop, Console.CursorLeft);

        private static void GoToStoredPosition() => Settings.SetCursorPosition(_storedPosition.Top, _storedPosition.Left);
    }

    public class PrintSettings
    {
        public static PrintSettings Instance { get; } = new PrintSettings();

        public ConsoleColor DefaultBackgroundColor { get; set; } = ConsoleColor.Black;
        public ConsoleColor DefaultForegroundColor { get; set; } = ConsoleColor.White;
        public ConsoleColor HeaderBackgroundColor { get; set; } = ConsoleColor.Green;
        public ConsoleColor HeaderForegroundColor { get; set; } = ConsoleColor.Black;
        public ConsoleColor SuccessBackgroundColor { get; set; } = ConsoleColor.Green;
        public ConsoleColor SuccessForegroundColor { get; set; } = ConsoleColor.Black;
        public ConsoleColor WarningBackgroundColor { get; set; } = ConsoleColor.Yellow;
        public ConsoleColor WarningForegroundColor { get; set; } = ConsoleColor.Black;
        public ConsoleColor ErrorBackgroundColor { get; set; } = ConsoleColor.Red;
        public ConsoleColor ErrorForegroundColor { get; set; } = ConsoleColor.Black;
        public bool HideCursorWhilePrinting { get; set; } = true;
        public string StringToPrintIfObjectIsNull { get; set; } = "<object is null>";
        public string StringToPrintIfEnuamerableIsNull { get; set; } = "<enumerable is null>";
        public string StringToPrintIfEnuamerableIsEmpty { get; set; } = "<enumerable is empty>";
        public string ProgramName { get; set; }

        private PrintSettings() { }

        public void SetHeaderColors()
        {
            this.SetColors(this.HeaderBackgroundColor, this.HeaderForegroundColor);
        }

        public void SetSuccessColors()
        {
            this.SetColors(this.SuccessBackgroundColor, this.SuccessForegroundColor);
        }

        public void SetWarningColors()
        {
            this.SetColors(this.WarningBackgroundColor, this.WarningForegroundColor);
        }

        public void SetErrorColors()
        {
            this.SetColors(this.ErrorBackgroundColor, this.ErrorForegroundColor);
        }

        public void ResetToDefaultColors()
        {
            this.SetColors(this.DefaultBackgroundColor, this.DefaultForegroundColor);
        }

        public void SwapColors()
        {
            this.SetColors(Console.ForegroundColor, Console.BackgroundColor);
        }

        public void SetColors(ConsoleColor background, ConsoleColor foreground)
        {
            Console.BackgroundColor = background;
            Console.ForegroundColor = foreground;
        }

        public void SetCursorPosition(int top, int left)
        {
            Console.SetCursorPosition(left, top);
        }

        public void ToggleCursorVisibility()
        {
            if (this.HideCursorWhilePrinting)
                Console.CursorVisible = !Console.CursorVisible;
        }
    }

    public enum PostPrintOption
    {
        None,
        PrintNewLine,
        WaitForKeyPress,
        PrintNewLineAndWaitForKeyPress
    }

    public enum ObjectSeparator
    {
        WhiteSpace,
        Tab,
        Comma,
        Dash,
        Pipe,
        NewLine
    }

    public enum MessageType
    {
        Basic,
        Success,
        Warning,
        Error
    }

    public static class PostPrintOptionExtensions
    {
        public static (char postPrintChar, bool waitForKeyPress) Divide(this PostPrintOption postPrintOption)
        {
            switch (postPrintOption)
            {
                case PostPrintOption.WaitForKeyPress:
                    return ('\0', true);
                case PostPrintOption.PrintNewLineAndWaitForKeyPress:
                    return ('\n', true);
                default:
                    return (postPrintOption == PostPrintOption.None ? '\0' : '\n', false);
            }
        }
    }

    public static class ObjectSeparatorExtensions
    {
        public static string ToCleanString(this ObjectSeparator objectSeparator)
        {
            switch (objectSeparator)
            {
                case ObjectSeparator.WhiteSpace:
                    return " ";
                case ObjectSeparator.Tab:
                    return "\t";
                case ObjectSeparator.Comma:
                    return ", ";
                case ObjectSeparator.Dash:
                    return " - ";
                case ObjectSeparator.Pipe:
                    return " | ";
                case ObjectSeparator.NewLine:
                    return "\n";
                default:
                    throw new ArgumentOutOfRangeException(nameof(objectSeparator), objectSeparator, null);
            }
        }
    }
}