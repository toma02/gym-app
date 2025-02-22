using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoiFitness.enums
{
    enum PlanLengths
    {
        [Description("2 weeks")]
        TwoWeeks = 2,
        [Description("3 weeks")]
        ThreeWeeks = 3,
        [Description("4 weeks")]
        FourWeeks = 4,
        [Description("6 weeks")]
        SixWeeks = 6,
        [Description("2 months")]
        TwoMonths = 8,
        [Description("3 months")]
        ThreeMonths = 12,
        [Description("4 months")]
        FourMonths = 16,
        [Description("6 months")]
        SixMonths = 24
    }
}
