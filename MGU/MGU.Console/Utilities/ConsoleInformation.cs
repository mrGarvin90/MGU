namespace MGU.Console.Utilities
{
    using System;
    using Interfaces;

    public class ConsoleInformation : IConsoleInformation
    {
        public int BufferWidth
        {
            get => Console.BufferWidth;
            set => Console.BufferWidth = value;
        }

        public int CursorTop
        {
            get => Console.CursorTop;
            set => Console.CursorTop = value;
        }

        public int CursorLeft
        {
            get => Console.CursorLeft;
            set => Console.CursorLeft = value;
        }
    }
}