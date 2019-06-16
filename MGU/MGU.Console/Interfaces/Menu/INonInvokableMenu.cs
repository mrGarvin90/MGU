namespace MGU.Console.Interfaces.Menu
{
    using Utilities.Menu;

    public interface INonInvokableMenu : IMenuItem
    {
        IMenuItem this[MenuOptionKey key] { get; }
        int OptionCount { get; }
        bool IsEmpty { get; }

        void AddOptions<T>(params IMenuOption<T>[] options) where T : IInvokable, IMenuItem;
        void RemoveOptionsBy(params MenuOptionKey[] keys);
        INonInvokableMenu GetSubmenuBy(MenuOptionKey key);
        INonInvokableMenuFunc GetMenuFuncBy(MenuOptionKey key);
    }
}