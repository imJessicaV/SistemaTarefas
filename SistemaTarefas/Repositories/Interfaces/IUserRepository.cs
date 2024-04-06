using SistemaTarefas.Models;

namespace SistemaTarefas.Repositories.Interfaces;

public interface IUserRepository
{
    Task<List<UserModel>> SearchAllUsers();
    Task<UserModel> SearchForId(int id);
    Task<UserModel> AddUser(UserModel user);
    Task<UserModel> UpdateUser(UserModel user, int id);
    Task<bool> DeleteUser(int id);

}
