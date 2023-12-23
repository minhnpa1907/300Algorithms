using NPAM.Algorithms.Extensions;
using NPAM.Algorithms.Logging;
using NPAM.Algorithms.Models;

// Author: minhnpa1907@gmail.com

namespace NPAM.Algorithms;

public static class Probl1ToProbl20
{
    /// <summary>
    /// Refs: https://leetcode.com/problems/two-sum
    /// </summary>
    /// <param name="nums">Example: [2,7,11,15]</param>
    /// <param name="target">Example: 9</param>
    /// <returns>Example: [0,1]</returns>
    public static int[] _1_TwoSum(int[] nums, int target)
    {
        Logger.FuncName = nameof(_1_TwoSum);
        Logger.LoggingStart();

        var output = Array.Empty<int>();

        // Process
        if (nums.Length == 2)
        {
            if (nums.Sum() == target)
            {
                output = [0, 1];
            }
        }
        else // nums.Length > 2
        {
            var dictMemory = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (dictMemory.ContainsKey(target - nums[i]))
                {
                    output = [dictMemory[target - nums[i]], i];
                    break;
                }

                dictMemory.TryAdd(nums[i], i);
            }
        }

        // Output
        Logger.LoggingStop(output);
        return output;
    }

    /// <summary>
    /// Refs: https://leetcode.com/problems/valid-parentheses
    /// </summary>
    /// <param name="input">Example: "()[]{}"</param>
    /// <returns>Example: true</returns>
    public static bool _2_ValidParentheses(string input)
    {
        Logger.FuncName = nameof(_2_ValidParentheses);
        Logger.LoggingStart();

        var output = true;
        Dictionary<char, char> dictChars = new() {
            {'(', ')'},
            {'{', '}'},
            {'[', ']'},
        };

        // Process
        // If the length is not evan -> invalid parentheses
        if (input.Length % 2 != 0)
        {
            output = false;
            goto printOutput;
        }

        var tempStack = new Stack<char>();
        foreach (char c in input)
        {
            if (dictChars.TryGetValue(c, out char value))
            {
                // c is open chars
                tempStack.Push(value);
            }
            else if (tempStack.Count == 0 || c != tempStack.Pop())
            {
                // c is close chars but not matched in the stack
                output = false;
                goto printOutput;
            }
        }

        // After looping, check if in stack any left
        output = tempStack.Count == 0;

    printOutput:
        // Output
        Logger.LoggingStop(output.ToString());
        return output;
    }

    /// <summary>
    /// Refs: https://leetcode.com/problems/merge-two-sorted-lists
    /// </summary>
    /// <param name="list1">Example: [1,2,4]</param>
    /// <param name="list2">Example: [1,3,4]</param>
    /// <returns>Example: [1,1,2,3,4,4]</returns>
    public static ListNode _3_MergeTwoLists(ListNode list1, ListNode list2)
    {
        Logger.FuncName = nameof(_3_MergeTwoLists);
        Logger.LoggingStart();

        // Process
        var output = ListNode.MergeTwoLists(list1, list2);

        // Output
        Logger.LoggingStop(string.Join(", ", output.ToArray()));
        return output;
    }

    /// <summary>
    /// Refs: https://leetcode.com/problems/best-time-to-buy-and-sell-stock
    /// </summary>
    /// <param name="prices">Example: [7,1,5,3,6,4]</param>
    /// <returns>Example: 5</returns>
    public static int _4_MaxProfit(int[] prices)
    {
        Logger.FuncName = nameof(_4_MaxProfit);
        Logger.LoggingStart();

        var output = 0;

        // Process
        if (prices.Length > 1)
        {
            var min = prices[0];

            for (int i = 1; i < prices.Length; i++)
            {
                if (prices[i] < min)
                {
                    min = prices[i];
                }
                else if ((prices[i] - min) > output)
                {
                    output = prices[i] - min;
                }
            }
        }

        // Output
        Logger.LoggingStop(output.ToString());
        return output;
    }

    /// <summary>
    /// Refs: https://leetcode.com/problems/valid-palindrome
    /// </summary>
    /// <param name="s">Example: "A man, a plan, a canal: Panama"</param>
    /// <returns>Example: true</returns>
    public static bool _5_ValidPalindrome(string s)
    {
        Logger.FuncName = nameof(_5_ValidPalindrome);
        Logger.LoggingStart();

        var output = true;

        // Process
        for (int i = 0, j = s.Length - 1; i < j;)
        {
            if (!char.IsLetterOrDigit(s[i]))
            {
                i++; continue;
            }

            if (!char.IsLetterOrDigit(s[j]))
            {
                j--; continue;
            }

            if (char.ToLower(s[i]) != char.ToLower(s[j]))
            {
                output = false;
                break;
            }
            else
            {
                i++; j--;
            }
        }

        // Output
        Logger.LoggingStop(output.ToString());
        return output;
    }

    /// <summary>
    /// Refs: https://leetcode.com/problems/invert-binary-tree
    /// </summary>
    /// <param name="root">Example: [4,2,7,1,3,6,9]</param>
    /// <returns>Example: [4,7,2,9,6,3,1]</returns>
    public static TreeNode _6_InvertTree(TreeNode root)
    {
        Logger.FuncName = nameof(_6_InvertTree);
        Logger.LoggingStart();

        // Process
        var output = TreeNode.InvertTree(root);

        // Output
        Logger.LoggingStop(output.ToArray());
        return output;
    }

    /// <summary>
    /// Refs: https://leetcode.com/problems/valid-anagram
    /// </summary>
    /// <param name="s">Example: "anagram"</param>
    /// <param name="t">Example: "nagaram"</param>
    /// <returns>Example: true</returns>
    public static bool _7_IsValidAnagram(string s, string t)
    {
        Logger.FuncName = nameof(_7_IsValidAnagram);
        Logger.LoggingStart();

        // Process
        var output = true;
        if (s.Length != t.Length)
        {
            output = false;
            goto printOutput;
        }

        if (s.Equals(t))
        {
            goto printOutput;
        }

        var clm = new Dictionary<char, int>();
        foreach (var c in s)
        {
            if (c.Equals(' ')) continue;

            if (!clm.TryGetValue(c, out int value))
            {
                value = 0;
                clm.Add(c, value);
            }

            clm[c] = ++value;
        }

        foreach (var c in t)
        {
            if (c.Equals(' ')) continue;
            if (!clm.TryGetValue(c, out int value) || value == 0)
            {
                output = false;
                goto printOutput;
            }

            clm[c]--;
        }

    printOutput:
        // Output
        Logger.LoggingStop(output.ToString());
        return output;
    }

    /// <summary>
    /// Refs: https://leetcode.com/problems/binary-search
    /// </summary>
    /// <param name="nums">Example: [-1,0,3,5,9,12]</param>
    /// <param name="target">Example: 9</param>
    /// <returns>Example: 4</returns>
    public static int _8_BinarySearch(int[] nums, int target)
    {
        Logger.FuncName = nameof(_8_BinarySearch);
        Logger.LoggingStart();

        // Process
        int left = 0;
        int right = nums.Length - 1;
        var output = -1;

        while (left <= right)
        {
            int mid = (left + right) / 2;

            if (nums[mid] == target) { output = mid; goto printOutput; }
            if (nums[mid] > target) right = mid - 1;
            else left = mid + 1;
        }

    printOutput:
        // Output
        Logger.LoggingStop(output.ToString());
        return output;
    }

    /// <summary>
    /// Refs: https://leetcode.com/problems/flood-fill
    /// </summary>
    /// <param name="image">Example: [[1,1,1],[1,1,0],[1,0,1]]</param>
    /// <param name="sr">Example: 1</param>
    /// <param name="sc">Example: 1</param>
    /// <param name="color">Example: 2</param>
    /// <returns>Example: [[2,2,2],[2,2,0],[2,0,1]]</returns>
    public static int[][] _9_FloodFill(int[][] image, int sr, int sc, int color)
    {
        Logger.FuncName = nameof(FloodFill);
        Logger.LoggingStart();

        // Process
        var visited = new bool[image.Length, image[0].Length];
        var output = FloodFill(image, sr, sc, color, image[sr][sc], visited);

        static int[][] FloodFill(int[][] image, int sr, int sc, int color, int memory, bool[,] visited)
        {
            if (sr < 0 || sc < 0 ||
               sr >= image.Length || sc >= image[sr].Length ||
               image[sr][sc] != memory ||
               visited[sr, sc]) // if the coordinates is out of range or the current center doesn't match the starting pixel or this coordinates had been visited before
            {
                return image;
            }

            visited[sr, sc] = true;
            image[sr][sc] = color;

            // Up & Use current coordinate as a new center
            FloodFill(image, sr - 1, sc, color, memory, visited);
            // Right & Use current coordinate as a new center
            FloodFill(image, sr, sc + 1, color, memory, visited);
            // Down & Use current coordinate as a new center
            FloodFill(image, sr + 1, sc, color, memory, visited);
            // Left & Use current coordinate as a new center
            FloodFill(image, sr, sc - 1, color, memory, visited);

            return image;
        }

        // Output
        Logger.LoggingStop(output);
        return output;
    }

    /// <summary>
    /// Refs: https://leetcode.com/problems/maximum-subarray
    /// </summary>
    /// <param name="nums">Example: [-2,1,-3,4,-1,2,1,-5,4]</param>
    /// <returns>Example: 6</returns>
    public static int _10_MaxSubArray(int[] nums)
    {
        Logger.FuncName = nameof(_10_MaxSubArray);
        Logger.LoggingStart();

        // Process
        int sum = nums[0];
        int output = nums[0];

        for (int i = 1; i < nums.Length; i++)
        {
            if (sum < 0 && sum < nums[i]) sum = nums[i];
            else sum += nums[i];
            output = Math.Max(output, sum);
        }

        // Output
        Logger.LoggingStop(output.ToString());
        return output;
    }

    /// <summary>
    /// Refs: https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-search-tree
    /// </summary>
    /// <param name="root">Example: [6,2,8,0,4,7,9,null,null,3,5]</param>
    /// <param name="p">Example: 2</param>
    /// <param name="q">Example: 8</param>
    /// <returns>Example: 6</returns>
    public static TreeNode _11_LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
    {
        Logger.FuncName = nameof(_11_LowestCommonAncestor);
        Logger.LoggingStart();

        // Process
        var output = TreeNode.LowestCommonAncestor(root, p, q);

        // Output
        Logger.LoggingStop(output.val);
        return output;
    }

    /// <summary>
    /// Refs: https://leetcode.com/problems/balanced-binary-tree
    /// </summary>
    /// <param name="root">Example: [1,2,2,3,3,null,null,4,4]</param>
    /// <returns>Example: false</returns>
    public static bool _12_IsBalancedBinaryTree(TreeNode root)
    {
        Logger.FuncName = nameof(_12_IsBalancedBinaryTree);
        Logger.LoggingStart();

        // Process
        var output = true;

        if (root.right is not null && root.left is not null)
        {
            output = TreeNode.IsBalancedBinaryTree(root);
        }

        // Output
        Logger.LoggingStop(output.ToString());
        return output;
    }

    /// <summary>
    /// Refs: https://leetcode.com/problems/linked-list-cycle
    /// </summary>
    /// <param name="head">Example: [3,2,0,-4]</param>
    /// <returns>Example: true</returns>
    public static bool _13_HasCycle(ListNode head)
    {
        Logger.FuncName = nameof(_13_HasCycle);
        Logger.LoggingStart();

        // Process
        var output = false;

        if (head is null)
        {
            output = false;
            goto printOutput;
        }

        HashSet<ListNode> hsNodes = [];
        var node = head.next;

        while (node is not null)
        {
            if (hsNodes.Contains(node))
            {
                output = true;
                goto printOutput;
            }

            hsNodes.Add(node);
            node = node.next;
        }

    printOutput:
        // Output
        Logger.LoggingStop(output.ToString());
        return output;
    }

    /// <summary>
    /// Refs: https://leetcode.com/problems/linked-list-cycle
    /// </summary>
    /// <param name="head">Example: [3,2,0,-4]</param>
    /// <returns>Example: true</returns>
    public static bool _13_2_HasCycle(ListNode head)
    {
        Logger.FuncName = nameof(_13_2_HasCycle);
        Logger.LoggingStart();

        var output = true;

        // Process
        if (head is null)
        {
            output = false;
            goto printOutput;
        }

        var slow = head;
        var fast = head.next;

        while (slow != fast)
        {
            if (fast is null || fast.next is null)
            {
                output = false;
                goto printOutput;
            }

            slow = slow.next;
            fast = fast.next.next;
        }

    printOutput:
        // Output
        Logger.LoggingStop(output.ToString());
        return output;
    }

    /// <summary>
    /// Refs: https://leetcode.com/problems/first-bad-version
    /// </summary>
    /// <param name="n">Example: 5</param>
    /// <returns>Example: 4</returns>
    public static int _15_FirstBadVersion(int n)
    {
        Logger.FuncName = nameof(_15_FirstBadVersion);
        Logger.LoggingStart();

        // Process
        var output = n;

        if (n == 1)
        {
            goto printOutput;
        }

        var min = 1;
        var max = n;

        while (min <= max)
        {
            var mid = min + (max - min) / 2;
            if (IsBadVersion(mid))
            {
                // current mid index is already a bad version, move search range to [min..mid-1] - skip [mid..max]
                max = mid - 1;
            }
            else
            {
                // current mid index is not a bad version, move search range to [mid+1..max] - skip [min..mid]
                min = mid + 1;
            }
        }

        output = min;

        static bool IsBadVersion(int version)
        {
            var bad = 1702766719;
            return version >= bad;
        }

    printOutput:
        // Output
        Logger.LoggingStop(output);
        return output;
    }

    /// <summary>
    /// Refs: https://leetcode.com/problems/ransom-note
    /// </summary>
    /// <param name="ransomNote">Example: "a"</param>
    /// <param name="magazine">Example: "b"</param>
    /// <returns>Example: fasle</returns>
    public static bool _16_RansomNote(string ransomNote, string magazine)
    {
        // Process
        var output = true;
        var magazineChars = new char[26];

        foreach (var c in magazine)
        {
            magazineChars[c - 'a']++;
        }

        foreach (var c in ransomNote)
        {
            if (magazineChars[c - 'a'] == 0)
            {
                output = false;
                goto printOutput;
            }

            magazineChars[c - 'a']--;
        }

    printOutput:
        // Output
        Logger.LoggingStop(output);
        return output;
    }

    /// <summary>
    /// Refs: https://leetcode.com/problems/climbing-stairs
    /// </summary>
    /// <param name="n">Example: 2</param>
    /// <returns>Example: 2</returns>
    public static int _17_ClimbStairs(int n)
    {
        // Process
        var output = n;
        if (n <= 3)
        {
            goto printOutput;
        }

        var visitedSteps = new int[n];
        visitedSteps[0] = 1;
        visitedSteps[1] = 2;
        visitedSteps[2] = 3;

        for (var i = 3; i < n; i++)
        {
            visitedSteps[i] = visitedSteps[i - 1] + visitedSteps[i - 2];
        }

        output = visitedSteps[n - 1];

    printOutput:
        // Output
        Logger.LoggingStop(output);
        return output;
    }

    /// <summary>
    /// Refs: https://leetcode.com/problems/climbing-stairs
    /// </summary>
    /// <param name="n">Example: 2</param>
    /// <returns>Example: 2</returns>
    public static int _17_2_ClimbStairs(int n)
    {
        // Process
        var output = n;
        if (n <= 3)
        {
            goto printOutput;
        }

        // If top is starting from 4 (> 3), then we have at least 3 ways already
        output = 3;
        var tempWays = 2; // we have 2 ways before index 3

        for (var i = 4; i <= n; i++)
        {
            var temp = tempWays + output;
            tempWays = output;
            output = temp;
        }

    printOutput:
        // Output
        Logger.LoggingStop(output);
        return output;
    }

    /// <summary>
    /// Refs: https://leetcode.com/problems/longest-palindrome
    /// </summary>
    /// <param name="s">Example: "abccccdd"</param>
    /// <returns>Example: 7</returns>
    public static int _18_LongestPalindrome(string s)
    {
        var output = 0;
        var hashChars = new HashSet<char>();

        foreach (var c in s)
        {
            if (!hashChars.Add(c))
            {
                output += 2;
                hashChars.Remove(c);
            }
        }

        if (hashChars.Count != 0)
        {
            output++;
        }

        // Output
        Logger.LoggingStop(output);
        return output;
    }

    /// <summary>
    /// Refs: https://leetcode.com/problems/reverse-linked-list
    /// </summary>
    /// <param name="head">Example: [1,2,3,4,5]</param>
    /// <returns>Example: [5,4,3,2,1]</returns>
    public static ListNode _19_ReverseList(ListNode head)
    {
        // Process
        if (head is null || head.next is null)
        {
            return head;
        }

        ListNode output = new(head.next.val);
        var tempNode = head.next.next;
        head.next = null;
        output.next = head;

        while (tempNode != null)
        {
            head = new(output.val, output.next);
            output.val = tempNode.val;
            output.next = head;
            tempNode = tempNode.next;
        }

        // Output
        Logger.LoggingStop(output);
        return output;
    }

    /// <summary>
    /// Refs: https://leetcode.com/problems/majority-element
    /// </summary>
    /// <param name="nums">Example: [3,2,3]</param>
    /// <returns>Example: 3</returns>
    public static int _20_MajorityElement(int[] nums)
    {
        // Process
        var output = nums[0];
        if (nums.Length == 1)
        {
            goto printOutput;
        }

        var appearTimes = 0;

        foreach (var num in nums)
        {
            if (appearTimes == 0)
            {
                output = num;
            }

            appearTimes += output == num ? 1 : -1;
        }

    printOutput:
        // Output
        Logger.LoggingStop(output);
        return output;
    }
}
