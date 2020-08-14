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

        public LinkedList()
        {
            Head = null;
        }

        public void AddNode(Node node)
        {
            if (Head == null)
            {
                Head = node;
            }
            else
            {
                Node tempNode = Head;
                while (tempNode.NextNode != null)
                {
                    tempNode = tempNode.NextNode;
                }
                tempNode.NextNode = node;
            }
        }

        public void DisplayLinkedList()
        {
            Node tempNode = Head;
            while (tempNode != null)
            {
                Console.WriteLine(tempNode.Data);
                tempNode = tempNode.NextNode;
            }
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

            while (currentNode != null)
            {
                if (currentNode.Data == data)
                {
                    Console.WriteLine($"Deleting... {currentNode.Data}");
                    prevNode.NextNode = currentNode.NextNode;
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
    }


    class Program
    {
        static void Main(string[] args)
        {
            LinkedList linkedList = new LinkedList();
            
            for (int i = 0; i < 10; i++)
            {
                linkedList.AddNode(new Node(i*10));
            }

            //Show list
            Console.WriteLine("Original List: ");
            linkedList.DisplayLinkedList();

            Console.WriteLine("-----------------------");

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

 
            Console.ReadKey();
        }
    }
}
