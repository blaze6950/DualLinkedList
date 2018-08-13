namespace DualLinkedList
{
    class ListNode<T>
    {
        public ListNode(T item)
        {
            Data = item;
        }
        public ListNode<T> PreviousNode { get; set; }
        public ListNode<T> NextNode { get; set; }
        public T Data { get; }
    }
}
