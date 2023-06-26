using Quartz;
using System.Diagnostics;

public class HelloJob : IJob
{
    public async Task Execute(IJobExecutionContext context)
    {
        //var now = DateTime.Now.ToString();
        var message = $"Simple executed at {DateTime.Now.ToString()}";
        Console.BackgroundColor
            = ConsoleColor.Red;
        Console.WriteLine(message);
    }
}