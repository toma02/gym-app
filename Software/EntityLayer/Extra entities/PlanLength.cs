using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Extra_entities
{
    public class PlanLength
    {
        public short LengthInWeeks { get; set; }
        public string LengthDescription { get; set; }

        public PlanLength(short lengthInWeeks, string lengthDescription) 
        {
            LengthDescription= lengthDescription;
            LengthInWeeks= lengthInWeeks;
        }

        public override string ToString()
        {
            return LengthDescription;
        }

    }
}
