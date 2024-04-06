using Microsoft.EntityFrameworkCore;
using SistemaTarefas.Data.Map;
using SistemaTarefas.Models;

namespace SistemaTarefas.Data;

public class TasksSystemDBContext : DbContext
{
    public TasksSystemDBContext(DbContextOptions<TasksSystemDBContext> options) : base(options)
    {

    }

    //ORM facilta o trabalho com banco de dados independente do banco de dados
    public DbSet<UserModel> Users { get; set; }
    //userModel representa uma tabela no banco de dados que no banco será a tabela USERS
    public DbSet<TaskModel> Tasks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.ApplyConfiguration(new MapUser());
        modelBuilder.ApplyConfiguration(new MapTask());

        base.OnModelCreating(modelBuilder);
    }
}
