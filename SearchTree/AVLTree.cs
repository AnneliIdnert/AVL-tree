///Anneli Idnert
///TGSYS, Datastrukturer & Algoritmer
///2014-10-14

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchTree
{
    class AVLTree
    {
        private TreeNode root = null;
        private int count = 0;
        public TreeNode Insert(int aValue)    /// Metoden lägger till ett värde
        {
            TreeNode node = new TreeNode(aValue); try
            {
                if (root == null)
                    root = node;
                else
                    Add(node, ref root);
                count++;
                return node;
            }
            catch (Exception)
            {
                Console.WriteLine("Value allready exist!");
                return null;
            }
        }
        private void Add(TreeNode node, ref TreeNode tree)     ///Metoden Add anropar sig själv för att se om det finns något värde noden
        {
            if (tree == null)                     /// Ser efter om noden är noll
            { tree = node; }
            else if (node.aValue < tree.aValue)     ///kollar nodens för att se om barnet kan placeras på vänster
            {
                Add(node, ref tree.left);                ///hittat en vänster plats
            }
            else if (node.aValue > tree.aValue)       ///kollar nodens för att se om barnet kan placeras på högersida
            {
                Add(node, ref tree.right);                 ///hittat en höger plats
            }
            return;

        }
        private TreeNode Find(ref TreeNode node, int aValue)
        {
            if (node == null)                 ///noden är noll
            {
                return null;
            }
            if (node.aValue == aValue)         ///node har ett värde
            {
                return node;
            }
            else if (node.aValue < aValue)
            {
                return Find(ref node.right, aValue);           ///Skickar höger noden
            }
            else if (node.aValue > aValue)
            {
                return Find(ref node.left, aValue);      ///skickar vänster nod
            }

            else
            {
                return null;
            }
        }

        public TreeNode FindValue(int aValue)
        {
            if (root != null)                    /// Ser efter om noden är noll
            {
                return Find(ref root, aValue);      ///kollar med Find metoden om de finns ett värde som motsvarar noden
            }
            else
            {
                return null;          ///Hittas inte värdet retunerar null
            }

           
           
        }
        private TreeNode FindParent(int aValue, ref TreeNode parent, ref TreeNode current)     ///Här hittas förälder genom Treenode praent och current
        {
            if (current == null)       ///Föräldervärde finns ej
            {
                return null;
            }
            
            if( aValue == current.aValue)    ///Skicka värde om det finns
             {
                 return current;  
             }
           
       
            else if (current.aValue > aValue)
            {
                parent = current;                       ///sparar värdet tillfälligt
                return FindParent(aValue, ref parent,ref current.left);   //Skickar värdet på föräldern
            }
            else if (current.aValue < aValue)
            {
                parent = current;                            ///sparar förälder
                return FindParent(aValue, ref parent, ref current.right);   ///retunerar förälder
            }

            return current;

           
            ///Om värdet inte finns returneras null
        }

      
        public void Delite(int aValue)
        {
            TreeNode parent = null; 
            TreeNode nodeToDelite = FindParent( aValue, ref parent, ref root);

            if (nodeToDelite != null)              ///OM det finns ett värde i FindValue så kolla om det finns barn
                if (nodeToDelite.left == null && nodeToDelite.right == null)
                {
                        if (parent.left == nodeToDelite) ///om noden har vänsterförälder ta bort det
                        {
                            parent.left = null;
                        }
                        if (parent.right == nodeToDelite)      ///Tar bort höger förälder
                        {
                            parent.right = null;
                        }
                }
                else if (nodeToDelite.left != null && nodeToDelite.right == null)      ///Om noden som tas bort har om det har ett höger barn
                {
                    if (root == nodeToDelite)
                    {
                        root = nodeToDelite.left;

                    }
                    else
                    {
                        if (parent.left == nodeToDelite)
                        {
                            parent.left = nodeToDelite.left;
                        }
                        if (parent.right == nodeToDelite)
                        {
                            parent.right = nodeToDelite.left;
                        }
                    }
                }
                else if (nodeToDelite.left == null && nodeToDelite.right != null)      ///Om noden som tas bort har om det har ett höger barn
                {
                    if (root == nodeToDelite)
                    {
                        root = nodeToDelite.right;

                    }
                    else
                    {
                        if (parent.right == nodeToDelite)
                        {
                            parent.right = nodeToDelite.right;
                        }
                        if (parent.left == nodeToDelite)
                        {
                            parent.right = nodeToDelite.right;
                        }
                    }
                  
                 }
                else if (nodeToDelite.left != null && nodeToDelite.right != null)       ///om den har två barn
                { 
            TreeNode successor = LeftMostNodeOnRight(nodeToDelite, ref parent );     ///letar efter barn och deklarerar det.
            TreeNode temp = new TreeNode(successor.aValue);
                                           
            if (parent.left == successor)   ///Vänster barn har hittats
                parent.left = successor.right;
            else
                parent.right = successor.right;    ///Höger barn har hittats
            nodeToDelite.aValue = temp.aValue;
                }
            
             }
       

           public TreeNode LeftMostNodeOnRight(TreeNode nodeToDelite, ref TreeNode parent)     ///Tittar efter om noden har barn
        {
            parent = nodeToDelite;
            nodeToDelite = nodeToDelite.right; while (nodeToDelite.left != null)     ///Går ner och ser efter om det finns någont barn i höger ben
            {
                parent = nodeToDelite;
                nodeToDelite = nodeToDelite.left;
            }
            return nodeToDelite;
        }
   
        private string DrawNode(TreeNode node)            ///Ritar ut värderna i tädet visuellt
        {
            if (node == null)
            {
                return "empty";
                if ((node.left == null) && (node.right == null))
                    return "" + node.aValue;
                if ((node.left != null) && (node.right == null))
                    return "" + node.aValue + "(" + DrawNode(node.left) + ",	_)";
                if ((node.right != null) && (node.left == null))
                    return "" + node.aValue + "(_," + DrawNode(node.right) + ")";
                return node.aValue + "(" + DrawNode(node.left) + ",	" +
                    DrawNode(node.right) + ")";


            }
            return null;
        }


        private void InorderTraversal(TreeNode node) ///Går igenom värderna på det olika trädnoderna 
        {
            if(node != null)
            {
                InorderTraversal(node.left);
                Console.Write(" , " + node.aValue);
                InorderTraversal(node.right);
            }
        }


        public void InOrderTraversal()
        {
            InorderTraversal(root);
        }
    }
}
