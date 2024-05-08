using OpenQA.Selenium.DevTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpFunda
{
    internal class leetcodeEx1
    {
        public static void Main(String[] args)
        {
            int[] nums = { 2, 7, 11, 15 };
            int target = 9;

            leetcodeEx1 lx= new leetcodeEx1();

            int[] sol=lx.twoSum(nums,target);

            foreach (int i in sol)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine(lx.ReversePrefix("abcd", 'c'));

            int[] Snum = { -1, 2, -3, 3 ,-4,4};

            Console.WriteLine(lx.FindMaxK(Snum));
        }

        public int[] twoSum(int[] nums, int target)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[j] == target - nums[i])
                    {
                        return new int[] { i, j };
                    }
                }
            }
            throw new ArgumentException("No two sum solution");
        }

        public string ReversePrefix(string word, char ch)
        {
            string result = ""; // Initialize result
            int index = word.IndexOf(ch); // Find the index of the character

            if (index != -1) // If character is found
            {
                string prefix = word.Substring(0, index + 1); // Extract prefix including the character
                Console.WriteLine(prefix);
                string reversedPrefix = new string(prefix.Reverse().ToArray()); // Reverse the prefix
                Console.WriteLine(reversedPrefix);
                result = reversedPrefix + word.Substring(index + 1); // Concatenate reversed prefix with the rest of the word


            }
            else // If character is not found
            {
                // Simply return the original word
                result = word;
            }
            return result;
        }

        public int LargestNegativePair(int[] nums)
        {
            HashSet<int> numSet = new HashSet<int>();

            // Add all elements to the set
            foreach (int num in nums)
            {
                numSet.Add(num);
            }

            int largestNegative = int.MinValue;

            // Check each element in nums
            foreach (int num in nums)
            {
                // Check if the negative counterpart exists in the set
                if (numSet.Contains(-num))
                {
                    largestNegative = Math.Max(largestNegative, num);
                }
            }

            // If no negative counterpart exists, return -1
            if (largestNegative == int.MinValue)
            {
                return -1;
            }

            return largestNegative;
        }

        public int FindMaxK(int[] nums)
        {
            Array.Sort(nums);

            for (int i = 0; i < nums.Length - 1; i++)
            {
                for (int j = nums.Length - 1; i < j; j--)
                {
                    if (-nums[i] == nums[j])
                    {
                        return -nums[i];
                    }
                }
            }
            return -1;
        }
        public string DayOfTheWeek(int day, int month, int year)
        {
            DateTime date = new DateTime(year, month, day);
            return date.ToString("dddd");
        }
    }
}
