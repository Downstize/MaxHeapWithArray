using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace MaxHeapWithArray
{
    public class MaxHeapNode<T>
    {
        public T Value { get; set; }
        public MaxHeapNode<T> Parent { get; set; }
        public MaxHeapNode<T> LeftChild { get; set; }
        public MaxHeapNode<T> RightChild { get; set; }

        public MaxHeapNode(T value)
        {
            Value = value;
        }
    }

    public class MaxHeapDouble<T> : IAbstractHeap<T> where T : IComparable<T>
    {
        private MaxHeapNode<T> root;
        private readonly Stopwatch stopwatch;

        public MaxHeapDouble()
        {
            stopwatch = new Stopwatch();
        }

        public void Add(T value)
        {
            MaxHeapNode<T> newNode = new MaxHeapNode<T>(value);

            if (root == null)
            {
                root = newNode;
            }
            else
            {
                InsertNode(root, newNode);
                HeapifyUp(newNode);
            }
        }

        public void GenerateAndAddRandomElements(int count)
        {
            Random random = new Random();

            for (int i = 0; i < count; i++)
            {
                T randomValue = (T)Convert.ChangeType(random.Next(301), typeof(T));
                Add(randomValue);
            }
        }


        private void InsertNode(MaxHeapNode<T> root, MaxHeapNode<T> newNode)
        {
            Queue<MaxHeapNode<T>> queue = new Queue<MaxHeapNode<T>>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();

                if (current.LeftChild == null)
                {
                    current.LeftChild = newNode;
                    newNode.Parent = current;
                    break;
                }
                else if (current.RightChild == null)
                {
                    current.RightChild = newNode;
                    newNode.Parent = current;
                    break;
                }

                queue.Enqueue(current.LeftChild);
                queue.Enqueue(current.RightChild);
            }
        }

        private void HeapifyUp(MaxHeapNode<T> node)
        {
            while (node.Parent != null && node.Value.CompareTo(node.Parent.Value) > 0)
            {
                Swap(node, node.Parent);
                node = node.Parent;
            }
        }

        public string RandomGetAllElements()
        {
            stopwatch.Start();
            var random = new Random();
            var elements = InOrderTraversal(root).ToList();
            var randomizedHeap = elements.OrderBy(x => random.Next()).ToList();
            //Thread.Sleep(153);
            stopwatch.Stop();

            return $"Затраченное время: {stopwatch.Elapsed} мс, Элементы: {string.Join(", ", randomizedHeap)}";
        }

        private List<T> InOrderTraversal(MaxHeapNode<T> node)
        {
            List<T> result = new List<T>();
            if (node != null)
            {
                result.AddRange(InOrderTraversal(node.LeftChild));
                result.Add(node.Value);
                result.AddRange(InOrderTraversal(node.RightChild));
            }
            return result;
        }

        public int Size()
        {
            throw new NotImplementedException();
        }

        public T Peek()
        {
            throw new NotImplementedException();
        }

        private void Swap(MaxHeapNode<T> node1, MaxHeapNode<T> node2)
        {
            T temp = node1.Value;
            node1.Value = node2.Value;
            node2.Value = temp;
        }
    }
}
