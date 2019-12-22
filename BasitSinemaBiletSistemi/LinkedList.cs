using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasitSinemaBiletSistemi
{
    class LinkedList : LinkedListADT
    {
        public override void InsertPos(int position, int value)
        {
            Node tmpNode = new Node { Data = value };
            if (Head == null)
            {
                Head = tmpNode;
            }
            else
            {
                Node tmpHead = Head;
                int i = 1;
                while (tmpHead.Next != null)
                {
                    i++;
                    if (i == position)
                    {
                        break;
                    }
                    tmpHead = tmpHead.Next;
                }
                tmpNode.Next = tmpHead.Next;
                tmpHead.Next = tmpNode;
                Size++;
            }
        }

        public override void DeletePos(int position)
        {
            if (Head != null)
            {
                Node tmpHead = Head;
                int i = 1;
                while (tmpHead.Next != null)
                {
                    i++;
                    if (i == position)
                    {
                        break;
                    }
                    tmpHead = tmpHead.Next;
                }
                tmpHead.Next = tmpHead.Next.Next;
                Size--;
            }
        }

        public override Node GetElement(int position)
        {
            Node retNode = null;
            Node tempNode = Head;
            int count = 1;

            while (tempNode != null)
            {
                if (count == position)
                {
                    retNode = tempNode;
                    break;
                }
                tempNode = tempNode.Next;
                count++;
            }
            return retNode;
        }

        public override string DisplayElements()
        {
            string temp = "";
            Node item = Head;
            for (; ; )
            {
                if (item.Data > 0 && item.Data < 61)
                {
                    string degisken = item.Data.ToString();
                    temp += "-->" + degisken;
                    if (item.Next == null)
                        break;
                    item = item.Next;
                }
                else
                {
                    if (item.Next == null)
                        break;
                    item = item.Next;
                }
            }
            return temp;
        }

        public override void InsertFirst(int value)
        {
            Node tmpHead = new Node
            {
                Data = value
            };
            if (Head == null)
                Head = tmpHead;
            else
            {
                tmpHead.Next = Head;
                Head = tmpHead;
            }
            Size++;
        }

        public override void InsertLast(int value)
        {
            Node oldLast = Head;
            if (Head == null)
                InsertFirst(value);
            else
            {
                Node newLast = new Node
                {
                    Data = value
                };
                while (oldLast != null)
                {
                    if (oldLast.Next != null)
                    {
                        oldLast = oldLast.Next;
                    }
                    else
                    {
                        break;
                    }
                }
                oldLast.Next = newLast;
                Size++;
            }
        }

        public override void DeleteFirst()
        {
            if (Head != null)
            {
                Node tempHeadNext = this.Head.Next;
                if (tempHeadNext == null)
                {
                    Head = null;
                }
                else
                {
                    Head = tempHeadNext;
                }
                Size--;
            }
        }

        public override void DeleteLast()
        {
            Node lastNode = Head;
            Node lastPrevNode = null;
            while (true)
            {
                if (lastNode.Next != null)
                {
                    lastPrevNode = lastNode;
                    lastNode = lastNode.Next;
                }
                else
                {
                    break;
                }
            }
            Size--;
            lastNode = null;
            if (lastPrevNode != null)
            {
                lastPrevNode.Next = null;
            }
            else
            {
                Head = null;
            }
        }
    }
}
