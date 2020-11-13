using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dewey_Decimals_Library_Game
{
    class Tree
    {
        public TreeNode Root { get; set; }

        public bool HasChildren(TreeNode node)
        {
            if(node.Children != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        } 

        //Checks call number subcategory
        public DeweyObject searchLvl2(int data)
        {
            if (HasChildren(Root))
            {
                foreach (TreeNode node in Root.Children)
                {
                    if (HasChildren(node))
                    {
                        foreach (TreeNode treeNode in node.Children)
                        {
                            if (treeNode.Data.callNumbers == data)
                            {
                                return treeNode.Data;
                            }
                        }
                    }
                }
            }
            return null;
        }

        //Dives deep into tree to check exact call number categories
        public DeweyObject searchLvl3(int data)
        {
            if (HasChildren(Root))
            {
                foreach (TreeNode node in Root.Children)
                {
                    if (HasChildren(node))
                    {
                        foreach (TreeNode treeNode in node.Children)
                        {
                            if (HasChildren(treeNode))
                            {
                                foreach(TreeNode child in treeNode.Children)
                                {
                                    if (child.Data.callNumbers == data)
                                    {
                                        return child.Data;
                                    }
                                }                               
                            }                          
                        }
                    }
                }
            }
            return null;
        }

    }
}
