using DataStructures.LinkedList;
using System;

namespace DataStructures
{
    public class Class1
    {
       static void Main(string[] args)
       {
            ZLinkedList<int> list = new ZLinkedList<int>();
            list.addFirst(1);
            list.addFirst(1);
            list.addFirst(2);
            list.addFirst(4);
            list.addFirst(4);
            //list.Print(list);
            //Console.WriteLine();

             //list.removeDuplicates();
            //list.removeFirst();
            //list.removeLast();
            list.Print(list);
            Console.WriteLine();

            ZLinkedList<int> list1 = new ZLinkedList<int>();
            list1.addFirst(5);
            list1.addFirst(6);
            list1.addFirst(7);
            list1.addFirst(8);
            list1.Print(list1);
            Console.WriteLine();

            var a = list.Merge(list1, list);
            list.Print(a);
            Console.WriteLine();
            //list.addElementRecursive(3, "MNO");
            //Console.WriteLine();
            ////list.removeFirst();
            ////list.removeLast();
            ////list.remove("ABC");
            //list.Print(list);
        }
    }
}
