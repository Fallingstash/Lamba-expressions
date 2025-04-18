using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class BinaryTree<T> : IEnumerable<T> where T : IComparable<T> {
  private TreeNode<T> Root;

  public void Add(T data) {
    if (Root == null) {
      Root = new TreeNode<T>(data);
    } else {
      AddChild(Root, data);
    }
  }

  private void AddChild(TreeNode<T> node, T data) {
    if (data.CompareTo(node.Data) < 0) {
      if (node.Left == null) {
        node.Left = new TreeNode<T>(data) { Parent = node };
      } else {
        AddChild(node.Left, data);
      }
    } else {
      if (node.Right == null) {
        node.Right = new TreeNode<T>(data) { Parent = node };
      } else {
        AddChild(node.Right, data);
      }
    }
  }

  public TreeNode<T> Next(TreeNode<T> node) {
    if (node == null) {
      return null;
    }

    if (node.Right != null) {
      node = node.Right;
      while (node.Left != null) {
        node = node.Left;
      }
    }
    else {
      while (node.Parent != null && node == node.Parent.Right) {
        node = node.Parent;
      }
    }

    return node;
  }

  public IEnumerator<T> GetEnumerator() {
    TreeNode<T> curent = GetMostLeftNode(Root);
    while (curent != null) {
      yield return curent.Data;
      curent = Next(curent);
    } 
  }

  private TreeNode<T> GetMostLeftNode(TreeNode<T> node) {
    if (node == null) {
      return null;
    }
    while (node.Left != null) {
      node = node.Left;
    }

    return node;
  }

  IEnumerator IEnumerable.GetEnumerator() {
    return GetEnumerator();
  }

  public IEnumerable<T> InOrderTraversal() {
    return Traverse(Root);

    IEnumerable<T> Traverse(TreeNode<T> node) {
      if (node == null) {
        yield break;
      }

      foreach (var leftNode in Traverse(node.Left)) {
        yield return leftNode;
      }

      yield return node.Data;

      foreach (var rightNode in Traverse(node.Right)) {
        yield return rightNode;
      }
    }
  }
}
