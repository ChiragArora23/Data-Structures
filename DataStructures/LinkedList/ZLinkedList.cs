using System;

namespace DataStructures.LinkedList
{
    public class ZLinkedList<T> : IComparable<ZLinkedList<T>>
    {
        /// <summary>
        /// Instantiate Node for LinkedList
        /// </summary>
        class Node<T>
        {
            public T data;
            public Node<T> next;
            public Node(T obj)
            {
                data = obj;
                next = null;
            }

            public Node(T obj, Node<T> node)
            {
                data = obj;
                next = node;
            }
        }

        private Node<T> Head;
        private Node<T> Tail;
        private int currentSize;
        public ZLinkedList()
        {
            Head = null;
            Tail = null;
            currentSize = 0;
        }

        /// <summary>
        /// Add Node to Beginning of Linked List
        /// </summary>
        public void addFirst(T obj)
        {
            Node<T> node = new Node<T>(obj);
            if (Head == null)
                Tail = node;

            node.next = Head;
            Head = node;
            currentSize++;
        }

        /// <summary>
        /// Add Node to the Last of Linked List
        /// </summary>
        public void addLast(T obj)
        {
            Node<T> node = new(obj);
            if (Head == null)
            {
                Head = node;
                currentSize++;
                return;
            }

            Node<T> temp = Head;
            while (temp.next != null)
            {
                temp = temp.next;
            }
            temp.next = node;
            currentSize++;
        }

        /// <summary>
        /// Add Nodes to the Last of Linked List using Tail Pointer
        /// </summary>
        public void addLastUsingTail(T obj)
        {
            Node<T> node = new Node<T>(obj);
            if (Head == null)
            {
                Head = Tail = node;
                currentSize++;
                return;
            }
            Tail.next = node;
            Tail = node;
            currentSize++;
        }

        /// <summary>
        /// 
        /// </summary>
        public void addElementRecursive(int index, T obj)
        {
            Head = addElementsRecursive(index, obj, Head);
        }

        /// <summary>
        /// Add Elements via recursive method
        /// </summary>
        private Node<T> addElementsRecursive(int index, T obj, Node<T> node)
        {
            if (index == 0)
            {
                Node<T> temp = new Node<T>(obj, node);
                currentSize++;
                return temp;
            }

            node.next = addElementsRecursive(index - 1, obj, node.next);
            return node;
        }

        /// <summary>
        /// 
        /// </summary>
        public T removeFirst()
        {
            if (Head == null)
                return default;

            T temp = Head.data;
            if (Head == Tail)
                Head = Tail = null;
            else
                Head = Head.next;

            currentSize--;
            return temp;

        }

        /// <summary>
        /// Remove last elements from Linked List
        /// </summary>
        public T removeLast()
        {
            if (Head == null)
                return default;

            if (Head == Tail)
                return removeFirst();
            else
            {
                Node<T> current = Head;
                Node<T> prev = null;

                while(current != Tail)
                {
                    prev = current;
                    current = current.next;
                }
                prev.next = null;
                Tail = prev;
                currentSize--;
                return current.data;
            }
        }

        /// <summary>
        /// Remove Desired Element From Linked List
        /// </summary>
        public T remove(T obj)
        {
            Node<T> current = Head;
            Node<T> prev = null;

            while (current != null)
            {
                if (((IComparable<T>)obj).CompareTo(current.data) == 0)
                {
                    if (current == Head)
                        return removeFirst();

                    if (current == Tail)
                        return removeLast();

                    currentSize--;
                    prev.next = current.next;
                    return current.data;   
                }
                prev = current;
                current = current.next;
            }
            return default;
        }

        /// <summary>
        /// Tells it element exists
        /// </summary>
        public bool Contains(T obj)
        {
            Node<T> current = Head;
            while (current != null)
            {
                if (((IComparable<T>)obj).CompareTo(current.data) == 0)
                {
                    return true;
                }
                current = current.next;
            }
            return false;
        }

        /// <summary>
        /// Remove Duplicates from linked list
        /// </summary>
        public void removeDuplicates()
        {
            Node<T> node = Head;

            while (node.next != null)
            {
                if (((IComparable<T>)node.data).CompareTo(node.next.data) == 0)
                {
                    node.next = node.next.next;
                    currentSize--;
                }
                else
                    node = node.next;
            }
            Tail = node;
            Tail.next = null;
        }

        /// <summary>
        /// Merge Two Linked List
        /// </summary>
        /// <param name="first">First Linked List</param>
        /// <param name="second">Second Linked List</param>
        /// <returns>New Merged Linked List</returns>
        public ZLinkedList<T> Merge(ZLinkedList<T> first, ZLinkedList<T> second)
        {
            Node<T> f = first.Head;
            Node<T> s = second.Head;
            ZLinkedList<T> ans = new ZLinkedList<T>();

            while (f != null & s != null)
            {
                if (((IComparable<T>)f.data).CompareTo(s.data) > 0)
                {
                    ans.addLast(f.data);
                    f = f.next;
                }
                else
                {
                    ans.addLast(s.data);
                    s = s.next;
                }
            }

            while (f != null)
            {
                ans.addLast(f.data);
                f = f.next;
            }

            while (s != null)
            {
                ans.addLast(s.data);
                s = s.next;
            }

            return ans;
        }

        /// <summary>
        /// printing the element of LinkedList 
        /// </summary>
        public void Print(ZLinkedList<T> list)
        {
            Node<T> temp = list.Head;
            while (temp != null)
            {
                Console.Write(temp.data + " ");
                temp = temp.next;
            }
        }

        public int CompareTo(ZLinkedList<T> other)
        {
            return CompareTo(other);
        }
    }
}
