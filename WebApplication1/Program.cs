using Quartz;
using System.Configuration;
using WebApplication1.Jobs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.   
builder.Services.AddControllersWithViews();
builder.Services.Configure<QuartzOptions>(builder.Configuration.GetSection("Quartz"));
builder.Services.AddQuartz(q =>
{
    q.UseMicrosoftDependencyInjectionScopedJobFactory();
    // Just use the name of your job that you created in the Jobs folder.
    var jobKey = new JobKey("SimpleJob");
    q.AddJob<SimpleJob>(opts => opts.WithIdentity(jobKey));

    q.AddTrigger(opts => opts
        .ForJob(jobKey)
        .WithIdentity("Simple-trigger")
        .WithSimpleSchedule(x => x
        .WithIntervalInSeconds(5)
        .RepeatForever())
    );
});
builder.Services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
