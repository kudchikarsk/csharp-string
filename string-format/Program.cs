using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace string_format
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Format Strings
             * 
             * The string.Format method allows a wide range of formatting options for string data. 
             * The first parameter of this method can be passed a string that may look similar to the following:
             */

            var i = 5;
            var s = "The value of i is {0,5:G}";
            Console.WriteLine(String.Format(s, i)); //Displays The value of i is     5                        
            Console.WriteLine(s, i); //Equivalent to above code

            /*
             * 'The value of i is ' will be displayed as is, with no changes. 
             * The interesting part of this string is the section enclosed in braces. 
             * This section has the following form: 
             * 
             * {index, alignment:formatString}
             * 
             * The section can contain the following three parts:

             * index:
             * A number identifying the zero-based position of the section’s data in the args parameter array. The data is to be formatted accordingly and substituted for this section. This number is required.
             * 
             * alignment:
             * The number of spaces to insert before or after this data. A negative number indicates left justification (spaces are added to the right of the data), and a positive number indicates right justification (spaces are added to the left of the data). This number is optional.
             * 
             * formatString:
             * A string indicating the type of formatting to perform on this data. This section is where most of the formatting information usually resides. Tables Table 2-2 and Table 2-3 contain valid formatting codes that can be used here. This part is optional.
             * 
             * {0,5:G} here 0 is our index, 5 is the number of spaces to be added before value and G represents the standard numeric format which displays the value in its shortest form.
             * You can get a complete list of the standard format specifiers here: https://docs.microsoft.com/en-us/dotnet/standard/base-types/standard-numeric-format-strings
             */

            /* String Interpolation:
             * 
             * String interpolation available in C# 6.0 and later, interpolated strings are 
             * identified by the $ special character and include interpolated expressions in braces.
             * 
             * String interpolation achieves the same results as the String.Format method, 
             * but improves ease of use and inline clarity.
             * 
             * Use string interpolation to improve the readability and maintainability of your code.
             */

            Console.WriteLine($"The value of i is {i,5:G}"); //Equivalent to above code

            /* Instead of passing i as second parameter we can directly use variable i within 
             * the string (in place of index)
             */

            /* Overriding ToString:
             * In addition to the string.Format and the Console.WriteLine methods, the overloaded ToString 
             * instance method of a value type may also use the previous formatting characters. 
             * 
             * Using ToString, the code would look like this:
             */

            var f = 3.1417f;
            string value = f.ToString("Value of pi is 00.####");
            Console.WriteLine(value); //Displays Value of pi is 03.1417

            /*
             * Here the overloaded ToString method accepts a single parameter of type IFormatProvider. 
             * The IFormatProvider provided for the f.ToString method is a string containing the formatting 
             * for the value type plus any extra text that needs to be supplied.
             */

            /* Overriding ToString in System.Object
             * 
             * Overriding ToString is a good practice. If you don’t do this, ToString will return by 
             * default the name of your type. When you override ToString, you can give it a more meaningful 
             * value, as below code shows.
             */

            var p = new Person("John", "Doe");
            Console.WriteLine(p); //Displays John Doe

            /*
             * You can also implement this custom formatting on your own types. 
             * You do this by creating a ToString(string) method on your type. When doing this, make 
             * sure that you are compliant with the standard format strings in the .NET Framework. 
             * 
             * For example, a format string of G should represent a common format for your object 
             * (the same as calling ToString()) and a null value for the format string should also display 
             * the common format.
             * 
             * Here is an example,
             */

            Console.WriteLine(p.ToString("G")); //Displays John Doe
            Console.WriteLine(p.ToString("LSF")); //Displays Doe, John


            Console.ReadLine();
        }
    }

    public class Person
    {
        public Person(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public override string ToString()
        {
            return FirstName + " " + LastName;
        }

        public string ToString(string format)
        {
            if (string.IsNullOrWhiteSpace(format) || format == "G")
            {
                format = "FL";
            }

            format = format.Trim().ToUpperInvariant();
            switch (format)
            {
                case "FL":
                    return FirstName + " " + LastName;
                case "LF":
                    return LastName + " " + FirstName;
                case "FSL":
                    return FirstName + ", " + LastName;
                case "LSF":
                    return LastName + ", " + FirstName;
                default:
                    throw new FormatException(String.Format(
                    "The ‘{0}' format string is not supported.", format));
            }
        }
    }
}
