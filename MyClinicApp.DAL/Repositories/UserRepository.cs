using Microsoft.EntityFrameworkCore;
using MyClinicApp.DAL.Interfaces;
using MyClinicApp.Domain.Classes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyClinicApp.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {

        public UserRepository()
        {
            throw new NotImplementedException();
        }

        public async Task<User> Create(User entity)
        {

            throw new NotImplementedException();
        }

       
        public async Task<User> Create(UserParams userParams)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Delete(User entity)
        {
            throw new NotImplementedException();
        }

        public async Task<User> Get(ulong id)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetUserByLogin(string login)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> HaveUserByLoginAndPassword(string login, string password)
        {
            throw new NotImplementedException();
        }

        public async Task<List<User>> Select()
        {
            throw new NotImplementedException();
        }
    }
}
