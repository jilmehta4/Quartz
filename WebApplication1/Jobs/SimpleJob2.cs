using Quartz;

namespace WebApplication1.Jobs
{
    public class SimpleJob2 : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            var message = $"Current Date is {DateTime.Now.ToString()}";
            //Console.WriteLine(message);
            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            return Task.CompletedTask;
        }
    }
}
