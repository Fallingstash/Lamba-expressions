using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program {
  static void Main(string[] args) {
    BinaryTree<int> tree = new BinaryTree<int>();

    tree.Add(5);
    tree.Add(3);
    tree.Add(8);
    tree.Add(1);
    tree.Add(4);
    tree.Add(7);
    tree.Add(9);

    tree.Root.Print();

    Console.WriteLine("Pre-order: " + string.Join(", ", tree.PreOrderTraversalStack()));
    Console.WriteLine("Post-order: " + string.Join(", ", tree.PostOrderTraversalStack()));

    Console.WriteLine("Central Order for lambda expression and delegate:");
    var central = tree.GetCentralTraversalIterator()();
    foreach (var item in central) {
      Console.Write(item + " ");
    }
  }
}