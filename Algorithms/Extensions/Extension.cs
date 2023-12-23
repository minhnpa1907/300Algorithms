using NPAM.Algorithms.Models;

// Author: minhnpa1907@gmail.com

namespace NPAM.Algorithms.Extensions;

public static class Extension
{
    public static ListNode? ToListNode(this int[] nums)
    {
        // Return null if nums is empty
        if (nums.Length == 0)
        {
            return null;
        }

        ListNode temp = new();
        ListNode result = temp;

        for (var i = 0; i < nums.Length; i++)
        {
            temp.val = nums[i];

            // If i is not the last index, then create new next node
            if (i != nums.Length - 1)
            {
                temp.next = new();
                temp = temp.next;
            }
        }

        return result;
    }

    public static int[] ToArray(this ListNode nodes)
    {
        if (nodes is null)
        {
            return [];
        }

        List<int> result = [nodes.val];
        var tempNode = nodes.next;

        // Loop and add node's value to list result until there is no next node
        while (tempNode is not null)
        {
            result.Add(tempNode.val);
            tempNode = tempNode.next;
        }

        return [.. result];
    }

    public static int[] ToArray(this TreeNode root)
    {
        if (root is null)
        {
            return [];
        }

        List<int> result = [root.val, .. root.GetNodeVal()];

        return [.. result];
    }

    private static int[] GetNodeVal(this TreeNode root)
    {
        List<int> result = [];

        if (root is not null)
        {
            // If left is still a node, then add its value to the list.
            if (root.left is not null)
            {
                result.Add(root.left.val);
            }

            // If right is still a node, then add its value to the list.
            if (root.right is not null)
            {
                result.Add(root.right.val);
            }

            result.AddRange(GetNodeVal(root.left));
            result.AddRange(GetNodeVal(root.right));
            return [.. result];
        }

        return [.. result];
    }
}