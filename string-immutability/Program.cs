using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace string_immutability
{
    class Program
    {
        static void Main(string[] args)
        {
            /*String immutability:
             * One of the special characteristics of a string is that it is immutable, 
             * so it cannot be changed after it has been created. Every change to a 
             * string will create a new string. This is why all of the String manipulation
             * methods return a string.
             * 
             * Immutability is useful in many scenarios. Reasoning about a structure if 
             * you know it will never change is easier. It cannot be modified so it is 
             * inherently thread-safe. 
             * 
             * It is more secure because no one can mess with it. Suddenly something like creating 
             * undo-redo is much easier, your data structure is immutable and you maintain only 
             * snapshots of your state.
             * 
             * But immutable data structures also have a negative side. Let's see how,
             */

            string s = string.Empty;
            for (int i = 0; i < 10000; i++)
            {
                s += "x";
            }
            Console.WriteLine(s);
            /*
             *The above looks innocent, but it will create a new string 
             * for each iteration in your loop. It uses a lot of unnecessary memory and 
             * shows why you have to use caution when working with strings. 
             * 
             * This code will run 10,000 times, and each time it will create a new string. 
             * The reference s will point only to the last item, so all other strings are 
             * immediately ready for garbage collection.
             * 
             * When working with such a large number of string operations, you have to keep in mind 
             * that string is immutable and that the .NET Framework offers some special helper classes 
             * when dealing with strings. Let's see one such class
             */

            var sb = new StringBuilder();

            /* 
             * StringBuilder - The StringBuilder class can be used when you are working with strings 
             * in a tight loop. Instead of creating a new string over and over again, you can use the 
             * StringBuilder, which uses a string buffer internally to improve performance. 
             * 
             * The StringBuilder class even enables you to change the value of individual characters 
             * inside a string.
             * 
             * Our previous example of concatenating a string 10,000 times can be rewritten 
             * with a StringBuilder,
             */

            for (int i = 0; i < 10000; i++)
            {
                sb.Append("x");
            }
            Console.WriteLine(sb.ToString());

            /*
             * One thing to keep in mind is that the StringBuilder does not always give better performance. 
             * When concatenating a fixed series of strings, the compiler can optimize this and combine 
             * individual concatenation operations into a single operation. When you are working with an 
             * arbitrary number of strings, such as in the loop example, a StringBuilder is a better choice 
             * (in this example, you could have also used new String('x', 10000) to create the string; 
             * when dealing with more varied data, this won’t be possible).
             */

            Console.WriteLine(new String('x', 10000));

            Console.ReadLine();

        }
    }
}
