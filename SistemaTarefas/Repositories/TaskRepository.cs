using Microsoft.EntityFrameworkCore;
using SistemaTarefas.Data;
using SistemaTarefas.Models;
using SistemaTarefas.Repositories.Interfaces;

namespace SistemaTarefas.Repositories;

public class TaskRepository : ITaskRepository
{
    private readonly TasksSystemDBContext _dbContext; 
    public TaskRepository(TasksSystemDBContext tasksSystemDBContext)
    {
        _dbContext = tasksSystemDBContext;
    }

    public async Task<List<TaskModel>> SearchAllTasks()
    {
        return await _dbContext.Tasks.ToListAsync();
    }

    public async Task<TaskModel> SearchForId(int id)
    {
        return await _dbContext.Tasks.FirstOrDefaultAsync(x => x.Id == id);
    }
    
    public async Task<TaskModel> AddTask(TaskModel task)
    {
        await _dbContext.Tasks.AddAsync(task);
        await _dbContext.SaveChangesAsync();

        return task;
    }

    public async Task<TaskModel> UpdateTask(TaskModel task, int id)
    {
       TaskModel taskForId = await SearchForId(id);

        if (taskForId == null)
        {
            throw new Exception($"Tarefa com o ID {id} não foi encontrado!");
        }

        taskForId.Name = task.Name;
        taskForId.Description = task.Description;
        taskForId.Status = task.Status; 
        taskForId.UserId = task.UserId;

        _dbContext.Tasks.Update(taskForId);
        await _dbContext.SaveChangesAsync();

        return taskForId;
    }

    public async Task<bool> DeleteTask(int id)
    {
        TaskModel taskForId = await SearchForId(id);

        if (taskForId == null) 
        {
            throw new Exception($"A tarefa com o id {id} não foi encontrado!");
        }

        _dbContext.Tasks.Remove(taskForId);
       await _dbContext.SaveChangesAsync(); 

        return true;
    }

    public Task<List<TaskModel>> SearchForId()
    {
        throw new NotImplementedException();
    }
}
