using System;
using System.Threading.Tasks;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HW_Delegate
{
    class Person
    {
        public delegate void OnPropertyChanged<T>(T oldValue, T newValue);
        public delegate void ChangeLocation();
        public Person(string name, int age, Inspector inspector)
        {
            Name = name;
            Age = age;
            this.inspector = inspector;
        }
        public event OnPropertyChanged<string> onNameChanged = null;
        public event OnPropertyChanged<int> onAgeChanged = null;
        public event ChangeLocation changeLocation = null;
        private string name;
        private int age;
        private bool inWork = false;
        private Inspector inspector;
        public string Name
        {
            get => name;
            set
            {
                string oldName = name;
                name = value;
                onNameChanged?.Invoke(oldName, value);
            }
        }
        public int Age
        {
            get => age;
            set
            {
                int oldAge = age;
                age = value;
                onAgeChanged?.Invoke(oldAge, value);
            }
        }
        public bool InWork
        {
            get => inWork;
            set
            {
                if (inWork == value)
                {
                    ForegroundColor = ConsoleColor.Red;
                    WriteLine("Wrong action");
                    ResetColor();
                }
                else
                {
                    inWork = value;
                    changeLocation?.Invoke();
                }
            }
        }
        public void CheckLocation()
        {
            if (inWork)
            {
                WriteLine("Person at work");
                ResetColor();
            }
            else
            {
                WriteLine("Person not at work");
                ResetColor();
            }
        }
        public void Handler_ChangeLocation()
        {
            if (inWork == true)
            {
                inspector.PInWork.Add(this);
                Console.WriteLine("Came at work");
                inspector.Invoke_CountUp();
            }
            else
            {

                Console.WriteLine("Leave work");
                if (inspector.pCount > 0)
                {
                    inspector.PInWork.Remove(this);
                    inspector.Invoke_CountDown();

                }
                else
                {
                    Console.WriteLine("Office is empty");
                }
            }
        }

    }
}
