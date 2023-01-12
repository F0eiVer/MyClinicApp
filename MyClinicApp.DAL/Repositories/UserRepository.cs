using Microsoft.EntityFrameworkCore;
using MyClinicApp.DAL.Models;
using MyClinicApp.DAL.Interfaces;
using MyClinicApp.Domain.Classes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyClinicApp.DAL.DBContext;
using MyClinicApp.DAL.Convert;

namespace MyClinicApp.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext db;

        public UserRepository(ApplicationDbContext _db)
        {
            db = _db;
        }

        public async Task<User> Create(User entity)
        {
            UserModel userModel = new UserModel()
            {
                Password = entity.Password,
                ID = entity.ID,
                PhoneNumber = entity.PhoneNumber,
                FullName = entity.FullName,
                Login = entity.Login,
                Role = entity.Role,
            };

            await db.Users.AddAsync(userModel);
            await db.SaveChangesAsync();

            return entity;
        }
        public async Task<User> Create(UserParams userParams)
        {
            UserModel userModel = new UserModel()
            {
                Password = userParams.Password,
                ID = userParams.ID,
                PhoneNumber = userParams.PhoneNumber,
                FullName = userParams.FullName,
                Login = userParams.Login,
                Role = userParams.Role
            };
            await db.Users.AddAsync(userModel);
            await db.SaveChangesAsync();

            return userModel.ToDomain();
        }

        public async Task<bool> Delete(User entity)
        {
            UserModel userModel = new UserModel()
            {
                Password = entity.Password,
                ID = entity.ID,
                PhoneNumber = entity.PhoneNumber,
                FullName = entity.FullName,
                Login = entity.Login,
                Role = entity.Role,
            };

            db.Users.Remove(userModel);
            await db.SaveChangesAsync();
            return true;
        }

        public async Task<User> Get(ulong id)
        {
            var user = await db.Users.FirstOrDefaultAsync(x => x.ID == id);
            if (user == null)
            {
                return null;
            }
            return user.ToDomain();
        }

        public async Task<User> GetUserByLogin(string login)
        {
            var user = await db.Users.FirstOrDefaultAsync(x => x.Login == login);
            if(user == null)
            {
                return null;
            }
            return user.ToDomain();
        }

        public async Task<bool> HaveUserByLoginAndPassword(string login, string password)
        {
            if (await db.Users.FindAsync(login, password) != null)
            {
                return true;
            }
            return false;
        }

        public async Task<List<User>> Select()
        {
            var userModels = await db.Users.ToListAsync();
            List<User> users = new List<User>();
            for (int i = 0; i < userModels.Count; i++)
            {
                users.Add(userModels[i].ToDomain());
            }
            return users;
        }
    }
}
