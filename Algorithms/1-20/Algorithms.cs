using Algorithms.Logging;
using Algorithms.Models;

// Author: minhnpa1907
namespace Algorithms
{
    public class Algorithms_1_20
    {
        public static int[] _1_TwoSum(int[] nums, int target)
        {
            var func = nameof(_1_TwoSum);
            Logger.LoggingStart(func);

            // input
            var output = new[] { -1, -1 };

            // process
            if (nums.Length == 2)
            {
                if (nums.Sum() == target)
                {
                    output = new[] { 0, 1 };
                }
            }
            else // nums.Length > 2
            {
                var dictMemory = new Dictionary<int, int>();
                for (int i = 0; i < nums.Length; i++)
                {
                    if (dictMemory.ContainsKey(target - nums[i]))
                    {
                        output = new[] { dictMemory[target - nums[i]], i };
                        break;
                    }

                    if (!dictMemory.ContainsKey(nums[i]))
                    {
                        dictMemory.Add(nums[i], i);
                    }
                }
            }

        printOutput:
            // output
            Logger.LoggingStop(func, string.Join(", ", output));
            return output;
        }

        public static bool _2_ValidParentheses(string input)
        {
            var func = nameof(_2_ValidParentheses);
            Logger.LoggingStart(func);

            // input
            var output = true;
            Dictionary<char, char> dictChars = new() {
                {'(', ')'},
                {'{', '}'},
                {'[', ']'},
            };

            // process
            // If the length is not evan -> invalid parentheses
            if (input.Length % 2 != 0)
            {
                output = false;
                goto printOutput;
            }

            var tempStack = new Stack<char>();
            foreach (char c in input)
            {
                if (dictChars.ContainsKey(c))
                {
                    // c is open chars
                    tempStack.Push(dictChars[c]);
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
            // output
            Logger.LoggingStop(func, output.ToString());
            return output;
        }

        public static ListNode _3_MergeTwoLists(ListNode list1, ListNode list2)
        {
            var func = nameof(_3_MergeTwoLists);
            Logger.LoggingStart(func);

            // process
            var output = ListNode.MergeTwoLists(list1, list2);

        printOutput:
            // output
            Logger.LoggingStop(func, string.Join(", ", output.ToArray()));
            return output;
        }

        public static void _4_MaxProfit()
        {
            var func = nameof(_4_MaxProfit);
            Logger.LoggingStart(func);

            // input
            int[] prices = new int[] { 7, 1, 5, 3, 6, 4 };
            var output = 0;

            // process
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

        printOutput:
            // output
            Logger.LoggingStop(func, output.ToString());
        }

        public static void _5_ValidPalindrome()
        {
            var func = nameof(_5_ValidPalindrome);
            Logger.LoggingStart(func);

            // input
            var input = "A man, a plan, a canal: Panama";
            var output = true;

            // process
            for (int i = 0, j = input.Length - 1; i < j;)
            {
                if (!char.IsLetterOrDigit(input[i]))
                {
                    i++; continue;
                }

                if (!char.IsLetterOrDigit(input[j]))
                {
                    j--; continue;
                }

                if (char.ToLower(input[i]) != char.ToLower(input[j]))
                {
                    output = false;
                    break;
                }
                else
                {
                    i++; j--; continue;
                }
            }


        printOutput:
            // output
            Logger.LoggingStop(func, output.ToString());
        }

        public static void _6_InvertTree()
        {
            var func = nameof(_6_InvertTree);
            Logger.LoggingStart(func);

            // input
            TreeNode root = new(4, new(2, new(1), new(3)), new(7, new(6), new(9)));
            //TreeNode root = new(2, new(1), new(3));
            //TreeNode root = new(1, new(2));

            // process
            var outputNode = TreeNode.InvertTree(root);
            var output = TreeNode.FlatTreeNode(outputNode);

        printOutput:
            // output
            Logger.LoggingStop(func, output);
        }

        public static void _7_ValidAnagram()
        {
            var func = nameof(_7_ValidAnagram);
            Logger.LoggingStart(func);

            // input
            string s = "anagram", t = "nagaram";
            var output = true;

            // process
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

                if (!clm.ContainsKey(c))
                {
                    clm.Add(c, 0);
                }

                clm[c]++;
            }

            foreach (var c in t)
            {
                if (c.Equals(' ')) continue;
                if (!clm.ContainsKey(c) || clm[c] == 0)
                {
                    output = false;
                    goto printOutput;
                }

                clm[c]--;
            }

        printOutput:
            // output
            Logger.LoggingStop(func, output.ToString());
        }

        public static void _8_BinarySearch()
        {
            var func = nameof(_8_BinarySearch);
            Logger.LoggingStart(func);

            // input
            int[] nums = new int[] { -1, 0, 3, 5, 9, 12 };
            int target = 9;
            int left = 0;
            int right = nums.Length - 1;
            var output = -1;

            // process
            while (left <= right)
            {
                int mid = (left + right) / 2;

                if (nums[mid] == target) { output = mid; goto printOutput; };
                if (nums[mid] > target) right = mid - 1;
                else left = mid + 1;
            }

        printOutput:
            // output
            Logger.LoggingStop(func, output.ToString());
        }

        public static void _9_FloodFill()
        {
            var func = nameof(FloodFill);
            Logger.LoggingStart(func);

            // input
            int[][] image = new[]
            {
        new int[]{ 1, 1, 1 },
        new int[]{ 1, 1, 0 },
        new int[]{ 1, 0, 1 },
    };
            int sr = 1, sc = 1, color = 2;
            bool[,] visited = new bool[image.Length, image[0].Length];
            bool output = true;

            // process
            output = FloodFill(image, sr, sc, color, image[sr][sc], visited);

            bool FloodFill(int[][] image, int sr, int sc, int color, int memory, bool[,] visited)
            {
                if (sr < 0 || sc < 0 ||
                   sr >= image.Length || sc >= image[sr].Length ||
                   image[sr][sc] != memory ||
                   visited[sr, sc]) // if the coordinates is out of range or the current center doesn't match the starting pixel or this coordinates had been visited before
                {
                    return false;
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

                return true;
            }
        printOutput:
            // output
            Logger.LoggingStop(func, output.ToString());
        }

        public static void _10_MaxSubArray()
        {
            var func = nameof(_10_MaxSubArray);
            Logger.LoggingStart(func);

            // input
            int[] nums = new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 };
            int sum = nums[0];
            int output = nums[0];

            // process
            for (int i = 1; i < nums.Length; i++)
            {
                if (sum < 0 && sum < nums[i]) sum = nums[i];
                else sum += nums[i];
                output = Math.Max(output, sum);
            }

        printOutput:
            // output
            Logger.LoggingStop(func, output.ToString());
        }

        public static void _11_LowestCommonAncestor()
        {
            var func = nameof(_11_LowestCommonAncestor);
            Logger.LoggingStart(func);

            // input
            TreeNode root = new(6,
                                new(2, new(0), new(4, new(3), new(5))),
                                new(8, new(7), new(9)));
            TreeNode p = new(2);
            TreeNode q = new(4);

            // process
            var outputNode = TreeNode.LowestCommonAncestor(root, p, q);
            var output = outputNode.val;

        printOutput:
            // output
            Logger.LoggingStop(func, output.ToString());
        }

        public static void _12_BalancedBinaryTree()
        {
            var func = nameof(_12_BalancedBinaryTree);
            Logger.LoggingStart(func);

            // input
            TreeNode root = new(1,
                                new(2,
                                    new(3,
                                        new(4))),
                                new(2,
                                    right: new(3,
                                               right: new(4))));
            var output = true;

            // process
            if (root.right is null && root.left is null)
            {
                goto printOutput;
            }

            output = TreeNode.BalancedBinaryTree(root);

        printOutput:
            // output
            Logger.LoggingStop(func, output.ToString());
        }

        public static void _13_LinkedListCycle(ListNode input)
        {
            var func = nameof(_13_LinkedListCycle);
            Logger.LoggingStart(func);

            var output = false;

            // process
            if (input is null)
            {
                output = false;
                goto printOutput;
            }

            HashSet<ListNode> hsNodes = new();
            var node = input.next;

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
            // output
            Logger.LoggingStop(func, output.ToString());
        }

        public static void _13_2_LinkedListCycle(ListNode input)
        {
            var func = nameof(_13_2_LinkedListCycle);
            Logger.LoggingStart(func);

            var output = true;

            // process
            if (input is null)
            {
                output = false;
                goto printOutput;
            }

            var slow = input;
            var fast = input.next;

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
            // output
            Logger.LoggingStop(func, output.ToString());
        }

        public static void _15_FirstBadVersion()
        {
            var func = nameof(_15_FirstBadVersion);
            Logger.LoggingStart(func);

            // input
            var n = 2126753390;
            var output = n;

            // process
            var bad = 1702766719;
            if (n == 1)
            {
                goto printOutput;
            }

            var min = 1;
            var max = n;

            while (min <= max)
            {
                var mid = min + (max - min) / 2;
                if (mid >= bad) // is bad version?
                {
                    max = mid - 1;
                }
                else
                {
                    min = mid + 1;
                }
            }

            output = min;

        printOutput:
            // output
            Logger.LoggingStop(func, output.ToString());
        }
    }
}
