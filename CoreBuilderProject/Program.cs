using System;

namespace CoreBuilderProject
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Enter your own project paths
            var filename = @"c:\users\bhp\source\repos\SDM\YetAnotherBank";
            
            var buildManager = new MyBuildManager();
            buildManager.AddAgent("Agent1", filename, 5);
            buildManager.AddAgent("Agent2", filename, 10);

            //Console.Write("Press any key to stop agent...");
            Console.ReadKey();

            buildManager.RemoveAgent("Agent1");

            Console.ReadKey();
            buildManager.RemoveAgent("Agent2");

            Console.WriteLine("Agents canceled");            
        }
    }
}
