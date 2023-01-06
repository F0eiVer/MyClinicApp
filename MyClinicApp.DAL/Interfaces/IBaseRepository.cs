using MyClinicApp.Domain.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClinicApp.DAL.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<T> Create(T entity);

        Task<T> Get(ulong id);

        Task<List<T>> Select();
        
        Task<bool> Delete(T entity);
    }
}
