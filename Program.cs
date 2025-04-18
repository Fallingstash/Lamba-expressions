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
    tree.Add(9);
    tree.Add(10);
    tree.Add(11);

    // Лямбда для центрального обхода
    Func<BinaryTree<int>, IEnumerable<int>> inorder = t => t.InOrderTraversal();

    // Получаем узлы в порядке возрастания
    foreach (var num in inorder(tree)) {
      Console.WriteLine(num);  // Выведет: 3, 5, 8
    }
  }
}