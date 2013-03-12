using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;

namespace ASPNET.Data.Interfaces
{
   public interface IRepositoryContext
    {

        IObjectSet<T> GetObjectSet<T>() where T : class;
        ObjectContext ObjectContext { get; }
        int SaveChanges();
        void Terminate();
    }
}
