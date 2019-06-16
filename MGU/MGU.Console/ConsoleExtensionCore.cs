namespace MGU.Console
{
    using System;
    using System.Reflection;
    using Core.Extensions.If;
    using Interfaces.Menu;
    using Utilities;
    using Utilities.Input;
    using Utilities.Menu;

    public abstract class ConsoleExtensionCore
    {
        private readonly IMenu _rootMenu;
        private readonly IMenuOption<IMenuFunc> _quitOption;

        protected ConsoleExtensionCore()
            : this("Main menu")
        {
        }

        protected ConsoleExtensionCore(string rootMenuLabel)
            : this(rootMenuLabel, GetDefaultProgramHeader())
        {
        }

        protected ConsoleExtensionCore(string rootMenuLabel, string programHeader)
        {
            this._rootMenu = new Menu(rootMenuLabel, true);
            this._quitOption = CreateQuitOption();
            this._rootMenu.AddOptions(this._quitOption);
            SetProgramHeader();
            this.Initialize();
            this._rootMenu.InvokeAsRootMenu();

            IMenuOption<IMenuFunc> CreateQuitOption()
            {
                var quitMenu = this.CreateYesOrNoMenu(
                    "Do you want to quit?",
                    () => { },
                    () => { },
                    PostInvokeCommand.ExitRootMenu
                );
                return this.CreateMenuFuncOption(MenuOptionKey.Q, "Quit", quitMenu.Invoke);
            }

            void SetProgramHeader()
            {
                Print.Settings.ProgramName = programHeader
                    .If().Null.Throw().Null(nameof(programHeader))
                    .If().Empty.Throw().Argument(nameof(programHeader));

                MenuOptionKeyService.ProgramHeaderPrinter = () => Print.Header(programHeader);
            }
        }

        private static string GetDefaultProgramHeader()
        {
            try
            {
                return $" {Assembly.GetEntryAssembly().GetName().Name} ";
            }
            catch
            {
                return " Program ";
            }
        }

        protected abstract void Initialize();

        protected void AddOptions(params IMenuOption<IMenuItem>[] options)
        {
            options
                .If().Null.Throw().Null(nameof(options))
                .If().Any(o => o?.Key == MenuOptionKey.Q).Throw().InvalidOperation($"{MenuOptionKey.Q} is reserved for the 'Quit' option.");

            this._rootMenu.RemoveOptionsBy(MenuOptionKey.Q);
            this.AddOptionsTo(this._rootMenu, options);
            this._rootMenu.AddOptions(this._quitOption);
        }

        protected void RemoveOptionsBy(params MenuOptionKey[] keys)
        {
            keys
                .If().Null.Throw().Null(nameof(keys))
                .If().Contains(MenuOptionKey.Q).Throw().InvalidOperation("Cannot remove the 'Quit' option.");

            this._rootMenu.RemoveOptionsBy(keys);
        }

        protected INonInvokableMenu GetSubmenuBy(MenuOptionKey key) => this._rootMenu.GetSubmenuBy(key);

        protected INonInvokableMenuFunc GetMenuFuncBy(MenuOptionKey key) => this._rootMenu.GetMenuFuncBy(key);

        protected bool Confirm(string question,
                               bool trueAsDefault = true)
        {
            return this.GetConfirmationOf(question, trueAsDefault, false).Value;
        }

        protected bool? TryToConfirm(string question,
                                     bool trueAsDefault = true)
        {
            return this.GetConfirmationOf(question, trueAsDefault, true);
        }

        protected IMenu CreateNewSubMenu(string label, params IMenuOption<IMenuItem>[] menuOptions)
        {
            IMenu menu = new Menu(label, false);
            this.AddOptionsTo(
                menu,
                menuOptions.If().Null.Throw().Null(nameof(menuOptions)));

            return menu;
        }

        protected IMenuOption<IMenu> CreateSubMenuOption(MenuOptionKey key, IMenu menu)
        {
            return new MenuOption<IMenu>(key, menu);
        }

        protected IMenuOption<IMenuFunc> CreateMenuFuncOption(MenuOptionKey key, string label, Func<PostInvokeCommand> func)
        {
            return new MenuOption<IMenuFunc>(key, new MenuFunc(label, func));
        }

        protected IMenuOption<IMenuFunc> CreateMenuFuncOption(MenuOptionKey key, string label, Action action, 
                                                              bool handleException = true, 
                                                              PostInvokeCommand postInvokeCommand = PostInvokeCommand.StayInSubmenu, 
                                                              bool waitForKeyPress = true)
        {
            return this.CreateMenuFuncOption(key, label, MenuFunc);

            PostInvokeCommand MenuFunc()
            {
                try
                {
                    action();
                }
                catch (Exception exception)
                {
                    if (!handleException)
                        throw exception;
                    Print.Error("Uh-oh! Something unexpected happened and an exception was thrown.");
                    if (this.Confirm("Do you want to view the exception?"))
                        Print.Exception(exception, PostPrintOption.PrintNewLineAndWaitForKeyPress);
                }
                return waitForKeyPress ? this.WaitForKeyPressAndReturn(postInvokeCommand) : postInvokeCommand;
            }
        }

        protected IMenu CreateYesOrNoMenu(string label, Action yesAction, Action noAction, 
                                          PostInvokeCommand yesActionPostInvokeCommand = PostInvokeCommand.ExitSubmenu, 
                                          bool yesAsDefault = true)
        {
            var yesOption = this.CreateMenuFuncOption(MenuOptionKey.Y, "Yes", YesFunc);
            var noOption = this.CreateMenuFuncOption(MenuOptionKey.N, "No", NoFunc);
            var yesNoMenu = yesAsDefault ? new Menu(label, yesOption, noOption) : new Menu(label, noOption, yesOption);
            return yesNoMenu;

            PostInvokeCommand YesFunc()
            {
                yesAction();
                return yesActionPostInvokeCommand;
            }

            PostInvokeCommand NoFunc()
            {
                noAction();
                return PostInvokeCommand.ExitSubmenu;
            }
        }

        protected void WaitForKeyPress() => Console.ReadKey();

        protected PostInvokeCommand WaitForKeyPressAndReturn(PostInvokeCommand postInvokeCommand = PostInvokeCommand.StayInSubmenu)
        {
            this.WaitForKeyPress();
            return postInvokeCommand;
        }

        private bool? GetConfirmationOf(string question, bool trueAsDefault, bool allowNull)
        {
            question += $" ({(trueAsDefault ? "Y/n" : "y/N")}): ";
            return allowNull ? InputService.GetNullableBool(question, trueAsDefault) : InputService.GetBool(question, trueAsDefault);
        }

        private void AddOptionsTo(IMenu menu, params IMenuOption<IMenuItem>[] menuOptions)
        {
            foreach (var menuOption in menuOptions)
            {
                switch (menuOption)
                {
                    case IMenuOption<IMenu> subMenu:
                        menu.AddOptions(subMenu);
                        break;
                    case IMenuOption<IMenuFunc> menuFunc:
                        menu.AddOptions(menuFunc);
                        break;
                    case null:
                        throw new ArgumentNullException(nameof(menuOption));
                    default:
                        throw new InvalidOperationException($"{nameof(menuOption)} is not a valid type.");
                }
            }
        }
    }
}