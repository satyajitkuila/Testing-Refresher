using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpFunda
{
    
    public class Dictionalry_HashMap
    {
        
        public static void Main(String[] args)
        {
            Dictionalry_HashMap d = new Dictionalry_HashMap();
            
            d.dictionarySave(3);
            d.countChars("Satyajitaaaaa", 'a');
        }
        
        public void dictionarySave(int n)
        {
            Hashtable hsh = new Hashtable();
            hsh.Add("a", "sam");

            Dictionary<int, string> dic = new Dictionary<int, string>();
            dic.Add(1, "Satyajit");
            dic.Add(2, "kuila");
            dic.Add(3, "QA");
            dic.Add(4, "Engineer");

            string value = dic[n];

            var v2 = hsh["a"];
            
            Console.WriteLine("the value is "+value+" new hash value "+v2);
        }

        public void countChars(String word,char letter)
        {
            Dictionary<int, char> dic = new Dictionary<int, char>();
            char[] chars = word.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                dic.Add(i, chars[i]);
            }

            int count = 0;

            for(int i = 0; i < chars.Length; i++)
            {
                if(dic[i]==letter)
                count++;
            }
            Console.WriteLine("The count of chars in the string is "+count);
        }
    }
}
