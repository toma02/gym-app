using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoiFitness.utils
{
    public static class DateHelper
    {
        public static string FormatDate(DateTime date)
        {
            return date.ToString("dd/MM/yyyy");
        }
    }
}
