using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace week3assignement
{
    public class DoublyLinkedList
    {
        Node head;

        public void AddNode(string data, int monsterHealth, int numberOfAttacks, int playerHealth)
        {
            Node newNode = new Node()
            {
                Data = data,
                MonsterHealth = monsterHealth,
                NumberOfAttacks = numberOfAttacks,
                PlayerHealth = playerHealth
            };

            if (head == null)
            {
                head = newNode;
            }
            else
            {
                Node temp = head;
                while (temp.Next != null)
                {
                    temp = temp.Next;
                }
                temp.Next = newNode;
                newNode.Prev = temp;
            }
        }

        public void PrintList()
        {
            using (StreamWriter file = new StreamWriter("Stats.txt", true))
            {
                Node temp = head;
                while (temp != null)
                {
                    file.WriteLine($"Data: {temp.Data}, MonsterHealth: {temp.MonsterHealth}, NumberOfAttacks: {temp.NumberOfAttacks}, PlayerHealth: {temp.PlayerHealth}");
                    temp = temp.Next;
                }
            }
        }
    }
}