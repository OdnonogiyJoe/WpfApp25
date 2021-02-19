using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace WpfApp25
{
    public class CommandWithUserState : ICommand
    {
        string name_old;
        int age_old;

        public string Name { get; set; }
        public int Age { get; set; }
        User user;

        public CommandWithUserState(User user)
        {
            this.user = user;
            Name = user.Name;
            Age = user.Age;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            name_old = user.Name;
            age_old = user.Age;
            user.Name = Name;
            user.Age = Age;
        }

        public void Undo()
        {
            user.Name = name_old;
            user.Age = age_old;
        }
    }
}
