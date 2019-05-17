using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelectionSort
{
    class Program
    {

        static int[] Numbers;
        const int Length = 100000;
        const bool Display = false;

        static void Main(string[] args)
        {
            Numbers = new int[Length];
            Random random = new Random();
            for (int i = 0; i < Numbers.Length; i++)
                Numbers[i] = random.Next(0, Numbers.Length + 1);

            //Console.WriteLine("Orignal Array:");

            //for (int i = 0; i < Numbers.Length; i++)
                //Console.Write($"{Numbers[i]} ");

            Stopwatch sw = new Stopwatch();

            sw.Restart();
            int[] selectionSort = SelectionSort();
            sw.Stop();
            Console.WriteLine($"Selection Sort: {sw.ElapsedMilliseconds} ms and {sw.ElapsedTicks} ticks");

            sw.Restart();
            int[] standardBubbleSort = StandardBubbleSort();
            sw.Stop();
            Console.WriteLine($"Standard Bubble Sort: {sw.ElapsedMilliseconds} ms and {sw.ElapsedTicks} ticks");

            sw.Restart();
            int[] insertionSort = InsertionSort();
            sw.Stop();
            Console.WriteLine($"Insertion Sort: {sw.ElapsedMilliseconds} ms and {sw.ElapsedTicks} ticks");

            if(Display)
            {
                Console.WriteLine("\n\nSelection Sort: ");
                for (int i = 0; i < selectionSort.Length; i++)
                    Console.Write($"{selectionSort[i]} ");

                Console.WriteLine("\n\nStandard Bubble Sort: ");
                for (int i = 0; i < standardBubbleSort.Length; i++)
                    Console.Write($"{standardBubbleSort[i]} ");

                Console.WriteLine("\n\nInsertion Sort: ");
                for (int i = 0; i < insertionSort.Length; i++)
                    Console.Write($"{insertionSort[i]} ");
            }

            Console.ReadLine();
        }

        static int[] SelectionSort()
        {
            int[] numbers = CopyNumbers();
            int min, temp;
            for (int i = 0; i < numbers.Length; i++)
            {
                min = i;
                for (int x = i + 1; x < numbers.Length; x++)
                    if (numbers[x] < numbers[min]) min = x;
                temp = numbers[i];
                numbers[i] = numbers[min];
                numbers[min] = temp;
            }
            return numbers;
        }

        static int[] StandardBubbleSort()
        {
            int[] numbers = CopyNumbers();
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                for (int j = 0; j < numbers.Length - 1; j++)
                {
                    if (numbers[j] > numbers[j + 1])
                    {
                        int temp = numbers[j + 1];
                        numbers[j + 1] = numbers[j];
                        numbers[j] = temp;
                    }
                }
            }
            return numbers;
        }

        static int[] InsertionSort()
        {
            int[] numbers = CopyNumbers();
            int temp, j;
            for (int i = 1; i < numbers.Length; i++)
            {
                j = i;
                temp = numbers[i];
                while (j > 0 && numbers[j - 1] >= temp)
                {
                    numbers[j] = numbers[j - 1];
                    j--;
                }
                numbers[j] = temp;
            }

            return numbers;
        }

        static int[] CopyNumbers()
        {
            int[] copy = new int[Length];
            Array.Copy(Numbers, copy, Numbers.Length);
            return copy;
        }
    }
}
