using AccessControlSystem.IO.Contracts;

namespace AccessControlSystem.IO
{
    public class Reader : IReader
    {
        public string ReadLine() => Console.ReadLine();
    }
}
