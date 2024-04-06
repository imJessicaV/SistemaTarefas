using SistemaTarefas.Models;

namespace SistemaTarefas.Repositories.Interfaces;

public interface ITaskRepository
{
    Task<List<TaskModel>> SearchAllTasks();
    Task<TaskModel> SearchForId(int id);
    Task<TaskModel> AddTask(TaskModel task);
    Task<TaskModel> UpdateTask(TaskModel task, int id);
    Task<bool> DeleteTask(int id);
    Task<List<TaskModel>> SearchForId();
}
