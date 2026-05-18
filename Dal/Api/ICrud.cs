using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dal.Api
{
    public interface ICrud<T>
    {
        Task CreateAsync(T item);

        Task UpdateAsync(T item);

        Task DeleteAsync(T item);

        Task<T> ReadAsync(int id);

        Task<List<T>> ReadAllAsync();

        Task<List<T>> ReadAsync(Func<T, bool> func);
    }
}