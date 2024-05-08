using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpFunda
{
    internal class chaper_findVowel
    {
        public static void Main(String[] args)
        {
            chaper_findVowel fv=new chaper_findVowel();
            fv.vowelCheck('a');

        }

        public void vowelCheck(char letter)
        {
            // Create a list of characters
            //List<char> vowels = new List<char>() { 'a', 'e', 'i', 'o', 'u' };

            char[] vowels = { 'a', 'e', 'i', 'o', 'u' };


            foreach (char c in vowels)
            {
                if (letter == c)
                {
                    Console.WriteLine("it is a vowel");
                }
            }
        }
    }
}
