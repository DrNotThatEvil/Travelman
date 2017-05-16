using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travelman.Data;

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
