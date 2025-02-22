using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoiFitness.enums
{
    public enum TrainingDaysPerWeek
    {
        [Description("1 - Once a Week")]
        One = 1,
        [Description("2 - Twice a Week")]
        Two = 2,
        [Description("3 - Three Times a Week")]
        Three = 3,
        [Description("4 - Four Times a Week")]
        Four = 4,
        [Description("5 - Five Times a Week")]
        Five = 5,
        [Description("6 - Six Times a Week")]
        Six = 6,
        [Description("7 - Seven Times a Week")]
        Seven = 7,
    }
}
