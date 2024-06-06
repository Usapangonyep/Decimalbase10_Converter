using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conversion
{
    class Program
    {
        static string toBinary(int decValue)
        {

            if (decValue == 0)
                return "0";

            string binValue = string.Empty;
            
            while (decValue > 0)
            {
                int remainder = decValue % 2;
                binValue = remainder + binValue;
                decValue /= 2;
            }

            return AddSpacing(binValue, 4);
        }

        static string toOcta(int decValue)
        {

            if (decValue == 0)
                return "0";

            string OctValue = string.Empty;

            while (decValue > 0)
            {
                int remainder = decValue % 8;
                OctValue = remainder + OctValue;
                decValue /= 8;
            }

            return AddSpacing(OctValue, 3);
        }

        static string HexEquivalent(int key)
        {
            Dictionary<int, string> hexValue = new Dictionary<int, string> { 
                { 0, "0" },
                { 1, "1" },
                { 2, "2" },
                { 3, "3" },
                { 4, "4" },
                { 5, "5" },
                { 6, "6" },
                { 7, "7" },
                { 8, "8" },
                { 9, "9" },
                { 10, "A" },
                { 11, "B" },
                { 12, "C" },
                { 13, "D" },
                { 14, "E" },
                { 15, "F" }
            };

            return hexValue[key];
        }

        static string toHexa(int decValue)
        {
         

            if (decValue == 0)
                return "0";

            string HexValue = string.Empty;

            while (decValue > 0)
            {
                int remainder = decValue % 16;
                string tempValue = HexEquivalent(remainder);

                HexValue = tempValue + HexValue;
                decValue /= 16;
            }

            return AddSpacing(HexValue, 2);
        }

        static string AddSpacing(string value, int groupNumber)
        {
            for (int i = value.Length - groupNumber; i > 0; i -= groupNumber)
            {
                value = value.Insert(i, " ");
            }
            return value;
        }

        static void Main(string[] args)
        {
            int DecValue = 0;
           
            Console.WriteLine($"\t====================");
            Console.WriteLine($"\t    CONVERSION      ");
            Console.WriteLine($"\t====================");

            while (true)
            {
                Console.Write($"\n\tPLEASE ENTER DECIMAL (base 10) NUMBER: ");
                String input = Console.ReadLine();

                if (int.TryParse(input, out DecValue))
                {

                    Console.ForegroundColor = ConsoleColor.Green; // change the font color to green

                    Console.WriteLine(); // add extra line, nore readable than \n
                    Console.WriteLine($"\t\t 1. Hex Value (base 16):       {toHexa(DecValue)}");
                    Console.WriteLine($"\t\t 2. Decimal Value (base 10):   {DecValue}");
                    Console.WriteLine($"\t\t 3. Octa Value (base 8):       {toOcta(DecValue)}");
                    Console.WriteLine($"\t\t 4. Binary Value (base 2):     {toBinary(DecValue)}");
                    Console.WriteLine(); //add extra line, nore readable than \n

                    Console.ForegroundColor = ConsoleColor.White; // change the font color back to white

                    Console.Write("Do you want to convert again? [y:n]: ");
                    input = Console.ReadLine();

                    if (input.ToLower() == "n")
                    {
                        break;
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red; // change the font color to red
                    Console.WriteLine($"\tInvalid Input!");
                    Console.ForegroundColor = ConsoleColor.White; // change the font color back to white
                }
            }
        }
    }
}
