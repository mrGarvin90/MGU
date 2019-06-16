namespace MGU.Console.Interfaces.Menu
{
    using System.Collections.Generic;
    using Utilities.Menu;

    public interface IMenuOptionsContainer
    {
        IInvokable this[MenuOptionKey key] { get; }
        int Count { get; }

        void Add<T>(IMenuOption<T> menuOption) where T : IInvokable, IMenuItem;
        void AddRange<T>(IEnumerable<IMenuOption<T>> menuOptions) where T : IInvokable, IMenuItem;
        void RemoveBy(MenuOptionKey key);
        IEnumerable<IMenuOption> ToReadOnly();
    }
}