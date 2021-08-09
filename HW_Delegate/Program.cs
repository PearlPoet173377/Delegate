using System;
using System.Threading.Tasks;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HW_Delegate
{
    class Program
    {
        static void Main(string[] args)
        {
            Inspector inspector = new Inspector();
            Person person1 = new Person("Ivan", 29, inspector);
            Person person2 = new Person("Vasya", 36, inspector);
            person1.changeLocation += person1.Handler_ChangeLocation;
            person2.changeLocation += person2.Handler_ChangeLocation;
            inspector.CUp += () => { inspector.pCount++; };
            inspector.CDown += () => { inspector.pCount--; };
            person1.InWork = true;
            person2.InWork = true;
            person1.InWork = false;
            person2.InWork = false;





        }
    }
}
