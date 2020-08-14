using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetronLabsTest
{

    public class Node
    {
        public int Data { get; set; }
        public Node NextNode { get; set; }
        public Node PrevNode { get; set; }

        public Node(int data)
        {
            Data = data;
            NextNode = null;
            PrevNode = null;
        }
    }

    public class LinkedList
    {
        public Node Head { get; private set; }
        public Node Tail { get; private set; }

        public LinkedList()
        {
            Head = null;
            Tail = null;
        }

        public void AddNode(Node node)
        {
            if (Head == null)
            {
                Head = node;
                Tail = Head;
            }
            else
            {
                Node currentNode = Head;
                while (currentNode.NextNode != null)
                {
                    currentNode = currentNode.NextNode;
                }
                node.PrevNode = currentNode;
                currentNode.NextNode = node;
                Tail = node;
            }
        }

        public void DisplayLinkedList()
        {
            Node currentNode = Head;
            while (currentNode != null)
            {
                Console.Write(currentNode.Data + " -> ");
                currentNode = currentNode.NextNode;
            }
            Console.Write("null\r\n");
        }

        public void DisplayReverseLinkedList()
        {
            Node currentNode = Tail;
            while (currentNode != null)
            {
                Console.Write(currentNode.Data + " -> ");
                currentNode = currentNode.PrevNode;
            }
            Console.Write("null\r\n");
        }

        public void DeleteNode(int data)
        {
            Node prevNode = null;
            Node currentNode = Head;

            //head node check
            if (currentNode.Data == data)
            {
                Console.WriteLine($"Deleting Head... {currentNode.Data}");
                Head = currentNode.NextNode;
                return;
            }

            if (Tail.Data == data)
            {
                Console.WriteLine(Tail.Data);
                Tail = Tail.PrevNode;
                return;
            }

            while (currentNode != null)
            {
                if (currentNode.Data == data)
                {
                    Console.WriteLine($"Deleting... {currentNode.Data}");
                    
                    prevNode.NextNode = currentNode.NextNode; //ok
                    currentNode.NextNode.PrevNode = currentNode.PrevNode; //ok
                    break;
                }
                prevNode = currentNode;
                currentNode = currentNode.NextNode;
            }
        }

        public Node GetNode(int position)
        {
            int currentPosition = 0;

            Node currentNode = Head;
            while (currentNode != null)
            {
                if (currentPosition == position)
                {
                   return currentNode;
                }
                
                currentNode = currentNode.NextNode;
                currentPosition++;
            }
            return null;
        }

        public bool IsEmpty()
        {
            if (Head == null) { return true; }

            return false;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            LinkedList linkedList = new LinkedList();

            //Checking if empty
            Console.WriteLine("List Empty? : " + linkedList.IsEmpty());

            for (int i = 0; i < 10; i++)
            {
                linkedList.AddNode(new Node(i*10));
            }
            Console.WriteLine("-----------------------");


            //Show list
            Console.WriteLine("Original List: ");
            linkedList.DisplayLinkedList();

            Console.WriteLine("-----------------------");

            //Show list
            Console.WriteLine("Reverse List: ");
            linkedList.DisplayReverseLinkedList();

            Console.WriteLine("-----------------------");
            Console.WriteLine("Get Node Method Test");
            for (int i = 0; i < 10; i++)
            {
                Node node = linkedList.GetNode(i);
                Console.WriteLine(node.Data);
            }

            Console.WriteLine("-----------------------");
            //Deletenode
            Console.WriteLine("Delete Node : ");
            linkedList.DeleteNode(40);

            Console.WriteLine("After Delete : ");
            linkedList.DisplayLinkedList();

            Console.WriteLine("-----------------------");
            Console.WriteLine("Delete Head Node : ");
            linkedList.DeleteNode(0);

            Console.WriteLine("After Delete : ");
            linkedList.DisplayLinkedList();

            Console.WriteLine("-----------------------");
            Console.WriteLine("Delete Head Node : ");
            linkedList.DeleteNode(90);

            Console.WriteLine("After Delete : ");
            linkedList.DisplayLinkedList();
            
            //Show list
            Console.WriteLine("Reverse List: ");
            linkedList.DisplayReverseLinkedList();

            Console.WriteLine("-----------------------");
            //Checking if empty
            Console.WriteLine("List Empty? : " + linkedList.IsEmpty());

            Console.ReadKey();
        }
    }
}
