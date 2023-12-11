using static System.Console;

namespace MaxHeapWithArray;

public class Program
{
    static void Main()
    {
        MaxHeap<int> maxHeap = new MaxHeap<int>();
        
        maxHeap.Add(72);
        maxHeap.Add(28);
        maxHeap.Add(39);
        maxHeap.Add(91);
        maxHeap.Add(7);
        maxHeap.Add(56);
        maxHeap.Add(1);

        foreach (var element in maxHeap.RandomGetAllElements())
        {
            WriteLine(element);
        }

        WriteLine($"Размер кучи : {maxHeap.Size()}");
        
        WriteLine($"Максимальный элемент кучи (корень) = {maxHeap.Peek()}");
    }
}
