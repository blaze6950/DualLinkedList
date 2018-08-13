using System.Collections;
using System.Collections.Generic;

namespace DualLinkedList
{
    class DoubleLinkedList <T> : ICollection<T>
    {
        private ListNode<T> _firstListNode;
        private ListNode<T> _lastListNode;
        private int _count;

        public DoubleLinkedList(){}
        public DoubleLinkedList(bool isReadOnly)
        {
            IsReadOnly = isReadOnly;
        }
        public ListNode<T> GetFirstListNode()
        { return _firstListNode; }
        public ListNode<T> GetLastListNode()
        { return _lastListNode; }
        // ReSharper disable once ConvertToAutoPropertyWithPrivateSetter
        public int Count => _count;
        public bool IsReadOnly { get; }
        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator<T>(this);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return new Enumerator<T>(this);
        }
        public void Add(T item)
        {
            ListNode<T> newNode = new ListNode<T>(item);
            if (GetFirstListNode() == null) _firstListNode = newNode;
            if (GetLastListNode() != null) GetLastListNode().NextNode = newNode;
            newNode.PreviousNode = GetLastListNode();
            newNode.NextNode = null;
            _lastListNode = newNode;
            _count = Count + 1;
        }
        public void AddToTheEnd(T item)
        {
            ListNode<T> newNode = new ListNode<T>(item);
            if (GetFirstListNode() == null) _firstListNode = newNode;
            if (GetLastListNode() != null) GetLastListNode().NextNode = newNode;
            newNode.PreviousNode = GetLastListNode();
            newNode.NextNode = null;
            _lastListNode = newNode;
            _count = Count + 1;
        }
        public void AddToTheBeginning(T item)
        {
            var newNode = new ListNode<T>(item);
            if (GetFirstListNode() == null)
            {
                _firstListNode = newNode;
                _lastListNode = newNode;
            }
            else
            {
                newNode.PreviousNode = GetFirstListNode().PreviousNode;
                newNode.NextNode = GetFirstListNode();
                GetFirstListNode().PreviousNode = newNode;
                _firstListNode = newNode;
            }
            _count = Count + 1;
        }
        public void Clear()
        {
            _firstListNode = null;
            _lastListNode = null;
            _count = 0;
        }
        public bool Contains(T item)
        {
            // ReSharper disable once GenericEnumeratorNotDisposed
            var enumerator = GetEnumerator();
            for (var i = 0; i < Count; i++)
            {
                if (item != null && item.Equals(enumerator.Current))
                {
                    return true;
                }
                enumerator.MoveNext();
            }
            return false;
        }
        public void CopyTo(T[] array, int arrayIndex)
        {
            // ReSharper disable once GenericEnumeratorNotDisposed
            var enumerator = GetEnumerator();
            for (var i = arrayIndex; i < array.Length; i++)
            {
                array[i] = enumerator.Current;
                enumerator.MoveNext();
            }
        }
        public bool Remove(T item)
        {
            if (!Contains(item)) return false;
            var currentNode = GetFirstListNode();
            for (var i = 0; i < Count; i++)
            {
                // ReSharper disable once PossibleNullReferenceException
                if (item.Equals(currentNode.Data))
                {
                    if (currentNode.PreviousNode != null) currentNode.PreviousNode.NextNode = currentNode.NextNode;
                    if (currentNode.NextNode != null) currentNode.NextNode.PreviousNode = currentNode.PreviousNode;
                    currentNode.NextNode = null;
                    currentNode.PreviousNode = null;
                    _count--;
                    return true;
                }
                currentNode = currentNode.NextNode;
            }
            return false;
        }
    }

    internal class Enumerator<T> : IEnumerator<T>
    {
        DoubleLinkedList<T> _linkedList;
        private ListNode<T> _currentNode;
        public Enumerator(DoubleLinkedList<T> nlinkedList)
        {
            _linkedList = nlinkedList;
            _currentNode = _linkedList.GetFirstListNode();
        }


        public bool MoveNext()
        {
            var result = _currentNode.NextNode == null;
            _currentNode = _currentNode.NextNode;
            return result;
        }

        public void Reset()
        {
            _currentNode = _linkedList.GetFirstListNode();
        }

        public T Current => _currentNode.Data;

        object IEnumerator.Current => Current;

        public void Dispose()
        {
            _linkedList = null;
            _currentNode = null;
        }
    }
}
