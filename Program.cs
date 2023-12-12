using static System.Console;

namespace MaxHeapWithArray;

public class Program
{
    static void Main()
    {
        MaxHeap<int> maxHeap = new MaxHeap<int>();

        MaxHeapDouble<int> maxHeapDouble = new MaxHeapDouble<int>();


        maxHeapDouble.GenerateAndAddRandomElements(100);

        maxHeap.GenerateAndAddRandomElementsForArray(100);

        WriteLine($"Вывод элементов в произвольном порядке из кучи на double linked list: {maxHeapDouble.RandomGetAllElements()}");
        WriteLine();
        WriteLine("--------------------------------------------");
        WriteLine();
        WriteLine($"Вывод элементов в произвольном порядке из кучи на массиве: {maxHeap.RandomGetAllElements()}");

        WriteLine($" Размер кучи : {maxHeap.Size()}");

        WriteLine($"Максимальный элемент кучи (корень) = {maxHeap.Peek()}");
    }
}