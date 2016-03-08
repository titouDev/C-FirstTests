using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks
{
    interface IDbOperations<T>
    {
        T save(T Obj);
        bool delete(T Obj);
        T update(T Obj);

    }
}
