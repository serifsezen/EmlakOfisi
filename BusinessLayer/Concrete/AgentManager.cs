using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
   public class AgentManager
    {
        Repository<Agent> repoAgent = new Repository<Agent>();
        public List<Agent> GetAll()
        {
            return repoAgent.List();
        }

        public int AddNewAgentBM(Agent p)
        {
            if(p.NameOfTheFirm==""|| p.AgentUserName=="")
            {
                return -1;
            }
            return repoAgent.Insert(p);
        }
    }
}
