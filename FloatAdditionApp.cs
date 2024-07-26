//3.Input: Consider n, and m as two float inputs

//Implementation: Convert float inputs to binary and perform addition and convert the result back to float.

//Output: Print the float result
namespace FloatAdditionApp
{
    /// <summary>
    /// Class <c>BinarybitAddition</c> Contains the methods to convert float to binary and performs the addition at bit level and
    /// returns the sum of two floats after binary addition
    /// </summary>
    class BinarybitAddition
    {
        /// <summary>
        /// Converts the float number input to the binary format with the decimal point
        /// </summary>
        /// <param name="input"></param>
        /// <returns ></returns>
        public static string Floattobinary(float input)
        {
            int integralpart = (int)Math.Floor(input);
            Console.WriteLine(integralpart);
            string integer = string.Empty;
            float decimalpart = input - integralpart;
            Console.WriteLine(decimalpart);
            if (integralpart == 0) integer += 0;
            while (integralpart > 0)
            {
                integer += integralpart % 2;
                integralpart /= 2;
            }
            char[] arr = integer.ToCharArray();
            Array.Reverse(arr);
            string rev_integer = new(arr);
            string decimalstr = string.Empty;
            float tempdecimal;
            for (int i = 0; i < 23; i++)
            {
                tempdecimal = decimalpart * 2;
                //Console.WriteLine(tempdecimal);
                int int_part = (int)Math.Floor(tempdecimal);
                //Console.WriteLine(int_part);
                decimalstr += int_part;
                decimalpart = tempdecimal - int_part;
                //Console.WriteLine(tempdecimal);
            }
            rev_integer += ".";
            rev_integer += decimalstr;

            Console.WriteLine(rev_integer);
            return rev_integer;

        }
        /// <summary>
        /// Adds the float numbers in the bit level
        /// </summary>
        /// <param name="str1"></param>
        /// <param name="str2"></param>
        public static void FloatAddition(string str1, string str2)
        {
            int indexofPoint1 = str1.IndexOf('.');
            int indexofPoint2 = str2.IndexOf('.');
            string str1withoutpoint = string.Empty, str2withoutpoint = string.Empty;

            if (indexofPoint1 - indexofPoint2 > 0)
                for (int i = 0; i < indexofPoint1 - indexofPoint2; i++)
                    str2withoutpoint += 0;
            else
                for (int i = 0; i < indexofPoint2 - indexofPoint1; i++) 
                    str1withoutpoint += 0;

            for (int i = 0; i < indexofPoint1; i++)
                str1withoutpoint += str1[i];
            for (int i = 0; i < indexofPoint2; i++)
                str2withoutpoint += str2[i];
            for (int i = indexofPoint1 + 1; i < str1.Length; i++)
                str1withoutpoint += str1[i];
            for (int i = indexofPoint2 + 1; i < str2.Length; i++)
                str2withoutpoint += str2[i];

            string finalans = string.Empty;
            char carry = '0';
            for (int i = str1withoutpoint.Length - 1; i >= 0; i--)
            {
                if (str1withoutpoint[i] == '0' & str2withoutpoint[i] == '0')
                {
                    if (carry == '0')
                    {
                        finalans += '0';
                        carry = '0';
                    }
                    else
                    {
                        carry = '0';
                        finalans += '1';
                    }
                }
                else if ((str1withoutpoint[i] == '0' & str2withoutpoint[i] == '1') | (str1withoutpoint[i] == '1' & str2withoutpoint[i] == '0'))
                {
                    if (carry == '1')
                    {
                        carry = '1';
                        finalans += '0';
                    }
                    else
                    {
                        carry = '0';
                        finalans += '1';
                    }
                }
                else
                {
                    if (carry == '0')
                    {
                        finalans += '0';
                        carry = '1';
                    }
                    else
                    {
                        carry = '1';
                        finalans += '1';
                    }
                }
            }
            if (carry == '1')
            {
                finalans += '1';
            }
            char[] arr = finalans.ToCharArray();
            Array.Reverse(arr);
            string finalstring = new(arr);
            BinarybitAddition.BinarytoFloat(finalstring);


        }
        public static void BinarytoFloat(string str)
        {
            //Console.WriteLine(str);
            //Console.WriteLine(point);
            float floataddition = 0;
            int power = 0;
            for (int i = str.Length - 23 - 1; i >= 0; i--)
            {
                if (str[i] == '1') floataddition += Convert.ToSingle(Math.Pow(2, power));
                power++;
            }
            //Console.WriteLine(floataddition);
            power = -1;
            for (int i = str.Length - 23; i < str.Length; i++)
            {
                if (str[i] == '1') floataddition += Convert.ToSingle(Math.Pow(2, power));
                power--;
            }
            Console.WriteLine(floataddition);
        }

    }
    class Program
    {
        public static void Main()
        {
            float number1 = Convert.ToSingle(Console.ReadLine());
            float number2 = Convert.ToSingle(Console.ReadLine());
            string num1str = BinarybitAddition.Floattobinary(number1);
            string num2str = BinarybitAddition.Floattobinary(number2);
            BinarybitAddition.FloatAddition(num1str, num2str);
        }
    }
}