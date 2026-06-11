using System;

class Program
{
    static void Main()
    {
        MyLinkedList list = new MyLinkedList();

        Console.WriteLine("=== SOAL 3 - DELETE EVEN NUMBERS ===\n");

        // Test Case 1: Campuran genap dan ganjil
        Console.WriteLine("--- Test Case 1: Campuran Genap & Ganjil ---");
        int[] data1 = { 2, 3, 4, 6, 7, 8 };
        foreach (int d in data1) list.InsertLast(d);
        Console.Write("Data awal   : "); list.Display();
        list.DeleteEvenNumbers();
        Console.Write("Setelah hapus genap: "); list.Display();

        Console.WriteLine();

        // Test Case 2: Semua genap
        Console.WriteLine("--- Test Case 2: Semua Genap ---");
        MyLinkedList list2 = new MyLinkedList();
        int[] data2 = { 2, 4, 6, 8 };
        foreach (int d in data2) list2.InsertLast(d);
        Console.Write("Data awal   : "); list2.Display();
        list2.DeleteEvenNumbers();
        Console.Write("Setelah hapus genap: "); list2.Display();

        Console.WriteLine();

        // Test Case 3: Semua ganjil
        Console.WriteLine("--- Test Case 3: Semua Ganjil ---");
        MyLinkedList list3 = new MyLinkedList();
        int[] data3 = { 1, 3, 5, 7 };
        foreach (int d in data3) list3.InsertLast(d);
        Console.Write("Data awal   : "); list3.Display();
        list3.DeleteEvenNumbers();
        Console.Write("Setelah hapus genap: "); list3.Display();

        Console.WriteLine();

        // Test Case 4: Genap di awal dan akhir
        Console.WriteLine("--- Test Case 4: Genap di Awal & Akhir ---");
        MyLinkedList list4 = new MyLinkedList();
        int[] data4 = { 4, 5, 9, 3, 10 };
        foreach (int d in data4) list4.InsertLast(d);
        Console.Write("Data awal   : "); list4.Display();
        list4.DeleteEvenNumbers();
        Console.Write("Setelah hapus genap: "); list4.Display();
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

    public void DeleteEvenNumbers()
    {
        // Bagian 1: Hapus node genap di awal list (head)
        while (head != null && head.Data % 2 == 0)
        {
            Console.WriteLine($"  → Menghapus {head.Data} (genap, di awal)");
            head = head.Next;
        }

        // Jika list kosong setelah pembersihan head
        if (head == null) return;

        // Bagian 2: Telusuri sisa list, hapus node genap di tengah/akhir
        Node current = head;
        while (current.Next != null)
        {
            if (current.Next.Data % 2 == 0)
            {
                Console.WriteLine($"  → Menghapus {current.Next.Data} (genap)");
                current.Next = current.Next.Next;
            }
            else
            {
                current = current.Next;
            }
        }
    }

    public void Display()
    {
        if (head == null) { Console.WriteLine("null (list kosong)"); return; }
        for (Node c = head; c != null; c = c.Next)
            Console.Write(c.Data + (c.Next != null ? " → " : " → null\n"));
    }
}
