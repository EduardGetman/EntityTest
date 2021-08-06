using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSecond
{
    class PersonContext : DbContext
    {
        public PersonContext() : base("DBConnection")
        { }
        public DbSet<Person> Persons { get; set; }
    }
}
