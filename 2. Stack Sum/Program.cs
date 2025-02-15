namespace _2._Stack_Sum;

internal class Program
{
    static void Main(string[] args)
    {
        List<int> integersList = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToList();

        Stack<int> integers = new Stack<int>(integersList);

        for (int i = 0; i < integers.Count; i++)
        {
            string input = Console.ReadLine().ToLower();

            if (input == "end")
            {
                break;
            }

            string[] tokens = input.Split();

            string command = tokens[0];

            if (command == "add")
            {
                int num1 = int.Parse(tokens[1]);
                int num2 = int.Parse(tokens[2]);
                integers.Push(num1);
                integers.Push(num2);
            }
            else  // command == "remove"
            {
                int num = int.Parse(tokens[1]);

                if (num > integers.Count)
                {
                    continue;
                }

                for (int j = 0; j < num; j++)
                {
                    integers.Pop();
                }
            }



        }

        Console.Write("Sum: ");
        Console.WriteLine(integers.Sum());

    }
}
