using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using MyClinicApp.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClinicApp.DAL.DBContext
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {

        // Я не стал заморачиваться и скрывать пароль, тк этот проект создается в учебном плане.
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseNpgsql(
            $"Server=localhost;Port=5432;Database=testDBClinic;Username=postgres;Password=Crjhgbjy123"
            );

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
