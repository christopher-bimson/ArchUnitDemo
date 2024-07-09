
using BasicTaskList.Api.Model.ApplicationServices;
using BasicTaskList.Api.Model.Core;
using BasicTaskList.Api.Model.InfrastructureServices;

namespace BasicTaskList.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        
        builder.Services.AddTransient<ListApplicationService>();
        builder.Services.AddSingleton<ITaskListRepository, InMemoryTaskListRepository>();
        
        var app = builder.Build();
        
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }
}
