using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RCP.Models;

namespace RCP.Repository.Interfaces
{
  public interface IUserRepository
  {
    Task<User> CreateUser(User model); //users only added via dbquery
    Task<User> ReadUser(string userName);
    Task<IList<User>> ReadUsers();
    Task UpdateUser();
    Task DeleteUser(string userId);
    Task<IList<User>> SearchUsers(int projectId, string query);
    Task<IList<User>> SearchUsers(string query);
  }
}
