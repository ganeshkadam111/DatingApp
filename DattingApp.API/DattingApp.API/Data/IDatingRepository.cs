using DattingApp.API.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DattingApp.API.Data
{
    public interface IDatingRepository
    {
        void Add<T>(T entity) where T : class;

        void Delete<T>(T entity) where T : class;

        Task<bool> SaveAll();

        Task<IEnumerable<User>> GetUsers();

        Task<User> GetUser(int Id);
    }
}
