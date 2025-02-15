namespace _1._Basic_Stack_Operations;

internal class Program
{
    static void Main(string[] args)
    {
        int[] tokens = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToArray();

        int n = tokens[0];
        int s = tokens[1];
        int x = tokens[2];

        int[] integersArray = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToArray();

        Stack<int> integers = new Stack<int>(integersArray);

        for (int i = 0; i < s; i++)
        {
            integers.Pop();
        }

        bool contains = integers.Contains(x);

        if (contains)
        {
            Console.WriteLine(true.ToString().ToLower());
        }
        else
        {
            if (integers.Count == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                integers.OrderBy(i => i);
                Console.WriteLine(integers.Peek());
            }
        }

    }
}

