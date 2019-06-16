namespace MGU.Console.Utilities.Menu
{
    using System;
    using System.Collections.Generic;
    using Core.Extensions.If;
    using Interfaces.Menu;

    public class Menu : IMenu
    {
        private readonly IMenuOptionsContainer _optionses = new MenuOptionsContainer();
        private PostInvokeCommand _emptyMenuReturnCommand;

        public IMenuItem this[MenuOptionKey key] => this._optionses[key] as IMenuItem;

        public string Label { get; }

        public int OptionCount => this._optionses.Count;
        public bool IsEmpty { get; private set; }

        private Menu(string label)
        {
            this.Label = label
                .If().Null.Throw().Null(nameof(label))
                .If().Empty.Throw().Argument("Cannot be empty.", nameof(label));
        }

        public Menu(string label, bool isRootMenu)
            : this(label)
        {
            this.SetEmptyMenuReturnCommand(isRootMenu);
            this.AddEmptyMenuOption();
        }

        public Menu(string label, params IMenuOption<IMenu>[] subMenuOptions)
            : this(label, subMenuOptions, null) { }

        public Menu(string label, params IMenuOption<IMenuFunc>[] menuFuncOptions)
            : this(label, null, menuFuncOptions) { }

        public Menu(string label, IEnumerable<IMenuOption<IMenu>> submenuOptions, IEnumerable<IMenuOption<IMenuFunc>> menuFuncOptions)
            : this(label)
        {
            if (submenuOptions is null && menuFuncOptions is null)
                throw new InvalidOperationException($"Both {nameof(submenuOptions)} and {nameof(menuFuncOptions)} cannot be null.");

            if (submenuOptions != null)
                this._optionses.AddRange(submenuOptions);

            if (menuFuncOptions != null)
                this._optionses.AddRange(menuFuncOptions);
        }
        
        private void AddEmptyMenuOption()
        {
            var menuIsEmptyOption = new MenuOption<IMenuFunc>(MenuOptionKey.E, new MenuFunc("Menu is empty", () => this._emptyMenuReturnCommand));
            this._optionses.Add(menuIsEmptyOption);
            this.IsEmpty = true;
        }

        private void RemoveEmptyMenuOption()
        {
            this._optionses.RemoveBy(MenuOptionKey.E);
            this.IsEmpty = false;
        }

        private void SetEmptyMenuReturnCommand(bool isRootMenu)
        {
            this._emptyMenuReturnCommand = isRootMenu ? PostInvokeCommand.ExitRootMenu : PostInvokeCommand.ExitSubmenu;
        }

        public void AddOptions<T>(params IMenuOption<T>[] options)
            where T : IInvokable, IMenuItem
        {
            options.If().Null.Throw().Null(nameof(options));

            if (this.IsEmpty)
                this.RemoveEmptyMenuOption();
            foreach (var option in options)
                this._optionses.Add(option);
        }

        public void RemoveOptionsBy(params MenuOptionKey[] keys)
        {
            keys.If().Null.Throw().Null(nameof(keys));

            foreach (var key in keys)
                this._optionses.RemoveBy(key);

            if (this.IsEmpty)
                this.AddEmptyMenuOption();
        }

        public INonInvokableMenu GetSubmenuBy(MenuOptionKey key)
            => this[key] as INonInvokableMenu;

        public INonInvokableMenuFunc GetMenuFuncBy(MenuOptionKey key)
            => this[key] as INonInvokableMenuFunc;

        public PostInvokeCommand Invoke()
        {
            this.SetEmptyMenuReturnCommand(false);
            MenuOptionKey? selectedOption = null;
            while (true)
            {
                selectedOption = MenuOptionKeyService.GetOptionKey(this.Label, this._optionses.ToReadOnly(), selectedOption, true);
                if (selectedOption is null)
                    return PostInvokeCommand.StayInSubmenu;
                switch (this._optionses[selectedOption.Value].Invoke())
                {
                    case PostInvokeCommand.StayInSubmenu:
                        continue;
                    case PostInvokeCommand.ExitSubmenu:
                        return PostInvokeCommand.StayInSubmenu;
                    case PostInvokeCommand.ExitRootMenu:
                        return PostInvokeCommand.ExitRootMenu;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        public void InvokeAsRootMenu()
        {
            this.SetEmptyMenuReturnCommand(true);
            MenuOptionKey? selectedOption = null;
            while (true)
            {
                selectedOption = MenuOptionKeyService.GetOptionKey(this.Label, this._optionses.ToReadOnly(), selectedOption, false);
                if (this._optionses[selectedOption.Value].Invoke() == PostInvokeCommand.ExitRootMenu)
                    return;
            }
        }
    }
}