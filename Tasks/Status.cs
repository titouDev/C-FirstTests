using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks
{
    class Status
    {
        private int id;
        private string name;

        public Status(string statuName)
        {
            setName(statuName);
        }

        public int getId()
        {
            return id;
        }
        public void setId(int newId)
        {
            id = newId;
        }

        public string getName()
        {
            return name;
        }

        public void setName(string statusName)
        {
            name = statusName;
        }

        public override string ToString()
        {
            return string.Format("Status Name: {0} - Id: {1}", name, id);
        }
        
    }

}
