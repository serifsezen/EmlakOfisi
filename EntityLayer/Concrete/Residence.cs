using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
   public class Residence
    {
        [Key]
        public int ResidenceId { get; set; }

        public int NumberOfRooms { get; set; }

        public int AgeOfResidence { get; set; }

        public int SquareMeter { get; set; }

        [StringLength(20)]
        public string TypeOfResidence { get; set; }

        public int AgentId { get; set; }

        public virtual Agent Agent { get; set; }
    }
}
