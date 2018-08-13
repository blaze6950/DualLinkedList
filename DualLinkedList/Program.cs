using System;

namespace DualLinkedList
{
    class Program
    {
        static void Main()
        {
            DoubleLinkedList<int> list = new DoubleLinkedList<int>();
            list.Add(23);
            list.AddToTheEnd(22);
            list.AddToTheBeginning(24);
            Console.WriteLine(list.Contains(23));
            Console.WriteLine(list.Count);
            list.Remove(24);
            Console.WriteLine(list.Count);
        }
    }
}
