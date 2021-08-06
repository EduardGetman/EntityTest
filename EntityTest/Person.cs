using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityTest
{
    class Person
    {
        public int Id {get; set;}
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }        
        public string Gender { get; set; }

        public override string ToString()
        {
            return $"Имя: {FirstName}, Фамилия {LastName}, Дата рождения: {BirthDate}, Пол: {Gender}";
        }
    }
}
