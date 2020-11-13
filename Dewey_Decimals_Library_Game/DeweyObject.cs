using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dewey_Decimals_Library_Game
{
    class DeweyObject
    {
        public int callNumbers { get; set; }

        public string description { get; set; }

        public string callNumberDesc()
        {
            return callNumbers + " - " + description;
        }

    }
}
