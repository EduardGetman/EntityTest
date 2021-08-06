using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelFerst
{
    class Program
    {
        static void Main(string[] args)
        {
            using (MyModelContainer container = new MyModelContainer())
            {
                container.UserSet.Add(new User() { Name = "Eduard", Age = 20 });
                container.UserSet.Add(new User() { Name = "Julia" });
                container.SaveChanges();
                foreach (var item in container.UserSet.ToList())
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}
