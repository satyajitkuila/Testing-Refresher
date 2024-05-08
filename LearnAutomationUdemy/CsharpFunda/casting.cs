using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpFunda
{
    public class casting
    {
        public static void main(String[] args)
        {
            int numInt1 = 10;
            double numDouble1 = numInt1; // Implicit typecasting from int to double

            double numDouble = 10.5;
            int numInt = (int)numDouble; // Explicit typecasting from double to int


        }
    }
}
