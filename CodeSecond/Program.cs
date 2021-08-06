using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSecond
{
    class Program
    {
        static void Main(string[] args)
        {
            using (PersonContext db = new PersonContext())
            {
                OutputPersons("Полученные объекты:", db.Persons.ToArray());
            }
        }

        static void OutputPersons(string declaringMessage, params Person[] persons)
        {
            Console.WriteLine(declaringMessage);
            foreach (var item in persons)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
