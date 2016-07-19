using System;
using System.Text.RegularExpressions;


namespace Algorithms
{
    /// <summary>
    /// input:
    /// 0123456789123
    /// 123012312
    /// 
    /// output:
    ///  ***
    /// **********
    /// 0123456789
    /// 
    ///  **
    ///  ***
    /// ****
    /// 0123456789 
    /// </summary>
    public class PrintStarHistogram 
    {
        private const int LENGTH = 10;
        public void Analysis(string pro)
        {
            int max = 0;
            if(String.IsNullOrEmpty(pro))
                return;
           
            int[]  product=new int[LENGTH];
            for (int i = 0; i < pro.Length; i++)
            {
                int index = pro[i]-48;
                product[index]++;
                if (max < product[index])
                    max = product[index];
            }
            Print(product, max);
        }
        public void Test()
        {
            string pro = "";

            Console.WriteLine("Please input Q for ending input.");
            do
            {
                pro = Console.ReadLine();
                if (!InternalCheck(pro))
                    Analysis(pro);
            } while (pro != "Q");

        }

        private bool InternalCheck(string input)
        {
            if (input.Length > 100) return false;
            string pattern = @"\D";
            return Regex.IsMatch(input, pattern);
        }

        private void Print(int[] product, int maxProduct)
        {
            if (product == null)
                return;
            if (product.Length != LENGTH)
                return;
            if (maxProduct == 0) return;
            int temp = maxProduct;
            while (temp > 0)
            {
                for (int i = 0; i < LENGTH; i++)
                {
                    if (product[i] < temp)
                        Console.Write(" ");
                    else
                    {
                        Console.Write("*");
                    }
                }
                Console.WriteLine();
                temp--;
            }
            for(int i=0;i<LENGTH;i++)
                Console.Write(i);
            Console.WriteLine();
            
        }
    }
}
