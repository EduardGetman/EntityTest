using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSecond
{
    class Person
    {
        public int Id { get; set; }
        public string FerstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }

        public override string ToString()
        {
            return $"Имя: {FerstName}, Фамилия {LastName}, Дата рождения: {BirthDate}";
        }
    }
}
