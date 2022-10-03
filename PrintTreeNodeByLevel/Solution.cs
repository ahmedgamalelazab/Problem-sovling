namespace PrintTreeNodeByLevel;

public class Node
{
    public Node Left;
    public Node Right;
    public int Value;

    public Node(Node l, Node r, int v)
    {
        Left = l;
        Right = r;
        Value = v;
    }
}
public class Solution
{
    public List<int> TreeByLevels(Node node)
    {
        //using BFS Algorithm , and the given tree will be considered as directed graph 
        var returnList = new List<int>();
        BFS(node, returnList);
        return returnList;
    }

    public void BFS(Node node, List<int> returnList)
    {
        //the list will be empty if the node is null
        if (node == null)
        {
            return;
        }

        //else apply the bfs on it 
        var queue = new LinkedList<Node>();
        queue.AddFirst(node);
        //while the queue is not empty
        while (queue.Count != 0)
        {
            //pop the first 
            var tnode = queue.First.Value; // getting the first element
            queue.RemoveFirst(); //popping the element
            returnList.Add(tnode.Value);
            //check for neighbors
            if (tnode.Left != null && tnode.Right != null)
            {
                //the node has left and right
                queue.AddLast(tnode.Left);
                queue.AddLast(tnode.Right);
            }
            else if (tnode.Left != null)
            {
                queue.AddLast(tnode.Left);

            }
            else if (tnode.Right != null)
            {
                queue.AddLast(tnode.Right);

            }

        }

    }

}
