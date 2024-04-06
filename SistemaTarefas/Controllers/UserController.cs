using Microsoft.AspNetCore.Mvc;
using SistemaTarefas.Models;
using SistemaTarefas.Repositories.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SistemaTarefas.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserRepository _userRepository;

    public UserController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    //BUSCA TODOS OS USUÁRIOS
    [HttpGet] //buscar dados | isso é chamado de verbo(verbose?) | Lista todos os user quando está sem parametro
    public async Task<ActionResult<List<UserModel>>> searchAllUser()
    {
       List<UserModel> users = await _userRepository.SearchAllUsers();
        return Ok(users);
    }

    //BUSCA UM UNICO USUÁRIO
    [HttpGet("{id}")]
    public async Task<ActionResult<UserModel>> searchForId(int id)
    {
        UserModel user = await _userRepository.SearchForId(id);
        return Ok(user);
    }

    //CADASTRO DE USUÁRIOS
    [HttpPost]
    public async Task<ActionResult<UserModel>> Register([FromBody] UserModel userModel)
    {
        UserModel user = await _userRepository.AddUser(userModel);    

        return Ok(user);
    }

    [HttpPut]
    public async Task<ActionResult<UserModel>> Update([FromBody] UserModel userModel, int id)
    {
        userModel.Id = id;
        UserModel user = await _userRepository.UpdateUser(userModel, id);
        return Ok(user);
    }

    [HttpDelete]
    public async Task<ActionResult<UserModel>> Delete(int id)
    {
        bool deleted = await _userRepository.DeleteUser(id);
        return Ok(deleted);
    }

}

