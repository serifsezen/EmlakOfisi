using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
   public class Agent
    {
        [Key]
        public int AgentId { get; set; }

        [StringLength(30)]
        public string AgentUserName { get; set; }

        [StringLength(30)]
        public string NameOfTheFirm { get; set; }

        [StringLength(30)]
        public string AgentPassword { get; set; }

        public ICollection<Residence> Residences { get; set; }
    }
}
