using System.Diagnostics;

namespace MaxHeapWithArray;

public class MaxHeap<T> : IAbstractHeap<T> where T : IComparable<T>
{
    private List<T> heap;
    private readonly Stopwatch stopwatch;

    public MaxHeap()
    {
        heap = new List<T>();
        stopwatch = new Stopwatch();
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

    public void GenerateAndAddRandomElementsForArray(int count)
    {
        Random random = new Random();

        for (int i = 0; i < count; i++)
        {
            T randomValue = (T)Convert.ChangeType(random.Next(301), typeof(T));
            Add(randomValue);
        }
    }


    public string RandomGetAllElements()
    {
        //long start = DateTime.UtcNow.Millisecond;
        stopwatch.Start();
        var random = new Random();
        var randomizedHeap = heap.OrderBy(x => random.Next()).ToList();
        //Thread.Sleep(123);
       // long end = DateTime.UtcNow.Millisecond;
        //stopwatch.Stop();
        return $"Затраченное время: {stopwatch.Elapsed} мс, Элементы: {string.Join(", ", randomizedHeap)}";
    }
    
    // public string RandomGetAllElements()
    // {
    //     long start = DateTime.UtcNow.Microsecond;
    //     var random = new Random();
    //     var randomizedHeap = heap.OrderBy(x => random.Next()).ToList();
    //     long end = DateTime.UtcNow.Microsecond;
    // return $"Затраченное время: {end - start} мс, Элементы: {string.Join(", ", randomizedHeap)}";
    //  }

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