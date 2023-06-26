using Microsoft.AspNetCore.Mvc;
using Quartz;
using Quartz.Impl;
using System.Diagnostics;
using WebApplication1.Jobs;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        // private readonly IScheduler _scheduler;
        public HomeController(ILogger<HomeController> logger)
        {
         
            _logger = logger;
        }

        public async Task<IActionResult> StartSimpleJob()
        {
            StdSchedulerFactory factory = new StdSchedulerFactory();
            IScheduler scheduler = await factory.GetScheduler();

            // and start it off
            await scheduler.Start();

            IJobDetail job = JobBuilder.Create<SimpleJob2>()
                .WithIdentity("simplejob", "quartzexample")
                .Build();

            ITrigger trigger = TriggerBuilder.Create().WithIdentity("testtrigger", "quartzexamples")
                                .StartNow()
                                .WithSimpleSchedule(x=>x.WithIntervalInSeconds(5).WithRepeatCount(5))
                                .Build();
            await scheduler.ScheduleJob(job, trigger);

            return RedirectToAction("Index");
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}