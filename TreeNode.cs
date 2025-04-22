using System;

public class TreeNode<T> {
  public TreeNode(T data) {
    this.Data = data;

  }

  public TreeNode<T> Parent { get; set; }
  public T Data { get; set; }
  public TreeNode<T> Left { get; set; }
  public TreeNode<T> Right { get; set; }

  public void Print() {
    Console.WriteLine(" " + Data + "\n");
    Console.WriteLine($"{Left.Data} {Right.Data}");
  }
}