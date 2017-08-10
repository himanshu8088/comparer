using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectsComparer
{
    class Program
    {
        static void Main(string[] args)
        {
            Mammal person1 = new Mammal();
            person1.Age = 22;

            Mammal person2 = new Mammal();
            person2.Age = 23;

            Comparer comparer = new Comparer();            
            Console.WriteLine(comparer.CompareObjects(person1,person2));
            Console.ReadKey();
        }
    }

}
