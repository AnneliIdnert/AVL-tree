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
    public class TreeNode
    {
        private int value;
        public TreeNode left;                  ///Detta är en behållare för trädets vänstra node
        public TreeNode right;                      ///Detta är en behållare för trädets högra node
        public TreeNode (int aValue)               ///tar emot värdet
        {
            this.value = aValue; left = null; right = null;
        }

        public int aValue
        {
            get { return value; }
            set { value = aValue; }
        }
         
           
    }
}
