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
        private readonly ApplicationDBContext _db;

        public UserRepository(ApplicationDBContext db)
        {
            _db = db;
        }

        public async Task<User> Create(User entity)
        {
            await _db.Users.AddAsync(entity);
            await _db.SaveChangesAsync();

            return entity;
        }

       
        public async Task<User> Create(UserParams userParams)
        {
            User entity = new User(userParams);
            await _db.Users.AddAsync(entity);
            await _db.SaveChangesAsync();

            return entity;
        }

        public async Task<bool> Delete(User entity)
        {
            _db.Users.Remove(entity);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<User> Get(ulong id)
        {
            return await _db.Users.FirstOrDefaultAsync(x => x.ID == id);
        }

        public async Task<User> GetUserByLogin(string login)
        {
            return await _db.Users.FirstOrDefaultAsync(x => x.Login == login);
        }

        public async Task<bool> HaveUserByLoginAndPassword(string login, string password)
        {
            if(await _db.Users.FindAsync(login, password) != null)
            {
                return true;
            }
            return false;
        }

        public async Task<List<User>> Select()
        {
            return await _db.Users.ToListAsync();
        }
    }
}
