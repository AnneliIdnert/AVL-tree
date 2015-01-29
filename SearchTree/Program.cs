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
    class Program
    {

        private AVLTree draw;
        static void Main(string[] args)
        {
            AVLTree bt = new AVLTree();
            bt.Insert (11);
            bt.Insert (6);
            bt.Insert (8);
            bt.Insert (20);
            bt.Insert (79);
            bt.Insert (50);
            bt.Insert (40);
            bt.InOrderTraversal();

            bt.Delite(40);
            
            bt.InOrderTraversal();
            
            Console.WriteLine();
            bt.InOrderTraversal();
            Console.ReadLine();
           
        }

          public void DrawTree()
        {
            Console.WriteLine(draw);
        }

       

    
    }
}
