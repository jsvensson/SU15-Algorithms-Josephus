using System;
using System.Linq;

namespace Josephus
{
    class Program
    {
        static void Main(string[] args)
        {
            JosephusValues(50);
        }

        private static void CircularListdemo()
        {
            var circle = new CircularList<int>();

            foreach (int i in Enumerable.Range(1, 5))
            {
                circle.Add(i);
            }

            Console.WriteLine("Starting circle:");
            Console.WriteLine(string.Join(", ", circle.ToArray()));
            Console.WriteLine($"Current: {circle.Current.Value}");

            Console.WriteLine("Advancing 3 steps");
            circle.Step(3);
            Console.WriteLine($"Current: {circle.Current.Value}");
            Console.WriteLine("Removing current");
            circle.RemoveCurrent();
            Console.WriteLine($"Current: {circle.Current.Value}");

            Console.WriteLine("Current circle:");
            Console.WriteLine(string.Join(", ", circle.ToArray()));
        }

        private static void Josephus(int size, int steps = 1, int survivors = 1)
        {
            var circle = new CircularList<int>();
            foreach (int i in Enumerable.Range(1, size))
            {
                circle.Add(i);
            }

            // Start the circus!
            int counter = 0;
            while (circle.Count > survivors)
            {
                circle.Step(steps);
                circle.RemoveCurrent();
                counter++;
            }

            Console.WriteLine($"{survivors} survivor(s) after {counter} steps:");
            Console.WriteLine(string.Join(", ", circle.ToArray()));

        }

        private static void JosephusValues(int maxSize)
        {
            for (int i = 1; i <= maxSize; i++)
            {
                int pos = BinarySolution(i);
                Console.WriteLine($"{i}: {pos}");
            }
        }

        private static int BinarySolution(int n)
        {
            // Fulhack?
            int msb = (int) Math.Log(n, 2);
            int l = n - (int) Math.Pow(2, msb);

            int pos = 2*l + 1;
            return pos;
        }
    }
}
