using Microsoft.AspNetCore.Mvc;
using SistemaTarefas.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SistemaTarefas.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    // GET: api/<UserController>
    [HttpGet] //buscar dados | isso é chamado de verbo(verbose?) | Lista todos os user quando está sem parametro
    public ActionResult<List<UserModel>> searchUser()
    {
       //List<UserModel> userModels = new List<UserModel>();
       //userModels.Add(new UserModel() { Id = 1, Name = "Jéssica Vitorianbo", Email = "Jéssica Vitoriano"});
        return Ok();
    }

    // GET api/<UserController>/5
    [HttpGet("{id}")]
    public UserModel Get(int id)
    {
        var user = new UserModel() { Id = 1, Name = "Jéssica Vitorianbo", Email = "Jéssica Vitoriano" };

        return user;
    }

    // POST api/<UserController>
    [HttpPost] //inserir dados
    public void Post([FromBody] UserModel user) //fromBody informa que os dados virão do corpo da API
    {

    }

    // PUT api/<UserController>/5
    [HttpPut("{id}")] //atualizar dados
    public void Put(int id, [FromBody] UserModel user)
    {
    }

    // DELETE api/<UserController>/5
    [HttpDelete("{id}")] //deletar dados
    public void Delete(int id)
    {
    }
}
