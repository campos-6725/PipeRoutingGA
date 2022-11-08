using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
    public interface IRepository<T>
    {
        void Store(T obj);

        T Get();
    }
}
