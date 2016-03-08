using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks
{
    class Task : IDbOperations<Task>
    {
        private Status status;
        public int id { get;set; }
        
        public void setStatus (string statusName)
        {
            status = new Status(statusName);
        }
        public Status getStatus()
        {
            return status;
        }

        public Task save(Task Obj)
        {
            DbConnector dbConn = new DbConnector();
            return null;

        }

        public bool delete(Task Obj)
        {
            throw new NotImplementedException();
        }

        public Task update(Task Obj)
        {
            throw new NotImplementedException();
        }
    }
}
