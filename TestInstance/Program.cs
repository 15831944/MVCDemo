using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Net.Sockets;

namespace TestInstance
{
    class Program
    {
        static void Main(string[] args)
        {
            Socket serversocket = new Socket(AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.Tcp);
            checked
            {
                serversocket.Accept(); 
            }


            XElement contacts = XElement.Load(@"c:\myContactList.xml");
//            Console.WriteLine(System.DateTime.Now.ToString("yyyyMMddHHmmssfff"));
//            System.Data.DataTable table = new DataTable();

//            string a = @"werewrewrew2dsfdsssssssssssssssssssssssssfff
//1rewrewrwe";

//            for (int i = 0; i < 1; i++)
//            {
//                string wer = "wer";
//            }

//            //计算常量，可以没有初始化列
//            object test = table.Compute("1+1", "");
//            Console.WriteLine();


            

//            test =table.Compute("1=2","true");
//            Console.WriteLine(test);
//            //test=2;常数计算和filter无关
//            Console.ReadKey();

            //generic list
        //List<int> ListGeneric = new List<int> { 5, 9, 1, 4 };
        ////non-generic list
        //ArrayList ListNonGeneric = new ArrayList { 5, 9, 1, 4 };
        //// timer for generic list sort
        //Stopwatch s = Stopwatch.StartNew();
        //ListGeneric.Sort();
        //s.Stop();
        //Console.WriteLine("Generic Sort: {ListGeneric}  \n Time taken: {"+s.Elapsed.TotalMilliseconds+"}ms");

        ////timer for non-generic list sort
        //Stopwatch s2 = Stopwatch.StartNew();
        //ListNonGeneric.Sort();
        //s2.Stop();
        //Console.WriteLine("Non-Generic Sort: {ListNonGeneric}  \n Time taken: {"+s2.Elapsed.TotalMilliseconds+"}ms");
        //Console.ReadLine();


            //Declare and instantiate a new generic SortedList class.
            //Person is the type argument.
            SortedList<Person> list = new SortedList<Person>();

            //Create name and age values to initialize Person objects.
            string[] names = new string[] 
        { 
            "Franscoise", 
            "Bill", 
            "Li", 
            "Sandra", 
            "Gunnar", 
            "Alok", 
            "Hiroyuki", 
            "Maria", 
            "Alessandro", 
            "Raul" 
        };

            int[] ages = new int[] { 45, 19, 28, 23, 18, 9, 108, 72, 30, 35 };

            //Populate the list.
            for (int x = 0; x < 10; x++)
            {
                list.AddHead(new Person(names[x], ages[x]));
            }

            //Print out unsorted list.
            foreach (Person p in list)
            {
                System.Console.WriteLine(p.ToString());
            }
            System.Console.WriteLine("Done with unsorted list");

            //Sort the list.
            list.BubbleSort();

            //Print out sorted list.
            foreach (Person p in list)
            {
                System.Console.WriteLine(p.ToString());
            }
            System.Console.WriteLine("Done with sorted list");

            //Linq
            // The Three Parts of a LINQ Query:
            //  1. Data source.
            int[] numbers = new int[7] { 0, 1, 2, 3, 4, 5, 6 };

            // 2. Query creation.
            // numQuery is an IEnumerable<int>
            var numQuery =
                from num in numbers
                where (num % 2) == 0
                select num;

            // 3. Query execution.
            foreach (int num in numQuery)
            {
                Console.Write("{0,1} ", num);
            }

        }


    }
    //Type parameter T in angle brackets.
    public class GenericList<T> : System.Collections.Generic.IEnumerable<T>
    {
        protected Node head;
        protected Node current = null;

        // Nested class is also generic on T
        protected class Node
        {
            public Node next;
            private T data;  //T as private member datatype

            public Node(T t)  //T used in non-generic constructor
            {
                next = null;
                data = t;
            }

            public Node Next
            {
                get { return next; }
                set { next = value; }
            }

            public T Data  //T as return type of property
            {
                get { return data; }
                set { data = value; }
            }
        }

        public GenericList()  //constructor
        {
            head = null;
        }

        public void AddHead(T t)  //T as method parameter type
        {
            Node n = new Node(t);
            n.Next = head;
            head = n;
        }

        // Implementation of the iterator
        public System.Collections.Generic.IEnumerator<T> GetEnumerator()
        {
            Node current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        // IEnumerable<T> inherits from IEnumerable, therefore this class 
        // must implement both the generic and non-generic versions of 
        // GetEnumerator. In most cases, the non-generic method can 
        // simply call the generic method.
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class SortedList<T> : GenericList<T> where T : System.IComparable<T>
    {
        // A simple, unoptimized sort algorithm that 
        // orders list elements from lowest to highest:

        public void BubbleSort()
        {
            if (null == head || null == head.Next)
            {
                return;
            }
            bool swapped;

            do
            {
                Node previous = null;
                Node current = head;
                swapped = false;

                while (current.next != null)
                {
                    //  Because we need to call this method, the SortedList
                    //  class is constrained on IEnumerable<T>
                    if (current.Data.CompareTo(current.next.Data) > 0)
                    {
                        Node tmp = current.next;
                        current.next = current.next.next;
                        tmp.next = current;

                        if (previous == null)
                        {
                            head = tmp;
                        }
                        else
                        {
                            previous.next = tmp;
                        }
                        previous = tmp;
                        swapped = true;
                    }
                    else
                    {
                        previous = current;
                        current = current.next;
                    }
                }
            } while (swapped);
        }
    }

    // A simple class that implements IComparable<T> using itself as the 
    // type argument. This is a common design pattern in objects that 
    // are stored in generic lists.
    public class Person : System.IComparable<Person>
    {
        string name;
        int age;

        public Person(string s, int i)
        {
            name = s;
            age = i;
        }

        // This will cause list elements to be sorted on age values.
        public int CompareTo(Person p)
        {
            return age - p.age;
        }

        public override string ToString()
        {
            return name + ":" + age;
        }

        // Must implement Equals.
        public bool Equals(Person p)
        {
            return (this.age == p.age);
        }
    }
    public class AStack<T>
    {

        private T[] m_item;

        //public T Pop() { T a = return a; }

        public void Push(T item){}

        public AStack(int i)
        {

            this.m_item = new T[i];

        }

    }
}
