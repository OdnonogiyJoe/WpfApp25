using System;
using System.Collections.Generic;
using System.Text;

namespace WpfApp25
{
    public class User : Mvvm1125.MvvmNotify
    {
        private string name;
        private int age;

        public string Name 
        {
            get => name; 
            set { name = value; NotifyPropertyChanged(); } 
        }
        
        public int Age
        {
            get => age; 
            set { age = value; NotifyPropertyChanged(); }
        }

        public User Clone()
        {
            return new User { Name = name, Age = age };
        }
    }
}
