using System;
using System.Linq;
using System.Collections.Generic;

namespace HelloWold;

public static class Program
{
    public static void Main()
    {
        string input = Console.ReadLine();
        Stack<char> stack = new Stack<char>(input);

        for (int i = 0; i < input.Length; i++)
        {
            Console.Write(stack.Pop());
        }

    }
}