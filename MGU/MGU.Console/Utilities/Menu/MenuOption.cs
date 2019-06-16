namespace MGU.Console.Utilities.Menu
{
    using Core.Extensions.If;
    using Interfaces.Menu;

    internal class MenuOption : IMenuOption
    {
        public MenuOptionKey Key { get; }
        public IMenuItem Item { get; }

        public MenuOption(MenuOptionKey key, IMenuItem item)
        {
            this.Key = key;
            this.Item = item;
        }
    }

    public class MenuOption<T> : IMenuOption<T>
        where T : IInvokable, IMenuItem
    {
        public MenuOptionKey Key { get; }
        public T Item { get; }

        public MenuOption(MenuOptionKey key, T item)
        {
            this.Key = key;
            this.Item = item.If().Null.Throw().Null(nameof(item));
        }
    }
}