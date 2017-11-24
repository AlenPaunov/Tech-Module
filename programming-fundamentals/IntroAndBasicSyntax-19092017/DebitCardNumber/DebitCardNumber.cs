    using System;

    class DebitCardNumber
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[4];
            for (int i = 0; i < 4; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }
            for (int i = 0; i < 4; i++)
            {
                Console.Write(numbers[i].ToString("0000"));
                if (i < 3)
                {
                    Console.Write(" ");
                }
            }
            Console.WriteLine();
        }
    }

