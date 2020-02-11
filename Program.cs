using System;
using System.Linq;
using System.Reflection;

namespace GetCountTypeMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach(var refAssem in Assembly.GetEntryAssembly().GetReferencedAssemblies())
            {
                var name  = Assembly.Load(new AssemblyName(refAssem.FullName));
                int count = 0;
                foreach(var type in name.DefinedTypes)
                {
                    count += type.GetMethods().Count();
                }
                Console.WriteLine($"types:{name.DefinedTypes.Count()} methods:{count} - assembly name:{refAssem.Name}");
            }
            Console.ReadKey();
        }
    }
}
