namespace MaxProductApp
{
    /// <summary>
    /// Class <c>MaxProduct</c> Contains a method that finds the maximum product of four numbers in the given input
    /// </summary>
    public class MaxProduct
    {   
        ///calculates the max product of four numbers 
        /// <param name="input"></param>
        public static void CalculateMaxProduct(string input)
        {   
            int maxProduct = -1;
            for (int i = 0; i < input.Length - 3; i++)
            {
                int fourNumbersstring = Convert.ToInt32(input.Substring(i, 4));
                int product = 1;
                while (fourNumbersstring > 0)
                {
                    product *= fourNumbersstring % 10;
                    fourNumbersstring /= 10;
                }
                if (product > maxProduct)
                {
                    maxProduct = product;
                }
            }
            Console.WriteLine("Max Product:{0}", maxProduct);
        }
    }
    class MaxProductApp
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            MaxProduct.CalculateMaxProduct(input);
        }
    }
}