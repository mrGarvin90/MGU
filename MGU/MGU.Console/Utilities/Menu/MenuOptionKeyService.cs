namespace MGU.Console.Utilities.Menu
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Core.Extensions.If;
    using Interfaces.Menu;

    public static class MenuOptionKeyService
    {
        private static IMenuOption[] MenuOptions { get; set; }
        private static string[] OptionRows { get; set; }
        private static int TopRow { get; set; }
        private static int BottomRow { get; set; }
        private static int CurrentOptionIndex { get; set; }
        private static bool AtTopRow => Console.CursorTop == TopRow;
        private static bool AtBottomRow => Console.CursorTop == BottomRow;

        public static Action ProgramHeaderPrinter { get; set; }

        private static void Setup(string menuLabel, IEnumerable<IMenuOption> menuOptions, MenuOptionKey? selectedOption)
        {
            Console.CursorVisible = false;
            Console.Clear();
            ProgramHeaderPrinter?.Invoke();
            Print.Header(menuLabel.If().Null.Throw().Null(nameof(menuLabel)), 0, '-');
            MenuOptions = menuOptions.If().Null.Throw().Null(nameof(menuOptions)).ToArray();
            OptionRows = CreateOptionRows();
            TopRow = Console.CursorTop;
            BottomRow = TopRow + MenuOptions.Length - 1;
            var selectedOptionIndex = selectedOption is null ? 0 : IndexOfKey();
            CurrentOptionIndex = 0;
            PrintMenu();
            CurrentOptionIndex = selectedOptionIndex;

            int IndexOfKey()
            {
                for (var index = 0; index < MenuOptions.Length; index++)
                    if (MenuOptions[index].Key == selectedOption.Value)
                        return index;
                throw new KeyNotFoundException($"'{selectedOption}' was not found.");
            }

            void PrintMenu()
            {
                Console.CursorTop = TopRow;
                for (var index = 0; index < MenuOptions.Length; index++)
                {
                    PrintCurrentRow(CurrentOptionIndex == selectedOptionIndex);
                    CurrentOptionIndex++;
                    Console.CursorTop++;
                }
                Console.CursorTop = selectedOptionIndex + TopRow;
            }
        }

        private static string[] CreateOptionRows()
        {
            var optionRows = new string[MenuOptions.Length];
            var labelLength = MenuOptions.Select(menuOption => menuOption.Item.Label.Length).Max() + 5;
            for (var index = 0; index < MenuOptions.Length; index++)
                optionRows[index] = CreateLabelFor(MenuOptions[index]);
            return optionRows;

            string CreateLabelFor(IMenuOption option)
            {
                var label = $"[{option.Key.ToCleanString()}]  {option.Item.Label}";
                if (option.Item is IMenu)
                    return label + " --> ";
                return label.PadRight(labelLength);
            }
        }

        public static MenuOptionKey? GetOptionKey(string menuLabel, IEnumerable<IMenuOption> menuOptions, MenuOptionKey? selectedOption, bool allowNull)
        {
            Setup(menuLabel, menuOptions, selectedOption);
            
            while (true)
            {
                var consoleKey = Console.ReadKey(true).Key;
                switch (consoleKey)
                {
                    case ConsoleKey.Escape:
                    case ConsoleKey.LeftArrow:
                        if (allowNull)
                            return TearDown(null);
                        break;
                    case ConsoleKey.Enter:
                    case ConsoleKey.RightArrow:
                        return TearDown(MenuOptions[CurrentOptionIndex].Key);
                    default:
                        if (IsMoveKey(consoleKey))
                            continue;
                        if (TryParseToMenuOptionKey(consoleKey, out selectedOption) && MenuOptions.Any(mo => mo.Key == selectedOption))
                            return TearDown(selectedOption);
                        break;
                }
            }
        }

        private static MenuOptionKey? TearDown(MenuOptionKey? key)
        {
            Console.Clear();
            Console.CursorVisible = true;
            return key;
        }

        private static bool TryParseToMenuOptionKey(ConsoleKey consoleKey, out MenuOptionKey? menuOptionKey)
        {
            switch (consoleKey)
            {
                case ConsoleKey.D0:
                case ConsoleKey.NumPad0:
                    menuOptionKey = MenuOptionKey.Zero;
                    break;
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    menuOptionKey = MenuOptionKey.One;
                    break;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    menuOptionKey = MenuOptionKey.Two;
                    break;
                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    menuOptionKey = MenuOptionKey.Three;
                    break;
                case ConsoleKey.D4:
                case ConsoleKey.NumPad4:
                    menuOptionKey = MenuOptionKey.Four;
                    break;
                case ConsoleKey.D5:
                case ConsoleKey.NumPad5:
                    menuOptionKey = MenuOptionKey.Five;
                    break;
                case ConsoleKey.D6:
                case ConsoleKey.NumPad6:
                    menuOptionKey = MenuOptionKey.Six;
                    break;
                case ConsoleKey.D7:
                case ConsoleKey.NumPad7:
                    menuOptionKey = MenuOptionKey.Seven;
                    break;
                case ConsoleKey.D8:
                case ConsoleKey.NumPad8:
                    menuOptionKey = MenuOptionKey.Eight;
                    break;
                case ConsoleKey.D9:
                case ConsoleKey.NumPad9:
                    menuOptionKey = MenuOptionKey.Nine;
                    break;
                default:
                    menuOptionKey = null;
                    if (!Enum.TryParse(consoleKey.ToString(), out MenuOptionKey result))
                        return false;
                    menuOptionKey = result;
                    break;
            }
            return true;
        }

        private static bool IsMoveKey(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    MoveUp();
                    break;
                case ConsoleKey.DownArrow:
                    MoveDown();
                    break;
                case ConsoleKey.PageUp:
                    if (AtTopRow)
                        return true;
                    MoveToTop();
                    break;
                case ConsoleKey.PageDown:
                    if (AtBottomRow)
                        return true;
                    MoveToBottom();
                    break;
                default:
                    return false;
            }
            return true;
        }

        private static void MoveUp()
        {
            if (AtTopRow)
            {
                MoveToBottom();
                return;
            }
            PrintCurrentRow(false);
            Console.CursorTop--;
            CurrentOptionIndex--;
            PrintCurrentRow(true);
        }

        private static void MoveDown()
        {
            if (AtBottomRow)
            {
                MoveToTop();
                return;
            }
            PrintCurrentRow(false);
            Console.CursorTop++;
            CurrentOptionIndex++;
            PrintCurrentRow(true);
        }

        private static void MoveToTop()
        {
            PrintCurrentRow(false);
            Console.CursorTop = TopRow;
            CurrentOptionIndex = 0;
            PrintCurrentRow(true);
        }

        private static void MoveToBottom()
        {
            PrintCurrentRow(false);
            Console.CursorTop = BottomRow;
            CurrentOptionIndex = MenuOptions.Length - 1;
            PrintCurrentRow(true);
        }

        private static void PrintCurrentRow(bool isSelected)
        {
            Print.ClearLine();
            if (isSelected)
                Print.Settings.SwapColors();
            Console.Write(OptionRows[CurrentOptionIndex]);
            if (isSelected)
                Print.Settings.SwapColors();
            Console.CursorLeft = 0;
        }
    }
}