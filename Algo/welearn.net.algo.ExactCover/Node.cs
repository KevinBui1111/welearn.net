namespace welearn.net.algo.ExactCover;

public class Node {
    public int Value;
    public Node? Left;
    public Node? Right;
    public Node? Above;
    public Node? Down;
}

public class Head : Node {
    public int Count;
}

