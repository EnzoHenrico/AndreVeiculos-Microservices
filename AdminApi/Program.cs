using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AdminApi.Data;
namespace AdminApi;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddDbContext<AdminApiContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("AdminApiContext") ?? throw new InvalidOperationException("Connection string 'AdminApiContext' not found.")));

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
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