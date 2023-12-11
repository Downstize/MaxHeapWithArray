namespace MaxHeapWithArray;

public interface IAbstractHeap<T> where T : IComparable<T>
{
    int Size();
    void Add(T value);
    T Peek();
}