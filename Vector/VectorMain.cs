using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vector
{
    class VectorMain
    {
        static void Main(string[] args)
        {
            Vector vector = new Vector(10, new double[]{1,5,6,7});
            Console.WriteLine(vector);
        }
    }
}
