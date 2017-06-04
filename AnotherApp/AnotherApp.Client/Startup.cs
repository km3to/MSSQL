using AnotherApp.Data;

namespace AnotherApp.Client
{
    class Startup
    {
        static void Main(string[] args)
        {
            var context = new AnotherAppEntities();
        }
    }
}
