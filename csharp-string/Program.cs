using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace string_interning
{
    class Program
    {
        static void Main(string[] args)
        {
            /* String interning:
             * 
             * In computer science, string interning is a method of storing only one copy 
             * of each distinct string value, which must be immutable. 
             * 
             * Interning strings makes some string processing tasks more time- or space-efficient 
             * at the cost of requiring more time when the string is created or interned. 
             * 
             * The distinct values are stored in a string intern pool.
             * 
             * String interning is supported by some modern programming languages, including .NET languages.
             */

            var s1 = "hello";
            var s2 = "hello";

            /*
             * When creating two identical string literals in one compilation unit, the compiler ensures
             * that only one string object is created by the CLR. This is string interning, which is done 
             * only at compile time. Like in the above example.
             * 
             * Doing it at runtime would incur too much of a performance penalty.
             * Searching through all strings every time you create a new one is too costly.
             * Below are some example where string interning does not work and creates new object in the heap.
             */



            var s3 = new String(new char []{ 'h', 'e', 'l', 'l', 'o'}); //string interning will not happen here

            /* The string object contains an array of Char objects internally. 
             * A string has a Length property that shows the number of Char objects it contains. */

            var s4 = String.Copy(s1); //string interning will not happen here

            /* The static String.Copy(string ...) method creates a new instance of a string by 
             * copying an existing instance. */



            Console.WriteLine("s1 = {0}", s1);
            Console.WriteLine("s2 = {0}", s2);
            Console.WriteLine("s3 = {0}", s3);
            Console.WriteLine("s4 = {0}", s4);

            /*
             * Let's run the program and see the result,
             * Here, ReferenceEquals method determines whether the specified 
             * System.Object instances (String in our case) are the same instance.
             * 
             * Thus, ReferenceEquals(s1, s3) and ReferenceEquals(s1, s4) will be false 
             * as they s1, s3 and s4 are three different objects in the heap.
             * 
             * But, s1 and s2 have reference to same object
             */
            Console.WriteLine("ReferenceEquals(s1, s2): {0}", ReferenceEquals(s1,s2));  //True
            Console.WriteLine("ReferenceEquals(s1, s3): {0}", ReferenceEquals(s1, s3)); //False     
            Console.WriteLine("ReferenceEquals(s1, s4): {0}", ReferenceEquals(s1, s4)); //False

            /*
             * The below condition will be true in our case because, String is a reference type 
             * that looks like value type (for example, the equality operators == and != are 
             * overloaded to compare on value, not on reference). 
             */

            Console.WriteLine("s1==s2: {0}", s1 == s2); //True
            Console.WriteLine("s1==s3: {0}", s1 == s3); //True
            Console.WriteLine("s1==s4: {0}", s1 == s4); //True

            Console.ReadLine();
        }
    }
}
