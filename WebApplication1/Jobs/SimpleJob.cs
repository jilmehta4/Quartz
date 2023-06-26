using Quartz;
using System.Diagnostics;

namespace WebApplication1.Jobs
{
    public class SimpleJob : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            var message = $"Current Date is {DateTime.Now.ToString()}";
            //Console.WriteLine(message);
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine(message);
        }
    }
}
