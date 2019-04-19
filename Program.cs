using System;
using System.Collections.Generic;

namespace PinGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Pool pool = new Pool(0, 9999);
            List<string> numbers = pool.GetRawNumberPool();
            numbers = pool.GetSortedNumberPool(numbers);

            List<string> pinBatch = new List<string>();
            Generator pinGenerator = new Generator(numbers);

            while (true)
            {
                Console.WriteLine("Press 'N' to create a new PIN batch. 'X' to exit.");
                string input = Console.ReadLine();
                int counter = 0;

                if (string.Compare(input, "n", true) == 0)
                {
                    Console.WriteLine("Getting a new batch of unique PINs.");
                    pinBatch = pinGenerator.GetNewBatch();
                    for (int i = 0; i < pinBatch.Count; i++)
                    {
                        Console.Write(pinBatch[i] + "    ");
                        if (counter % 5 == 0)
                            Console.WriteLine("");
                        counter++;
                    }
                }
                else if (string.Compare(input, "x", true) == 0)
                    Environment.Exit(0);

                Console.WriteLine("");
                Console.WriteLine("End of the process.");
            }
        }
    }
}
