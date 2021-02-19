using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace WpfApp25
{
    public class MainVm : Mvvm1125.MvvmNotify
    {
        public ObservableCollection<User> Users { get; set; }
        public User SelectedUser { get; set; }

        public CommandWithUserState EditUser { get; set; }

        public Mvvm1125.MvvmCommand Edit { get; set; }
        public Mvvm1125.MvvmCommand Apply { get; set; }
        public Mvvm1125.MvvmCommand Undo { get; set; }

        Stack<CommandWithUserState> AppliedCommands;

        public MainVm()
        {
            AppliedCommands = new Stack<CommandWithUserState>();
            Users = new ObservableCollection<User>(
                new User[] { 
                    new User { Name = "test1", Age = 15 } , 
                    new User { Name = "test2", Age = 10 }});
            Edit = new Mvvm1125.MvvmCommand(
                () => {
                    EditUser = new CommandWithUserState(SelectedUser);
                    NotifyPropertyChanged("EditUser");
                }, 
                () => SelectedUser != null);
            Apply = new Mvvm1125.MvvmCommand(
                () => {
                    EditUser.Execute(null);
                    AppliedCommands.Push(EditUser);
                    EditUser = null;
                    NotifyPropertyChanged("EditUser");
                },
                () => !(SelectedUser == null || EditUser == null));
            Undo = new Mvvm1125.MvvmCommand(
                () => {
                    var lastCommand = AppliedCommands.Pop();
                    lastCommand.Undo();
                }, 
                ()=> AppliedCommands.Count != 0);
        }
    }
}
