using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyClinicApp.Domain.Classes;
using MyClinicApp.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MyClinicApp.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDBContext _db;

        public UserRepository(ApplicationDBContext db)
        {
            _db = db;
        }

        public bool Create(User entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(User entity)
        {
            throw new NotImplementedException();
        }

        public User Get(ulong id)
        {
            throw new NotImplementedException();
        }

        public User GetUserByLogin(string login)
        {
            throw new NotImplementedException();
        }

        public bool HaveUserByLoginAndPassword(string login, string password)
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> Select()
        {
            return _db.Users.ToListAsync(); // get database like a list;
        }
    }
}
