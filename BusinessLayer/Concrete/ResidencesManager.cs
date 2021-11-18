using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
   public class ResidencesManager
    {
        Repository<Residence> repoResidence = new Repository<Residence>();

        public List<Residence> GetAll()
        {
            return repoResidence.List();
        }

        public int ResidencesAddBM(Residence p)
        {
            if(p.TypeOfResidence == "")
            {
                return -1;
            }
           return repoResidence.Insert(p); 
        }

        public int DeleteResidencesBM(int p)
        {
            Residence residence = repoResidence.Find(x => x.ResidenceId == p);
            return repoResidence.Delete(residence);
        }

        public Residence FindResidence(int id)
        {
            return repoResidence.Find(x => x.ResidenceId == id);
        }

        public int UpdateResidence(Residence p)
        {
            Residence residence = repoResidence.Find(x => x.ResidenceId == p.ResidenceId);
            residence.NumberOfRooms = p.NumberOfRooms;
            residence.AgeOfResidence = p.AgeOfResidence;
            residence.SquareMeter = p.SquareMeter;
            residence.TypeOfResidence = p.TypeOfResidence;
            residence.Agent.AgentUserName = p.Agent.AgentUserName;
            return repoResidence.Update(residence);
        }
    }
}
