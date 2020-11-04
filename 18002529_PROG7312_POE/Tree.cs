﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18002529_PROG7312_POE
{
    class Tree
    {
        public TreeNode Root { get; set; }

        private bool HasChildren(TreeNode node)
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

        public DeweyObject searchLvl2(int data)
        {
            if (HasChildren(Root))
            {
                foreach(TreeNode node in Root.Children)
                {
                    if(node.Data.callNumbers == data)
                    {
                        return node.Data;
                    }
                }
            }
            return null;
        }

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
    }
}
