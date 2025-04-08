using AccessControlSystem.Core;
using AccessControlSystem.Core.Contracts;

namespace AccessControlSystem
{
    public class StartUp
    {
        public static void Main()
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}