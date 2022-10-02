namespace IsSymmetric;

public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}
public class Solution
{
    public bool IsSymmetric(TreeNode root)
    {
        return isMirror(root, root);
    }

    public bool isMirror(TreeNode t1, TreeNode t2)
    {
        //basecase 
        if (t1 == null && t2 == null) return true;
        if (t1 == null || t2 == null) return false;

        //recursive call
        //we check each level of the node but before we say it is mirror we go down deeper more and check the down levels until it reach the base case then we go up and verify the rest of the conditions  
        return (t1.val == t2.val && isMirror(t1.right, t2.left) && isMirror(t1.left, t2.right));
    }
}
