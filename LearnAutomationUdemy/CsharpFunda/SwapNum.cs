using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpFunda
{
    internal class SwapNum
    {
        public static void main(String[] args)
        {

            /********************/
            // Reading integer from user input
            Console.WriteLine("Enter an integer:");
            int intValue = int.Parse(Console.ReadLine());
            Console.WriteLine($"Integer entered: {intValue}");

            // Reading float from user input
            Console.WriteLine("Enter a float:");
            float floatValue = float.Parse(Console.ReadLine());
            Console.WriteLine($"Float entered: {floatValue}");

            // Reading double from user input
            Console.WriteLine("Enter a double:");
            double doubleValue = double.Parse(Console.ReadLine());
            Console.WriteLine($"Double entered: {doubleValue}");

            // Reading boolean from user input
            Console.WriteLine("Enter a boolean (true/false):");
            bool boolValue = bool.Parse(Console.ReadLine());
            Console.WriteLine($"Boolean entered: {boolValue}");

            // Reading character from user input
            Console.WriteLine("Enter a character:");
            char charValue = char.Parse(Console.ReadLine());
            Console.WriteLine($"Character entered: {charValue}");

            // Reading string from user input
            Console.WriteLine("Enter a string:");
            string stringValue = Console.ReadLine();
            Console.WriteLine($"String entered: {stringValue}");
            /*******************/


            Console.WriteLine("Enter the Numbers");

            int aa = int.Parse(Console.ReadLine());
            int bb = int.Parse(Console.ReadLine());
            SwapNum swap = new SwapNum();

            swap.swapwith3rdVar(aa, bb);
            swap.swapwithout3rdVar(aa, bb);

        }

        public void swapwith3rdVar(int a, int b)
        {

            Console.WriteLine("Before swapping with 3rd var: a = " + a + ", b = " + b);
            int c = a;
            a = b;
            b = c;

            Console.WriteLine("After swapping  3rd var: a = " + a + ", b = " + b);

        }

        public void swapwithout3rdVar(int a, int b)
        {

            Console.WriteLine("Before swapping: a = " + a + ", b = " + b);

            a = a + b; // Store sum of both numbers in 'a'
            b = a - b; // Subtract 'b' (initial value of 'b') from 'a' to get the original value of 'a'
                       // and store it in 'b'
            a = a - b; // Subtract 'b' (new value of 'b') from 'a' to get the original value of 'b' and
                       // store it in 'a'

            Console.WriteLine("After swapping: a = " + a + ", b = " + b);

        }

    }
}
