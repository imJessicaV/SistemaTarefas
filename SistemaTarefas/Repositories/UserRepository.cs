using Microsoft.EntityFrameworkCore;
using SistemaTarefas.Data;
using SistemaTarefas.Models;
using SistemaTarefas.Repositories.Interfaces;

namespace SistemaTarefas.Repositories;

public class UserRepository : IUserRepository
{
    private readonly TasksSystemDBContext _dbContext; 
    public UserRepository(TasksSystemDBContext tasksSystemDBContext)
    {
        _dbContext = tasksSystemDBContext;
    }

    public async Task<List<UserModel>> SearchAllUsers()
    {
        return await _dbContext.Users.ToListAsync();
    }

    public async Task<UserModel> SearchForId(int id)
    {
        return await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
    }
    
    public async Task<UserModel> AddUser(UserModel user)
    {
        await _dbContext.Users.AddAsync(user);
        await _dbContext.SaveChangesAsync();

        return user;
    }

    public async Task<UserModel> UpdateUser(UserModel user, int id)
    {
       UserModel userForId = await SearchForId(id);

        if (userForId == null)
        {
            throw new Exception($"Usuário com o ID {id} não foi encontrado!");
        }

        userForId.Name = user.Name;
        userForId.Email = user.Email;

        _dbContext.Users.Update(userForId);
        await _dbContext.SaveChangesAsync();

        return userForId;
    }

    public async Task<bool> DeleteUser(int id)
    {
        UserModel userForId = await SearchForId(id);

        if (userForId == null) 
        {
            throw new Exception($"O usuário com o id {id} não foi encontrado!");
        }

        _dbContext.Users.Remove(userForId);
       await _dbContext.SaveChangesAsync(); 

        return true;
    }

   
}
