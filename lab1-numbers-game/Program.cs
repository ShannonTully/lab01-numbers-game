using System;

namespace lab1_numbers_game
{
    class Program
    {
        static void Main(string[] args)
        {
            try 
	        {
                StartSequence();  // handles all the stuff
	        }
	        catch (Exception e)
	        {
                Console.WriteLine("It Broke.");  // all the errors
                Console.Error.WriteLine(e.Message);  // actual message
	        }
            finally
            {
                Console.WriteLine("You are done.");  // end of game
                Console.Write("Press anything to end.");
                Console.ReadKey();  // this thing is so it doesn't end until the user is ready
            }
            
        }

        static void StartSequence()
        {
            try 
	        {	        
		        Console.Write("Enter a number greater than 0: ");  // ammount of numbers
                int num = Convert.ToInt32(Console.ReadLine());
                int[] intarray = new int[num];
                intarray = Populate(intarray);  // add numbers into array
                int sum = GetSum(intarray);  // get sum of array
                int product = GetProduct(intarray, sum);  // get product
                decimal quotient = GetQuotient(product);  // get quotient
                Console.WriteLine(String.Format("There are {0} numbers in your array.", intarray.Length));
                Console.WriteLine(String.Format("The numbers of this array are: {0}.", String.Join(", ", intarray)));
                Console.WriteLine(String.Format("The sum of the array is {0}.", sum));
                Console.WriteLine(String.Format("The number you selected times the sum of the array is {0}.", product));
                Console.WriteLine(String.Format("The product of that divided by the number you chose is {0}.", quotient));
	        }
	        catch (OverflowException)
	        {
		        throw new OverflowException("That number is too big!");  // if they decided to be smarty pants
	        }
	        catch (FormatException)
	        {
		        throw new FormatException("I can't print that.");  // I don't know when this will be thrown
	        }
            
        }

        static int[] Populate(int[] intarray)
        {
            for (int i = 0; i < intarray.Length; i++)
			{
                Console.WriteLine(String.Format("Enter a number ({0} out of {1}): ", i + 1, intarray.Length));
                int num = Convert.ToInt32(Console.ReadLine());
                intarray[i] = num;
			}
            return intarray;
        }

        static int GetSum(int[] intarray)
        {
            int sum = 0;
            for (int i = 0; i < intarray.Length; i++)
			{
                sum = sum + intarray[i];
			}
            if (sum < 20)
            {
                throw new Exception("Use bigger numbers!");
            }
            return sum;

        }

        static int GetProduct(int[] intarray, int sum)
        {
            Console.WriteLine(String.Format("Pick a number between 1 and {0}.", intarray.Length));
            int num = Convert.ToInt32(Console.ReadLine());
            if (num > intarray.Length)
            {
                throw new IndexOutOfRangeException("That's too big.");
            }
            return sum * intarray[num - 1];
        }

        static decimal GetQuotient(int product)
        {
            Console.WriteLine($"Enter a number to divide {product} by."); // This is so much nicer than String.Format
            int num = Convert.ToInt32(Console.ReadLine());
            try
            {
                decimal quotient = decimal.Divide(product, num);
                return quotient;
            }
            catch (DivideByZeroException)
            {

                throw new DivideByZeroException("Don't divide by zero.");
            }
        }

    }
}
