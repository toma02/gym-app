using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Extra_entities
{
    public class TrainingDay
    {
        public short Amount { get; set; }
        public string Description { get; set; }

        public TrainingDay(short amount, string desc) { 
            Amount= amount;
            Description= desc;
        }

        public override string ToString()
        {
            return Description;
        }
    }
}
