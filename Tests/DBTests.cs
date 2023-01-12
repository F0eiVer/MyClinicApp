using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyClinicApp.DAL.DBContext;
using MyClinicApp.DAL.Models;
using Xunit;

namespace Tests
{
    public class DBTests
    {
        /*
        //Playground
        private readonly DbContextOptionsBuilder<ApplicationDbContext> _optionsBuilder;

        public DBTests()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseNpgsql(
                $"Host=localhost;Port=5432;Database=testDBClinic;Username=postgres;Password=Crjhgbjy123");
            _optionsBuilder = optionsBuilder;
        }
        
        [Fact]
        public void PlaygroundMethod1()
        {
            using var context = new ApplicationDbContext(_optionsBuilder.Options);
            context.Users.Add(new UserModel
            {
                ID = 123,
                Login = "TEST"
            });
            context.SaveChanges(); // сохранили в БД

            Assert.True(context.Users.Any(u => u.Login == "TEST")); // проверим, нашло ли в нашей бд
        }
        

        [Fact]
        public void PlaygroundMethod2()
        {
            using var context = new ApplicationDbContext(_optionsBuilder.Options);
            var u = context.Users.FirstOrDefault(u => u.Login == "TEST");
            context.Users.Remove(u);
            context.SaveChanges(); // удалили в БД

            Assert.True(!context.Users.Any(u => u.Login == "TEST"));
        }
        */
    }
}
