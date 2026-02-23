using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Api
{
    public interface ICrud<T>
    {
        void Delete(T item);

        void Create(T item);

        void Update(T item);
        Task<T> Read(int id);
        Task<List<T>> ReadAll();

        Task<List<T>> Read(Func<T, bool> func);
    }
}
