using System;
using System.Threading.Tasks;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HW_Delegate
{
    class Inspector
    {
        public int pCount = 0;
        public List<Person> PInWork = new List<Person>();
        public delegate void CountChanged();
        public event CountChanged CUp;
        public event CountChanged CDown;
        public void Invoke_CountUp()
        {
            CUp.Invoke();
            WriteLine($"People at work: {pCount}");
            foreach (Person item in PInWork)
            {
                WriteLine(item.Name);
            }
            ResetColor();
        }
        public void Invoke_CountDown()
        {
            CDown.Invoke();
            WriteLine($"People at work: {pCount}");
            foreach (Person item in PInWork)
            {
                WriteLine(item.Name);
            }
        }

        


    }
}
