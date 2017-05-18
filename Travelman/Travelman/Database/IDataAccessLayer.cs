using System.Collections.Generic;

namespace Travelman.Database
{
    interface IDataAccessLayer<T>
    {
        ICollection<T> GetEntities();
        bool SaveEntity(T t);
        bool DeleteEntity(T t);
        bool ModifyEntity(T t);
    }
}
