// Author: minhnpa1907@gmail.com
namespace NPAM.Algorithms.Models;

public class ListNode(int val = 0, ListNode next = null)
{
    public int val = val;
    public ListNode next = next;

    public static ListNode MergeTwoLists(ListNode list1, ListNode list2)
    {
        if (list1 is null && list2 is null) return null;
        if (list1 is null) return list2;
        if (list2 is null) return list1;

        if (list1.val <= list2.val)
        {
            list1.next = MergeTwoLists(list1.next, list2);
            return list1;
        }
        else
        {
            list2.next = MergeTwoLists(list2.next, list1);
            return list2;
        }
    }
}

public class TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
{
    public int val = val;
    public TreeNode left = left;
    public TreeNode right = right;

    public static TreeNode InvertTree(TreeNode root)
    {
        if (root is not null)
        {
            (root.left, root.right) = (root.right, root.left);
            InvertTree(root.left);
            InvertTree(root.right);
        }

        return root;
    }

    public static TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
    {
        if (root.val < p.val && root.val < q.val) // the node looking for is on the right
        {
            return LowestCommonAncestor(root.right, p, q);
        }
        else if (root.val > p.val && root.val > q.val) // the node looking for is on the left
        {
            return LowestCommonAncestor(root.left, p, q);
        }
        else // descendant of itself
        {
            return root;
        }
    }

    public static bool IsBalancedBinaryTree(TreeNode root)
    {
        var heightL = BalancedBinaryTreeRec(root.left);
        var heightR = BalancedBinaryTreeRec(root.right);

        if (Math.Abs(heightL - heightR) <= 1)
        {
            return true && IsBalancedBinaryTree(root.left) && IsBalancedBinaryTree(root.right); // true - A height-balanced binary tree is a binary tree in which the depth of the two subtrees of every node never differs by more than one. Otherwise returns false
        }

        return false;
    }

    private static int BalancedBinaryTreeRec(TreeNode root)
    {
        if (root is null)
        {
            return 0;
        }

        var heightL = BalancedBinaryTreeRec(root.left);
        var heightR = BalancedBinaryTreeRec(root.right);

        return Math.Max(heightL, heightR) + 1;
    }
}

public class MyQueue
{
    readonly Queue<int> queue;

    public MyQueue()
    {
        queue = new();
    }

    public void Push(int x)
    {
        queue.Enqueue(x);
    }

    public int Pop()
    {
        return queue.Dequeue();
    }

    public int Peek()
    {
        return queue.Peek();
    }

    public bool Empty()
    {
        return queue.Count == 0;
    }
}