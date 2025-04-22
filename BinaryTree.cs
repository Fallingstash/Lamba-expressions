using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class BinaryTree<T> : IEnumerable<T> where T : IComparable<T> {
  public TreeNode<T> Root;

  public void Print(TreeNode<T> node) {
    node.Print();
  }

  public TreeNode<T> Current(TreeNode<T> node) {
    if (this == null) {
      return null;
    } else {
      return node;
    }
  }
 
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

  public TreeNode<T> Previous(TreeNode<T> node) {
    if (node == null) {
      return null;
    }
    if (node.Left != null) {
      node = node.Left;
      while (node.Right != null) {
      }
      return node;
    } else {
      while (node.Parent != null && node == node.Parent.Left) {
        node = node.Parent; 
      }
    }

    return node.Parent; 
  }

  public IEnumerable<T> PreOrderTraversalStack() {
    if (Root == null) {
      yield break;
    }

    var stack = new Stack<TreeNode<T>>();
    stack.Push(Root);

    while (stack.Count > 0) {
      var node = stack.Pop();
      yield return node.Data;

      if (node.Right != null) {
        stack.Push(node.Right);
      }
      if (node.Left != null) {
        stack.Push(node.Left);   
      }
    }
  }

  public IEnumerable<T> PostOrderTraversalStack() {
    if (Root == null) {
      yield break;
    }

    var stack = new Stack<TreeNode<T>>();
    var result = new Stack<T>();
    stack.Push(Root);

    while (stack.Count > 0) {
      var node = stack.Pop();
      result.Push(node.Data);
      if (node.Left != null) {
        stack.Push(node.Left);
      }
      if (node.Right != null) {
        stack.Push(node.Right);
      }
    }

    while (result.Count > 0) {
      yield return result.Pop();
    }
  }

  public Func<IEnumerable<T>> GetCentralTraversalIterator() => () =>
  {
    List<T> result = new List<T>();
    TraverseInOrder(Root, result);
    return result;
  };

  private void TraverseInOrder(TreeNode<T> node, List<T> result) {
    if (node == null) {
      return;
    }
    TraverseInOrder(node.Left, result);
    result.Add(node.Data);
    TraverseInOrder(node.Right, result);
  }

  public IEnumerator<T> GetEnumerator() {
    TreeNode<T> current = GetMostLeftNode(Root);
    while (current != null) {
      yield return current.Data;
      current = Next(current);
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
}
