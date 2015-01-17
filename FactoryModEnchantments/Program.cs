using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryModEnchantments
{
    class Program
    {
        static void Main(string[] args)
        {
            MetaData m = new MetaData(System.IO.File.ReadAllLines(@"input.txt"));

            System.IO.File.WriteAllLines(@"config.yml", m.output);

            foreach (string l in m.output)
            {
                Console.WriteLine(l);
            }

            Console.ReadKey();
        }
    }
}
