using System;

LinkedList list = new LinkedList();

// Memasukkan data awal: [10, 20, 30, 40, 50]
list.InsertLast(10);
list.InsertLast(20);
list.InsertLast(30);
list.InsertLast(40);
list.InsertLast(50);

Console.Write("Keadaan awal list      : ");
list.Display();

// Eksekusi operasi sesuai soal
list.DeleteFirst();
list.DeleteLast();
list.DeleteAt(2);

Console.Write("Output setelah operasi : ");
list.Display(); 

Console.WriteLine("\nTekan ENTER untuk keluar...");
Console.ReadLine();

// ==========================================
// DEFINISI STRUKTUR DATA (Diletakkan di bawah)
// ==========================================

public class Node
{
    public int Data;
    public Node Next;

    public Node(int data)
    {
        this.Data = data;
        this.Next = null;
    }
}

public class LinkedList
{
    private Node head;

    public LinkedList()
    {
        head = null;
    }

    public void InsertLast(int data)
    {
        Node newNode = new Node(data);
        if (head == null)
        {
            head = newNode;
            return;
        }
        Node temp = head;
        while (temp.Next != null)
        {
            temp = temp.Next;
        }
        temp.Next = newNode;
    }

    public void DeleteFirst()
    {
        if (head == null) return;
        head = head.Next;
    }

    public void DeleteLast()
    {
        if (head == null) return;
        if (head.Next == null)
        {
            head = null;
            return;
        }
        Node temp = head;
        while (temp.Next.Next != null)
        {
            temp = temp.Next;
        }
        temp.Next = null;
    }

    public void DeleteAt(int index)
    {
        if (head == null) return;
        if (index == 0)
        {
            DeleteFirst();
            return;
        }
        Node temp = head;
        for (int i = 0; temp != null && i < index - 1; i++)
        {
            temp = temp.Next;
        }
        if (temp == null || temp.Next == null) return;
        temp.Next = temp.Next.Next;
    }

    public void Display()
    {
        if (head == null)
        {
            Console.WriteLine("List Kosong");
            return;
        }
        Node temp = head;
        while (temp != null)
        {
            Console.Write(temp.Data + " ");
            temp = temp.Next;
        }
        Console.WriteLine();
    }
}