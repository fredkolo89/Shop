using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;


namespace _45.Tree
{
    public class TreeNode
    {
        private ArrayList mChilds = null;
        private Attribute mAttribute;

        public TreeNode(Attribute attribute)
        {
            if (attribute.values != null)
            {
                mChilds = new ArrayList(attribute.values.Length);
                for (int i = 0; i < attribute.values.Length; i++)
                    mChilds.Add(null);
            }
            else
            {
                mChilds = new ArrayList(1);
                mChilds.Add(null);
            }
            mAttribute = attribute;
        }

        public void AddTreeNode(TreeNode treeNode, string ValueName)
        {
            int index = mAttribute.indexValue(ValueName);
            mChilds[index] = treeNode;
        }

        public int totalChilds
        {
            get
            {
                return mChilds.Count;
            }
        }


        public TreeNode getChild(int index)
        {
            return (TreeNode)mChilds[index];
        }


        public Attribute attribute
        {
            get
            {
                return mAttribute;
            }
        }


        public TreeNode getChildByBranchName(string branchName)
        {
            int index = mAttribute.indexValue(branchName);
            return (TreeNode)mChilds[index];
        }

        public void SetColor(TreeNode root, ref TreeViewItem tvi)
        {
            if (root.attribute.mLabel != null)
            {

                if (root.attribute.mLabel.ToString() == true.ToString())
                {
                    tvi.Foreground = new SolidColorBrush(Colors.Green);
                }
                else
                {
                    tvi.Foreground = new SolidColorBrush(Colors.Red);
                }
            }
        }

        public void printNode(TreeNode root, ref TreeViewItem tvi)
        {

            TreeViewItem child = new TreeViewItem() { Header = root.attribute };
            SetColor(root, ref child);
            tvi.Items.Add(child);

            if (root.attribute.values != null)
            {
                for (int i = 0; i < root.attribute.values.Length; i++)
                {
                    var a = root.attribute.values[i];
                    TreeViewItem child1 = new TreeViewItem() { Header = root.attribute.values[i] };                   
                    child.Items.Add(child1);
                    TreeNode childNode = root.getChildByBranchName(root.attribute.values[i]);
                    printNode(childNode, ref child1);
                }
            }

        }


    }
}

