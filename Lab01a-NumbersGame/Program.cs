using System;
using System.Runtime.Serialization;

namespace Lab01a_NumbersGame
{
    class Program
    {
        static void StartSequence()
        {
            try
            {
                Console.WriteLine("Enter an integer number greater than 0 : ");
                String input = Console.ReadLine();
                int num = Convert.ToInt32(input);
                int[] arr = new int[num];
                Populate(arr);
                int sum = GetSum(arr);
                int product = GetProduct(arr, sum);
                decimal co = GetQuotient(product);

                Console.WriteLine("------------------------------");
                Console.WriteLine("Array Size: " + num);
                Console.Write("Array Elements: ");
                foreach (int e in arr)
                {
                    Console.Write(e+", ");
                }
                
                Console.WriteLine("Array Sum is: " + sum);
                
                Console.WriteLine("Array Product is: " + product);
                
                Console.WriteLine("Array Quotient is: " + co);
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong! " + e);
            }

            
        }

        static int[] Populate(int[] arr)
        {
            for(int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine("Enter number " + (i + 1) + "/" + (arr.Length));
                String input = Console.ReadLine();
                arr[i] = Convert.ToInt32(input);
            }

            return arr;
        }

        static int GetSum(int[] arr)
        {
            int sum = 0;

            foreach (int e in arr)
            {
                sum += e;
            }

            if (sum < 20)
            {
                throw new Exception("Value is less than 20");
            }

            return sum;
        }

        static int GetProduct(int[] arr, int sum)
        {
            int num = -1;
            Console.WriteLine("Pick a random number between 1 and " + arr.Length);
            String input = Console.ReadLine();
            
            try
            {
                num = Convert.ToInt32(input);
                if(num < 1 || num > arr.Length)
                {
                    throw new IndexOutOfRange();
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }

            int product = sum * arr[num];

            return product;
        }

        static decimal GetQuotient(int product)
        {
            Console.WriteLine("Enter number to divide by " + product + " :");
            String input = Console.ReadLine();
            decimal result = 0;
            try
            {
                int num = Convert.ToInt32(input);
                result = Decimal.Divide(product, num);
            }
            catch(DivideByZeroException e)
            {
                Console.WriteLine("Cannot divide on Zero!" + e);
            }
            catch(Exception e)
            {
                Console.WriteLine("Something went wrong! " + e);
            }

            return result;            
        }

        static void Main(string[] args)
        {
            try {
                StartSequence();
            }
            catch(Exception e) {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Program is complete!");
            }
        }
    }

    [Serializable]
    internal class IndexOutOfRange : Exception
    {
        public IndexOutOfRange()
        {
        }

        public IndexOutOfRange(string message) : base(message)
        {
        }

        public IndexOutOfRange(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected IndexOutOfRange(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
