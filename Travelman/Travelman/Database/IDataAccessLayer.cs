using System.Collections.Generic;

namespace Travelman.Database
{
    public interface IDataAccessLayer<T>
    {
        ICollection<T> GetEntities();
        bool SaveEntity(T route);
        bool DeleteEntity(T route);
        bool ModifyEntity(T route);
    }
}
