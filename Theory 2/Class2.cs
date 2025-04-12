using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theory_2
{
    public class Class2
    {

        public int a;

        private Dictionary<string, Dictionary<int, int>> dict;
        private Dictionary<string, Stack<int>> dict2;
        private Dictionary<string, List<int>> dict3;

        public Queue<int> queue = new Queue<int>();

        public Stack<int> stack = new Stack<int>();

        public Class2() : this (5)
        {
            queue.Enqueue(3);

            queue.Dequeue();

            queue.Peek();



            stack.Push(3);

            stack.Peek();

            stack.Pop();
        }

        private SortedDictionary<int, int> Dictionary = new SortedDictionary<int, int>();


        private SortedSet<int> Ints = new SortedSet<int>();

        public Class2(int a)
        {
            this.a = a;

            
        }
    }
}
