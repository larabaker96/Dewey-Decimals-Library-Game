using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dewey_Decimals_Library_Game
{
    class TreeNode
    {
        public DeweyObject Data { get; set; }

        public TreeNode Parent { get; set; }

        public List<TreeNode> Children { get; set; }

    }
}
