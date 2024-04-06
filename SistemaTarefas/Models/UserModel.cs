
namespace SistemaTarefas.Models;

public class UserModel //Modelo com os dados que serão obtidos ou inseridos(?)
{
    public int Id { get; set; } 
    public string? Name { get; set; } 
    public string? Email { get; set; }

    public static implicit operator UserModel(TaskModel v)
    {
        throw new NotImplementedException();
    }
}
