using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private LinkedList myList = new LinkedList();
        public class Node
        {
            public int Data { get; set; }
            public Node Next { get; set; }

            public Node(int value)
            {
                Data = value;
                Next = null;
            }
        }

        public class LinkedList
        {
            private Node head;

            public LinkedList()
            {
                head = null;
            }

            public void Insert(int value)
            {
                Node newNode = new Node(value);

                if (head == null)
                {
                    head = newNode;
                }
                else
                {
                    Node current = head;
                    while (current.Next != null)
                    {
                        current = current.Next;
                    }
                    current.Next = newNode;
                }
            }

            public void InsertAfter(int existingValue, int newValue)
            {
                Node current = head;
                while (current != null && current.Data != existingValue)
                {
                    current = current.Next;
                }

                if (current != null)
                {
                    Node newNode = new Node(newValue);
                    newNode.Next = current.Next;
                    current.Next = newNode;
                }
                else
                {
                    MessageBox.Show("Няма такава стойност в списъка!");
                }
            }

            public void Print(ListBox listBox)
            {
                Node current = head;
                while (current != null)
                {
                    listBox.Items.Add(current.Data);
                    current = current.Next;
                }
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int newValue))
            {
                myList.Insert(newValue);
                listBox3.Items.Clear();
                myList.Print(listBox3);
                textBox1.Clear();
            }
            else
            {
                MessageBox.Show("Въведете вярна стойност!");
            }
        }

        private void InsertNewNode_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox2.Text, out int newValue) &&
               int.TryParse(textBox3.Text, out int existingValue))
            {
                myList.InsertAfter(existingValue, newValue);
                listBox3.Items.Clear();
                myList.Print(listBox3);
                textBox2.Clear();
                textBox3.Clear();
            }
            else
            {
                MessageBox.Show("Въведете вярна стойност!");
            }
        }


















        private void PrintButton_Click(object sender, EventArgs e)
        {
            // Izchistvame listbox 
            listBox1.Items.Clear();

            // Zapulvame lista s 10 sluchaini chisla ot 1 do 20 
            HashSet<int> randNum = new HashSet<int>(); ;
            Random rand = new Random();

            while (randNum.Count < 10) // 10 sluchaini chisla
            {
                int randomNumber = rand.Next(1, 21);
                while (randNum.Contains(randomNumber))
                {
                    randomNumber = rand.Next(1, 21);
                }
                randNum.Add(randomNumber);
            }

            // Sortirame chislata ot po-malko kum po-golqmo
            var sortedNumbers = randNum.OrderBy(x => x);

            // Otpechatvame chislata v listbox
            foreach (int number in sortedNumbers)
            {
                listBox1.Items.Add(number);
            }

            {
                // Izchistvame listbox
                listBox2.Items.Clear();

                // Suzdavame nov list
                LinkedList myList = new LinkedList();

                // Zapulvame lista s cifri
                myList.Insert(1);
                myList.Insert(2);
                myList.Insert(3);
                myList.Insert(4);
                myList.Insert(5);
                myList.Insert(6);
                myList.Insert(7);
                myList.Insert(8);
                myList.Insert(9);
                myList.Insert(10);

                // Otpechatvame chislata
                myList.Print(listBox2);
            }
        }
    }
}
