using System;

class Program
{
    static void Main()
    {
        MyLinkedList list = new MyLinkedList();

        // Isi linked list dengan [10, 20, 30, 40, 50]
        list.InsertLast(10);
        list.InsertLast(20);
        list.InsertLast(30);
        list.InsertLast(40);
        list.InsertLast(50);

        Console.WriteLine("=== SOAL 2 - ANALISIS OUTPUT LINKED LIST ===\n");
        Console.Write("Data awal          : "); list.Display();

        list.DeleteFirst();
        Console.Write("Setelah DeleteFirst: "); list.Display();

        list.DeleteLast();
        Console.Write("Setelah DeleteLast : "); list.Display();

        list.DeleteAt(2);
        Console.Write("Setelah DeleteAt(2): "); list.Display();
    }
}

class Node
{
    public int Data;
    public Node Next;
    public Node(int d) { Data = d; Next = null; }
}

class MyLinkedList
{
    private Node head;

    public void InsertLast(int d)
    {
        Node n = new Node(d);
        if (head == null) { head = n; return; }
        Node c = head;
        while (c.Next != null) c = c.Next;
        c.Next = n;
    }

    public void DeleteFirst()
    {
        if (head == null) { Console.WriteLine("List kosong!"); return; }
        Console.WriteLine($"  → Menghapus {head.Data} dari awal");
        head = head.Next;
    }

    public void DeleteLast()
    {
        if (head == null) { Console.WriteLine("List kosong!"); return; }
        if (head.Next == null)
        {
            Console.WriteLine($"  → Menghapus {head.Data} dari akhir");
            head = null;
            return;
        }
        Node c = head;
        while (c.Next.Next != null) c = c.Next;
        Console.WriteLine($"  → Menghapus {c.Next.Data} dari akhir");
        c.Next = null;
    }

    public void DeleteAt(int pos)
    {
        if (head == null) { Console.WriteLine("List kosong!"); return; }
        if (pos <= 0) { Console.WriteLine("Posisi harus > 0!"); return; }

        if (pos == 1)
        {
            Console.WriteLine($"  → Menghapus {head.Data} dari posisi {pos}");
            head = head.Next;
            return;
        }

        Node c = head;
        for (int i = 1; i < pos - 1 && c != null; i++) c = c.Next;

        if (c == null || c.Next == null)
        {
            Console.WriteLine($"  → Posisi {pos} melebihi panjang list!");
            return;
        }

        Console.WriteLine($"  → Menghapus {c.Next.Data} dari posisi {pos}");
        c.Next = c.Next.Next;
    }

    public void Display()
    {
        if (head == null) { Console.WriteLine("null"); return; }
        for (Node c = head; c != null; c = c.Next)
            Console.Write(c.Data + (c.Next != null ? " → " : " → null\n"));
    }
}
