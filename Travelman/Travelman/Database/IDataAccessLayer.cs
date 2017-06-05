using System.Collections.Generic;

namespace Travelman.Database
{
    public interface IDataAccessLayer<T>
    {
        ICollection<T> GetEntities();
        bool SaveEntity(T entity);
        bool DeleteEntity(T entity);
        bool ModifyEntity(T entity);
    }
}
