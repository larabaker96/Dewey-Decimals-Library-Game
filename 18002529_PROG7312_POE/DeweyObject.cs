using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18002529_PROG7312_POE
{
    class DeweyObject
    {
        public int callNumbers { get; set; }

        public string Description { get; set; }

        public string callNumberDesc()
        {
            return callNumbers + " - " + Description;
        }

    }
}
