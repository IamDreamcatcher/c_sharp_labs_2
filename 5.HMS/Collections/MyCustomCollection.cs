using System;

namespace HMS.Collection
{
    class MyCustomCollection<T> : ICustomCollection<T>
    {
        private class Node
        {
            public Node(T data)
            {
                Data = data;
            }
            public T Data { get; set; }
            public Node Prev { get; set; }
            public Node Next { get; set; }
        } 
        Node head;
        Node tail;
        int size;
        Node cursor;
        public T this[int index] {
            get
            {
                if (index < 0 || index >= size)
                {
                    throw new Exception("No such index");
                }
                Node current = head;
                for(int i = 0; i < index; i++)
                {
                    current = current.Next;
                }
                return current.Data;
            } 
            set 
            {
                if (index > size - 1)
                {
                    throw new Exception("No such index");
                }
                Node current = head;
                for (int i = 0; i < index; i++)
                {
                    current = current.Next;
                }
                current.Data = value;
            }
        }
        public int Count { get => size; }

        public void Add(T item)
        {
            Node newNode = new Node(item);
            if (head == null)
            {
                head = newNode;
            }
            else
            {
                tail.Next = newNode;
                newNode.Prev = tail;
            }
            tail = newNode;
            size++;
        }

        public T Current()
        {
            if (cursor == null)
            {
                throw new Exception("Cursor is on null");
            }
            return cursor.Data;
        }

        public void Next()
        {
            if (cursor == null)
            {
                throw new Exception("Cursor is on null");
            }
            cursor = cursor.Next;
        }
        public void Prev()
        {
            if (cursor == null)
            {
                throw new Exception("Cursor is null");
            }
            cursor = cursor.Prev;
        }

        public void Remove(T item)
        {
            Node current = head;
            while(current != null && current.Data.Equals(item))
            {
                current = current.Next;
            }

            if (current != null)
            { 
                if (current == head)
                {
                    head = head.Next;
                    head.Prev = null;
                }
                else if (current == tail)
                {
                    tail = tail.Prev;
                    tail.Prev = null;
                }
                else
                {
                    current.Prev.Next = current.Next;
                    current.Next.Prev = current.Prev;
                }
                size--;
            }
        }

        public T RemoveCurrent()
        {
            if (cursor == null)
            {
                throw new Exception("Cursor is on null");
            }
            T data = cursor.Data;

            if (cursor == head)
            {
                head = head.Next;
                head.Prev = null;
            }
            else if (cursor == tail)
            {
                tail = tail.Prev;
                tail.Prev = null;
            }
            else
            {
                cursor.Prev.Next = cursor.Next;
                cursor.Next.Prev = cursor.Prev;
            }
            size--;
            return data;
        }

        public void Reset()
        {
            cursor = head;
        }
    }
}