using System;

namespace LinkedListGenap
{
    // 1. Definisi Node
    public class Node
    {
        public int Data { get; set; }
        public Node Next { get; set; }

        public Node(int data)
        {
            Data = data;
            Next = null;
        }
    }

    // 2. Definisi Linked List
    public class LinkedList
    {
        public Node Head { get; private set; }

        public LinkedList()
        {
            Head = null;
        }

        // Fungsi untuk menambahkan node di akhir list
        public void Append(int data)
        {
            Node newNode = new Node(data);
            if (Head == null)
            {
                Head = newNode;
                return;
            }

            Node last = Head;
            while (last.Next != null)
            {
                last = last.Next;
            }
            last.Next = newNode;
        }

        // FUNGSI UTAMA: Menghapus semua node bernilai genap
        public void HapusGenap()
        {
            // Kasus 1: Jika head bernilai genap, geser head ke node berikutnya
            while (Head != null && Head.Data % 2 == 0)
            {
                Head = Head.Next;
            }

            // Kasus 2: Periksa node-node setelah head
            Node current = Head;
            while (current != null && current.Next != null)
            {
                if (current.Next.Data % 2 == 0)
                {
                    // Lewati/putus hubungan dengan node genap
                    current.Next = current.Next.Next;
                }
                else
                {
                    // Maju ke node berikutnya jika bernilai ganjil
                    current = current.Next;
                }
            }
        }

        // Fungsi untuk mencetak isi linked list
        public void CetakList()
        {
            if (Head == null)
            {
                Console.WriteLine("Linked List Kosong");
                return;
            }

            Node current = Head;
            while (current != null)
            {
                Console.Write(current.Data + (current.Next != null ? " -> " : ""));
                current = current.Next;
            }
            Console.WriteLine();
        }
    }

    // 3. Program Utama (Main)
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList llist = new LinkedList();
            int[] dataInput = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            // Memasukkan data ke list
            foreach (int angka in dataInput)
            {
                llist.Append(angka);
            }

            Console.WriteLine("Linked list awal:");
            llist.CetakList();

            // Eksekusi penghapusan node genap
            llist.HapusGenap();

            Console.WriteLine("\nLinked list setelah node genap dihapus:");
            llist.CetakList();
        }
    }
}