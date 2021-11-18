using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
   public class UserProfileManager
    {
        Repository<Agent> repoUser = new Repository<Agent>();
        Repository<Residence> repoResidence = new Repository<Residence>();
        public List<Agent>GetAgentByUserName(string p)
        {
            return repoUser.List(x => x.AgentUserName == p);
        }

        public List<Residence> GetResidenceByAgent(int id)
        {
            return repoResidence.List(x => x.AgentId == id);
        }

        public int UpdateAgent(Agent p)
        {
            Agent agent = repoUser.Find(x => x.AgentId == p.AgentId);
            agent.AgentUserName = p.AgentUserName;
            agent.NameOfTheFirm = p.NameOfTheFirm;
            agent.AgentPassword = p.AgentPassword;
            return repoUser.Update(agent);
        }
    }
}
