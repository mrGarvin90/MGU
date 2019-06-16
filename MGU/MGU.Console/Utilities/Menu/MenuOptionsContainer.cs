namespace MGU.Console.Utilities.Menu
{
    using System;
    using System.Collections.Generic;
    using Core.Extensions.If;
    using Interfaces.Menu;

    public class MenuOptionsContainer : IMenuOptionsContainer
    {
        private readonly IDictionary<MenuOptionKey, IMenu> _submenuMapper = new Dictionary<MenuOptionKey, IMenu>();
        private readonly IDictionary<MenuOptionKey, IMenuFunc> _menuFuncMapper = new Dictionary<MenuOptionKey, IMenuFunc>();

        public IInvokable this[MenuOptionKey key]
        {
            get
            {
                if (this._submenuMapper.TryGetValue(key, out var value))
                    return value;
                return this._menuFuncMapper[key];
            }
        }

        public int Count => this._submenuMapper.Count + this._menuFuncMapper.Count;

        public void Add<T>(IMenuOption<T> menuOption) where T : IInvokable, IMenuItem
        {
            menuOption.If().Null.Throw().Null(nameof(menuOption));
            this.AddToMapper(menuOption.Key, menuOption.Item);
        }

        public void AddRange<T>(IEnumerable<IMenuOption<T>> menuOptions) where T : IInvokable, IMenuItem
        {
            menuOptions.If().Null.Throw().Null(nameof(menuOptions));

            foreach (var menuOption in menuOptions)
                this.Add(menuOption);
        }

        public void RemoveBy(MenuOptionKey key)
        {
            if (this._submenuMapper.ContainsKey(key))
                this._submenuMapper.Remove(key);
            else
                this._menuFuncMapper.Remove(key);
        }

        public IEnumerable<IMenuOption> ToReadOnly()
        {
            var readOnly = new List<IMenuOption>();
            foreach (var submenuOption in this._submenuMapper)
                readOnly.Add(new MenuOption(submenuOption.Key, submenuOption.Value));
            foreach (var menuFuncOption in this._menuFuncMapper)
                readOnly.Add(new MenuOption(menuFuncOption.Key, menuFuncOption.Value));
            return readOnly;
        }

        private void AddToMapper<T>(MenuOptionKey key, T item) where T : IInvokable, IMenuItem
        {
            if (this._submenuMapper.ContainsKey(key) || this._menuFuncMapper.ContainsKey(key))
                throw new InvalidOperationException($"An {nameof(IMenuOption)} is already mapped to that key.");
            switch (item)
            {
                case IMenu _:
                    this._submenuMapper.Add(key, (IMenu)item);
                    break;
                case IMenuFunc _:
                    this._menuFuncMapper.Add(key, (IMenuFunc)item);
                    break;
                default:
                    throw new InvalidOperationException($"{typeof(T)} is not a valid type.");
            }
        }
    }
}