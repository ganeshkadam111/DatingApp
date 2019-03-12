using DattingApp.API.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DattingApp.API.Data
{
   public interface IAuthRepository
    {
        Task<User> Register(User user, string password);
        Task<User> Login(string username, string passowrd);

        Task<bool> UserExists(string username);
    }
}
