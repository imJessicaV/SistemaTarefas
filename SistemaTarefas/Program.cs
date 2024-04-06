
using Microsoft.EntityFrameworkCore;
using SistemaTarefas.Data;
using SistemaTarefas.Repositories;
using SistemaTarefas.Repositories.Interfaces;

namespace SistemaTarefas;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        //Configuração da conexação com o banco de dados
        builder.Services.AddEntityFrameworkSqlServer()
            .AddDbContext<TasksSystemDBContext>(
                options => options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase"))
            );

        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<ITaskRepository, TaskRepository>();

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
