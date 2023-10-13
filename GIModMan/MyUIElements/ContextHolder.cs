using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace GIModMan.MyUIElements
{
    internal class ContextHolder : ContentControl
    {
        private readonly Dictionary<ICommand, CommandBinding> _dict;

        public static readonly DependencyProperty CommandsProperty = 
            DependencyProperty.Register("Commands", typeof(CommandsCollection), typeof(ContextHolder), new PropertyMetadata(null));

        public CommandsCollection Commands
        {
            get { return (CommandsCollection) GetValue(CommandsProperty); }
            set { SetValue(CommandsProperty, value); }
        }

        public ContextHolder()
        {
            _dict = new Dictionary<ICommand, CommandBinding>();
            Commands = new CommandsCollection();
            Commands.Changed += FreezableCollectionChanged;

            CommandManager.AddCanExecuteHandler(this, CanExecute);
            CommandManager.AddExecutedHandler(this, OnExecute);
        }

        private void OnExecute(object sender, ExecutedRoutedEventArgs e)
        {
            if(_dict.TryGetValue(e.Command, out CommandBinding binding))
            {
                if(binding.RelayCommand != null)
                {
                    binding.RelayCommand.Execute(e.Parameter);
                }
            }
        }

        private void CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if(_dict.TryGetValue(e.Command, out CommandBinding binding))
            {
                if(binding.RelayCommand != null)
                {
                    e.CanExecute = binding.RelayCommand.CanExecute(e.Parameter);
                }
            }
        }

        private void FreezableCollectionChanged(object sender, EventArgs e)
        {
            _dict.Clear();
            foreach(var command in Commands) 
            { 
                _dict.Add(command.RoutedCommand, command);
            }
        }
    }
    class CommandsCollection : FreezableCollection<CommandBinding> { }
    class CommandBinding : Freezable
    {
        public static readonly DependencyProperty RoutedCommandProperty =
            DependencyProperty.Register("RoutedCommand", typeof(ICommand), typeof(CommandBinding), new PropertyMetadata(null));

        public static readonly DependencyProperty RelayCommandProperty =
            DependencyProperty.Register("RelayCommand", typeof(ICommand), typeof(CommandBinding), new PropertyMetadata(null));

        public ICommand RoutedCommand
        {
            get { return (ICommand) GetValue(RoutedCommandProperty); }
            set { SetValue(RoutedCommandProperty, value); }
        }

        public ICommand RelayCommand
        {
            get { return (ICommand) GetValue(RelayCommandProperty); }
            set { SetValue(RoutedCommandProperty, value); }
        }

        protected override Freezable CreateInstanceCore()
        {
            return new CommandBinding();
        }
    }
}
