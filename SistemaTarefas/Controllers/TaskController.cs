using Microsoft.AspNetCore.Mvc;
using SistemaTarefas.Models;
using SistemaTarefas.Repositories;
using SistemaTarefas.Repositories.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SistemaTarefas.Controllers;
[Route("api/[controller]")]
[ApiController]
public class TaskController : ControllerBase
{
    private readonly ITaskRepository _taskRepository;

    public TaskController(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    //BUSCA TODOS OS USUÁRIOS
    [HttpGet] //buscar dados | isso é chamado de verbo(verbose?) | Lista todos os user quando está sem parametro
    public async Task<ActionResult<List<TaskModel>>> searchAllTasks()
    {
       List<TaskModel> tasks = await _taskRepository.SearchAllTasks();
        return Ok(tasks);
    }

    //BUSCA UM UNICO USUÁRIO
    [HttpGet("{id}")]
    public async Task<ActionResult<TaskModel>> searchForId(int id)
    {
        TaskModel task = await _taskRepository.SearchForId(id);
        return Ok(task);
    }

    //CADASTRO DE USUÁRIOS
    [HttpPost]
    public async Task<ActionResult<TaskModel>> Register([FromBody] TaskModel taskModel)
    {
        TaskModel task = await _taskRepository.AddTask(taskModel);    

        return Ok(task);
    }

    [HttpPut]
    public async Task<ActionResult<TaskModel>> Update([FromBody] TaskModel taskModel, int id)
    {
        taskModel.Id = id;
        TaskModel task = await _taskRepository.UpdateTask(taskModel, id);
        return Ok(task);
    }

    [HttpDelete]
    public async Task<ActionResult<TaskModel>> Delete(int id)
    {
        bool deleted = await _taskRepository.DeleteTask(id);
        return Ok(deleted);
    }

}

