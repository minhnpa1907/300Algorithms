namespace Algorithms
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }

        public static ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {
            if (list1 is null && list2 is null) return new();
            if (list1 is null) return list2;
            if (list2 is null) return list1;

            if (list1.val <= list2.val)
            {
                list1.next = MergeTwoLists(list1.next, list2);
                return list1;
            }
            else
            {
                list2.next = MergeTwoLists(list1, list2.next);
                return list2;
            }
        }
    }

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

        public static bool BalancedBinaryTree(TreeNode root)
        {
            var heightL = BalancedBinaryTreeRec(root.left);
            var heightR = BalancedBinaryTreeRec(root.right);

            if (Math.Abs(heightL - heightR) <= 1)
            {
                return true && BalancedBinaryTree(root.left) && BalancedBinaryTree(root.right); // true - A height-balanced binary tree is a binary tree in which the depth of the two subtrees of every node never differs by more than one. Otherwise returns false
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

        public static string FlatTreeNode(TreeNode root)
        {
            if (root is null)
            {
                return string.Empty;
            }

            var result = new List<int>() { root.val };
            result.AddRange(GetVal(root));

            return string.Join(", ", result);
        }

        private static List<int> GetVal(TreeNode root)
        {
            var result = new List<int>();

            if (root is not null)
            {
                if (root.left is not null)
                {
                    result.Add(root.left.val);
                }
                if (root.right is not null)
                {
                    result.Add(root.right.val);
                }


                result.AddRange(GetVal(root.left));
                result.AddRange(GetVal(root.right));
                return result;
            }

            return result;
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
            return !queue.Any();
        }
    }
}
