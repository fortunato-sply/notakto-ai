public class Node {
  public List<Node> Childs { get; set; } = new List<Node>();
  public int Value { get; set; }
  public Node(int value) 
  {
    this.Value = value;
  }

  public void Add(Node n) => Childs.Add(n);
  public bool IsTerminalNode() => Childs.Count == 0;
}