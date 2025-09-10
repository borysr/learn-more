using System.Collections;

namespace ClassLibrary
{
    public class CircularLinkedList<T> : LinkedList<T>
    {
        public new IEnumerator<T> GetEnumerator()
        {
            return new CircuralLinkedListEnumerator<T>(this);
        }
    }
    public class CircuralLinkedListEnumerator<T> : IEnumerator<T>
    {
        private LinkedListNode<T> _current;
        public T Current => _current.Value;
        object IEnumerator.Current => Current;

        public CircuralLinkedListEnumerator(LinkedList<T> list)
        {
            _current = list.First;
        }
        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            if (_current == null)
            {
                return false;
            }
            _current = _current.Next ?? _current.List.First;
            return true;
        }

        public void Reset()
        {
            _current = _current.List.First; ;
        }
    }
}

public static class LinkedListNodeExtensions
{
    public static LinkedListNode<T> Next<T>(this LinkedListNode<T> node)
    {
        if (node != null && node.List != null)
        {
            return node.Next ?? node.List.First;
        }
        return null;
    }

    public static LinkedListNode<T> Previous<T>(this LinkedListNode<T> node)
    {
        if (node != null && node.List != null)
        {
            return node.Previous ?? node.List.Last;
        }
        return null;
    }
}