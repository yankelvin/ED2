namespace ed2_arvore_avl.Models
{
    public class AvlTree<K, V>
    {
        protected Node<K, V> Root;

        public bool Add(K key, V value)
        {
            var node = Root;

            while (node != null)
            {
                int compare = key.GetHashCode() - node.Key.GetHashCode();

                if (compare < 0)
                {
                    var left = node.Left;

                    if (left == null)
                    {
                        node.Left = new Node<K, V>(key, value, node);
                        AddWithCompare(node, 1);

                        return true;
                    }
                    else
                    {
                        node = left;
                    }
                }
                else if (compare > 0)
                {
                    var right = node.Right;

                    if (right == null)
                    {
                        node.Right = new Node<K, V>(key, value, node);
                        AddWithCompare(node, -1);

                        return true;
                    }
                    else
                    {
                        node = right;
                    }
                }
                else
                {
                    node.Value = value;

                    return false;
                }
            }

            Root = new Node<K, V>(key, value);

            return true;
        }

        private void AddWithCompare(Node<K, V> node, int weight)
        {
            while (node != null)
            {
                weight = (node.Weight += weight);

                if (weight == 0)
                {
                    return;
                }
                else if (weight == 2)
                {
                    if (node.Left.Weight == 1)
                    {
                        RotateRight(node);
                    }
                    else
                    {
                        RotateLeftRight(node);
                    }

                    return;
                }
                else if (weight == -2)
                {
                    if (node.Right.Weight == -1)
                    {
                        RotateLeft(node);
                    }
                    else
                    {
                        RotateRightLeft(node);
                    }

                    return;
                }

                var parent = node.Parent;

                if (parent != null)
                {
                    weight = parent.Left == node ? 1 : -1;
                }

                node = parent;
            }
        }

        public V Search(K key)
        {
            var node = Root;

            while (node != null)
            {
                if (key.GetHashCode() < node.Key.GetHashCode())
                {
                    node = node.Left;
                }
                else if (key.GetHashCode() > node.Key.GetHashCode())
                {
                    node = node.Right;
                }
                else
                {
                    return node.Value;
                }
            }

            return default;
        }

        private Node<K, V> RotateLeft(Node<K, V> node)
        {
            var right = node.Right;
            var rightLeft = right.Left;
            var parent = node.Parent;

            right.Parent = parent;
            right.Left = node;
            node.Right = rightLeft;
            node.Parent = right;

            if (rightLeft != null)
            {
                rightLeft.Parent = node;
            }

            if (node == Root)
            {
                Root = right;
            }
            else if (parent.Right == node)
            {
                parent.Right = right;
            }
            else
            {
                parent.Left = right;
            }

            right.Weight++;
            node.Weight = -right.Weight;

            return right;
        }

        private Node<K, V> RotateRight(Node<K, V> node)
        {
            var left = node.Left;
            var leftRight = left.Right;
            var parent = node.Parent;

            left.Parent = parent;
            left.Right = node;
            node.Left = leftRight;
            node.Parent = left;

            if (leftRight != null)
            {
                leftRight.Parent = node;
            }

            if (node == Root)
            {
                Root = left;
            }
            else if (parent.Left == node)
            {
                parent.Left = left;
            }
            else
            {
                parent.Right = left;
            }

            left.Weight--;
            node.Weight = -left.Weight;

            return left;
        }

        private Node<K, V> RotateLeftRight(Node<K, V> node)
        {
            var left = node.Left;
            var leftRight = left.Right;
            var parent = node.Parent;
            var leftRightRight = leftRight.Right;
            var leftRightLeft = leftRight.Left;

            leftRight.Parent = parent;
            node.Left = leftRightRight;
            left.Right = leftRightLeft;
            leftRight.Left = left;
            leftRight.Right = node;
            left.Parent = leftRight;
            node.Parent = leftRight;

            if (leftRightRight != null)
            {
                leftRightRight.Parent = node;
            }

            if (leftRightLeft != null)
            {
                leftRightLeft.Parent = left;
            }

            if (node == Root)
            {
                Root = leftRight;
            }
            else if (parent.Left == node)
            {
                parent.Left = leftRight;
            }
            else
            {
                parent.Right = leftRight;
            }

            if (leftRight.Weight == -1)
            {
                node.Weight = 0;
                left.Weight = 1;
            }
            else if (leftRight.Weight == 0)
            {
                node.Weight = 0;
                left.Weight = 0;
            }
            else
            {
                node.Weight = -1;
                left.Weight = 0;
            }

            leftRight.Weight = 0;

            return leftRight;
        }

        private Node<K, V> RotateRightLeft(Node<K, V> node)
        {
            var right = node.Right;
            var rightLeft = right.Left;
            var parent = node.Parent;
            var rightLeftLeft = rightLeft.Left;
            var rightLeftRight = rightLeft.Right;

            rightLeft.Parent = parent;
            node.Right = rightLeftLeft;
            right.Left = rightLeftRight;
            rightLeft.Right = right;
            rightLeft.Left = node;
            right.Parent = rightLeft;
            node.Parent = rightLeft;

            if (rightLeftLeft != null)
            {
                rightLeftLeft.Parent = node;
            }

            if (rightLeftRight != null)
            {
                rightLeftRight.Parent = right;
            }

            if (node == Root)
            {
                Root = rightLeft;
            }
            else if (parent.Right == node)
            {
                parent.Right = rightLeft;
            }
            else
            {
                parent.Left = rightLeft;
            }

            if (rightLeft.Weight == 1)
            {
                node.Weight = 0;
                right.Weight = -1;
            }
            else if (rightLeft.Weight == 0)
            {
                node.Weight = 0;
                right.Weight = 0;
            }
            else
            {
                node.Weight = 1;
                right.Weight = 0;
            }

            rightLeft.Weight = 0;

            return rightLeft;
        }

        public bool Remove(K key)
        {
            var node = Root;

            while (node != null)
            {
                if (key.GetHashCode() < node.Key.GetHashCode())
                {
                    node = node.Left;
                }
                else if (key.GetHashCode() > node.Key.GetHashCode())
                {
                    node = node.Right;
                }
                else
                {
                    var left = node.Left;
                    var right = node.Right;

                    if (left == null)
                    {
                        if (right == null)
                        {
                            if (node == Root)
                            {
                                Root = null;
                            }
                            else
                            {
                                var parent = node.Parent;

                                if (parent.Left == node)
                                {
                                    parent.Left = null;

                                    DeleteBalance(parent, -1);
                                }
                                else
                                {
                                    parent.Right = null;

                                    DeleteBalance(parent, 1);
                                }
                            }
                        }
                        else
                        {
                            Replace(node, right);

                            DeleteBalance(node, 0);
                        }
                    }
                    else if (right == null)
                    {
                        Replace(node, left);

                        DeleteBalance(node, 0);
                    }
                    else
                    {
                        var successor = right;

                        if (successor.Left == null)
                        {
                            var parent = node.Parent;

                            successor.Parent = parent;
                            successor.Left = left;
                            successor.Weight = node.Weight;
                            left.Parent = successor;

                            if (node == Root)
                            {
                                Root = successor;
                            }
                            else
                            {
                                if (parent.Left == node)
                                {
                                    parent.Left = successor;
                                }
                                else
                                {
                                    parent.Right = successor;
                                }
                            }

                            DeleteBalance(successor, 1);
                        }
                        else
                        {
                            while (successor.Left != null)
                            {
                                successor = successor.Left;
                            }

                            var parent = node.Parent;
                            var successorParent = successor.Parent;
                            var successorRight = successor.Right;

                            if (successorParent.Left == successor)
                            {
                                successorParent.Left = successorRight;
                            }
                            else
                            {
                                successorParent.Right = successorRight;
                            }

                            if (successorRight != null)
                            {
                                successorRight.Parent = successorParent;
                            }

                            successor.Parent = parent;
                            successor.Left = left;
                            successor.Weight = node.Weight;
                            successor.Right = right;
                            right.Parent = successor;
                            left.Parent = successor;

                            if (node == Root)
                            {
                                Root = successor;
                            }
                            else
                            {
                                if (parent.Left == node)
                                {
                                    parent.Left = successor;
                                }
                                else
                                {
                                    parent.Right = successor;
                                }
                            }

                            DeleteBalance(successorParent, -1);
                        }
                    }

                    return true;
                }
            }

            return false;
        }

        private void DeleteBalance(Node<K, V> node, int Weight)
        {
            while (node != null)
            {
                Weight = (node.Weight += Weight);

                if (Weight == 2)
                {
                    if (node.Left.Weight >= 0)
                    {
                        node = RotateRight(node);

                        if (node.Weight == -1)
                        {
                            return;
                        }
                    }
                    else
                    {
                        node = RotateLeftRight(node);
                    }
                }
                else if (Weight == -2)
                {
                    if (node.Right.Weight <= 0)
                    {
                        node = RotateLeft(node);

                        if (node.Weight == 1)
                        {
                            return;
                        }
                    }
                    else
                    {
                        node = RotateRightLeft(node);
                    }
                }
                else if (Weight != 0)
                {
                    return;
                }

                var parent = node.Parent;

                if (parent != null)
                {
                    Weight = parent.Left == node ? -1 : 1;
                }

                node = parent;
            }
        }

        private static void Replace(Node<K, V> target, Node<K, V> source)
        {
            var left = source.Left;
            var right = source.Right;

            target.Weight = source.Weight;
            target.Key = source.Key;
            target.Value = source.Value;
            target.Left = left;
            target.Right = right;

            if (left != null)
            {
                left.Parent = target;
            }

            if (right != null)
            {
                right.Parent = target;
            }
        }

        public void Clean()
        {
            Root = null;
        }
    }
}
