using Algorithms.Models;

public static class Extension
{
    public static ListNode? ToListNode(this int[] nums)
    {
        // Return null if nums is empty
        if (!nums.Any())
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
            return new int[] { };
        }

        List<int> result = new() { nodes.val };
        var tempNode = nodes.next;

        // Loop and add node's value to list result until there is no next node
        while (tempNode is not null)
        {
            result.Add(tempNode.val);
            tempNode = tempNode.next;
        }

        return result.ToArray();
    }
}