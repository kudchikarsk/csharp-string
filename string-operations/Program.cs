using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace string_operations
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Searching for strings
             * 
             * When working with strings, you often look for a substring inside another string (to parse some
             * content or to check for valid user input or some other scenario).
             * The String class offers a couple of methods that can help you perform all kinds of search
             * actions. The most common are IndexOf, LastIndexOf, StartsWith, EndsWith, and SubString.
             */

            /*
            IndexOf returns the index of the first occurrence of a character or substring within a string.
            If the value cannot be found, it returns -1. The same is true with LastIndexOf, except this
            method begins searching at the end of a string and moves to the beginning.
             */

            {
                string value = "My Sample Value";
                int indexOfp = value.IndexOf('p'); // returns 6
                int lastIndexOfm = value.LastIndexOf('m'); // returns 5
            }

            /*
            StartsWith and EndsWith see whether a string starts or ends with a certain value, respectively.
            It returns true or false depending on the result.
            */

            {
                string value = "< mycustominput >";
                Console.WriteLine(value.StartsWith("<"));
                Console.WriteLine(value.EndsWith(">"));
            }

            /* Substring can be used to retrieve a partial string from another string. You can pass a start
            and a length to Substring. If necessary, you can calculate these indexes by using IndexOf or
            LastIndexOf.
            */
            {
                string value = "My Sample Value";
                string subString = value.Substring(3, 6); // Returns 'Sample'
            }


            /*
             * Use the Replace method to replace all occurrences of a specified substring with a new string. 
             * Like the Substring method, Replace actually returns a new string and does not modify the original string.
             */

            {
                string[] names = { "Mr. Henry Hunt", "Ms. Sara Samuels",
                                    "Abraham Adams", "Ms. Nicole Norris" };
                foreach (string name in names)
                {
                    Console.WriteLine(name.Replace("Mr. ", String.Empty).Replace("Ms. ", String.Empty));
                }
                    
            }
            Console.ReadLine();
        }
    }
}
