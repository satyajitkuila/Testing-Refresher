using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpFunda
{
    internal class Palindrome
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Please enter the string to check Palindrome");
            String usrInput = Console.ReadLine();
            Console.WriteLine($"You have entered {usrInput} to check palindrome");
            String reverse = "";
            int length = usrInput.Length;
            Console.WriteLine(length);
            for (int i = length - 1; i >= 0; i--)
            {
                reverse = reverse + usrInput[i];
                Console.WriteLine(reverse);
            }
            if (usrInput.Equals(reverse))
            {
                Console.WriteLine("Entered string/number is a palindrome.");
            }

            else
            {
                Console.WriteLine("Entered string/number isn't a palindrome.");
            }

        }
    }
}
