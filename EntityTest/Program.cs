using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityTest
{
    class Program
    {
        static void Main(string[] args)
        {
            using (PersonContext db = new PersonContext())
            {
                Person[] persons =
                {
                    new Person{ FirstName = "Эдуард", LastName ="Гетман", BirthDate = new DateTime(2000,10,19), Gender ="Муж"},
                    new Person{ FirstName = "Юлия", LastName ="Попова", BirthDate = new DateTime(2000,10,19), Gender ="Жен"}
                };
                OutputPersons("Созданныее объекты:", persons);
                db.Persons.AddRange(persons);
                db.SaveChanges();
                OutputPersons("Полученные объекты:" ,db.Persons.ToArray());

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
