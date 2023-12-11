namespace MaxHeapWithArray;

public class MaxHeap<T> : IAbstractHeap<T> where T : IComparable<T>
{
    private List<T> heap;

    public MaxHeap()
    {
        heap = new List<T>();
    }

    public void Add(T value)
    {
        heap.Add(value);
        HeapifyUp(heap.Count - 1);
    }
    
    private void HeapifyUp(int index)
    {
        while (index > 0)
        {
            int parentIndex = (index - 1) / 2;

            if (heap[index].CompareTo(heap[parentIndex]) > 0)
            {
                Swap(index, parentIndex);
                index = parentIndex;
            }
            else
            {
                break;
            }
        }
    }

    // private void HeapifyDown(int index)
    // {
    //     while (true)
    //     {
    //        int rightChild = 2 * index + 1;
    //        int leftChild = 2 * index + 2;
    //
    //        int largest = index;
    //
    //        if (leftChild < heap.Count && heap[leftChild].CompareTo(heap[largest]) > 0)
    //        {
    //            largest = leftChild;
    //        }
    //
    //        if (rightChild < heap.Count && heap[rightChild].CompareTo(heap[largest]) > 0)
    //        {
    //            largest = rightChild;
    //        }
    //
    //        if (largest != index)
    //        {
    //            Swap(index, largest);
    //            index = largest;
    //        }
    //        else
    //        {
    //            break;
    //        }
    //     }
    // }

    public T[] RandomGetAllElements()
    {
        return heap.ToArray();
    }

    public int Size()
    {
        if (heap.Count == 0)
        {
            throw new InvalidOperationException("Куча пуста!");
        }
        return heap.Count;
    }

    public T Peek()
    {
        if (heap.Count == 0)
        {
            throw new InvalidOperationException("Куча пуста!");
        }

        return heap[0];
    }
    
    
    
    private void Swap(int i, int k)
    {
        T obmen = heap[i];
        heap[i] = heap[k];
        heap[k] = obmen;
    }
}