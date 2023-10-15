// Author: minhnpa1907@gmail.com

using Algorithms.Logging;
using System.Text;

namespace Algorithms
{
    public static class Algorithms_21_40
    {
        /// <summary>
        /// Refs: https://leetcode.com/problems/add-binary
        /// </summary>
        /// <param name="a">Example: 11</param>
        /// <param name="b">Example: 1</param>
        /// <returns>Example: 100</returns>
        public static string _21_AddBinary(string a, string b)
        {
            var func = nameof(_21_AddBinary);
            Logger.LoggingStart(func);

            // Input
            var output = new StringBuilder();
            var carry = 0;

            // Process
            var i = a.Length - 1;
            var j = b.Length - 1;

            while (i >= 0 || j >= 0 || carry > 0)
            {
                var sum = carry;

                if (i >= 0)
                {
                    sum += a[i] - '0';
                    i--;
                }

                if (j >= 0)
                {
                    sum += b[j] - '0';
                    j--;
                }

                carry = sum / 2;
                output.Insert(0, sum % 2);
            }

        printOutput:
            // Output
            Logger.LoggingStop(func, output.ToString());
            return output.ToString();
        }
    }
}
